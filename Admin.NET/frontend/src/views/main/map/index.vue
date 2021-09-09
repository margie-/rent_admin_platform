<template>
  <a-row :gutter="24">
    <a-col :md="6" :sm="24" style="padding: 0 0 0 0">
      <a-card :bordered="false" :loading="treeLoading">
        <div v-if="this.orgTree != ''">
          <a-tree
            :treeData="orgTree"
            v-if="orgTree.length"
            @select="handleClick"
            :defaultExpandAll="true"
            :defaultExpandedKeys="defaultExpandedKeys"
            :replaceFields="replaceFields"
          />
        </div>
        <div v-else>
          <a-empty :image="simpleImage" />
        </div>
      </a-card>
    </a-col>
    <a-col :md="18" :sm="24">
      <div>
        <div id="map">
          <a-drawer
            title="图元属性"
            placement="right"
            :width="600"
            :closable="false"
            :visible="drawerVisible"
            :get-container="false"
            :wrap-style="{ position: 'absolute' }"
            @close="onCloseDrawer">
            <p>{{ geosjonData }}</p>
          </a-drawer>
        </div>
      </div>
    </a-col>
  </a-row>
</template>

<script>
   import { GetDeviceOTree } from '@/api/modular/main/DeviceInfoManage'
  import L from 'leaflet'
  import icon from 'leaflet/dist/images/marker-icon.png'
  import iconShadow from 'leaflet/dist/images/marker-shadow.png'
  import {
    LMap,
    LTileLayer,
    LMarker,
    LControlLayers,
    LGeoJson
  } from 'vue2-leaflet'
  import 'leaflet/dist/leaflet.css'
  import 'leaflet.pm'
  import 'leaflet.pm/dist/leaflet.pm.css'
  import { Empty } from 'ant-design-vue'

  export default {
    name: 'Map',
    components: {
      LMap,
      LTileLayer,
      LMarker,
      LControlLayers,
      LGeoJson
    },
    data() {
      return {
        map: '',
        geosjonData: {},
        drawerVisible: false,
        marker: [],
        mapData: [],
        treeLoading: true,
        orgTree: [],
        queryParam: {},
        simpleImage: Empty.PRESENTED_IMAGE_SIMPLE,
        defaultExpandedKeys: [],
        replaceFields: {
          key: 'id'
        },
        geojsonFeature: {}
      }
    },
    mounted() {
      this.GetDeviceOTree()
      this.initMap()
      this.initMapPm()
      this.getlatLngs()
      this.initData()
      this.getPointer(this.map)
    },
    methods: {
      getPointer(map) {
      // const _this = this // 防止变量冲突
      if (this.marker) {
          this.marker.map(res => {
              map.removeLayer(res) // 清空标记
          })
      }
      this.mapData.map((res, index) => {
          const marker = L.marker([res.lat, res.lng]).addTo(this.map) // 设置标记经纬度
          map.addLayer(marker) // 添加标记
          marker.setIcon(L.icon({ // 标记配置-详见leaflet官网
              iconUrl: icon, // 使用require加载标记图
              iconSize: [20, 25]
          }))
          var customerOptions = {
             'closeButton': true,
              'minWidth': 300,
              'minHeight': 500
          }
          var content = '<s-table><a-row :gutter="24"><a-col :md="6" :sm="24">名称：</a-col><a-col :md="6" :sm="24">' + res.deviceName + '</a-col><a-col>状态</a=col><a-col>' + res.devicestatus + '</a-col></a-row>' +
                              '<a-row><br>设备号：' + res.deviceNo + '设防状态:' + res.devicefenstatus +
                              '<br>控制:' + res.powerState + ' 定位类型:' + res.locType +
                              '<br>当日里程(公里):' + res.curDayMileCount + ' 总里程(公里):' + res.sumMileCount +
                              '<br>电压：' + res.curVoltage + 'FAC:' +
                              '<br>通信:' + res.lastComDtime +
                              '<br>定位:' + res.lastLocationDtime +
                              '<br>地址:' + res.LocationName +
                              '<br><a>轨迹</a><a>报警</a><a>指令</a><a>围栏</a><a>街景</a><a>设备信息</a><a>BMS</a><a>指令记录</a></a-row></s-table>'
          var content2 = '<a-row :gutter="24"><a-col :md="12" :sm="24" >名称：' + res.deviceName + '</a-col :md="12" :sm="24">状态: ' + res.devicestatus + '<a-col></a-col></a-row>'
          if (index === 0) {
               marker.bindPopup(content2, customerOptions).openPopup() // 默认展开标记点击弹窗
               marker.bindTooltip(res.name).openTooltip()// 默认展开tooltip
          } else {
               marker.bindPopup(content, customerOptions) // 标记点击弹窗
               marker.bindTooltip(res.name) // 标记悬浮弹窗
          }
          // 自定义其他事件
          marker.on('click', () => {
            console.log(res.name + '123123')
          })
          this.marker.push(marker) // 保存标记，便于清空
      })
    },
      initData() {
          this.mapData = [
          { name: 'marker1', tips: 'Z0001', lat: 30.16, lng: 120.53 },
          { name: 'marker2', tips: 'Z0002', lat: 30.40, lng: 120.26 },
          { name: 'marker3', tips: 'Z0003', lat: 30.04, lng: 120.41 },
          { name: 'marker4', tips: 'Z0004', lat: 30.03, lng: 120.85 },
          { name: 'marker5', tips: 'Z0005', lat: 30.18, lng: 120.45 },
          { name: 'marker6', tips: 'Z0006', lat: 30.46, lng: 120.24 }
        ]
      },
      initMap() {
        this.map = L.map('map', {
          center: [39.064576, 117.06969],
          zoom: 4.5,
          zoomControl: false,
          doubleClickZoom: false,
          attributionControl: false // 移除右下角leaflet标识
        })
        var mapLayers = {
          '高德/卫星': L.layerGroup([
            L.tileLayer('https://webst0{s}.is.autonavi.com/appmaptile?style=7&x={x}&y={y}&z={z}', {
              maxZoom: 20,
              maxNativeZoom: 18,
              minZoom: 3,
              attribution: '高德地图 AutoNavi.com',
              subdomains: '1234'
            })
          ]).addTo(this.map),
          '高德/街道': L.tileLayer(
            'https://webrd0{s}.is.autonavi.com/appmaptile?lang=zh_cn&size=1&scale=1&style=8&x={x}&y={y}&z={z}', {
              maxZoom: 20,
              maxNativeZoom: 18,
              minZoom: 3,
              attribution: '高德地图 AutoNavi.com',
              subdomains: '1234'
            }),
          '智图/街道': L.tileLayer(
            'https://map.geoq.cn/ArcGIS/rest/services/ChinaOnlineStreetPurplishBlue/MapServer/tile/{z}/{y}/{x}', {
              maxZoom: 20,
              maxNativeZoom: 16,
              minZoom: 3,
              attribution: '智图 GeoQ.cn'
            })
        }
        L.control.layers(mapLayers, {}, {
          position: 'topright',
          collapsed: false
        }).addTo(this.map)
	L.control.zoom({
         zoomInTitle: '放大',
		zoomOutTitle: '缩小'
	}).addTo(this.map)
     const DefaultIcon = L.icon({
          iconUrl: icon,
          shadowUrl: iconShadow
      })
     L.Marker.prototype.options.icon = DefaultIcon
  },
  onMapClick(e) {
   // alert('You clicked the map at ' + e.latlng)
	},
      initMapPm() {
        this.map.pm.addControls({
          position: 'topleft',
          drawPolygon: false, // 添加绘制多边形
          drawMarker: false, // 添加按钮以绘制标记
          drawCircleMarker: false, // 添加按钮以绘制圆形标记
          drawPolyline: false, // 添加按钮绘制线条
          drawRectangle: false, // 添加按钮绘制矩形
          drawCircle: false, //  添加按钮绘制圆圈
          editMode: false, //  添加按钮编辑多边形
          dragMode: false, //   添加按钮拖动多边形
          cutPolygon: false, // 添加一个按钮以删除图层里面的部分内容
          removalMode: false // 清除图层
        })
        this.map.on('click', this.onMapClick)
        // 设置绘制后的线条颜色等
        this.map.pm.setPathOptions({
          color: 'orange',
          fillColor: 'green',
          fillOpacity: 0.4
        })
        this.map.pm.setLang('zh') // 设置语言  en, de, it, ru, ro, es, fr, pt_br, zh , nl
      },
      getlatLngs() {
        this.map.on('pm:drawstart', e => {})
        this.map.on('pm:drawend', e => {})
        this.map.on('pm:create', e => {
          // console.log(e.layer._latlngs[0], '绘制坐标')
          this.GetGeoJson()
        })
      },
      // 生成geojson数据
      GetGeoJson() {
        var layerArray = []
        this.map.eachLayer(function(layer) {
          if (layer.pm !== 'undefined' && layer.pm != null && layer.pm !== '') {
            if (layer.pm._enabled === false && layer.pm.options.draggable === true) {
              layerArray.push(layer)
            }
          }
        })
        var geojson = L.layerGroup(layerArray).toGeoJSON()
        for (var n = 0; n < geojson.features.length; n++) {
          var nowJson = JSON.stringify(geojson.features[n])
          for (var m = n + 1; m < geojson.features.length; m++) {
            var nextJson = JSON.stringify(geojson.features[m])
            if (nowJson === nextJson) {
              geojson.features.splice(n, 1)
            }
          }
        }
        this.drawerVisible = true
        this.geosjonData = geojson
        return geojson
        // 重新加载geojson数据
        // L.geoJson(geojson).addTo(map);
      },
      onCloseDrawer() {
        this.drawerVisible = false
      },
      GetDeviceOTree() {
      GetDeviceOTree(Object.assign(this.queryParam)).then((res) => {
        this.treeLoading = false
        if (!res.success) {
          return
        }
        this.orgTree = res.data
        this.queryParam.parentId = this.orgTree[0].id
        // 全部展开，上面api方法提供的不生效，先用此方法
        for (var item of res.data) {
          // eslint-disable-next-line eqeqeq
          if (item.parentId == 0) {
            this.defaultExpandedKeys.push(item.id)
          }
        }
        // this.$refs.table.refresh()
        // this.$refs.table_sim.refresh()
        // this.$refs.table_mile.refresh()
      })
    },
    typeFilter(orgType) {
      // eslint-disable-next-line eqeqeq
      const values = this.typeDictTypeDropDown.filter((item) => item.code == orgType)
      if (values.length > 0) {
        return values[0].value
      }
    },
     handleClick(e) {
      this.queryParam = {
        OwnedOrg: e.toString()
      }
      // this.$refs.table.refresh(true)
      // this.$refs.table_sim.refresh(true)
      // this.$refs.table_mile.refresh(true)
    }
    }
  }
</script>
<style lang="less">
  #map {
    width: 100%;
    height: calc(100vh);
    z-index: 1;
    margin-left: -24px;
    margin-top: -24px;
    position: fixed;
  }

  .leaflet-right .leaflet-control {
    position: fixed;
    right: -5px;
  }
</style>
