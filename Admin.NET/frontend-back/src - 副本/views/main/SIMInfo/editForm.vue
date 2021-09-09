<template>
  <a-modal
    title="编辑SIM信息"
    :width="900"
    :visible="visible"
    :confirmLoading="confirmLoading"
    @ok="handleSubmit"
    @cancel="handleCancel">
    <a-spin :spinning="confirmLoading">
      <a-form :form="form">
        <a-form-item label="设备编号" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入设备编号" v-decorator="['deviceNo']" />
        </a-form-item>
        <a-form-item label="Sim卡类型" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-select style="width: 100%" placeholder="请选择Sim卡类型" v-decorator="['simType', {rules: [{ required: true, message: '请选择Sim卡类型！' }]}]">
            <a-select-option v-for="(item,index) in simTypeData" :key="index" :value="item.code">{{ item.name }}</a-select-option>
          </a-select>
        </a-form-item>
        <a-form-item label="卡号" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入卡号" v-decorator="['cardNo']" />
        </a-form-item>
        <a-form-item label="ICCID" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入ICCID" v-decorator="['iCCID']" />
        </a-form-item>
        <a-form-item label="卡状态" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-select style="width: 100%" placeholder="请选择卡状态" v-decorator="['simStatus', {rules: [{ required: true, message: '请选择卡状态！' }]}]">
            <a-select-option v-for="(item,index) in simStatusData" :key="index" :value="item.code">{{ item.name }}</a-select-option>
          </a-select>
        </a-form-item>
        <a-form-item label="激活时间" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入激活时间" v-decorator="['activationDtime']" />
        </a-form-item>
        <a-form-item label="过期时间" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入过期时间" v-decorator="['expiredDtime']" />
        </a-form-item>
        <a-form-item label="年费" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入年费" v-decorator="['annualFee']" />
        </a-form-item>
        <a-form-item label="备注" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入备注" v-decorator="['note']" />
        </a-form-item>
        <a-form-item label="租户id" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入租户id" v-decorator="['tenantId']" />
        </a-form-item>
        <a-form-item v-show="false"><a-input v-decorator="['id']" /></a-form-item>
      </a-form>
    </a-spin>
  </a-modal>
</template>

<script>
  import {
    SIMInfoEdit
  } from '@/api/modular/main/SIMInfoManage'
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
        simTypeData: [],
        simStatusData: [],
        visible: false,
        confirmLoading: false,
        form: this.$form.createForm(this)
      }
    },
    methods: {
      // 初始化方法
      edit (record) {
        this.visible = true
        const simTypeOption = this.$options
        this.simTypeData = simTypeOption.filters['dictData']('common_status')
        const simStatusOption = this.$options
        this.simStatusData = simStatusOption.filters['dictData']('common_status')
        setTimeout(() => {
          this.form.setFieldsValue(
            {
              id: record.id,
              deviceNo: record.deviceNo,
              simType: record.simType,
              cardNo: record.cardNo,
              iCCID: record.iCCID,
              simStatus: record.simStatus,
              activationDtime: record.activationDtime,
              expiredDtime: record.expiredDtime,
              annualFee: record.annualFee,
              note: record.note,
              tenantId: record.tenantId
            }
          )
        }, 100)
      },
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
            SIMInfoEdit(values).then((res) => {
              if (res.success) {
                this.$message.success('编辑成功')
                this.confirmLoading = false
                this.$emit('ok', values)
                this.handleCancel()
              } else {
                this.$message.error('编辑失败：' + JSON.stringify(res.message))
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
