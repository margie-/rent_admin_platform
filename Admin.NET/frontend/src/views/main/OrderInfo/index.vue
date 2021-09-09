<template>
  <div>
    <a-card :bordered="false" :bodyStyle="tstyle">

      <div class="table-page-search-wrapper" v-if="hasPerm('OrderInfo:page')">
        <a-form layout="inline">
          <a-row :gutter="48">
            <a-col :md="8" :sm="24">
              <a-form-item label="订单编号">
                <a-input v-model="queryParam.orderNo" allow-clear placeholder="请输入订单编号"/>
              </a-form-item>
            </a-col>
            <a-col :md="8" :sm="24">
              <a-form-item label="设备编号">
                <a-input v-model="queryParam.deviceNo" allow-clear placeholder="请输入设备编号"/>
              </a-form-item>
            </a-col><template v-if="advanced">
              <a-col :md="8" :sm="24">
                <a-form-item label="商家">
                  <a-input v-model="queryParam.vendor" allow-clear placeholder="请输入商家"/>
                </a-form-item>
              </a-col>
              <a-col :md="8" :sm="24">
                <a-form-item label="用户">
                  <a-input v-model="queryParam.user" allow-clear placeholder="请输入用户"/>
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
        <template class="table-operator" slot="operator" v-if="hasPerm('OrderInfo:add')" >
          <a-button type="primary" v-if="hasPerm('OrderInfo:add')" icon="plus" @click="$refs.addForm.add()">新增续费记录</a-button>
        </template>
        <span slot="action" slot-scope="text, record">
          <a v-if="hasPerm('OrderInfo:edit')" @click="$refs.editForm.edit(record)">编辑</a>
          <a-divider type="vertical" v-if="hasPerm('OrderInfo:edit') & hasPerm('OrderInfo:delete')"/>
          <a-popconfirm v-if="hasPerm('OrderInfo:delete')" placement="topRight" title="确认删除？" @confirm="() => OrderInfoDelete(record)">
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
  import { OrderInfoPage, OrderInfoDelete } from '@/api/modular/main/OrderInfoManage'
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
            title: '订单编号',
            align: 'center',
sorter: true,
            dataIndex: 'orderNo'
          },
          {
            title: '设备编号',
            align: 'center',
sorter: true,
            dataIndex: 'deviceNo'
          },
          {
            title: '商家',
            align: 'center',
sorter: true,
            dataIndex: 'vendor'
          },
          {
            title: '用户',
            align: 'center',
sorter: true,
            dataIndex: 'user'
          },
          {
            title: '卡号',
            align: 'center',
sorter: true,
            dataIndex: 'cardId'
          },
          {
            title: 'ICCID',
            align: 'center',
sorter: true,
            dataIndex: 'iCCID'
          },
          {
            title: '付款账户',
            align: 'center',
sorter: true,
            dataIndex: 'payAccount'
          },
          {
            title: '金额',
            align: 'center',
sorter: true,
            dataIndex: 'payAmount'
          },
          {
            title: '发生时间',
            align: 'center',
sorter: true,
            dataIndex: 'payDtime'
          }
        ],
        tstyle: { 'padding-bottom': '0px', 'margin-bottom': '10px' },
        // 加载数据方法 必须为 Promise 对象
        loadData: parameter => {
          return OrderInfoPage(Object.assign(parameter, this.queryParam)).then((res) => {
            return res.data
          })
        },
        selectedRowKeys: [],
        selectedRows: []
      }
    },
    created () {
      if (this.hasPerm('OrderInfo:edit') || this.hasPerm('OrderInfo:delete')) {
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
      OrderInfoDelete (record) {
        OrderInfoDelete(record).then((res) => {
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
