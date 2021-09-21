<template>
  <a-row style="height:100%">
    <a-col :md="6" :sm="24" style="height:100%">
      <a-row class="group-outBox">
        <div class="group-header">
          <div class="group-title">轨迹回放</div>
        </div>
        <a-form-model
          :label-col="{ span: 6 }"
          :wrapper-col="{ span: 14 }"
          :form="form"
          @submit="searchDeviceLoc"
          hideRequiredMark
        >
          <a-form-model-item label="设备号">
            <a-input
              v-model="form.deviceNo"
              v-decorator="['deviceNo', { rules: [{ required: true, message: '请输入设备号' }] }]"
            />
          </a-form-model-item>
          <a-form-model-item label="开始时间">
            <a-date-picker
              v-decorator="['date-time-picker', {rules: [{ type: 'object', required: true, message: '请选择开始时间' }]}]"
              show-time
              format="YYYY-MM-DD HH:mm:ss"
            >
              <a-icon slot="suffixIcon" type="clock-circle" />
            </a-date-picker>
          </a-form-model-item>
          <a-form-model-item label="结束时间">
            <a-date-picker
              v-decorator="['date-time-picker', {rules: [{ type: 'object', required: true, message: '请选择结束时间' }]}]"
              show-time
              format="YYYY-MM-DD HH:mm:ss"
            >
              <a-icon slot="suffixIcon" type="clock-circle" />
            </a-date-picker>
          </a-form-model-item>
          <a-form-model-item label="回放速度">
            <a-slider id="test" :default-value="30" />
          </a-form-model-item>
          <a-row type="flex" justify="center" style="width:100%; padding-bottom:10px;">
            <a-col :span="10">
              <a-checkbox value="1" name="type" checked>显示报警</a-checkbox>
            </a-col>
            <a-col :span="10">
              <a-checkbox value="2" name="type">原速回放</a-checkbox>
            </a-col>
          </a-row>
          <a-row type="flex" justify="center" style="width:100%; padding-bottom:10px;">
            <a-button type="primary" icon="search" html-type="submit">查询</a-button>
            <a-button style="margin-left: 10px;" icon="play-circle">回放</a-button>
          </a-row>
        </a-form-model>
      </a-row>
      <a-tabs class="device-tabs" type="card" style="margin:20px">
        <a-tab-pane key="1" tab="停留">
          <a-table
            expandRowByClick
            size="middle"
            :columns="deviceCol"
            :data-source="deviceLocList"
            :showHeader="false"
            :loading="loading"
            :pagination="false"
            :customRow="openPop"
          >
            <div slot="info" slot-scope="record">
              <div style="padding-bottom:5px">
                <a-tag color="blue">起点</a-tag>
                {{ record.addr }}
              </div>
              <div>
                <!-- <a-tag color="orange">时间</a-tag> -->
                <a-icon type="clock-circle" />
                {{ record.device_time }}
              </div>
            </div>
          </a-table>
        </a-tab-pane>
      </a-tabs>
    </a-col>
    <a-col :md="18" :sm="24" style="positon:relative">
      <div class="tip" style="position: absolute; top: 5px; right: 250px; z-index: 1000;">
        <i class="speed-marker" style="background-color: rgb(51, 102, 153);"></i>
        <span class="p-lr5">慢速</span>
        <i class="speed-marker" style="background-color: rgb(0, 255, 0);"></i>
        <span class="p-lr5">正常</span>
        <i class="speed-marker" style="background-color: rgb(245, 7, 19);"></i>
        <span class="p-lr5">超速</span>
        <i class="speed-marker" style="background-color: rgb(149, 2, 34);"></i>
        <span class="p-lr5">超速</span>(1.5)
      </div>
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
            @close="onCloseDrawer"
          >
            <p>{{ geosjonData }}</p>
          </a-drawer>
        </div>
      </div>
    </a-col>
  </a-row>
</template>

<script>
import { GetDeviceLocList } from '@/api/modular/main/DeviceInfoManage'
import L from 'leaflet'
import icon from 'leaflet/dist/images/marker-icon.png'
import iconShadow from 'leaflet/dist/images/marker-shadow.png'
import { LMap, LTileLayer, LMarker, LControlLayers, LGeoJson } from 'vue2-leaflet'
import 'leaflet/dist/leaflet.css'
import 'leaflet.pm'
import 'leaflet.pm/dist/leaflet.pm.css'
import { Empty } from 'ant-design-vue'
import AMapLoader from '@amap/amap-jsapi-loader'

export default {
  name: 'Map',
  components: {
    LMap,
    LTileLayer,
    LMarker,
    LControlLayers,
    LGeoJson
  },
  data () {
    return {
      map: '',
      geosjonData: {},
      drawerVisible: false,
      marker: [],
      markerGroup: null,
      simpleImage: Empty.PRESENTED_IMAGE_SIMPLE,
      replaceFields: {
        key: 'id'
      },
      geojsonFeature: {},
      OwnedOrg: '',
      // 设备列表
      deviceCol: [{
        title: '设备信息',
        key: 'info',
        scopedSlots: { customRender: 'info' }
      }],
      deviceLocList: [],
      deviceParams: {
        DeviceNo: ''
      },
      loading: false,
      finished: false,
      // 查询框
      form: {
        deviceNo: this.$route.query.mac_id,
        from: '',
        to: ''
      },
      // 地图
      geocoderObject: null,
      AMap: null
    }
  },
  mounted () {
    // this.getDeviceLocList()
    this.initMap()
    this.initMapPm()
    this.getlatLngs()
    // 初始化高德地图API
    AMapLoader.load({
      // 高德开发者密钥 ：平台申请
      key: 'f8b3c00b5cf78fc551e81ebf18b50342',
      // 高德API版本: 2.0
      version: '2.0',
      // 加载高德内置插件
      plugins: ['AMap.Geocoder', 'AMap.convertFrom']
    })
      .then((AMap) => {
        this.geocoderObject = new AMap.Geocoder()
        this.AMap = AMap
        this.getDeviceLocList()
      })
      .catch((err) => {
        console.error(err)
      })
  },
  watch: {
    deviceLocList (newVal) {
      this.deviceLocList = newVal
    }
  },
  methods: {
    // 设置地图标记和弹窗
    getPointer (map, loc) {
      const that = this // 防止变量冲突
      const latlngs = [] // 定义坐标集

      // 如果有标记则清空
      if (that.markerGroup !== null) {
        that.markerGroup.clearLayers()
      }
      console.log('kic', loc)
      // 设置标记
      loc.map((item, index) => {
        latlngs.push([item.longitude, item.latitude]) // 添加坐标集
        const marker = L.marker([item.longitude, item.latitude]).addTo(map) // 设置标记经纬度
        // map.addLayer(marker) // 添加标记
        marker.setIcon(
          L.icon({
            // 标记配置-详见leaflet官网
            iconUrl: icon, // 使用require加载标记图
            iconSize: [20, 25]
          })
        )
        var customerOptions = {
          closeButton: true,
          minWidth: 200,
          minHeight: 500
        }
        var content =
          '<div class="c-popup">' +
          '<div class="c-row">' +
          '<div><span class="c-row-title">速度(Km/h)：</span>' +
          item.speed +
          ' Km/h</div>' +
          '</div>' +
          '<div class="c-row">' +
          '<div><span class="c-row-title">电压：</span>' +
          item.batteryVoltage +
          ' V</div>' +
          '</div>' +
          '<div class="c-row">' +
          '<div><span class="c-row-title">时间：</span>' +
          item.device_time +
          '</div>' +
          '</div>' +
          '</div>'
        if (index === 0) {
          marker.bindPopup(content, customerOptions).openPopup() // 标记点击弹窗，并打开
        } else {
          marker.bindPopup(content, customerOptions) // 标记点击弹窗
        }
        that.marker.push(marker) // 保存标记，便于清空
      })
      that.markerGroup = L.layerGroup(that.marker)
      map.addLayer(that.markerGroup)
      console.log('坐标->', latlngs)
      // 绘制折线
      const polyline = L.polyline(latlngs, { color: 'red' }).addTo(map)
      map.fitBounds(polyline.getBounds())
    },
    // 打开指定弹出框
    openPop (record, index) {
      const that = this
      return {
        props: {
          locationAdd: null
        },
        on: {
          click: () => {
            that.map.setView(L.latLng(record.latitude, record.longitude), 13)
            that.marker[index].openPopup()
          }
        }
      }
    },
    initMap () {
      this.map = L.map('map', {
        center: [39.064576, 117.06969],
        zoom: 4.5,
        zoomControl: false,
        doubleClickZoom: false,
        attributionControl: false // 移除右下角leaflet标识
      })
      var mapLayers = {
        '高德/街道': L.tileLayer('https://webrd0{s}.is.autonavi.com/appmaptile?lang=zh_cn&size=1&scale=1&style=8&x={x}&y={y}&z={z}', {
          maxZoom: 20,
          maxNativeZoom: 18,
          minZoom: 3,
          attribution: '高德地图 AutoNavi.com',
          subdomains: '1234'
        }).addTo(this.map),
        '高德街道/谷歌卫星': L.layerGroup([
          L.tileLayer('http://mt3.google.cn/vt/lyrs=m&hl=zh-CN&gl=cn&x={x}&y={y}&z={z}', {
            maxZoom: 20,
            minZoom: 3,
            attribution: '谷歌提供卫星图，高德提供街道图'
          }),
          L.tileLayer('https://webst0{s}.is.autonavi.com/appmaptile?style=8&x={x}&y={y}&z={z}', {
            maxZoom: 20,
            maxNativeZoom: 18,
            minZoom: 3,
            attribution: '谷歌提供卫星图，高德提供街道图',
            subdomains: '1234',
            opacity: 0.5
          })
        ]),
        '高德/卫星': L.layerGroup([
          L.tileLayer('https://webst0{s}.is.autonavi.com/appmaptile?style=6&x={x}&y={y}&z={z}', {
            maxZoom: 20,
            maxNativeZoom: 18,
            minZoom: 3,
            attribution: '高德地图 AutoNavi.com',
            subdomains: '1234'
          }),
          L.tileLayer('https://webst0{s}.is.autonavi.com/appmaptile?style=8&x={x}&y={y}&z={z}', {
            maxZoom: 20,
            maxNativeZoom: 18,
            minZoom: 3,
            attribution: '高德地图 AutoNavi.com',
            subdomains: '1234',
            opacity: 0.5
          })
        ]),
        '谷歌/卫星': L.tileLayer('http://mt3.google.cn/vt/lyrs=m&hl=zh-CN&gl=cn&x={x}&y={y}&z={z}', {
          maxZoom: 20,
          minZoom: 3,
          attribution: '谷歌 Google.cn'
        }),
        '谷歌/街道': L.tileLayer('http://mt3.google.cn/vt/lyrs=m&hl=zh-CN&gl=cn&x={x}&y={y}&z={z}', {
          maxZoom: 20,
          minZoom: 3,
          attribution: '谷歌 Google.cn'
        })
        // '高德/卫星': L.layerGroup([
        //   L.tileLayer('https://webst0{s}.is.autonavi.com/appmaptile?style=7&x={x}&y={y}&z={z}', {
        //     maxZoom: 20,
        //     maxNativeZoom: 18,
        //     minZoom: 3,
        //     attribution: '高德地图 AutoNavi.com',
        //     subdomains: '1234'
        //   })
        // ]).addTo(this.map),
        // '高德/街道': L.tileLayer(
        //   'https://webrd0{s}.is.autonavi.com/appmaptile?lang=zh_cn&size=1&scale=1&style=8&x={x}&y={y}&z={z}',
        //   {
        //     maxZoom: 20,
        //     maxNativeZoom: 18,
        //     minZoom: 3,
        //     attribution: '高德地图 AutoNavi.com',
        //     subdomains: '1234'
        //   }
        // ),
        // '智图/街道': L.tileLayer(
        //   'https://map.geoq.cn/ArcGIS/rest/services/ChinaOnlineStreetPurplishBlue/MapServer/tile/{z}/{y}/{x}',
        //   {
        //     maxZoom: 20,
        //     maxNativeZoom: 16,
        //     minZoom: 3,
        //     attribution: '智图 GeoQ.cn'
        //   }
        // )
      }
      L.control
        .layers(
          mapLayers,
          {},
          {
            position: 'topright',
            collapsed: false
          }
        )
        .addTo(this.map)
      L.control
        .zoom({
          zoomInTitle: '放大',
          zoomOutTitle: '缩小'
        })
        .addTo(this.map)
      const DefaultIcon = L.icon({
        iconUrl: icon,
        shadowUrl: iconShadow
      })
      L.Marker.prototype.options.icon = DefaultIcon
    },
    onMapClick (e) {
      // alert('You clicked the map at ' + e.latlng)
    },
    initMapPm () {
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
    getlatLngs () {
      this.map.on('pm:drawstart', e => { })
      this.map.on('pm:drawend', e => { })
      this.map.on('pm:create', e => {
        // console.log(e.layer._latlngs[0], '绘制坐标')
        this.GetGeoJson()
      })
    },
    // 生成geojson数据
    GetGeoJson () {
      var layerArray = []
      this.map.eachLayer(function (layer) {
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
    onCloseDrawer () {
      this.drawerVisible = false
    },
    // 获取路径列表数据
    getDeviceLocList () {
      const that = this
      that.loading = true
      GetDeviceLocList(that.deviceParams).then(res => {
        if (res.code === 200) {
          console.log('GetdeviceLocList init -> ', res)
          if (res.data.rows.length > 0) {
            that.pageLen = res.data.totalPage
            const list = res.data.rows
            list.map((item, index) => {
              // GPS坐标(WGS84)转为GCJ-02火星坐标(适用高德、谷歌)
              that.AMap.convertFrom([item.latitude, item.longitude], 'gps', function (status, result) {
                if (result.info === 'ok') {
                  that.$set(list[index], 'latitude', result.locations[0].lat)
                  that.$set(list[index], 'longitude', result.locations[0].lng)
                }
              })

              // 逆地理解析，坐标解析为地址
              that.geocoderObject.getAddress([item.latitude, item.longitude], (status, { regeocode }) => {
                if (status === 'complete' && regeocode) {
                  // result为对应的地理位置详细信息
                  that.$set(list[index], 'addr', regeocode.formattedAddress)
                } else {
                  that.$set(list[index], 'addr', '地址无法解析')
                }
              })
            })
            console.log('未负值', res)
            that.deviceLocList = that.deviceLocList.concat(list)
            // 设置标记
            that.getPointer(that.map, that.deviceLocList)
          }
        }
        that.loading = false
      })
    },
    // 查询设备轨迹
    searchDeviceLoc () {
      this.deviceParams = {
        DeviceNo: this.form.deviceNo,
        from: this.form.from,
        to: this.form.to
      }
      this.deviceLocList = []
      this.getDeviceLocList()
    }
  }
}
</script>
<style lang="less">
#map {
  width: 100%;
  height: calc(100vh);
  z-index: 1;
  // margin-left: -24px;
  // margin-top: -24px;
  position: fixed;
}

.leaflet-right .leaflet-control {
  position: fixed;
  right: -5px;
}

.c-popup {
  .c-row {
    display: flex;
    justify-content: space-between;
    line-height: 22px;
    .c-row-title {
      font-weight: bold;
    }
  }
  .c-row-bottom a {
    display: inline-block;
    margin-right: 8px;
  }
  .dotLine {
    display: inline-block;
    vertical-align: middle;
    border-radius: 5px;
    width: 3px;
    height: 10px;
    background: #baded6;
    margin-right: 2px;
  }
  .dotLine.green {
    background: #11bf96;
  }
}
.group-outBox {
  height: 50%;
  border-bottom: 1px solid #fff0ff;
  .ant-form-item {
    margin-bottom: 5px;
  }
}
.device-tabs {
  height: calc(50% - 40px);
  overflow: visible;
  > .ant-tabs-content {
    height: calc(100% - 60px);
    overflow-y: auto;
  }
}
// 左侧框
.group-header {
  padding: 18px 0 18px 20px;
  .group-title {
    font-weight: 700;
    font-size: 16px;
    color: #303133;
    overflow: hidden;
    white-space: nowrap;
    text-overflow: ellipsis;
    text-align: left;
    margin-bottom: 10px;
  }
}
.group-contain {
  height: calc(100% - 102px);
  overflow-y: scroll;
  .ant-tree li .ant-tree-node-content-wrapper {
    font-size: 12px;
    line-height: 20px;
    height: 20px;
    color: #606266;
  }
  .ant-tree li span.ant-tree-switcher,
  .ant-tree li span.ant-tree-iconEle {
    height: 20px;
    width: 20px;
    line-height: 18px;
  }
}
.tip {
  background: #f7f7f7;
  padding: 2px;
  font-size: 12px;
  opacity: 0.9;
  .speed-marker {
    position: relative;
    width: 16px;
    height: 10px;
    display: inline-block;
  }
  .p-lr5 {
    padding-left: 5px;
    padding-right: 5px;
  }
}
.demo-loading-container {
  position: absolute;
  bottom: 40px;
  width: 100%;
  text-align: center;
}
.ant-table-thead > tr > th,
.ant-table-tbody > tr > td {
  font-size: 12px;
  .expendInfo {
    a {
      padding-right: 5px;
    }
  }
}
.ant-table-tbody > tr > td + td {
  color: rgb(144 147 153);
}
</style>
