<template>
  <a-row style="height:100%">
    <a-col :md="6" :sm="24" style="height:100%">
      <a-row class="group-outBox">
        <div class="group-header">
          <div class="group-title">客户列表</div>
          <a-row type="flex" justify="space-between">
            <a-col :span="12">
              <a-input v-model="OwnedOrg" placeholder="搜索"></a-input>
            </a-col>
            <a-col :span="10">
              <a-button class="searchBtn" type="primary" icon="search" @click="onSearch">搜索</a-button>
            </a-col>
          </a-row>
        </div>
        <!-- <a-card :bordered="false" :loading="treeLoading"> -->
        <div v-if="this.orgTree != ''" class="group-contain">
          <a-tree
            :treeData="orgTree"
            v-if="orgTree.length"
            @select="handleClick"
            :replaceFields="replaceFields"
          />
        </div>
        <div v-else>
          <a-empty :image="simpleImage" />
        </div>
        <!-- </a-card> -->
      </a-row>
      <a-tabs class="device-tabs" type="card" style="margin:20px">
        <a-tab-pane key="1" tab="设备">
          <a-row type="flex" justify="space-between">
            <a-col :span="12">
              <a-input placeholder="搜索设备"></a-input>
            </a-col>
            <a-col :span="10">
              <a-button-group>
                <a-button type="primary" shape="round">
                  <a-icon type="search" />
                </a-button>
                <a-button type="primary" shape="round">
                  <a-icon type="right" />
                </a-button>
              </a-button-group>
            </a-col>
          </a-row>

          <a-tabs default-active-key="1" tab-position="top" @change="changeDeviceList">
            <a-tab-pane key="1" tab="全部"></a-tab-pane>
            <a-tab-pane key="2" tab="在线"></a-tab-pane>
            <a-tab-pane key="3" tab="离线"></a-tab-pane>
            <a-tab-pane key="4" tab="到期"></a-tab-pane>
          </a-tabs>
          <a-table
            expandRowByClick
            size="middle"
            :columns="deviceCol"
            :data-source="deviceList"
            :showHeader="false"
            :loading="loading"
            :pagination="false"
            :expandIconAsCell="false"
            :expandIconColumnIndex="-1"
            :customRow="openPop"
          >
            <span
              slot="deviceStatus"
              slot-scope="status"
            >{{ status ? (status == 1 ? '在线':'离线') : '无状态' }}</span>
            <div slot="deviceNo" slot-scope="record">
              <div>{{ record }}</div>
            </div>
            <div slot="expandedRowRender" slot-scope="record" class="expendInfo">
              <router-link
                target="_blank"
                :to="{path: '/playback',query: {mac_id: record.deviceNo}}"
              >轨迹</router-link>
              <a href="javascript:void(0);">报警</a>
            </div>
          </a-table>
        </a-tab-pane>
      </a-tabs>
    </a-col>
    <a-col :md="18" :sm="24" style="positon:relative">
      <div
        id="timerCt"
        class="tip"
        style="position: absolute; top: 5px; left: 65px; z-index: 1000;"
      >
        <span id="refTimer">5</span> 秒后刷新
      </div>
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
import { GetDeviceOTree, GetMapDeviceList } from '@/api/modular/main/DeviceInfoManage'
import L from 'leaflet'
import icon from 'leaflet/dist/images/marker-icon.png'
import iconShadow from 'leaflet/dist/images/marker-shadow.png'
import { LMap, LTileLayer, LMarker, LControlLayers, LGeoJson } from 'vue2-leaflet'
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
  data () {
    return {
      map: '',
      geosjonData: {},
      drawerVisible: false,
      marker: [],
      markerGroup: null,
      // mapData: [],
      // treeLoading: true,
      orgTree: [],
      orgTreeParam: {
        OwnedOrg: ''
      },
      simpleImage: Empty.PRESENTED_IMAGE_SIMPLE,
      replaceFields: {
        key: 'id'
      },
      geojsonFeature: {},
      OwnedOrg: '',
      // 设备列表
      deviceCol: [{
        title: '设备名称',
        dataIndex: 'deviceNo',
        scopedSlots: { customRender: 'deviceNo' }
      }, {
        title: '设备状态',
        dataIndex: 'deviceStatus',
        scopedSlots: { customRender: 'deviceStatus' }
      }],
      deviceList: [],
      deviceParams: {
        OwnedOrg: '',
        devicestatus: 'ALL',
        pageNo: 0
      },
      loading: false,
      finished: false
    }
  },
  mounted () {
    this.getDeviceOTree()
    this.getMapDeviceList()
    this.initMap()
    this.initMapPm()
    this.getlatLngs()
    // this.getPointer(this.map)
  },
  methods: {
    // 设置地图标记和弹窗
    getPointer (map, loc) {
      const that = this // 防止变量冲突

      // 如果有标记则清空
      if (that.markerGroup !== null) {
        that.markerGroup.clearLayers()
      }

      loc.map((res) => {
        const marker = L.marker([res.cur_lat, res.cur_log]).addTo(map) // 设置标记经纬度
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
          minWidth: 300,
          minHeight: 500
        }
        // 设备状态展示
        const deviceStatus = res.deviceStatus ? (res.deviceStatus === 1 ? '在线' : '离线') : '无状态'
        const fortifiedState = res.fortifiedState ? (res.fortifiedState === 1 ? '设防' : '撤防') : '无状态'
        const locType = res.locType === 1 ? 'LBS' : 'GPS'
        const onOffState = res.on_off_state === 1 ? '通电' : '断电'
        let dotLine = ''
        let gms = ''
        for (let i = 0; i < 5; i++) {
          if (i < res.gps_grage) {
            dotLine = dotLine + '<div class="dotLine green"></div>'
          } else {
            dotLine = dotLine + '<div class="dotLine"></div>'
          }
          if (i < res.gms_grage) {
            gms = gms + '<div class="dotLine green"></div>'
          } else {
            gms = gms + '<div class="dotLine"></div>'
          }
        }
        var content =
          '<div class="c-popup">' +
          '<div class="c-row ant-row-flex-space-between">' +
          '<div class="c-row" style="align-items: center;"><span class="c-row-title" style="padding-right:5px">GPS</span>' +
          dotLine +
          '</div>' +
          '<div class="c-row" style="align-items: center;"><span class="c-row-title" style="padding-right:5px">GSM</span>' +
          gms +
          '</div>' +
          '</div>' +
          '<div class="c-row">' +
          '<div><span class="c-row-title">名称：</span>' +
          res.deviceName +
          '</div>' +
          '<div style="width:50%"><span class="c-row-title">状态：</span>' +
          deviceStatus +
          '</div>' +
          '</div>' +
          '<div class="c-row">' +
          '<div><span class="c-row-title">设备号：</span>' +
          res.deviceNo +
          '</div>' +
          '<div style="width:50%"><span class="c-row-title">设防状态：</span>' +
          fortifiedState +
          '</div>' +
          '</div>' +
          '<div class="c-row">' +
          '<div><span class="c-row-title">控制：</span>' +
          onOffState +
          '</div>' +
          '<div style="width:50%"><span class="c-row-title">定位类型：</span>' +
          locType +
          '</div>' +
          '</div>' +
          '<div class="c-row">' +
          '<div><span class="c-row-title">当日里程(公里)：</span>' +
          res.cur_day_miles +
          '</div>' +
          '<div style="width:50%"><span class="c-row-title">总里程(公里)：</span>' +
          res.cur_gps_miles +
          '</div>' +
          '</div>' +
          '<div class="c-row">' +
          '<div><span class="c-row-title">电压：</span>' +
          res.batteryVoltage +
          '</div>' +
          '<div style="width:50%"><span class="c-row-title">FAC：</span>' +
          res.sumMileCount +
          '</div>' +
          '</div>' +
          '<div class="c-row">' +
          '<div><span class="c-row-title">通信：</span>' +
          res.lastComDtime +
          '</div>' +
          '</div>' +
          '<div class="c-row">' +
          '<div><span class="c-row-title">定位：</span>' +
          res.lastLocDtime +
          '</div>' +
          '</div>' +
          '<div class="c-row">' +
          '<div><span class="c-row-title">地址：</span>' +
          res.LocationName +
          '</div>' +
          '</div>' +
          '<div class="c-row-bottom">' +
          '<a>轨迹</a><a>报警</a><a>指令</a><a>围栏</a><a>街景</a><a>设备信息</a><a>BMS</a><a>指令记录</a>' +
          '</div>' +
          '</div>'
        // var content2 =
        //   '<div class="c-popup">' +
        //   '<div class="c-row">' +
        //   '<div><span class="c-row-title">名称：</span>' +
        //   res.deviceName +
        //   '</div>' +
        //   '<div style="width:50%"><span class="c-row-title">状态：</span>' +
        //   res.devicestatus +
        //   '</div>' +
        //   '</div>' +
        //   '</div>'
        // if (index === 0) {
        //   marker.bindPopup(content2, customerOptions).openPopup() // 默认展开标记点击弹窗
        //   marker.bindTooltip(res.name).openTooltip() // 默认展开tooltip
        // } else {
        marker.bindPopup(content, customerOptions) // 标记点击弹窗
        // }
        // 自定义其他事件
        // marker.on('click', () => {
        //   console.log(res.deviceName + ' -> 123123')
        // })
        that.marker.push(marker) // 保存标记，便于清空
      })
      that.markerGroup = L.layerGroup(that.marker)
      map.addLayer(that.markerGroup)
    },
    // 打开指定弹出框
    openPop (record, index) {
      const that = this
      return {
        on: {
          click: () => {
            that.map.setView(L.latLng(record.cur_lat, record.cur_log), 13)
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
          'https://webrd0{s}.is.autonavi.com/appmaptile?lang=zh_cn&size=1&scale=1&style=8&x={x}&y={y}&z={z}',
          {
            maxZoom: 20,
            maxNativeZoom: 18,
            minZoom: 3,
            attribution: '高德地图 AutoNavi.com',
            subdomains: '1234'
          }
        ),
        '智图/街道': L.tileLayer(
          'https://map.geoq.cn/ArcGIS/rest/services/ChinaOnlineStreetPurplishBlue/MapServer/tile/{z}/{y}/{x}',
          {
            maxZoom: 20,
            maxNativeZoom: 16,
            minZoom: 3,
            attribution: '智图 GeoQ.cn'
          }
        ),
        '天地图': L.tileLayer(
          'http://t7.tianditu.gov.cn/vec_w/wmts?SERVICE=WMTS&REQUEST=GetTile&VERSION=1.0.0&LAYER=vec&STYLE=default&TILEMATRIXSET=w&FORMAT=tiles&TILEMATRIX={z}&TILEROW={y}&TILECOL={x}&tk=e3b434f191257368fc43c5b011ab5911',
          {
            maxZoom: 20,
            maxNativeZoom: 18,
            minZoom: 3,
            attribution: '天地图矢量',
            subdomains: '1234'
          }
        )
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
    // 客户列表搜索事件
    onSearch () {
      this.orgTreeParam = {
        OwnedOrg: this.OwnedOrg
      }
      this.getDeviceOTree()
    },
    // 获取客户列表数据
    getDeviceOTree () {
      // GetDeviceOTree(Object.assign(this.queryParam)).then(res => {
      GetDeviceOTree(this.orgTreeParam).then(res => {
        // this.treeLoading = false
        if (!res.success) {
          return
        }
        console.log('GetDeviceOTree-> ', res)
        this.orgTree = res.data
      })
    },
    // 获取设备列表数据
    getMapDeviceList () {
      const that = this
      that.loading = true
      GetMapDeviceList(that.deviceParams).then(res => {
        if (res.code === 200) {
          if (res.data.rows.length > 0) {
            that.deviceList = that.deviceList.concat(res.data.rows)
            that.pageLen = res.data.totalPage
            // 设置标记
            that.getPointer(that.map, that.deviceList)
          }
        }
        that.loading = false
        console.log('GetMapDeviceList init -> ', res)
      })
    },
    // 点击客户树更新设备列表
    handleClick (key) {
      const that = this
      that.deviceParams = {
        OwnedOrg: key,
        devicestatus: 'ALL'
      }
      that.deviceList = []
      that.getMapDeviceList()
    },
    // 切换显示设备状态
    changeDeviceList (activeKey) {
      switch (activeKey) {
        case '1':
          this.deviceParams.devicestatus = 'ALL'
          break
        case '2':
          this.deviceParams.devicestatus = 'ONLINE'
          break
        case '3':
          this.deviceParams.devicestatus = 'OFFLINE'
          break
        case '4':
          this.deviceParams.devicestatus = 'EXPIRE'
          break
      }
      this.deviceList = []
      this.getMapDeviceList()
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
  height: 40%;
  border-bottom: 1px solid #fff0ff;
}
.device-tabs {
  height: calc(60% - 40px);
  overflow: visible;
  > .ant-tabs-content {
    height: calc(100% - 40px);
    > .ant-tabs-tabpane {
      height: 100%;
    }
    .ant-tabs-bar {
      margin-bottom: 10px;
    }
    .infinite-container {
      overflow-y: auto;
      padding: 0;
      height: calc(100% - 100px);
    }
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
