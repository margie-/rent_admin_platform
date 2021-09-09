<template>
  <a-modal
    title="新增设备信息"
    :width="900"
    :visible="visible"
    :confirmLoading="confirmLoading"
    @ok="handleSubmit"
    @cancel="handleCancel">
    <a-spin :spinning="confirmLoading">
      <a-form :form="form">
        <a-form-item label="设备名称" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入设备名称" v-decorator="['deviceName']" />
        </a-form-item>
        <a-form-item label="设备编号" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入设备编号" v-decorator="['deviceNo']" />
        </a-form-item>
        <a-form-item label="类型" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-select style="width: 100%" placeholder="请选择类型" v-decorator="['deviceType', {rules: [{ required: true, message: '请选择类型！' }]}]">
            <a-select-option v-for="(item,index) in deviceTypeData" :key="index" :value="item.code">{{ item.name }}</a-select-option>
          </a-select>
        </a-form-item>
        <a-form-item label="型号" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-select style="width: 100%" placeholder="请选择型号" v-decorator="['dModel', {rules: [{ required: true, message: '请选择型号！' }]}]">
            <a-select-option v-for="(item,index) in dModelData" :key="index" :value="item.code">{{ item.name }}</a-select-option>
          </a-select>
        </a-form-item>
        <a-form-item label="电压" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input-number placeholder="请输入电压" style="width: 100%" v-decorator="['voltage']" />
        </a-form-item>
        <a-form-item label="电流" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input-number placeholder="请输入电流" style="width: 100%" v-decorator="['electricity']" />
        </a-form-item>
        <a-form-item label="电芯" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-select style="width: 100%" placeholder="请选择电芯" v-decorator="['batteryType', {rules: [{ required: true, message: '请选择电芯！' }]}]">
            <a-select-option v-for="(item,index) in batteryTypeData" :key="index" :value="item.code">{{ item.name }}</a-select-option>
          </a-select>
        </a-form-item>
        <a-form-item label="ICCD" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入ICCD" v-decorator="['iCCID']" />
        </a-form-item>
        <a-form-item label="版本" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入版本" v-decorator="['fWVersion']" />
        </a-form-item>
        <a-form-item label="所属门店" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-select style="width: 100%" placeholder="请选择所属门店" v-decorator="['ownedOrg', {rules: [{ required: true, message: '请选择所属门店！' }]}]">
            <a-select-option v-for="(item,index) in ownedOrgData" :key="index" :value="item.code">{{ item.name }}</a-select-option>
          </a-select>
        </a-form-item>
        <a-form-item label="设备状态" :labelCol="labelCol" :wrapperCol="wrapperCol">
          <a-select style="width: 100%" placeholder="请选择设备状态" v-decorator="['deviceStatus', {rules: [{ required: true, message: '请选择设备状态！' }]}]">
            <a-select-option v-for="(item,index) in deviceStatusData" :key="index" :value="item.code">{{ item.name }}</a-select-option>
          </a-select>
        </a-form-item>
        <a-form-item label="制造日期" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-date-picker style="width: 100%" placeholder="请选择制造日期" v-decorator="['manufactureDate']" @change="onChangemanufactureDate"/>
        </a-form-item>
        <a-form-item label="最后定位日期" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-date-picker style="width: 100%" placeholder="请选择最后定位日期" v-decorator="['lastLoationDtime']" @change="onChangelastLoationDtime"/>
        </a-form-item>
        <a-form-item label="蓝牙ID" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入蓝牙ID" v-decorator="['blueToothID']" />
        </a-form-item>
        <a-form-item label="激活时间" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-date-picker style="width: 100%" placeholder="请选择激活时间" v-decorator="['activeDtime']" @change="onChangeactiveDtime"/>
        </a-form-item>
        <a-form-item label="过期时间" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-date-picker style="width: 100%" placeholder="请选择过期时间" v-decorator="['expiredDtime']" @change="onChangeexpiredDtime"/>
        </a-form-item>
        <a-form-item label="车牌号" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入车牌号" v-decorator="['carNo']" />
        </a-form-item>
        <a-form-item label="车主姓名" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入车主姓名" v-decorator="['carOwerName']" />
        </a-form-item>
        <a-form-item label="电话" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入电话" v-decorator="['carOwnerPhone']" />
        </a-form-item>
        <a-form-item label="图标" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入图标" v-decorator="['iconId']" />
        </a-form-item>
        <a-form-item label="租户id" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入租户id" v-decorator="['tenantId']" />
        </a-form-item>
      </a-form>
    </a-spin>
  </a-modal>
</template>

<script>
  import {
    DeviceInfoAdd
  } from '@/api/modular/main/DeviceInfoManage'

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
        deviceTypeData: [],
        dModelData: [],
        batteryTypeData: [],
        ownedOrgData: [],
        deviceStatusData: [],
        manufactureDateDateString: '',
        lastLoationDtimeDateString: '',
        activeDtimeDateString: '',
        expiredDtimeDateString: '',
        visible: false,
        confirmLoading: false,
        form: this.$form.createForm(this)
      }
    },
    methods: {
      // 初始化方法
      add (record) {
        this.visible = true
        const deviceTypeOption = this.$options
        this.deviceTypeData = deviceTypeOption.filters['dictData']('org_type')
        const dModelOption = this.$options
        this.dModelData = dModelOption.filters['dictData']('')
        const batteryTypeOption = this.$options
        this.batteryTypeData = batteryTypeOption.filters['dictData']('battery_type')
        const ownedOrgOption = this.$options
        this.ownedOrgData = ownedOrgOption.filters['dictData']('org_type')
        const deviceStatusOption = this.$options
        this.deviceStatusData = deviceStatusOption.filters['dictData']('devive_rent_status')
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
            values.manufactureDate = this.manufactureDateDateString
            values.lastLoationDtime = this.lastLoationDtimeDateString
            values.activeDtime = this.activeDtimeDateString
            values.expiredDtime = this.expiredDtimeDateString
            DeviceInfoAdd(values).then((res) => {
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
      onChangemanufactureDate(date, dateString) {
        this.manufactureDateDateString = dateString
      },
      onChangelastLoationDtime(date, dateString) {
        this.lastLoationDtimeDateString = dateString
      },
      onChangeactiveDtime(date, dateString) {
        this.activeDtimeDateString = dateString
      },
      onChangeexpiredDtime(date, dateString) {
        this.expiredDtimeDateString = dateString
      },
      handleCancel () {
        this.form.resetFields()
        this.visible = false
      }
    }
  }
</script>
