<template>
 <a-row :gutter="24">
    <a-col :md="5" :sm="24" style="padding: 0 0 0 0;">
      <a-card :bordered="false" :loading="treeLoading" >
        <div v-if="this.orgTree != ''">
          <a-tree
            :treeData="orgTree"
            v-if="orgTree.length"
            @select="handleClick"
            :defaultExpandAll="true"
            :defaultExpandedKeys="defaultExpandedKeys"
            :replaceFields="replaceFields" />
        </div>
        <div v-else>
          <a-empty :image="simpleImage" />
        </div>
      </a-card>
    </a-col>
    <a-col :md="19" :sm="24">
      <a-spin :spinning="confirmLoading">
       <a-tabs default-active-key="1">
        <a-tab-pane key="1" tab="设备" >
          <div>
          <a-card :bordered="false" :bodyStyle="tstyle">
        <div class="table-page-search-wrapper" v-if="hasPerm('DeviceInfo:page')">
        <a-form layout="inline">
          <a-row :gutter="48">
            <a-col :md="8" :sm="24">
              <a-form-item label="设备名称">
                <a-input v-model="queryParam.deviceName" allow-clear placeholder="请输入设备名称"/>
              </a-form-item>
            </a-col>
            <a-col :md="8" :sm="24">
              <a-form-item label="设备编号">
                <a-input v-model="queryParam.deviceNo" allow-clear placeholder="请输入设备编号"/>
              </a-form-item>
            </a-col><template v-if="advanced"><a-col :md="8" :sm="24">
                <a-form-item label="类型">
                  <a-select :allowClear="true" style="width: 100%" v-model="queryParam.deviceType" placeholder="请选择类型">
                    <a-select-option v-for="(item,index) in deviceTypeData" :key="index" :value="item.code">{{ item.name }}</a-select-option>
                  </a-select>
                </a-form-item>
              </a-col><a-col :md="8" :sm="24">
                <a-form-item label="电芯">
                  <a-select :allowClear="true" style="width: 100%" v-model="queryParam.batteryType" placeholder="请选择电芯">
                    <a-select-option v-for="(item,index) in batteryTypeData" :key="index" :value="item.code">{{ item.name }}</a-select-option>
                  </a-select>
                </a-form-item>
              </a-col><a-col :md="8" :sm="24">
                <a-form-item label="所属门店">
                  <a-select :allowClear="true" style="width: 100%" v-model="queryParam.ownedOrg" placeholder="请选择所属门店">
                    <a-select-option v-for="(item,index) in ownedOrgData" :key="index" :value="item.code">{{ item.name }}</a-select-option>
                  </a-select>
                </a-form-item>
              </a-col><a-col :md="8" :sm="24">
                <a-form-item label="设备状态">
                  <a-select :allowClear="true" style="width: 100%" v-model="queryParam.deviceStatus" placeholder="请选择设备状态">
                    <a-select-option v-for="(item,index) in deviceStatusData" :key="index" :value="item.code">{{ item.name }}</a-select-option>
                  </a-select>
                </a-form-item>
              </a-col>            </template>

            <a-col :md="8" :sm="24" >
              <span class="table-page-search-submitButtons">
                <a-button type="primary" @click="$refs.table.refresh(true)" >查询</a-button>
                <a-button style="margin-left: 8px" @click="() => queryParam = {}">重置</a-button>
                <a @click="toggleAdvanced" style="margin-left: 8px"> {{ advanced ? '收起' : '展开' }}
                  <a-icon :type="advanced ? 'up' : 'down'"/>
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
        :rowSelection="{ selectedRowKeys: selectedRowKeys, onChange: onSelectChange }">
        <template class="table-operator" slot="operator" v-if="hasPerm('DeviceInfo:add')" >
          <a-button type="primary" v-if="hasPerm('DeviceInfo:add')" icon="retweet" @click="$refs.addForm.add()">批量转移</a-button>
           <a-button type="primary" v-if="hasPerm('DeviceInfo:add')" icon="edit" @click="$refs.addForm.add()">批量修改</a-button>
            <a-button type="primary" v-if="hasPerm('DeviceInfo:add')" icon="enter" @click="$refs.addForm.add()">指令群发</a-button>
             <a-button type="primary" v-if="hasPerm('DeviceInfo:add')" icon="down" @click="$refs.addForm.add()">导出</a-button>
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
          {{ 'device_status' | dictType(text) }}
        </span>
        <span slot="action" slot-scope="text, record">
          <a v-if="hasPerm('DeviceInfo:edit')" @click="$refs.editForm.edit(record)">编辑</a>
          <a-divider type="vertical" v-if="hasPerm('DeviceInfo:edit') & hasPerm('DeviceInfo:delete')"/>
          <a-popconfirm v-if="hasPerm('DeviceInfo:delete')" placement="topRight" title="确认删除？" @confirm="() => DeviceInfoDelete(record)">
            <a>删除</a>
          </a-popconfirm>
        </span>
      </s-table>
      <add-form ref="addForm" @ok="handleOk" />
      <edit-form ref="editForm" @ok="handleOk" />
        </a-card>
          </div>
        </a-tab-pane>
        <a-tab-pane key ="2" tab ="SIM">
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
                  <a-select-option v-for="(item, index) in simTypeData" :key="index" :value="item.code">{{
                    item.name
                  }}</a-select-option>
                </a-select>
              </a-form-item> </a-col
            ><template v-if="advanced"
              ><a-col :md="8" :sm="24">
                <a-form-item label="卡状态">
                  <a-select
                    :allowClear="true"
                    style="width: 100%"
                    v-model="queryParam.simStatus"
                    placeholder="请选择卡状态"
                  >
                    <a-select-option v-for="(item, index) in simStatusData" :key="index" :value="item.code">{{
                      item.name
                    }}</a-select-option>
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
        :columns="columns2"
        :data="loadData2"
        :alert="true"
        :rowKey="(record) => record.id"
        :rowSelection="{ selectedRowKeys: selectedRowKeys, onChange: onSelectChange }"
      >
        <template class="table-operator" slot="operator" v-if="hasPerm('SIMInfo:add')">
          <a-button type="primary" v-if="hasPerm('SIMInfo:add')" icon="credit-card" @click="$refs.addForm.add()"
            >批量充值</a-button>
<a-button type="primary" v-if="hasPerm('SIMInfo:add')" icon="edit" @click="$refs.addForm.add()"
            >批量修改</a-button>

        </template>
        <span slot="simTypescopedSlots" slot-scope="text">
          {{ 'common_status' | dictType(text) }}
        </span>
        <span slot="simStatusscopedSlots" slot-scope="text">
          {{ 'common_status' | dictType(text) }}
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
      <add-form ref="addForm" @ok="handleOk" />
      <edit-form ref="editForm" @ok="handleOk" />
    </a-card>
            </div>
        </a-tab-pane>
           <a-tab-pane key ="3" tab ="里程">
               <div>
    <a-card :bordered="false" :bodyStyle="tstyle">

      <div class="table-page-search-wrapper" v-if="hasPerm('MileStatistics:page')">
        <a-form layout="inline">
          <a-row :gutter="48">
            <a-col :md="8" :sm="24">
              <a-form-item label="设备编号">
                <a-input v-model="queryParam.deviceNo" allow-clear placeholder="请输入设备编号"/>
              </a-form-item>
            </a-col>
            <a-col :md="8" :sm="24">
              <a-form-item label="统计日期">
                <a-input v-model="queryParam.sdate" allow-clear placeholder="请输入统计日期"/>
              </a-form-item>
            </a-col><template v-if="advanced">
             
              <a-col :md="8" :sm="24">
                <a-form-item label="最后更新时间">
                  <a-input v-model="queryParam.lastLocationDtime" allow-clear placeholder="请输入最后更新时间"/>
                </a-form-item>
              </a-col>
                </template>

            <a-col :md="8" :sm="24" >
              <span class="table-page-search-submitButtons">
                <a-button type="primary" @click="$refs.table.refresh(true)" >查询</a-button>
                <a-button style="margin-left: 8px" @click="() => queryParam = {}">重置</a-button>
                <a @click="toggleAdvanced" style="margin-left: 8px"> {{ advanced ? '收起' : '展开' }}
                  <a-icon :type="advanced ? 'up' : 'down'"/>
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
        :rowSelection="{ selectedRowKeys: selectedRowKeys, onChange: onSelectChange }">
        
        <span slot="action" slot-scope="text, record">
          <a v-if="hasPerm('MileStatistics:edit')" @click="$refs.editForm.edit(record)">编辑</a>
          <a-divider type="vertical" v-if="hasPerm('MileStatistics:edit') & hasPerm('MileStatistics:delete')"/>
          <a-popconfirm v-if="hasPerm('MileStatistics:delete')" placement="topRight" title="确认删除？" @confirm="() => MileStatisticsDelete(record)">
            <a>删除</a>
          </a-popconfirm>
        </span>
      </s-table>
      <add-form ref="addForm" @ok="handleOk" />
      <edit-form ref="editForm" @ok="handleOk" />
    </a-card>
  </div>
          </a-tab-pane>
           <a-tab-pane key ="4" tab ="下级客户">

          </a-tab-pane>
           <a-tab-pane key ="5" tab ="到期提醒">

          </a-tab-pane>
       </a-tabs>

    </a-spin>
   </a-col>
 </a-row>
</template>
<script>
import { STable } from '@/components'
import { DeviceInfoPage, DeviceInfoDelete } from '@/api/modular/main/DeviceInfoManage'
import addForm from './addForm.vue'
import editForm from './editForm.vue'
import {
    Empty
} from 'ant-design-vue'
import { getOrgTree } from '@/api/modular/system/orgManage'
import { SIMInfoPage, SIMInfoDelete } from '@/api/modular/main/SIMInfoManage'
import { MileStatisticsPage, MileStatisticsDelete } from '@/api/modular/main/MileStatisticsManage'
export default {
  components: {
    STable,
    addForm,
    editForm,
  },
  data() {
    return {
      advanced: false, // 高级搜索 展开/关闭
      queryParam: {},
      columns: [
        {
          title: '设备名称',
          align: 'center',
          sorter: true,
          dataIndex: 'deviceName',
        },
        {
          title: '设备编号',
          align: 'center',
          sorter: true,
          dataIndex: 'deviceNo',
        },
        {
          title: '类型',
          align: 'center',
          sorter: true,
          dataIndex: 'deviceType',
          scopedSlots: { customRender: 'deviceTypescopedSlots' },
        },
        {
          title: '型号',
          align: 'center',
          sorter: true,
          dataIndex: 'dModel',
          scopedSlots: { customRender: 'dModelscopedSlots' },
        },
       
        
        {
          title: '设备状态',
          align: 'center',
          sorter: true,
          dataIndex: 'deviceStatus',
          scopedSlots: { customRender: 'deviceStatusscopedSlots' },
        },
        
        {
          title: '最后定位日期',
          align: 'center',
          sorter: true,
          dataIndex: 'lastLoationDtime',
        },
       
      
        {
          title: '过期时间',
          align: 'center',
          sorter: true,
          dataIndex: 'expiredDtime',
        },
       
       
      ],
      columns2: [
        {
          title: '设备编号',
          align: 'center',
          sorter: true,
          dataIndex: 'deviceNo',
        },
        {
          title: 'Sim卡类型',
          align: 'center',
          sorter: true,
          dataIndex: 'simType',
          scopedSlots: { customRender: 'simTypescopedSlots' },
        },
        {
          title: '卡号',
          align: 'center',
          sorter: true,
          dataIndex: 'cardNo',
        },
        {
          title: 'ICCID',
          align: 'center',
          sorter: true,
          dataIndex: 'iCCID',
        },
        {
          title: '卡状态',
          align: 'center',
          sorter: true,
          dataIndex: 'simStatus',
          scopedSlots: { customRender: 'simStatusscopedSlots' },
        },
        {
          title: '激活时间',
          align: 'center',
          sorter: true,
          dataIndex: 'activationDtime',
        },
        {
          title: '过期时间',
          align: 'center',
          sorter: true,
          dataIndex: 'expiredDtime',
        },
        {
          title: '年费',
          align: 'center',
          sorter: true,
          dataIndex: 'annualFee',
        },
       
       
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
            dataIndex: 'sdate'
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
            dataIndex: 'mileUnit'
          },
          
          {
            title: '定位时间',
            align: 'center',
sorter: true,
            dataIndex: 'lastLocationDtime'
          },
        
         
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
       loadData3: parameter => {
          return MileStatisticsPage(Object.assign(parameter, this.queryParam)).then((res) => {
            return res.data
          })
        },
      orgTree: [],
      deviceTypeData: [],
      batteryTypeData: [],
      ownedOrgData: [],
      deviceStatusData: [],
      selectedRowKeys: [],
      selectedRows: [],
      treeLoading: true,
      confirmLoading: false,
      simpleImage: Empty.PRESENTED_IMAGE_SIMPLE,
      replaceFields: {
        key: 'id',
      },
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
    getOrgTree(Object.assign(this.queryParam)).then((res) => {
      this.treeLoading = false
      if (!res.success) {
        return
      }
      this.orgTree = res.data
      for (var item of res.data) {
        // eslint-disable-next-line eqeqeq
        if (item.parentId == 0) {
          this.defaultExpandedKeys.push(item.id)
        }
      }
    })
    if (this.hasPerm('DeviceInfo:edit') || this.hasPerm('DeviceInfo:delete')) {
      this.columns.push({
        title: '操作',
        width: '50px',
        dataIndex: 'action',
        scopedSlots: { customRender: 'action' },
      })
    }
    const deviceTypeOption = this.$options
    this.deviceTypeData = deviceTypeOption.filters['dictData']('device_type')
    const batteryTypeOption = this.$options
    this.batteryTypeData = batteryTypeOption.filters['dictData']('Battery_Type')
    const ownedOrgOption = this.$options
    this.ownedOrgData = ownedOrgOption.filters['dictData']('org_type')
    const deviceStatusOption = this.$options
    this.deviceStatusData = deviceStatusOption.filters['dictData']('device_status')
  },
  methods: {
    MileStatisticsDelete (record) {
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
    /**
     * 点击左侧机构树查询列表
     */
    handleClick(e) {
      this.queryParam = {
        'sysEmpParam.orgId': e.toString(),
      }
      this.$refs.table.refresh(true)
    },
    toggleAdvanced() {
      this.advanced = !this.advanced
    },
    handleOk() {
      this.$refs.table.refresh()
    },
    onSelectChange(selectedRowKeys, selectedRows) {
      this.selectedRowKeys = selectedRowKeys
      this.selectedRows = selectedRows
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
    },
    
  },
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
