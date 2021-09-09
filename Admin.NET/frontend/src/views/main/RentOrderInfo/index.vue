<template>
  <div>
    <a-card :bordered="false" :bodyStyle="tstyle">

      <div class="table-page-search-wrapper" v-if="hasPerm('RentOrderInfo:page')">
        <a-form layout="inline">
          <a-row :gutter="48">
            <a-col :md="8" :sm="24">
              <a-form-item label="订单号">
                <a-input v-model="queryParam.orderNo" allow-clear placeholder="请输入订单号"/>
              </a-form-item>
            </a-col>
            <a-col :md="8" :sm="24">
              <a-form-item label="所属门店">
                <a-input v-model="queryParam.ownedOrg" allow-clear placeholder="请输入所属门店"/>
              </a-form-item>
            </a-col><template v-if="advanced">
              <a-col :md="8" :sm="24">
                <a-form-item label="设备编号">
                  <a-input v-model="queryParam.deviceNo" allow-clear placeholder="请输入设备编号"/>
                </a-form-item>
              </a-col>
              <a-col :md="8" :sm="24">
                <a-form-item label="租赁用户">
                  <a-input v-model="queryParam.rentUser" allow-clear placeholder="请输入租赁用户"/>
                </a-form-item>
              </a-col>
              <a-col :md="8" :sm="24">
                <a-form-item label="订单创建时间">
                  <a-input v-model="queryParam.orderCreateDtime" allow-clear placeholder="请输入订单创建时间"/>
                </a-form-item>
              </a-col>
              <a-col :md="8" :sm="24">
                <a-form-item label="支付类型">
                  <a-input v-model="queryParam.payType" allow-clear placeholder="请输入支付类型"/>
                </a-form-item>
              </a-col>
              <a-col :md="8" :sm="24">
                <a-form-item label="支付状态">
                  <a-input v-model="queryParam.payStatus" allow-clear placeholder="请输入支付状态"/>
                </a-form-item>
              </a-col>
              <a-col :md="8" :sm="24">
                <a-form-item label="分佣状态">
                  <a-input v-model="queryParam.subCommissionStatus" allow-clear placeholder="请输入分佣状态"/>
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
        <template class="table-operator" slot="operator" v-if="hasPerm('RentOrderInfo:add')" >
          <a-button type="primary" v-if="hasPerm('RentOrderInfo:add')" icon="down" @click="$refs.addForm.add()">导出</a-button>
        </template>
        <span slot="action" slot-scope="text, record">
          <a v-if="hasPerm('RentOrderInfo:edit')" @click="$refs.editForm.edit(record)">编辑</a>
          <a-divider type="vertical" v-if="hasPerm('RentOrderInfo:edit') & hasPerm('RentOrderInfo:delete')"/>
          <a-popconfirm v-if="hasPerm('RentOrderInfo:delete')" placement="topRight" title="确认删除？" @confirm="() => RentOrderInfoDelete(record)">
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
  import { RentOrderInfoPage, RentOrderInfoDelete } from '@/api/modular/main/RentOrderInfoManage'
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
            title: '订单号',
            align: 'center',
sorter: true,
            dataIndex: 'orderNo'
          },
          {
            title: '所属门店',
            align: 'center',
sorter: true,
            dataIndex: 'ownedOrg'
          },
          {
            title: '设备编号',
            align: 'center',
sorter: true,
            dataIndex: 'deviceNo'
          },
          {
            title: '租赁价格',
            align: 'center',
sorter: true,
            dataIndex: 'rentPrice'
          },
          {
            title: '租赁时长',
            align: 'center',
sorter: true,
            dataIndex: 'rentTime'
          },
          {
            title: '租赁金额',
            align: 'center',
sorter: true,
            dataIndex: 'rentAmount'
          },
          {
            title: '应付金额',
            align: 'center',
sorter: true,
            dataIndex: 'pRAmmount'
          },
          {
            title: '实收金额',
            align: 'center',
sorter: true,
            dataIndex: 'aRAmount'
          },
          {
            title: '租赁用户',
            align: 'center',
sorter: true,
            dataIndex: 'rentUser'
          },
          {
            title: '订单创建时间',
            align: 'center',
sorter: true,
            dataIndex: 'orderCreateDtime'
          },
          {
            title: '付款时间',
            align: 'center',
sorter: true,
            dataIndex: 'payDtime'
          },
          {
            title: '设备解绑时间',
            align: 'center',
sorter: true,
            dataIndex: 'disAssignDtime'
          },
          {
            title: '支付状态',
            align: 'center',
sorter: true,
            dataIndex: 'payStatus'
          },
          {
            title: '分佣状态',
            align: 'center',
sorter: true,
            dataIndex: 'subCommissionStatus'
          }
        ],
        tstyle: { 'padding-bottom': '0px', 'margin-bottom': '10px' },
        // 加载数据方法 必须为 Promise 对象
        loadData: parameter => {
          return RentOrderInfoPage(Object.assign(parameter, this.queryParam)).then((res) => {
            return res.data
          })
        },
        selectedRowKeys: [],
        selectedRows: []
      }
    },
    created () {
      if (this.hasPerm('RentOrderInfo:edit') || this.hasPerm('RentOrderInfo:delete')) {
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
      RentOrderInfoDelete (record) {
        RentOrderInfoDelete(record).then((res) => {
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
