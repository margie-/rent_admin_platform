<template>
  <div>
    <a-card :bordered="false" :bodyStyle="tstyle">

      <div class="table-page-search-wrapper" v-if="hasPerm('ContractList:page')">
        <a-form layout="inline">
          <a-row :gutter="48">
            <a-col :md="8" :sm="24">
              <a-form-item label="合同名称">
                <a-input v-model="queryParam.contractName" allow-clear placeholder="请输入合同名称"/>
              </a-form-item>
            </a-col>
            <a-col :md="8" :sm="24">
              <a-form-item label="合同内容">
                <a-input v-model="queryParam.contractDetails" allow-clear placeholder="请输入合同内容"/>
              </a-form-item>
            </a-col><a-col :md="8" :sm="24">
              <span class="table-page-search-submitButtons">
                <a-button type="primary" @click="$refs.table.refresh(true)">查询</a-button>
                <a-button style="margin-left: 8px" @click="() => queryParam = {}">重置</a-button>
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
        <template class="table-operator" slot="operator" v-if="hasPerm('ContractList:add')" >
          <a-button type="primary" v-if="hasPerm('ContractList:add')" icon="plus" @click="$refs.addForm.add()">新增合同</a-button>
        </template>
        <span slot="action" slot-scope="text, record">
          <a v-if="hasPerm('ContractList:edit')" @click="$refs.editForm.edit(record)">编辑</a>
          <a-divider type="vertical" v-if="hasPerm('ContractList:edit') & hasPerm('ContractList:delete')"/>
          <a-popconfirm v-if="hasPerm('ContractList:delete')" placement="topRight" title="确认删除？" @confirm="() => ContractListDelete(record)">
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
  import { ContractListPage, ContractListDelete } from '@/api/modular/main/ContractListManage'
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
        queryParam: {},
        columns: [
          {
            title: '合同名称',
            align: 'center',
sorter: true,
            dataIndex: 'contractName'
          },
          {
            title: '合同内容',
            align: 'center',
sorter: true,
            dataIndex: 'contractDetails'
          },
          {
            title: '备注',
            align: 'center',
sorter: true,
            dataIndex: 'contractNote'
          },
          {
            title: '是否展示给用户',
            align: 'center',
sorter: true,
            dataIndex: 'isShowToUser'
          }
        ],
        tstyle: { 'padding-bottom': '0px', 'margin-bottom': '10px' },
        // 加载数据方法 必须为 Promise 对象
        loadData: parameter => {
          return ContractListPage(Object.assign(parameter, this.queryParam)).then((res) => {
            return res.data
          })
        },
        selectedRowKeys: [],
        selectedRows: []
      }
    },
    created () {
      if (this.hasPerm('ContractList:edit') || this.hasPerm('ContractList:delete')) {
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
      ContractListDelete (record) {
        ContractListDelete(record).then((res) => {
          if (res.success) {
            this.$message.success('删除成功')
            this.$refs.table.refresh()
          } else {
            this.$message.error('删除失败') // + res.message
          }
        })
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
