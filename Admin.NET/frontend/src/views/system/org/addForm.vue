<template>
  <a-modal
    title="新增客户"
    :width="750"
    :visible="visible"
    :confirmLoading="confirmLoading"
    @ok="handleSubmit"
    @cancel="handleCancel">
    <a-spin :spinning="formLoading">
      <a-form :form="form">
        <a-row :gutter="24">
          <a-col :md="24" :sm="24" >
            <a-form-item label="客户类型" :labelCol="labelCol1" :wrapperCol="wrapperCol1" >
              <a-radio-group v-decorator="['orgtype',{rules: [{ required: true, message: '请选择客户类型！' }]}]">
                <a-radio v-for="(item, index) in typeEnumDataDropDown" :key="index" :value="parseInt(item.code)">
                  {{ item.value }}</a-radio>
              </a-radio-group>
            </a-form-item>
          </a-col>
        </a-row>
        <a-row :gutter="24">
          <a-col :md="8" :sm="24">
            <a-form-item label="公司名称" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
              <a-input placeholder="请输入客户公司名称" v-decorator="['name', {rules: [{required: true, message: '请输入客户公司名称！'}]}]" />
            </a-form-item>
          </a-col>
          <a-col :md="8" :sm="24">
            <a-form-item label="联系人" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
              <a-input placeholder="请输入联系人" v-decorator="['contacts' ]" />
            </a-form-item>
          </a-col>
          <a-col :md="8" :sm="24">
            <a-form-item label="联系电话" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
              <a-input placeholder="请输入联系电话" v-decorator="['tel']" />
            </a-form-item>
          </a-col>
        </a-row>
        <a-row :gutter="24">
          <a-col :md="8" :sm="24">
            <a-form-item label="登录名称" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
              <a-input placeholder="请输入登录名称" v-decorator="['admin_User', {rules: [{required: true, message: '请输入登录名称！'}]}]" />
            </a-form-item>
          </a-col>
          <a-col :md="8" :sm="24">
            <a-form-item label="登录密码" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
              <a-input placeholder="请输入登录密码" v-decorator="['admin_PWD', {rules: [{required: true, message: '请输入登录密码！'}]}]" />
            </a-form-item>
          </a-col>
          <a-col :md="8" :sm="24">
            <a-form-item label="唯一编码" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
              <a-input placeholder="请输入唯一编码" v-decorator="['code',{rules: [{required: true, message: '请输入客户唯一编码！'}]}]" />
            </a-form-item>
          </a-col>
        </a-row>
        <a-row :gutter="24">
          <a-col :md="8" :sm="24">
            <a-form-item label="店名" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
              <a-input placeholder="请输入店名" v-decorator="['shopName', {rules: [{required: true, message: '请输入店名！'}]}]" />
            </a-form-item>
          </a-col>
          <a-col :md="8" :sm="24">
            <a-form-item label="店铺Logo" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
              <!--<a-input placeholder="请输入店铺Logo" v-decorator="['shopLogo', {rules: [{required: true, message: '请输入店铺Logo！'}]}]" />-->
              <div class="clearfix">
                <a-upload
                  action="https://www.mocky.io/v2/5cc8019d300000980a055e76"
                  list-type="picture-card"
                  :file-list="fileList"
                  @preview="handlePreview"
                  @change="handleChange"
                >
                  <div v-if="fileList.length < 1">
                    <a-icon type="plus" />
                    <div class="ant-upload-text">
                      Upload
                    </div>
                  </div>
                </a-upload>
                <a-modal :visible="previewVisible" :footer="null" @cancel="handleCancel2">
                  <img alt="example" style="width: 100%" :src="previewImage" />
                </a-modal>
              </div>
            </a-form-item>
          </a-col>
          <a-col :md="8" :sm="24">
            <a-form-item label="店铺照片" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
              <!--<a-input placeholder="请输入店铺照片" v-decorator="['shopPhoto', {rules: [{required: true, message: '请输入店铺照片！'}]}]" /> -->
              <div class="clearfix">
                <a-upload
                  action="https://www.mocky.io/v2/5cc8019d300000980a055e76"
                  list-type="picture-card"
                  :file-list="fileList3"
                  @preview="handlePreview3"
                  @change="handleChange3"
                >
                  <div v-if="fileList3.length < 8">
                    <a-icon type="plus" />
                    <div class="ant-upload-text">
                      Upload
                    </div>
                  </div>
                </a-upload>
                <a-modal :visible="previewVisible" :footer="null" @cancel="handleCancel3">
                  <img alt="example" style="width: 100%" :src="previewImage3" />
                </a-modal>
              </div>
            </a-form-item>
          </a-col>
        </a-row >
        <a-row :gutter="24">
          <a-col :md="24" :sm="24">
            <a-form-item label="店铺介绍" has-feedback>
              <a-textarea :rows="2" placeholder="请输入店铺介绍" v-decorator="['shopInfo']"></a-textarea>
              <a-input-number
                v-show="false"
                placeholder="请输入排序"
                style="width: 100%"
                v-decorator="['sort', { initialValue: 100 }]"
                :min="1"
                :max="1000" />
            </a-form-item>
          </a-col>
        </a-row>
        <a-row>
          <a-col>
            <a-form-item label="店铺地址" has-feedback>
              <a-tree-select
                v-decorator="['pid', {rules: [{ required: true, message: '请选择客户机构！' }]}]"
                style="width: 100%"
                :dropdownStyle="{ maxHeight: '300px', overflow: 'auto' }"
                :treeData="orgTree"
                placeholder="请选择上级客户"
                treeDefaultExpandAll>
                <span slot="title" slot-scope="{ id }">{{ id }}
                </span>
              </a-tree-select>
            </a-form-item>
          </a-col>
        </a-row>
        <a-row :gutter="24">
          <a-col :md="24" :sm="24">
            <a-form-item label="店铺地址" has-feedback>
              <a-input placeholder="请输入店铺地址" v-decorator="['shopAddress', {rules: [{required: true, message: '请输入店铺地址！'}]}]" />
            </a-form-item>
          </a-col>
        </a-row>
        <a-row :gutter="24">
          <a-col :md="18" :sm="24">
            <div>
              <div id="map">
                <a-drawer
                  title="图元属性"
                  placement="right"
                  :width="600"
                  :height="200"
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
      </a-form>
    </a-spin>
  </a-modal>
</template>
<script>
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
  import {
    sysOrgAdd,
    getOrgTree
  } from '@/api/modular/system/orgManage'
  import {
    sysDictTypeDropDown
  } from '@/api/modular/system/dictManage'
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
    getBase64(file) {
      return new Promise((resolve, reject) => {
        const reader = new FileReader()
        reader.readAsDataURL(file)
        reader.onload = () => resolve(reader.result)
        reader.onerror = error => reject(error)
      })
    },
    data() {
      return {
         labelCol1: {
          xs: {
            span: 24
          },
          sm: {
            span: 5
          }
        },
        wrapperCol1: {
          xs: {
            span: 24
          },
          sm: {
            span: 19
          }
        },

        labelCol: {
          xs: {
            span: 24
          },
          sm: {
            span: 9
          }
        },
        wrapperCol: {
          xs: {
            span: 24
          },
          sm: {
            span: 15
          }
        },
        typeEnumDataDropDown: [],
        orgTree: [],
        visible: false,
        confirmLoading: false,
        formLoading: true,
        form: this.$form.createForm(this),
        previewVisible: false,
        previewImage: '',
        fileList: [],
        previewVisible3: false,
        previewImage3: '',
        fileList3: [],
        map: '',
        geosjonData: {},
        drawerVisible: false,
        marker: [],
        mapData: [],
        treeLoading: true,
        queryParam: {},
        simpleImage: Empty.PRESENTED_IMAGE_SIMPLE,
        defaultExpandedKeys: [],
        replaceFields: {
          key: 'id'
        },
        geojsonFeature: {}
      }
    },
    created() {
      this.sysDictTypeDropDown()
    },
     mounted() {
         /* this.map = L.map('map', {
          center: [39.064576, 117.06969],
          zoom: 4.5,
          zoomControl: false,
          doubleClickZoom: false,
          attributionControl: false // 移除右下角leaflet标识
        }) */
      // eslint-disable-next-line no-unused-vars
      var mymap = L.map(this.$refs['map']).setView([39.064576, 117.06969], 13)
      this.initMap()
      this.initMapPm()
      this.getlatLngs()
      this.initData()
      this.getPointer(this.map)
    },
    methods: {
      // 初始化方法
      add() {
        this.visible = true
        this.getOrgTree()
      },
      /**
       * 获取字典数据
       */
      sysDictTypeDropDown(text) {
        sysDictTypeDropDown({
          code: 'org_type'
        }).then((res) => {
          this.typeEnumDataDropDown = res.data
        })
      },
      /**
       * 获取机构树，并加载于表单中
       */
      getOrgTree() {
        getOrgTree().then((res) => {
          this.formLoading = false
          if (!res.success) {
            this.orgTree = []
             return
          }
          this.orgTree = res.data
          /* this.orgTree = [{
            'id': '-1',
            'parentId': '0',
            'title': '顶级',
            'value': '0',
            'pid': '0',
            'children': res.data
          }] */
        })
      },

      handleSubmit() {
        const {
          form: {
            validateFields
          }
        } = this
        this.confirmLoading = true
        validateFields((errors, values) => {
          if (!errors) {
            sysOrgAdd(values).then((res) => {
              if (res.success) {
                this.$message.success('新增成功')
                this.visible = false
                this.confirmLoading = false
                this.$emit('ok', values)
                this.form.resetFields()
              } else {
                this.$message.error('新增失败：' + res.message)
              }
            }).finally((res) => {
              this.confirmLoading = false
            })
          } else {
            this.confirmLoading = false
          }
        })
      },
      handleCancel() {
        this.form.resetFields()
        this.visible = false
        this.previewVisible = false
        this.previewVisible3 = false
      },
      async handlePreview(file) {
        if (!file.url && !file.preview) {
          file.preview = await this.getBase64(file.originFileObj)
        }
        this.previewImage = file.url || file.preview
        this.previewVisible = true
      },
      handleChange({ fileList }) {
        this.fileList = fileList
      },
      handleCancel2() {
        this.previewVisible = false
      },
      async handlePreview3(file) {
      if (!file.url && !file.preview) {
        file.preview = await this.getBase64(file.originFileObj)
      }
      this.previewImage3 = file.url || file.preview
      this.previewVisible3 = true
      },
      handleChange3({ fileList }) {
        this.fileList3 = fileList
      },
      handleCancel3() {
        this.previewVisible3 = false
      },
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
      }
    }
  }
</script>
<style>
/* you can make up upload button and sample style by using stylesheets */
.ant-upload-select-picture-card i {
  font-size: 32px;
  color: #999;
}

.ant-upload-select-picture-card .ant-upload-text {
  margin-top: 8px;
  color: #666;
}
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
