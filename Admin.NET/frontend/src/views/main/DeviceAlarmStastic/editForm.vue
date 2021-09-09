<template>
  <a-modal
    title="编辑报警统计日报表"
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
        <a-form-item label="设备名称" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入设备名称" v-decorator="['deviceName']" />
        </a-form-item>
        <a-form-item label="所属门店" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入所属门店" v-decorator="['ownedOrg']" />
        </a-form-item>
        <a-form-item label="报表日期" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入报表日期" v-decorator="['reportDate']" />
        </a-form-item>
        <a-form-item label="出围栏报警" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入出围栏报警" v-decorator="['alarm1']" />
        </a-form-item>
        <a-form-item label="入围栏报警" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入入围栏报警" v-decorator="['alarm2']" />
        </a-form-item>
        <a-form-item label="断电报警" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入断电报警" v-decorator="['alarm3']" />
        </a-form-item>
        <a-form-item label="低电报警" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入低电报警" v-decorator="['alarm4']" />
        </a-form-item>
        <a-form-item label="震动报警" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入震动报警" v-decorator="['alarm5']" />
        </a-form-item>
        <a-form-item label="位移报警" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入位移报警" v-decorator="['alarm6']" />
        </a-form-item>
        <a-form-item label="点火报警" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入点火报警" v-decorator="['alarm7']" />
        </a-form-item>
        <a-form-item label="侧翻报警" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入侧翻报警" v-decorator="['alarm8']" />
        </a-form-item>
        <a-form-item label="拆卸报警" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入拆卸报警" v-decorator="['alarm9']" />
        </a-form-item>
        <a-form-item v-show="false"><a-input v-decorator="['id']" /></a-form-item>
      </a-form>
    </a-spin>
  </a-modal>
</template>

<script>
  import {
    DeviceAlarmStasticEdit
  } from '@/api/modular/main/DeviceAlarmStasticManage'
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
              deviceNo: record.deviceNo,
              deviceName: record.deviceName,
              ownedOrg: record.ownedOrg,
              reportDate: record.reportDate,
              alarm1: record.alarm1,
              alarm2: record.alarm2,
              alarm3: record.alarm3,
              alarm4: record.alarm4,
              alarm5: record.alarm5,
              alarm6: record.alarm6,
              alarm7: record.alarm7,
              alarm8: record.alarm8,
              alarm9: record.alarm9
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
            DeviceAlarmStasticEdit(values).then((res) => {
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
