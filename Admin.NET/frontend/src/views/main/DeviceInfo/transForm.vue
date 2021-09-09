<template>
  <a-modal
    title="批量转移设备信息"
    :width="900"
    :visible="visible"
    :confirmLoading="confirmLoading"
    @ok="handleSubmit"
    @cancel="handleCancel"
  >
    <a-card :bordered="false">
      <a-form :form="form">
        <a-row :gutter="24">
          <a-col :span="20">
            <a-form-item label="转移门店" :labelCol="labelCol" :wrapperCol="wrapperCol" >
              <a-tree-select
                v-decorator="['ownedOrg', { rules: [{ required: true, message: '请选择门店！' }] }]"
                style="width: 80%"
                :dropdownStyle="{ maxHeight: '300px', overflow: 'auto' }"
                :treeData="orgTree"
                placeholder="请选择门店"
                treeDefaultExpandAll
              >
                <span slot="title" slot-scope="{ id }">{{ id }} </span>
              </a-tree-select>
            </a-form-item>
          </a-col>
        </a-row >
        <a-row :gutter="24">
          <a-col :span="20">
            <a-form-item label="选择设备" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-textarea
                style="width:80%"
                :rows="4"
                allow-clear
                placeholder="请填入设备编号"
                v-model="queryDeviceIds"
              ></a-textarea>
              <a-button type="primary" @click="newMember2">添加</a-button>
            </a-form-item>
          </a-col>
        </a-row>
        <a-row :gutter="24">
          <a-col :span="22">
            <a-table
              :columns="columns"
              :dataSource="data"
              :pagination="false"
              :loading="memberLoading"
              :rowKey="(record) => record.id"
            >
              <template slot="operation" slot-scope="text, record">
                <a @click="remove(record)">删除</a>
              </template>
            </a-table>
          </a-col>
        </a-row>
      </a-form>
    </a-card>
  </a-modal>
</template>
<script>

 import {
    getOrgTree
  } from '@/api/modular/system/orgManage'
import moment from 'moment'
import { DeviceInfoTransfer, DeviceInfoFromIDs } from '@/api/modular/main/DeviceInfoManage'
const columns = [
    {
      title: '设备名称',
      dataIndex: 'deviceName'
    },
    {
      title: '设备编号',
      dataIndex: 'deviceNo'
    },
    {
      title: '所属门店',
      dataIndex: 'ownedOrgName'
    },
    {
      title: '操作',
      key: 'action',
      scopedSlots: { customRender: 'operation' }
    }
  ]

export default {
  data() {
    return {
      labelCol: {
        xs: { span: 24 },
        sm: { span: 5 }
      },
      wrapperCol: {
        xs: { span: 24 },
        sm: { span: 15 }
      },
      queryDeviceIds: '',
      columns,
      ownedOrgData: [],
      orgTree: [],
      visible: false,
      loading: true,
      confirmLoading: false,
      memberLoading: false,
      data: [],
      data2: [],
      form: this.$form.createForm(this)
    }
  },
  methods: {
    moment,
    // 初始化方法
    transfer(record) {
      this.getOrgTree()
      this.visible = true
      if (record.length > 0) {
        this.data = record
        record.forEach(element => {
          this.data2.push(element.deviceNo)
        })
      }
      const ownedOrgOption = this.$options
      this.ownedOrgData = ownedOrgOption.filters['dictData']('org_type')
      setTimeout(() => {
        this.recordEntity = record
      }, 100)
    },
    /**
     * 获取机构树，并加载于表单中
     */
    getOrgTree() {
        getOrgTree().then((res) => {
          this.formLoading = false
          if (!res.success) {
            this.orgTree = []
            return
          }
          this.orgTree = res.data
        })
      },
    handleSubmit() {
      const {
        form: { validateFields }
      } = this
      this.confirmLoading = true
      validateFields((errors, values) => {
        if (!errors) {
          values.transferDeviceList = this.data2
          DeviceInfoTransfer({ OwnedOrg: values.ownedOrg, transferDeviceList: this.data2 })
            .then((res) => {
              if (res.success) {
                this.$message.success('传递成功')
                this.confirmLoading = false
                this.$emit('ok', values)
                this.handleCancel()
              } else {
                this.$message.error('失败：' + JSON.stringify(res.message))
              }
            })
            .finally((res) => {
              this.confirmLoading = false
            })
        } else {
          this.confirmLoading = false
        }
      })
    },
    handleCancel() {
      this.data = []
      this.data2 = []
      this.form.resetFields()
      this.visible = false
    },
     /**
     * 增行
     */
    newMember2 () {
        this.confirmLoading = true
            // eslint-disable-next-line no-undef
            if (this.queryDeviceIds === '') {
                this.$message.error('请填入设备编号!')
                return
            }
            var deviceArr = this.queryDeviceIds.split('\n')
            if (deviceArr.length <= 0) {
               this.$message.error('请填入设备编号!')
               return
            }
            DeviceInfoFromIDs({ deviceNos: deviceArr }).then((res) => {
              if (res.success) {
                this.confirmLoading = false
                this.queryDeviceIds = ''
                res.data.forEach(element => {
                   // eslint-disable-next-line eqeqeq
                   if (!this.data.find(a => { return a.deviceNo == element.deviceNo })) {
                      const length = this.data.length
                      this.data.push({
                       key: length === 0 ? '1' : (parseInt(this.data[length - 1].key) + 1).toString(),
                            deviceName: element.deviceName,
                            deviceNo: element.deviceNo,
                            ownedOrgName: element.ownedOrgName
                      })
                      this.data2.push(element.deviceNo)
                   }
                })
                } else {
                  this.queryDeviceIds = ''
                }
                })
                this.confirmLoading = false
     },
    /**
     * 删除
    */
    remove (record) {
      const newData = this.data.filter(item => item.deviceNo !== record.deviceNo)
      this.data = newData
    }
  }
}
</script>
