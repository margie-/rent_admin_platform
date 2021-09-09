<template>
  <div>
    <a-card :bordered="false" :bodyStyle="tstyle">

      <div class="table-page-search-wrapper" v-if="hasPerm('ReturnList:page')">
        <a-form layout="inline">
          <a-row :gutter="48">
            <a-col :md="8" :sm="24">
              <a-form-item label="退款单号">
                <a-input v-model="queryParam.returnNo" allow-clear placeholder="请输入退款单号"/>
              </a-form-item>
            </a-col>
            <a-col :md="8" :sm="24">
              <a-form-item label="订单号">
                <a-input v-model="queryParam.orderNo" allow-clear placeholder="请输入订单号"/>
              </a-form-item>
            </a-col><template v-if="advanced"><a-col :md="8" :sm="24">
                <a-form-item label="所属门店">
                  <a-select :allowClear="true" style="width: 100%" v-model="queryParam.ownedOrg" placeholder="请选择所属门店">
                    <a-select-option v-for="(item,index) in ownedOrgData" :key="index" :value="item.code">{{ item.name }}</a-select-option>
                  </a-select>
                </a-form-item>
              </a-col>
              <a-col :md="8" :sm="24">
                <a-form-item label="设备编号">
                  <a-input v-model="queryParam.deviceNo" allow-clear placeholder="请输入设备编号"/>
                </a-form-item>
              </a-col>
              <a-col :md="8" :sm="24">
                <a-form-item label="租赁用户">
                  <a-input v-model="queryParam.rentUser" allow-clear placeholder="请输入租赁用户"/>
                </a-form-item>
              </a-col><a-col :md="8" :sm="24">
                <a-form-item label="退款原因">
                  <a-select :allowClear="true" style="width: 100%" v-model="queryParam.returnReason" placeholder="请选择退款原因">
                    <a-select-option v-for="(item,index) in returnReasonData" :key="index" :value="item.code">{{ item.name }}</a-select-option>
                  </a-select>
                </a-form-item>
              </a-col><a-col :md="8" :sm="24">
                <a-form-item label="退款类型">
                  <a-select :allowClear="true" style="width: 100%" v-model="queryParam.returnType" placeholder="请选择退款类型">
                    <a-select-option v-for="(item,index) in returnTypeData" :key="index" :value="item.code">{{ item.name }}</a-select-option>
                  </a-select>
                </a-form-item>
              </a-col>
              <a-col :md="8" :sm="24">
                <a-form-item label="创建时间">
                  <a-input v-model="queryParam.returnCreateDtime" allow-clear placeholder="请输入创建时间"/>
                </a-form-item>
              </a-col>
              <a-col :md="8" :sm="24">
                <a-form-item label="到账时间">
                  <a-input v-model="queryParam.accountDtime" allow-clear placeholder="请输入到账时间"/>
                </a-form-item>
              </a-col><a-col :md="8" :sm="24">
                <a-form-item label="退款状态">
                  <a-select :allowClear="true" style="width: 100%" v-model="queryParam.returnStatus" placeholder="请选择退款状态">
                    <a-select-option v-for="(item,index) in returnStatusData" :key="index" :value="item.code">{{ item.name }}</a-select-option>
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
        <template class="table-operator" slot="operator" v-if="hasPerm('ReturnList:add')" >
          <a-button type="primary" v-if="hasPerm('ReturnList:add')" icon="plus" @click="$refs.addForm.add()">导出</a-button>
        </template>
        <span slot="ownedOrgscopedSlots" slot-scope="text">
          {{ '' | dictType(text) }}
        </span>
        <span slot="batteryTypescopedSlots" slot-scope="text">
          {{ 'battery_type' | dictType(text) }}
        </span>
        <span slot="returnReasonscopedSlots" slot-scope="text">
          {{ '' | dictType(text) }}
        </span>
        <span slot="returnTypescopedSlots" slot-scope="text">
          {{ '' | dictType(text) }}
        </span>
        <span slot="returnStatusscopedSlots" slot-scope="text">
          {{ 'common_status' | dictType(text) }}
        </span>
        <span slot="action" slot-scope="text, record">
          <a v-if="hasPerm('ReturnList:edit')" @click="$refs.editForm.edit(record)">编辑</a>
          <a-divider type="vertical" v-if="hasPerm('ReturnList:edit') & hasPerm('ReturnList:delete')"/>
          <a-popconfirm v-if="hasPerm('ReturnList:delete')" placement="topRight" title="确认删除？" @confirm="() => ReturnListDelete(record)">
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
  import { ReturnListPage, ReturnListDelete } from '@/api/modular/main/ReturnListManage'
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
            title: '退款单号',
            align: 'center',
sorter: true,
            dataIndex: 'returnNo'
          },
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
            dataIndex: 'ownedOrg',
            scopedSlots: { customRender: 'ownedOrgscopedSlots' }
          },
          {
            title: '设备编号',
            align: 'center',
sorter: true,
            dataIndex: 'deviceNo'
          },
          {
            title: '电芯类型',
            align: 'center',
sorter: true,
            dataIndex: 'batteryType',
            scopedSlots: { customRender: 'batteryTypescopedSlots' }
          },
          {
            title: '租赁用户',
            align: 'center',
sorter: true,
            dataIndex: 'rentUser'
          },
          {
            title: '押金金额',
            align: 'center',
sorter: true,
            dataIndex: 'depositAmount'
          },
          {
            title: '退款金额',
            align: 'center',
sorter: true,
            dataIndex: 'returnAmount'
          },
          {
            title: '退款原因',
            align: 'center',
sorter: true,
            dataIndex: 'returnReason',
            scopedSlots: { customRender: 'returnReasonscopedSlots' }
          },
          {
            title: '退款类型',
            align: 'center',
sorter: true,
            dataIndex: 'returnType',
            scopedSlots: { customRender: 'returnTypescopedSlots' }
          },
          {
            title: '创建时间',
            align: 'center',
sorter: true,
            dataIndex: 'returnCreateDtime'
          },
          {
            title: '审核时间',
            align: 'center',
sorter: true,
            dataIndex: 'auditDtime'
          },
          {
            title: '到账时间',
            align: 'center',
sorter: true,
            dataIndex: 'accountDtime'
          },
          {
            title: '退款状态',
            align: 'center',
sorter: true,
            dataIndex: 'returnStatus',
            scopedSlots: { customRender: 'returnStatusscopedSlots' }
          }
        ],
        tstyle: { 'padding-bottom': '0px', 'margin-bottom': '10px' },
        // 加载数据方法 必须为 Promise 对象
        loadData: parameter => {
          return ReturnListPage(Object.assign(parameter, this.queryParam)).then((res) => {
            return res.data
          })
        },
        ownedOrgData: [],
        returnReasonData: [],
        returnTypeData: [],
        returnStatusData: [],
        selectedRowKeys: [],
        selectedRows: []
      }
    },
    created () {
      if (this.hasPerm('ReturnList:edit') || this.hasPerm('ReturnList:delete')) {
        this.columns.push({
          title: '操作',
          width: '150px',
          dataIndex: 'action',
          scopedSlots: { customRender: 'action' }
        })
      }
      const ownedOrgOption = this.$options
      this.ownedOrgData = ownedOrgOption.filters['dictData']('')
      const returnReasonOption = this.$options
      this.returnReasonData = returnReasonOption.filters['dictData']('')
      const returnTypeOption = this.$options
      this.returnTypeData = returnTypeOption.filters['dictData']('')
      const returnStatusOption = this.$options
      this.returnStatusData = returnStatusOption.filters['dictData']('common_status')
    },
    methods: {
      /**
       * 查询参数组装
       */
      switchingDate () {
        const obj = JSON.parse(JSON.stringify(this.queryParam))
        return obj
      },
      ReturnListDelete (record) {
        ReturnListDelete(record).then((res) => {
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
