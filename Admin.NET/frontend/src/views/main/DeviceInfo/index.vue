<template>
  <a-row :gutter="24">
    <a-col :md="5" :sm="24" style="padding: 0 0 0 0">
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
    <a-col :md="19" :sm="24">
      <a-spin :spinning="confirmLoading">
        <a-tabs default-active-key="1">
          <a-tab-pane key="1" tab="设备">
            <div>
              <a-card :bordered="false" :bodyStyle="tstyle">
                <div class="table-page-search-wrapper" v-if="hasPerm('DeviceInfo:page')">
                  <a-form layout="inline">
                    <a-row :gutter="48">
                      <a-col :md="8" :sm="24">
                        <a-form-item label="设备名称/编号">
                          <a-input v-model="queryParam.deviceName" allow-clear placeholder="设备名称" />
                        </a-form-item>
                      </a-col>
                      <template
                        v-if="advanced"
                      ><a-col :md="5" :sm="24">
                        <a-form-item label="电压(V)">
                          <a-input v-model="queryParam.Voltage" allow-clear placeholder="电压" />
                        </a-form-item> </a-col
                      ><a-col :md="5" :sm="24">
                        <a-form-item label="电量(AH)">
                          <a-input v-model="queryParam.Electricity" allow-clear placeholder="电量" />
                        </a-form-item>
                      </a-col
                      ><a-col :md="6" :sm="24">
                        <a-form-item label="在线否">
                          <a-select
                            :allowClear="true"
                            style="width: 100%"
                            v-model="queryParam.deviceStatus"
                            placeholder="请选择设备状态"
                          >
                            <a-select-option
                              v-for="(item) in deviceStatusData"
                              :key="item.id"
                              :value="item.code"
                            >{{ item.name }}</a-select-option
                            >
                          </a-select>
                        </a-form-item>
                      </a-col>
                      </template>

                      <a-col :md="8" :sm="24">
                        <span class="table-page-search-submitButtons">
                          <a-button type="primary" @click="$refs.table.refresh(true)">查询</a-button>
                          <a-button style="margin-left: 8px" @click="() => (queryParam = {})">重置</a-button>
                          <a @click="toggleAdvanced" style="margin-left: 8px">
                            {{ advanced ? '收起' : '展开' }}
                            <a-icon :type="advanced ? 'up' : 'down'" />
                          </a>
                        </span>
                      </a-col>
                    </a-row>
                  </a-form>
                </div>
              </a-card>
              <a-card :bordered="false">
                <s-table
                  ref="table"
                  :columns="columns"
                  :data="loadData"
                  :alert="true"
                  :rowKey="(record) => record.id"
                  :rowSelection="{ selectedRowKeys: selectedRowKeys, onChange: onSelectChange }"
                  bordered
                >
                  <template class="table-operator" slot="operator" v-if="hasPerm('DeviceInfo:page')">
                    <a-button
                      type="primary"
                      v-if="hasPerm('DeviceInfo:transfer')"
                      icon="retweet"
                      @click="$refs.transForm.transfer(selectedRows,)"
                    >批量转移</a-button
                    >
                    <a-button
                      type="primary"
                      v-if="hasPerm('DeviceInfo:lotEdit')"
                      icon="edit"
                      @click="$refs.lotEditForm.lotEdit(selectedRows)"
                    >批量修改</a-button
                    >
                    <a-button
                      type="primary"
                      v-if="hasPerm('DeviceInfo:lotSend')"
                      icon="enter"
                      @click="$refs.lotSendForm.lotSend(selectedRows,)"
                    >指令群发</a-button
                    >
                    <a-button
                      type="primary"
                      v-if="hasPerm('DeviceInfo:export')"
                      icon="down"
                      @click="DeviceInfoExport"
                    >导出</a-button
                    >
                  </template>
                  <span slot="deviceTypescopedSlots" slot-scope="text">
                    {{ 'device_type' | dictType(text) }}
                  </span>
                  <span slot="dModelscopedSlots" slot-scope="text">
                    {{ 'org_type' | dictType(text) }}
                  </span>
                  <span slot="batteryTypescopedSlots" slot-scope="text">
                    {{ 'Battery_Type' | dictType(text) }}
                  </span>
                  <span slot="ownedOrgscopedSlots" slot-scope="text">
                    {{ 'org_type' | dictType(text) }}
                  </span>
                  <span slot="deviceStatusscopedSlots" slot-scope="text">
                    {{ 'device_loc_status' | dictType(text) }}
                  </span>
                  <span slot="action" slot-scope="text, record">
                    <a v-if="hasPerm('DeviceInfo:edit')" @click="$refs.editForm.edit(record)">编辑</a>
                    <a-divider type="vertical" v-if="hasPerm('DeviceInfo:edit') & hasPerm('DeviceInfo:delete')" />
                  </span>
                </s-table>
                <add-form ref="addForm" @ok="handleOk" />
                <edit-form ref="editForm" @ok="handleOk" />
                <trans-form ref="transForm" @ok="handleOk" />
                <lot-Edit-Form ref="lotEditForm" @ok="handleOk"/>
                <lot-Send-Form ref="lotSendForm" @ok="handleOk" />
              </a-card>
            </div>
          </a-tab-pane>
          <a-tab-pane key="2" tab="SIM">
            <div>
              <a-card :bordered="false" :bodyStyle="tstyle">
                <div class="table-page-search-wrapper" v-if="hasPerm('SIMInfo:page')">
                  <a-form layout="inline">
                    <a-row :gutter="48">
                      <a-col :md="8" :sm="24">
                        <a-form-item label="设备编号">
                          <a-input v-model="queryParam.deviceNo" allow-clear placeholder="请输入设备编号" />
                        </a-form-item> </a-col
                        ><a-col :md="8" :sm="24">
                        <a-form-item label="Sim卡类型">
                          <a-select
                            :allowClear="true"
                            style="width: 100%"
                            v-model="queryParam.simType"
                            placeholder="请选择Sim卡类型"
                          >
                            <a-select-option v-for="(item) in simTypeData" :key="item.id" :value="item.code">{{
                              item.name
                            }}</a-select-option>
                          </a-select>
                        </a-form-item> </a-col
                      >
                      <!-- <template
                        v-if="advanced"
                      ><a-col :md="8" :sm="24">
                         <a-form-item label="卡状态">
                          <a-select
                            :allowClear="true"
                            style="width: 100%"
                            v-model="queryParam.simStatus"
                            placeholder="请选择卡状态"
                          >
                            <a-select-option v-for="(item ) in simStatusData" :key="item.id" :value="item.code">{{
                              item.name
                            }}</a-select-option>
                          </a-select>
                        </a-form-item>
                      </a-col>
                      </template> -->

                      <a-col :md="8" :sm="24">
                        <span class="table-page-search-submitButtons">
                          <a-button type="primary" @click="$refs.table.refresh(true)">查询</a-button>
                          <a-button style="margin-left: 8px" @click="() => (queryParam = {})">重置</a-button>
                          <a @click="toggleAdvanced2" style="margin-left: 8px">
                            {{ advanced2 ? '收起' : '展开' }}
                            <a-icon :type="advanced ? 'up' : 'down'" />
                          </a>
                        </span>
                      </a-col>
                    </a-row>
                  </a-form>
                </div>
              </a-card>
              <a-card :bordered="false">
                <s-table
                  ref="table"
                  :columns="columns2"
                  :data="loadData2"
                  :alert="true"
                  :rowKey="(record) => record.id"
                  :rowSelection="{ selectedRowKeys: selectedRowKeys_sim, onChange: onSelectChange_sim }"
                >
                  <template class="table-operator" slot="operator" v-if="hasPerm('SIMInfo:add')">
                    <a-button
                      type="primary"
                      v-if="hasPerm('SIMInfo:Charge')"
                      icon="credit-card"
                    >批量充值</a-button
                    >
                    <a-button
                      type="primary"
                      v-if="hasPerm('DeviceInfo:lotEdit')"
                      icon="edit"
                      @click="$refs.lotEditForm.lotEdit(selectedRows_sim)"
                    >批量修改</a-button
                    >
                  </template>
                  <span slot="simTypescopedSlots" slot-scope="text">
                    {{ 'sim_type' | dictType(text) }}
                  </span>
                  <span slot="simStatusscopedSlots" slot-scope="text">
                    {{ 'sim_status' | dictType(text) }}
                  </span>
                  <span slot="action" slot-scope="text, record">
                    <a v-if="hasPerm('SIMInfo:edit')" @click="$refs.editForm.edit(record)">编辑</a>
                    <a-divider type="vertical" v-if="hasPerm('SIMInfo:edit') & hasPerm('SIMInfo:delete')" />
                    <a-popconfirm
                      v-if="hasPerm('SIMInfo:delete')"
                      placement="topRight"
                      title="确认删除？"
                      @confirm="() => SIMInfoDelete(record)"
                    >
                      <a>删除</a>
                    </a-popconfirm>
                  </span>
                </s-table>
                <add-form ref="addForm" @ok="handleOk2" />
                <edit-form ref="editForm" @ok="handleOk2" />
              </a-card>
            </div>
          </a-tab-pane>
          <a-tab-pane key="3" tab="里程">
            <div>
              <a-card :bordered="false" :bodyStyle="tstyle">
                <div class="table-page-search-wrapper" v-if="hasPerm('MileStatistics:page')">
                  <a-form layout="inline">
                    <a-row :gutter="48">
                      <a-col :md="8" :sm="24">
                        <a-form-item label="设备编号">
                          <a-input v-model="queryParam.deviceNo3" allow-clear placeholder="请输入设备编号" />
                        </a-form-item>
                      </a-col>
                      <a-col :md="8" :sm="24">
                        <span class="table-page-search-submitButtons">
                          <a-button type="primary" @click="$refs.table.refresh(true)">查询</a-button>
                          <a-button style="margin-left: 8px" @click="() => (queryParam = {})">重置</a-button>
                          <a @click="toggleAdvanced3" style="margin-left: 8px">
                            {{ advanced3 ? '收起' : '展开' }}
                            <a-icon :type="advanced ? 'up' : 'down'" />
                          </a>
                        </span>
                      </a-col>
                    </a-row>
                  </a-form>
                </div>
              </a-card>
              <a-card :bordered="false">
                <s-table
                  ref="table"
                  :columns="columns3"
                  :data="loadData3"
                  :alert="true"
                  :rowKey="(record) => record.id"
                  :rowSelection="{ selectedRowKeys: selectedRowKeys, onChange: onSelectChange_mile }"
                >
                  <span slot="action">
                    <a v-if="hasPerm('MileStatistics:edit')">统计</a>
                  </span>
                </s-table>
                <add-form ref="addForm" @ok="handleOk3" />
                <edit-form ref="editForm" @ok="handleOk3" />
              </a-card>
            </div>
          </a-tab-pane>
        </a-tabs>
      </a-spin>
    </a-col>
  </a-row>
</template>
<script>
import { STable } from '@/components'
import { DeviceInfoPage, DeviceInfoDelete, DeviceInfoExport, GetDeviceOTree } from '@/api/modular/main/DeviceInfoManage'
import addForm from './addForm.vue'
import editForm from './editForm.vue'
import transForm from './transForm.vue'
import lotEditForm from './lotEditForm.vue'
import lotSendForm from './lotSendForm.vue'
import { Empty } from 'ant-design-vue'
import { sysDictTypeDropDown } from '@/api/modular/system/dictManage'
import { SIMInfoPage, SIMInfoDelete } from '@/api/modular/main/SIMInfoManage'
import { MileStatisticsDelete, MileStatisticsPagesum } from '@/api/modular/main/MileStatisticsManage'

export default {
  components: {
    STable,
    addForm,
    editForm,
    transForm,
    lotEditForm,
    lotSendForm
  },
  data() {
    return {
      advanced: false, // 高级搜索 展开/关闭
      advanced2: false,
      advanced3: false,
      queryParam: {},
      columns: [
        {
          title: '设备名称',
          align: 'center',
          sorter: true,
          dataIndex: 'deviceName'
        },
        {
          title: '设备编号',
          align: 'center',
          sorter: true,
          dataIndex: 'deviceNo'
        },
        {
          title: '类型',
          align: 'center',
          sorter: true,
          dataIndex: 'deviceType',
          scopedSlots: { customRender: 'deviceTypescopedSlots' }
        },
        {
          title: '型号',
          align: 'center',
          sorter: true,
          dataIndex: 'dModel'
        },
        {
          title: '在线状态',
          align: 'center',
          sorter: true,
          dataIndex: 'deviceStatus',
          scopedSlots: { customRender: 'deviceStatusscopedSlots' }
        },
        {
          title: '最后定位日期',
          align: 'center',
          sorter: true,
          dataIndex: 'lastLoationDtime'
        },
        {
           title: '制造时间',
           align: 'center',
           sorter: true,
           dataIndex: 'manufactureDate'
        },
        {
          title: '过期时间',
          align: 'center',
          sorter: true,
          dataIndex: 'expiredDtime'
        }
      ],
      columns2: [
        {
          title: '设备编号',
          align: 'center',
          sorter: true,
          dataIndex: 'deviceNo'
        },
        {
          title: 'Sim卡类型',
          align: 'center',
          sorter: true,
          dataIndex: 'simType',
          scopedSlots: { customRender: 'simTypescopedSlots' }
        },
        {
          title: '卡号',
          align: 'center',
          sorter: true,
          dataIndex: 'cardNo'
        },
        {
          title: 'ICCID',
          align: 'center',
          sorter: true,
          dataIndex: 'iCCID'
        },
        {
          title: '卡状态',
          align: 'center',
          sorter: true,
          dataIndex: 'simStatus',
          scopedSlots: { customRender: 'simStatusscopedSlots' }
        },
        {
          title: '激活时间',
          align: 'center',
          sorter: true,
          dataIndex: 'activationDtime'
        },
        {
          title: '过期时间',
          align: 'center',
          sorter: true,
          dataIndex: 'expiredDtime'
        },
        {
          title: '年费',
          align: 'center',
          sorter: true,
          dataIndex: 'annualFee'
        }
      ],

      columns3: [
        {
          title: '设备编号',
          align: 'center',
          sorter: true,
          dataIndex: 'deviceNo'
        },
        {
          title: '总里程数(公里)',
          align: 'center',
          sorter: true,
          dataIndex: 'sumMileCount'
        },
        {
          title: '油耗(公里/升)',
          align: 'center',
          sorter: true,
          dataIndex: 'dayMiles'
        },
        {
          title: '当日里程（公里）',
          align: 'center',
          sorter: true,
          dataIndex: 'curDayMileCount'
        },
        {
          title: '当月里程（公里）',
          align: 'center',
          sorter: true,
          dataIndex: 'curMonMileCount'
        },
         {
          title: '当年里程（公里）',
          align: 'center',
          sorter: true,
          dataIndex: 'curYearMileCount'
        },
        {
          title: '定位时间',
          align: 'center',
          sorter: true,
          dataIndex: 'lastLoationDtime'
        }
      ],

      tstyle: { 'padding-bottom': '0px', 'margin-bottom': '10px' },
      // 加载数据方法 必须为 Promise 对象
      loadData: (parameter) => {
        return DeviceInfoPage(Object.assign(parameter, this.queryParam)).then((res) => {
          return res.data
        })
      },
      loadData2: (parameter) => {
        return SIMInfoPage(Object.assign(parameter, this.queryParam)).then((res) => {
          return res.data
        })
      },
      loadData3: (parameter) => {
        return MileStatisticsPagesum(Object.assign(parameter, this.queryParam)).then((res) => {
          return res.data
        })
      },
      orgTree: [],
      typeDictTypeDropDown: [],
      deviceTypeData: [],
      batteryTypeData: [],
      ownedOrgData: [],
      simTypeData: [],
      simStatusData: [],
      deviceStatusData: [],
      selectedRowKeys: [],
      selectedRows: [],
      selectedRowKeys_sim: [],
      selectedRows_sim: [],
      selectedRowKeys_mile: [],
      selectedRows_mile: [],
      defaultExpandedKeys: [],
      treeLoading: true,
      confirmLoading: false,
      simpleImage: Empty.PRESENTED_IMAGE_SIMPLE,
      replaceFields: {
        key: 'id'
      }
    }
  },
  created() {
    if (this.hasPerm('MileStatistics:edit') || this.hasPerm('MileStatistics:delete')) {
      this.columns3.push({
        title: '操作',
        width: '50px',
        dataIndex: 'action',
        scopedSlots: { customRender: 'action' }
      })
    }
    this.sysDictTypeDropDown()
    this.GetDeviceOTree()
    if (this.hasPerm('DeviceInfo:edit') || this.hasPerm('DeviceInfo:delete')) {
      this.columns.push({
        title: '操作',
        width: '50px',
        dataIndex: 'action',
        scopedSlots: { customRender: 'action' }
      })
    }
    const deviceTypeOption = this.$options
    this.deviceTypeData = deviceTypeOption.filters['dictData']('device_type')
    const deviceStatusOption = this.$options
    this.deviceStatusData = deviceStatusOption.filters['dictData']('device_loc_status')
    const simTypeDataOption = this.$options
    this.simTypeData = simTypeDataOption.filters['dictData']('sim_type')
    const simStatusDataOption = this.$options
    this.simStatusData = simStatusDataOption.filters['dictData']('sim_status')
  },
  methods: {
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
        this.$refs.table.refresh()
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

    /**
     * 获取字典数据
     */
    sysDictTypeDropDown(text) {
      sysDictTypeDropDown({
        code: 'org_type'
      }).then((res) => {
        this.typeDictTypeDropDown = res.data
      })
    },
    MileStatisticsDelete(record) {
      MileStatisticsDelete(record).then((res) => {
        if (res.success) {
          this.$message.success('删除成功')
          this.$refs.table.refresh()
        } else {
          this.$message.error('删除失败') // + res.message
        }
      })
    },
    /**
     * 查询参数组装
     */
    switchingDate() {
      const obj = JSON.parse(JSON.stringify(this.queryParam))
      return obj
    },
    DeviceInfoDelete(record) {
      DeviceInfoDelete(record).then((res) => {
        if (res.success) {
          this.$message.success('删除成功')
          this.$refs.table.refresh()
        } else {
          this.$message.error('删除失败') // + res.message
        }
      })
    },
      // 导出用户文件
      DeviceInfoExport(e) {
        this.cardLoading = true
        DeviceInfoExport().then((res) => {
          this.cardLoading = false
          this.downloadfile(res)
          // eslint-disable-next-line handle-callback-err
        }).catch((err) => {
          this.cardLoading = false
          this.$message.error('下载错误：获取文件流错误')
        })
      },
      downloadfile(res) {
        var blob = new Blob([res.data], {
          type: 'application/octet-stream;charset=UTF-8'
        })
        var contentDisposition = res.headers['content-disposition']
        var patt = new RegExp('filename=([^;]+\\.[^\\.;]+);*')
        var result = patt.exec(contentDisposition)
        var filename = result[1]
        var downloadElement = document.createElement('a')
        var href = window.URL.createObjectURL(blob) // 创建下载的链接
        var reg = /^["](.*)["]$/g
        downloadElement.style.display = 'none'
        downloadElement.href = href
        downloadElement.download = decodeURI(filename.replace(reg, '$1')) // 下载后文件名
        document.body.appendChild(downloadElement)
        downloadElement.click() // 点击下载
        document.body.removeChild(downloadElement) // 下载完成移除元素
        window.URL.revokeObjectURL(href)
      },
    /**
     * 点击左侧机构树查询列表
     */
    handleClick(e) {
      this.queryParam = {
        OwnedOrg: e.toString()
      }
      this.$refs.table.refresh(true)
      // this.$refs.table_sim.refresh(true)
      // this.$refs.table_mile.refresh(true)
    },
    toggleAdvanced() {
      this.advanced = !this.advanced
    },
     toggleAdvanced2() {
      this.advanced2 = !this.advanced2
    },
     toggleAdvanced3() {
      this.advanced3 = !this.advanced3
    },
    handleOk() {
      this.GetDeviceOTree()
      this.$refs.table.refresh()
    },
     handleOk2() {
      this.GetDeviceOTree()
      this.$refs.table.refresh()
    },
     handleOk3() {
      this.GetDeviceOTree()
      this.$refs.table.refresh()
    },
    onSelectChange(selectedRowKeys, selectedRows) {
      this.selectedRowKeys = selectedRowKeys
      this.selectedRows = selectedRows
    },
     onSelectChange_sim(selectedRowKeys, selectedRows) {
      this.selectedRowKeys_sim = selectedRowKeys
      this.selectedRows_sim = selectedRows
    },
     onSelectChange_mile(selectedRowKeys, selectedRows) {
      this.selectedRowKeys_mile = selectedRowKeys
      this.selectedRows_mile = selectedRows
    },
    SIMInfoDelete(record) {
      SIMInfoDelete(record).then((res) => {
        if (res.success) {
          this.$message.success('删除成功')
          this.$refs.table.refresh()
        } else {
          this.$message.error('删除失败') // + res.message
        }
      })
    }
  }
}
</script>
<style lang="less">
.table-operator {
  margin-bottom: 18px;
}
button {
  margin-right: 8px;
}
</style>
