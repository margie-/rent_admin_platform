<template>
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
                <a-form-item label="日里程数">
                  <a-input v-model="queryParam.dayMiles" allow-clear placeholder="请输入日里程数"/>
                </a-form-item>
              </a-col>
              <a-col :md="8" :sm="24">
                <a-form-item label="里程单位">
                  <a-input v-model="queryParam.mileUnit" allow-clear placeholder="请输入里程单位"/>
                </a-form-item>
              </a-col>
              <a-col :md="8" :sm="24">
                <a-form-item label="当日油耗">
                  <a-input v-model="queryParam.dayUsedOil" allow-clear placeholder="请输入当日油耗"/>
                </a-form-item>
              </a-col>
              <a-col :md="8" :sm="24">
                <a-form-item label="油耗单位">
                  <a-input v-model="queryParam.oilUnit" allow-clear placeholder="请输入油耗单位"/>
                </a-form-item>
              </a-col>
              <a-col :md="8" :sm="24">
                <a-form-item label="最后更新时间">
                  <a-input v-model="queryParam.lastLocationDtime" allow-clear placeholder="请输入最后更新时间"/>
                </a-form-item>
              </a-col>
              <a-col :md="8" :sm="24">
                <a-form-item label="行驶时间">
                  <a-input v-model="queryParam.driverTimes" allow-clear placeholder="请输入行驶时间"/>
                </a-form-item>
              </a-col>
              <a-col :md="8" :sm="24">
                <a-form-item label="平均速度">
                  <a-input v-model="queryParam.avgSpeed" allow-clear placeholder="请输入平均速度"/>
                </a-form-item>
              </a-col>
              <a-col :md="8" :sm="24">
                <a-form-item label="最大速度">
                  <a-input v-model="queryParam.maxSpeed" allow-clear placeholder="请输入最大速度"/>
                </a-form-item>
              </a-col>
              <a-col :md="8" :sm="24">
                <a-form-item label="GPS里程数">
                  <a-input v-model="queryParam.gPSMiles" allow-clear placeholder="请输入GPS里程数"/>
                </a-form-item>
              </a-col>
              <a-col :md="8" :sm="24">
                <a-form-item label="租户id">
                  <a-input v-model="queryParam.tenantId" allow-clear placeholder="请输入租户id"/>
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
        <template class="table-operator" slot="operator" v-if="hasPerm('MileStatistics:add')" >
          <a-button type="primary" v-if="hasPerm('MileStatistics:add')" icon="down" @click="$refs.addForm.add()">导出</a-button>
        </template>
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
</template>
<script>
  import { STable } from '@/components'
  import { MileStatisticsPage, MileStatisticsDelete } from '@/api/modular/main/MileStatisticsManage'
  import addForm from './addForm.vue'
  import editForm from './editForm.vue'
  export default {
    components: {
      STable,
      addForm,
      editForm
    },
    data () {
      return {
        advanced: false, // 高级搜索 展开/关闭
        queryParam: {},
        columns: [
          {
            title: '设备编号',
            align: 'center',
sorter: true,
            dataIndex: 'deviceNo'
          },
          {
            title: '统计日期',
            align: 'center',
sorter: true,
            dataIndex: 'sdate'
          },
          {
            title: '日里程数',
            align: 'center',
sorter: true,
            dataIndex: 'dayMiles'
          },
          {
            title: '里程单位',
            align: 'center',
sorter: true,
            dataIndex: 'mileUnit'
          },
          {
            title: '当日油耗',
            align: 'center',
sorter: true,
            dataIndex: 'dayUsedOil'
          },
          {
            title: '油耗单位',
            align: 'center',
sorter: true,
            dataIndex: 'oilUnit'
          },
          {
            title: '最后更新时间',
            align: 'center',
sorter: true,
            dataIndex: 'lastLocationDtime'
          },
          {
            title: '行驶时间',
            align: 'center',
sorter: true,
            dataIndex: 'driverTimes'
          },
          {
            title: '平均速度',
            align: 'center',
sorter: true,
            dataIndex: 'avgSpeed'
          },
          {
            title: '最大速度',
            align: 'center',
sorter: true,
            dataIndex: 'maxSpeed'
          },
          {
            title: 'GPS里程数',
            align: 'center',
sorter: true,
            dataIndex: 'gPSMiles'
          },
          {
            title: '租户id',
            align: 'center',
sorter: true,
            dataIndex: 'tenantId'
          }
        ],
        tstyle: { 'padding-bottom': '0px', 'margin-bottom': '10px' },
        // 加载数据方法 必须为 Promise 对象
        loadData: parameter => {
          return MileStatisticsPage(Object.assign(parameter, this.queryParam)).then((res) => {
            return res.data
          })
        },
        selectedRowKeys: [],
        selectedRows: []
      }
    },
    created () {
      if (this.hasPerm('MileStatistics:edit') || this.hasPerm('MileStatistics:delete')) {
        this.columns.push({
          title: '操作',
          width: '150px',
          dataIndex: 'action',
          scopedSlots: { customRender: 'action' }
        })
      }
    },
    methods: {
      /**
       * 查询参数组装
       */
      switchingDate () {
        const obj = JSON.parse(JSON.stringify(this.queryParam))
        return obj
      },
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
      toggleAdvanced () {
        this.advanced = !this.advanced
      },
      handleOk () {
        this.$refs.table.refresh()
      },
      onSelectChange (selectedRowKeys, selectedRows) {
        this.selectedRowKeys = selectedRowKeys
        this.selectedRows = selectedRows
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
