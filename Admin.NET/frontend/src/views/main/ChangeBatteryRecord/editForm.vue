<template>
  <a-modal
    title="编辑换电记录"
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
        <a-form-item label="租赁用户" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入租赁用户" v-decorator="['rentUser']" />
        </a-form-item>
        <a-form-item label="租赁价格" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入租赁价格" v-decorator="['rentPrice']" />
        </a-form-item>
        <a-form-item label="旧设备门店" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入旧设备门店" v-decorator="['oldOrg']" />
        </a-form-item>
        <a-form-item label="旧设备编号" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入旧设备编号" v-decorator="['oldDeviceNo']" />
        </a-form-item>
        <a-form-item label="新设备编号" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入新设备编号" v-decorator="['newDeviceNo']" />
        </a-form-item>
        <a-form-item label="新设备门店" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入新设备门店" v-decorator="['newOrg']" />
        </a-form-item>
        <a-form-item label="新设备名称" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入新设备名称" v-decorator="['newDeviceName']" />
        </a-form-item>
        <a-form-item label="换电时间" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入换电时间" v-decorator="['changeDtime']" />
        </a-form-item>
        <a-form-item v-show="false"><a-input v-decorator="['id']" /></a-form-item>
      </a-form>
    </a-spin>
  </a-modal>
</template>

<script>
  import {
    ChangeBatteryRecordEdit
  } from '@/api/modular/main/ChangeBatteryRecordManage'
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
              rentUser: record.rentUser,
              rentPrice: record.rentPrice,
              oldOrg: record.oldOrg,
              oldDeviceNo: record.oldDeviceNo,
              newDeviceNo: record.newDeviceNo,
              newOrg: record.newOrg,
              newDeviceName: record.newDeviceName,
              changeDtime: record.changeDtime
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
            ChangeBatteryRecordEdit(values).then((res) => {
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
