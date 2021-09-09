<template>
  <div>
    <a-card :bordered="false" :bodyStyle="tstyle">

      <div class="table-page-search-wrapper" v-if="hasPerm('SIMInfo:page')">
        <a-form layout="inline">
          <a-row :gutter="48">
            <a-col :md="8" :sm="24">
              <a-form-item label="设备编号">
                <a-input v-model="queryParam.deviceNo" allow-clear placeholder="请输入设备编号"/>
              </a-form-item>
            </a-col><a-col :md="8" :sm="24">
              <a-form-item label="Sim卡类型">
                <a-select :allowClear="true" style="width: 100%" v-model="queryParam.simType" placeholder="请选择Sim卡类型">
                  <a-select-option v-for="(item,index) in simTypeData" :key="index" :value="item.code">{{ item.name }}</a-select-option>
                </a-select>
              </a-form-item>
            </a-col><template v-if="advanced"><a-col :md="8" :sm="24">
              <a-form-item label="卡状态">
                <a-select :allowClear="true" style="width: 100%" v-model="queryParam.simStatus" placeholder="请选择卡状态">
                  <a-select-option v-for="(item,index) in simStatusData" :key="index" :value="item.code">{{ item.name }}</a-select-option>
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
        <template class="table-operator" slot="operator" v-if="hasPerm('SIMInfo:add')" >
          <a-button type="primary" v-if="hasPerm('SIMInfo:add')" icon="down" @click="$refs.addForm.add()">导出</a-button>
        </template>
        <span slot="simTypescopedSlots" slot-scope="text">
          {{ 'common_status' | dictType(text) }}
        </span>
        <span slot="simStatusscopedSlots" slot-scope="text">
          {{ 'common_status' | dictType(text) }}
        </span>
        <span slot="action" slot-scope="text, record">
          <a v-if="hasPerm('SIMInfo:edit')" @click="$refs.editForm.edit(record)">编辑</a>
          <a-divider type="vertical" v-if="hasPerm('SIMInfo:edit') & hasPerm('SIMInfo:delete')"/>
          <a-popconfirm v-if="hasPerm('SIMInfo:delete')" placement="topRight" title="确认删除？" @confirm="() => SIMInfoDelete(record)">
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
  import { SIMInfoPage, SIMInfoDelete } from '@/api/modular/main/SIMInfoManage'
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
          },
          {
            title: '备注',
            align: 'center',
sorter: true,
            dataIndex: 'note'
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
          return SIMInfoPage(Object.assign(parameter, this.queryParam)).then((res) => {
            return res.data
          })
        },
        simTypeData: [],
        simStatusData: [],
        selectedRowKeys: [],
        selectedRows: []
      }
    },
    created () {
      if (this.hasPerm('SIMInfo:edit') || this.hasPerm('SIMInfo:delete')) {
        this.columns.push({
          title: '操作',
          width: '150px',
          dataIndex: 'action',
          scopedSlots: { customRender: 'action' }
        })
      }
      const simTypeOption = this.$options
      this.simTypeData = simTypeOption.filters['dictData']('common_status')
      const simStatusOption = this.$options
      this.simStatusData = simStatusOption.filters['dictData']('common_status')
    },
    methods: {
      /**
       * 查询参数组装
       */
      switchingDate () {
        const obj = JSON.parse(JSON.stringify(this.queryParam))
        return obj
      },
      SIMInfoDelete (record) {
        SIMInfoDelete(record).then((res) => {
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
