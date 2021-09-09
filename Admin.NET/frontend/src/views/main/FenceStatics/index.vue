<template>
  <div>
    <a-card :bordered="false" :bodyStyle="tstyle">

      <div class="table-page-search-wrapper" v-if="hasPerm('FenceStatics:page')">
        <a-form layout="inline">
          <a-row :gutter="48">
            <a-col :md="8" :sm="24">
              <a-form-item label="设备编号">
                <a-input v-model="queryParam.deviceNo" allow-clear placeholder="请输入设备编号"/>
              </a-form-item>
            </a-col>
            <a-col :md="8" :sm="24">
              <a-form-item label="所属客户">
                <a-input v-model="queryParam.ownedCus" allow-clear placeholder="请输入所属客户"/>
              </a-form-item>
            </a-col><template v-if="advanced">
              <a-col :md="8" :sm="24">
                <a-form-item label="围栏类型">
                  <a-input v-model="queryParam.fenceType" allow-clear placeholder="请输入围栏类型"/>
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
        <template class="table-operator" slot="operator" v-if="hasPerm('FenceStatics:add')" >
          <a-button type="primary" v-if="hasPerm('FenceStatics:add')" icon="plus" @click="$refs.addForm.add()">新增围栏报警统计</a-button>
        </template>
        <span slot="action" slot-scope="text, record">
          <a v-if="hasPerm('FenceStatics:edit')" @click="$refs.editForm.edit(record)">编辑</a>
          <a-divider type="vertical" v-if="hasPerm('FenceStatics:edit') & hasPerm('FenceStatics:delete')"/>
          <a-popconfirm v-if="hasPerm('FenceStatics:delete')" placement="topRight" title="确认删除？" @confirm="() => FenceStaticsDelete(record)">
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
  import { FenceStaticsPage, FenceStaticsDelete } from '@/api/modular/main/FenceStaticsManage'
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
            title: '所属客户',
            align: 'center',
sorter: true,
            dataIndex: 'ownedCus'
          },
          {
            title: '围栏名称',
            align: 'center',
sorter: true,
            dataIndex: 'fenceName'
          },
          {
            title: '围栏类型',
            align: 'center',
sorter: true,
            dataIndex: 'fenceType'
          },
          {
            title: '速度(km/h)',
            align: 'center',
sorter: true,
            dataIndex: 'speed'
          },
          {
            title: '定位时间',
            align: 'center',
sorter: true,
            dataIndex: 'locationDtime'
          }
        ],
        tstyle: { 'padding-bottom': '0px', 'margin-bottom': '10px' },
        // 加载数据方法 必须为 Promise 对象
        loadData: parameter => {
          return FenceStaticsPage(Object.assign(parameter, this.queryParam)).then((res) => {
            return res.data
          })
        },
        selectedRowKeys: [],
        selectedRows: []
      }
    },
    created () {
      if (this.hasPerm('FenceStatics:edit') || this.hasPerm('FenceStatics:delete')) {
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
      FenceStaticsDelete (record) {
        FenceStaticsDelete(record).then((res) => {
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
