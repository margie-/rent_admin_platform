<template>
  <a-modal
    title="编辑设备警报"
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
        <a-form-item label="报警时间" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入报警时间" v-decorator="['alertDtime']" />
        </a-form-item>
        <a-form-item label="报警日期" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入报警日期" v-decorator="['alertDate']" />
        </a-form-item>
        <a-form-item label="报警位置X" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入报警位置X" v-decorator="['alertPosition_x']" />
        </a-form-item>
        <a-form-item label="报警位置Y" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入报警位置Y" v-decorator="['alertPosition_y']" />
        </a-form-item>
        <a-form-item label="报警位置" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入报警位置" v-decorator="['alertPosition']" />
        </a-form-item>
        <a-form-item label="报警类型" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-select style="width: 100%" placeholder="请选择报警类型" v-decorator="['alertType', {rules: [{ required: true, message: '请选择报警类型！' }]}]">
            <a-select-option v-for="(item,index) in alertTypeData" :key="index" :value="item.code">{{ item.name }}</a-select-option>
          </a-select>
        </a-form-item>
        <a-form-item label="报警信息" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入报警信息" v-decorator="['alertInfo']" />
        </a-form-item>
        <a-form-item label="当前速度" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入当前速度" v-decorator="['curSpeed']" />
        </a-form-item>
        <a-form-item label="报警状态" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入报警状态" v-decorator="['alterStatus']" />
        </a-form-item>
        <a-form-item label="是否处理" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入是否处理" v-decorator="['isHandled']" />
        </a-form-item>
        <a-form-item label="处理信息" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入处理信息" v-decorator="['handleInfo']" />
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
    DeviceAlarmRecordEdit
  } from '@/api/modular/main/DeviceAlarmRecordManage'
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
        alertTypeData: [],
        visible: false,
        confirmLoading: false,
        form: this.$form.createForm(this)
      }
    },
    methods: {
      // 初始化方法
      edit (record) {
        this.visible = true
        const alertTypeOption = this.$options
        this.alertTypeData = alertTypeOption.filters['dictData']('device_alarm_type')
        setTimeout(() => {
          this.form.setFieldsValue(
            {
              id: record.id,
              deviceNo: record.deviceNo,
              alertDtime: record.alertDtime,
              alertDate: record.alertDate,
              alertPosition_x: record.alertPosition_x,
              alertPosition_y: record.alertPosition_y,
              alertPosition: record.alertPosition,
              alertType: record.alertType,
              alertInfo: record.alertInfo,
              curSpeed: record.curSpeed,
              alterStatus: record.alterStatus,
              isHandled: record.isHandled,
              handleInfo: record.handleInfo,
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
            DeviceAlarmRecordEdit(values).then((res) => {
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
