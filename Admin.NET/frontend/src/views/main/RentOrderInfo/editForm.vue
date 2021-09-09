<template>
  <a-modal
    title="编辑订单列表"
    :width="900"
    :visible="visible"
    :confirmLoading="confirmLoading"
    @ok="handleSubmit"
    @cancel="handleCancel">
    <a-spin :spinning="confirmLoading">
      <a-form :form="form">
        <a-form-item label="订单号" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入订单号" v-decorator="['orderNo']" />
        </a-form-item>
        <a-form-item label="所属门店" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入所属门店" v-decorator="['ownedOrg']" />
        </a-form-item>
        <a-form-item label="设备编号" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入设备编号" v-decorator="['deviceNo']" />
        </a-form-item>
        <a-form-item label="电池编号" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入电池编号" v-decorator="['batteryNo']" />
        </a-form-item>
        <a-form-item label="电池类型" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入电池类型" v-decorator="['batteryType']" />
        </a-form-item>
        <a-form-item label="租赁价格" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入租赁价格" v-decorator="['rentPrice']" />
        </a-form-item>
        <a-form-item label="租赁时长" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入租赁时长" v-decorator="['rentTime']" />
        </a-form-item>
        <a-form-item label="租赁金额" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入租赁金额" v-decorator="['rentAmount']" />
        </a-form-item>
        <a-form-item label="应付金额" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入应付金额" v-decorator="['pRAmmount']" />
        </a-form-item>
        <a-form-item label="实收金额" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入实收金额" v-decorator="['aRAmount']" />
        </a-form-item>
        <a-form-item label="租赁用户" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入租赁用户" v-decorator="['rentUser']" />
        </a-form-item>
        <a-form-item label="订单创建时间" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入订单创建时间" v-decorator="['orderCreateDtime']" />
        </a-form-item>
        <a-form-item label="付款时间" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入付款时间" v-decorator="['payDtime']" />
        </a-form-item>
        <a-form-item label="设备解绑时间" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入设备解绑时间" v-decorator="['disAssignDtime']" />
        </a-form-item>
        <a-form-item label="支付端设备" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入支付端设备" v-decorator="['payDevice']" />
        </a-form-item>
        <a-form-item label="支付类型" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入支付类型" v-decorator="['payType']" />
        </a-form-item>
        <a-form-item label="支付状态" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入支付状态" v-decorator="['payStatus']" />
        </a-form-item>
        <a-form-item label="分佣状态" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入分佣状态" v-decorator="['subCommissionStatus']" />
        </a-form-item>
        <a-form-item v-show="false"><a-input v-decorator="['id']" /></a-form-item>
      </a-form>
    </a-spin>
  </a-modal>
</template>

<script>
  import {
    RentOrderInfoEdit
  } from '@/api/modular/main/RentOrderInfoManage'
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
        visible: false,
        confirmLoading: false,
        form: this.$form.createForm(this)
      }
    },
    methods: {
      // 初始化方法
      edit (record) {
        this.visible = true
        setTimeout(() => {
          this.form.setFieldsValue(
            {
              id: record.id,
              orderNo: record.orderNo,
              ownedOrg: record.ownedOrg,
              deviceNo: record.deviceNo,
              batteryNo: record.batteryNo,
              batteryType: record.batteryType,
              rentPrice: record.rentPrice,
              rentTime: record.rentTime,
              rentAmount: record.rentAmount,
              pRAmmount: record.pRAmmount,
              aRAmount: record.aRAmount,
              rentUser: record.rentUser,
              orderCreateDtime: record.orderCreateDtime,
              payDtime: record.payDtime,
              disAssignDtime: record.disAssignDtime,
              payDevice: record.payDevice,
              payType: record.payType,
              payStatus: record.payStatus,
              subCommissionStatus: record.subCommissionStatus
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
            RentOrderInfoEdit(values).then((res) => {
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
