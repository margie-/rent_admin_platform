<template>
  <a-modal
    title="编辑里程统计"
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
        <a-form-item label="统计日期" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入统计日期" v-decorator="['sdate']" />
        </a-form-item>
        <a-form-item label="日里程数" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入日里程数" v-decorator="['dayMiles']" />
        </a-form-item>
        <a-form-item label="里程单位" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入里程单位" v-decorator="['mileUnit']" />
        </a-form-item>
        <a-form-item label="当日油耗" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入当日油耗" v-decorator="['dayUsedOil']" />
        </a-form-item>
        <a-form-item label="油耗单位" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入油耗单位" v-decorator="['oilUnit']" />
        </a-form-item>
        <a-form-item label="最后更新时间" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入最后更新时间" v-decorator="['lastLocationDtime']" />
        </a-form-item>
        <a-form-item label="行驶时间" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入行驶时间" v-decorator="['driverTimes']" />
        </a-form-item>
        <a-form-item label="平均速度" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入平均速度" v-decorator="['avgSpeed']" />
        </a-form-item>
        <a-form-item label="最大速度" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入最大速度" v-decorator="['maxSpeed']" />
        </a-form-item>
        <a-form-item label="GPS里程数" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入GPS里程数" v-decorator="['gPSMiles']" />
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
    MileStatisticsEdit
  } from '@/api/modular/main/MileStatisticsManage'
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
              sdate: record.sdate,
              dayMiles: record.dayMiles,
              mileUnit: record.mileUnit,
              dayUsedOil: record.dayUsedOil,
              oilUnit: record.oilUnit,
              lastLocationDtime: record.lastLocationDtime,
              driverTimes: record.driverTimes,
              avgSpeed: record.avgSpeed,
              maxSpeed: record.maxSpeed,
              gPSMiles: record.gPSMiles,
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
            MileStatisticsEdit(values).then((res) => {
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
