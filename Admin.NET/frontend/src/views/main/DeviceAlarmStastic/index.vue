<template>
  <div>
    <a-card :bordered="false" :bodyStyle="tstyle">

      <div class="table-page-search-wrapper" v-if="hasPerm('DeviceAlarmStastic:page')">
        <a-form layout="inline">
          <a-row :gutter="48">
            <a-col :md="8" :sm="24">
              <a-form-item label="设备编号">
                <a-input v-model="queryParam.deviceNo" allow-clear placeholder="请输入设备编号"/>
              </a-form-item>
            </a-col>
            <a-col :md="8" :sm="24">
              <a-form-item label="所属门店">
                <a-input v-model="queryParam.ownedOrg" allow-clear placeholder="请输入所属门店"/>
              </a-form-item>
            </a-col><template v-if="advanced">
              <a-col :md="8" :sm="24">
                <a-form-item label="报表日期">
                  <a-input v-model="queryParam.reportDate" allow-clear placeholder="请输入报表日期"/>
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
        <template class="table-operator" slot="operator" v-if="hasPerm('DeviceAlarmStastic:add')" >
          <a-button type="primary" v-if="hasPerm('DeviceAlarmStastic:add')" icon="plus" @click="$refs.addForm.add()">导出</a-button>
        </template>
        <span slot="action" slot-scope="text, record">
          <a v-if="hasPerm('DeviceAlarmStastic:edit')" @click="$refs.editForm.edit(record)">编辑</a>
          <a-divider type="vertical" v-if="hasPerm('DeviceAlarmStastic:edit') & hasPerm('DeviceAlarmStastic:delete')"/>
          <a-popconfirm v-if="hasPerm('DeviceAlarmStastic:delete')" placement="topRight" title="确认删除？" @confirm="() => DeviceAlarmStasticDelete(record)">
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
  import { DeviceAlarmStasticPage, DeviceAlarmStasticDelete } from '@/api/modular/main/DeviceAlarmStasticManage'
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
            title: '设备名称',
            align: 'center',
sorter: true,
            dataIndex: 'deviceName'
          },
          {
            title: '所属门店',
            align: 'center',
sorter: true,
            dataIndex: 'ownedOrg'
          },
          {
            title: '报表日期',
            align: 'center',
sorter: true,
            dataIndex: 'reportDate'
          },
          {
            title: '出围栏报警',
            align: 'center',
sorter: true,
            dataIndex: 'alarm1'
          },
          {
            title: '入围栏报警',
            align: 'center',
sorter: true,
            dataIndex: 'alarm2'
          },
          {
            title: '断电报警',
            align: 'center',
sorter: true,
            dataIndex: 'alarm3'
          },
          {
            title: '低电报警',
            align: 'center',
sorter: true,
            dataIndex: 'alarm4'
          },
          {
            title: '震动报警',
            align: 'center',
sorter: true,
            dataIndex: 'alarm5'
          },
          {
            title: '位移报警',
            align: 'center',
sorter: true,
            dataIndex: 'alarm6'
          },
          {
            title: '点火报警',
            align: 'center',
sorter: true,
            dataIndex: 'alarm7'
          },
          {
            title: '侧翻报警',
            align: 'center',
sorter: true,
            dataIndex: 'alarm8'
          },
          {
            title: '拆卸报警',
            align: 'center',
sorter: true,
            dataIndex: 'alarm9'
          }
        ],
        tstyle: { 'padding-bottom': '0px', 'margin-bottom': '10px' },
        // 加载数据方法 必须为 Promise 对象
        loadData: parameter => {
          return DeviceAlarmStasticPage(Object.assign(parameter, this.queryParam)).then((res) => {
            return res.data
          })
        },
        selectedRowKeys: [],
        selectedRows: []
      }
    },
    created () {
      if (this.hasPerm('DeviceAlarmStastic:edit') || this.hasPerm('DeviceAlarmStastic:delete')) {
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
      DeviceAlarmStasticDelete (record) {
        DeviceAlarmStasticDelete(record).then((res) => {
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
