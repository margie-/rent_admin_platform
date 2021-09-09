<template>
  <a-modal
    title="新增设备退押记录"
    :width="900"
    :visible="visible"
    :confirmLoading="confirmLoading"
    @ok="handleSubmit"
    @cancel="handleCancel">
    <a-spin :spinning="confirmLoading">
      <a-form :form="form">
        <a-form-item label="所属门店" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-select style="width: 100%" placeholder="请选择所属门店" v-decorator="['ownedOrg', {rules: [{ required: true, message: '请选择所属门店！' }]}]">
            <a-select-option v-for="(item,index) in ownedOrgData" :key="index" :value="item.code">{{ item.name }}</a-select-option>
          </a-select>
        </a-form-item>
        <a-form-item label="设备编号" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入设备编号" v-decorator="['deviceNo']" />
        </a-form-item>
        <a-form-item label="电芯类型" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-select style="width: 100%" placeholder="请选择电芯类型" v-decorator="['batteryType', {rules: [{ required: true, message: '请选择电芯类型！' }]}]">
            <a-select-option v-for="(item,index) in batteryTypeData" :key="index" :value="item.code">{{ item.name }}</a-select-option>
          </a-select>
        </a-form-item>
        <a-form-item label="租赁用户" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入租赁用户" v-decorator="['rentUser']" />
        </a-form-item>
        <a-form-item label="押金金额" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入押金金额" v-decorator="['depositAmount']" />
        </a-form-item>
        <a-form-item label="退款金额" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入退款金额" v-decorator="['returnAmount']" />
        </a-form-item>
        <a-form-item label="退款原因" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-select style="width: 100%" placeholder="请选择退款原因" v-decorator="['returnReason', {rules: [{ required: true, message: '请选择退款原因！' }]}]">
            <a-select-option v-for="(item,index) in returnReasonData" :key="index" :value="item.code">{{ item.name }}</a-select-option>
          </a-select>
        </a-form-item>
        <a-form-item label="退款类型" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-select style="width: 100%" placeholder="请选择退款类型" v-decorator="['returnType', {rules: [{ required: true, message: '请选择退款类型！' }]}]">
            <a-select-option v-for="(item,index) in returnTypeData" :key="index" :value="item.code">{{ item.name }}</a-select-option>
          </a-select>
        </a-form-item>
        <a-form-item label="创建时间" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入创建时间" v-decorator="['returnCreateDtime']" />
        </a-form-item>
        <a-form-item label="审核时间" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入审核时间" v-decorator="['auditDtime']" />
        </a-form-item>
        <a-form-item label="到账时间" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入到账时间" v-decorator="['accountDtime']" />
        </a-form-item>
        <a-form-item label="退款状态" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-select style="width: 100%" placeholder="请选择退款状态" v-decorator="['returnStatus', {rules: [{ required: true, message: '请选择退款状态！' }]}]">
            <a-select-option v-for="(item,index) in returnStatusData" :key="index" :value="item.code">{{ item.name }}</a-select-option>
          </a-select>
        </a-form-item>
      </a-form>
    </a-spin>
  </a-modal>
</template>

<script>
  import {
    ReturnListAdd
  } from '@/api/modular/main/ReturnListManage'

  export default {
    data () {
      return {
        labelCol: {
          xs: { span: 24 },
          sm: { span: 5 }
        },
        wrapperCol: {
          xs: { span: 24 },
          sm: { span: 15 }
        },
        ownedOrgData: [],
        batteryTypeData: [],
        returnReasonData: [],
        returnTypeData: [],
        returnStatusData: [],
        visible: false,
        confirmLoading: false,
        form: this.$form.createForm(this)
      }
    },
    methods: {
      // 初始化方法
      add (record) {
        this.visible = true
        const ownedOrgOption = this.$options
        this.ownedOrgData = ownedOrgOption.filters['dictData']('')
        const batteryTypeOption = this.$options
        this.batteryTypeData = batteryTypeOption.filters['dictData']('battery_type')
        const returnReasonOption = this.$options
        this.returnReasonData = returnReasonOption.filters['dictData']('')
        const returnTypeOption = this.$options
        this.returnTypeData = returnTypeOption.filters['dictData']('')
        const returnStatusOption = this.$options
        this.returnStatusData = returnStatusOption.filters['dictData']('common_status')
      },
      /**
       * 提交表单
       */
      handleSubmit () {
        const { form: { validateFields } } = this
        this.confirmLoading = true
        validateFields((errors, values) => {
          if (!errors) {
            for (const key in values) {
              if (typeof (values[key]) === 'object') {
                values[key] = JSON.stringify(values[key])
              }
            }
            ReturnListAdd(values).then((res) => {
              if (res.success) {
                this.$message.success('新增成功')
                this.confirmLoading = false
                this.$emit('ok', values)
                this.handleCancel()
              } else {
                this.$message.error('新增失败：' + JSON.stringify(res.message))
              }
            }).finally((res) => {
              this.confirmLoading = false
            })
          } else {
            this.confirmLoading = false
          }
        })
      },
      handleCancel () {
        this.form.resetFields()
        this.visible = false
      }
    }
  }
</script>
