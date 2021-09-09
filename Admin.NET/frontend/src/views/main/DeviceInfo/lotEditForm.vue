<template>
  <a-modal
    title="批量修改设备信息"
    :width="800"
    :visible="visible"
    :confirmLoading="confirmLoading"
    @ok="handleSubmit"
    @cancel="handleCancel"
  >
    <a-spin :spinning="confirmLoading">

      <a-form :form="form">
        <a-row :gutter="24" >
          <a-col :span="12">
            <a-form-item >
              <a-checkbox style="width:30%" v-decorator="['selDeviceTypeData']" name="deviceType" @change="((e)=>OnChange(e,0))">类型</a-checkbox>
              <a-select
                :disabled="GetDisabled(0)"
                style="width: 60%"
                placeholder="请选择类型"
                v-decorator="['deviceType']"
              >
                <a-select-option v-for="(item, index) in deviceTypeData" :key="index+1" :value="item.code">{{
                  item.name
                }}</a-select-option>
              </a-select>
            </a-form-item>
          </a-col>
          <a-col :span="12" >
            <a-form-item >
              <a-checkbox style="width:30%" v-decorator="['selDModelData' ]" name="voltage" @change="((e)=>OnChange(e,1))">型号</a-checkbox>
              <a-input-number
                :disabled="GetDisabled(1)"
                placeholder=""
                style="width: 30%"
                v-decorator="['voltage']"
              />V
              <a-input-number
                :disabled="GetDisabled(1)"
                placeholder=""
                style="width: 30%"
                v-decorator="['electricity']"
                name="electricity"
              />AH
            </a-form-item>
            <a-input v-show="false" v-decorator="['dModel']" />
          </a-col>
        </a-row>
        <a-row :gutter="24">
          <a-col :span="12">
            <a-form-item >
              <a-checkbox style="width:30%" name="simType" v-decorator="['selSimType' , {valuePropName:'checked',initialValue:false }] " @change="((e)=>OnChange(e,2))">SIM卡类型</a-checkbox>
              <a-select
                :disabled="GetDisabled(2)"
                style="width:60%"
                placeholder="请选择"
                v-decorator="['simType']"
              >
                <a-select-option v-for="(item, index) in simTypeData" :key="index+2" :value="item.code">{{
                  item.name
                }}</a-select-option>
              </a-select>
            </a-form-item>
          </a-col>
          <a-col :span="12">
            <a-form-item>
              <a-checkbox style="width:30%" name="annualFee" v-decorator="['selAnnualFee' , {valuePropName:'checked',vinitialValue:'false' }]" @change="((e)=>OnChange(e,3))">用户年费</a-checkbox>
              <a-input style="width:30%" :disabled="GetDisabled(3)" placeholder="请输入年费" v-decorator="['annualFee']" />元/年
            </a-form-item>
          </a-col>
        </a-row>
        <a-row :gutter="24">
          <a-col :span="12">
            <a-form-item>
              <a-checkbox style="width:30%" name="batteryType" v-decorator="['selBatteryType' , {valuePropName:'checked',initialValue:false}]" @change="((e)=>OnChange(e,4))">电芯</a-checkbox>
              <a-select
                style="width:40%"
                :disabled="GetDisabled(4)"
                placeholder="请选择电芯"
                v-decorator="['batteryType']"
              >
                <a-select-option v-for="(item, index) in batteryTypeData" :key="index+3" :value="item.code">{{
                  item.name
                }}</a-select-option>
              </a-select>
            </a-form-item>
          </a-col>
        </a-row>
        <a-row :gutter="24">
          <a-col :span="12">
            <a-form-item >
              <a-checkbox style="width:30%" name="batteryCalType" v-decorator="['selIconType' , {valuePropName:'checked',initialValue:false }]" @change="((e)=>OnChange(e,6))">电池校正</a-checkbox>
              <a-radio-group style="width:60%" :disabled="GetDisabled(6)" v-model="Battery_calibration_type" v-decorator="['batteryCalType']" >
                <a-radio :value="1">默认</a-radio>
                <a-radio :value="2">自定义</a-radio>
              </a-radio-group>
            </a-form-item>
          </a-col>
        </a-row>
        <a-row :gutter="24">
          <a-col :span="20">
            <a-form-item v-show="GetDisabled2()" label="电池串数" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-input-number
                :min="1"
                :max="60"
                placeholder=""
                style="width: 40%"
                v-decorator="['batterySerialQty']" />串
              <a-button type="" icon="plus" @click="addEl">增加一行</a-button>
              <form action="" class="ready-form">
                <a-ul v-for="(list,index) in lists" :key="list.id">
                  <a-li>
                    <!--<input v-model="list.name">
                      <input v-model="list.value" type="text"> -->
                    <a-input v-model="list.name" v-show="false"></a-input>
                    <a-input-number
                      :precision="2"
                      :min="0.1"
                      :max="100"
                      style="width: 30%"
                      v-model="list.electronicPer_s"/>%
                    <a-input-number style="width: 30%" :min="0.01" :max="100" v-model="list.electronicVol_s"/>V
                    <a-button style="width: 20%" type="dashed" icon="delete" @click="del(index)"></a-button>
                  </a-li>
                </a-ul>
              </form>
            </a-form-item>
          </a-col>
        </a-row>
        <a-row :gutter="24">
          <a-col :span="20">
            <a-form-item label="选择设备" :labelCol="labelCol" :wrapperCol="wrapperCol">
              <a-textarea
                style="width:80%"
                :rows="4"
                placeholder="请填入设备编号"
                v-model="queryDeviceIds"
                allow-clear
              ></a-textarea>
              <a-button type="primary" @click="newMember2">添加</a-button>
            </a-form-item>
          </a-col>
        </a-row>
        <a-row :gutter="24">
          <a-col :span="20">
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
        <a-form-item v-show="false" label="租户id" :labelCol="labelCol" :wrapperCol="wrapperCol" has-feedback>
          <a-input placeholder="请输入租户id" v-decorator="['tenantId']" />
        </a-form-item>
        <a-form-item v-show="false">
          <a-input v-decorator="['id']" />
          <a-input v-decorator="['deviceStatus']" />
          <a-input v-decorator="['lastLoationDtime']" />
        </a-form-item>
      </a-form>
    </a-spin>
  </a-modal>
</template>
<script>
import moment from 'moment'
import { DeviceInfoFromIDs, DeviceInfoLotUpdate } from '@/api/modular/main/DeviceInfoManage'
const columns = [
    // {
    //   title: '设备名称',
    //  dataIndex: 'deviceName'
    // },
    {
      title: '设备编号',
      dataIndex: 'deviceNo'
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
      updateColumns: [],
      updateValues: [],
      checked: [],
      disabled: [],
      Battery_calibration_type: '1',
      lists: [{
          name: '0',
          value: '0.00',
          ElectronicPer_s: '0',
          ElectronicVol_s: '0.00'
      }],
      labelCol: {
        xs: { span: 24 },
        sm: { span: 5 }
      },
      wrapperCol: {
        xs: { span: 24 },
        sm: { span: 15 }
      },
      typeDictTypeDropDown: [],
      deviceTypeData: [],
      batteryTypeData: [],
      simTypeData: [],
      ownedOrgData: [],
      updateProperty: [],
      orgTree: [],
      data: [],
      data2: [],
      columns,
      queryDeviceIds: '',
      visible: false,
      confirmLoading: false,
      memberLoading: false,
      form: this.$form.createForm(this)
      }
  },
  methods: {
    setInit: function() {
      this.disabled = [true, true, true, true, true, true, true, true]
      this.checked = [false, false, false, false, false, false, false, false]
      // eslint-disable-next-line no-undef
    },
    OnChange(e, index) {
          this.checked[index] = e.target.checked
          this.disabled[index] = !this.checked[index]
          if (e.target.checked) {
            this.updateProperty.push(e.target.name)
          } else {
            var listD = this.updateProperty
              listD.forEach(function(item, index, arr) {
              if (item === e.target.name) {
                  listD.splice(index, 1)
              }
              })
              this.updateProperty = listD
          }
      },
    GetDisabled(index) {
       return this.disabled[index]
    },
    GetDisabled2() {
      // eslint-disable-next-line eqeqeq
      if (this.disabled[6] == false && this.Battery_calibration_type == '2') {
        return true
      } else {
        // console.log(false)
        return false
      }
    },
    addEl: function () {
    const cope = {
      name: ' 0',
      value: ' ',
      ElectronicPer_s: '0',
      ElectronicVol_s: '0.00'
    }
    this.lists.push(cope)
  },
    del: function(index) {
    this.lists.splice(index, 1)
  },
    moment,
    // 初始化方法
    lotEdit(record) {
      this.visible = true
      this.setInit()
      const deviceTypeOption = this.$options
      this.deviceTypeData = deviceTypeOption.filters['dictData']('device_type')
      const batteryTypeOption = this.$options
      this.batteryTypeData = batteryTypeOption.filters['dictData']('battery_type')
      const batteryTypeDataOption = this.$options
      this.batteryTypeData = batteryTypeDataOption.filters['dictData']('battery_type')
      const simTypeDataOption = this.$options
      this.simTypeData = simTypeDataOption.filters['dictData']('sim_type')
      // eslint-disable-next-line no-undef
       console.log(record)
      if (record.length > 0) {
        this.data = record
        record.forEach(element => {
                   this.data2.push(element.deviceNo)
        })
      }
    },
    handleSubmit() {
      const {
        form: { validateFields }
      } = this
      validateFields((errors, values) => {
        if (!errors) {
          if (this.data2.length <= 0) {
            this.$message.error('请选择需要更新的设备')
            return
          }
          if (this.updateProperty.length <= 0) {
            this.$message.error('请选择需要更新内容！')
            return
          }
          if (this.checked[0] === true) {
            if (values.deviceType == null) {
                this.$message.error('请选择设备类型！')
                return
            }
          }
          if (this.checked[1] === true) {
            if (values.voltage == null || values.electricity == null) {
                this.$message.error('请维护型号信息！')
                return
            } else {
              values.dModel = values.voltage + 'V' + values.electricity + 'AH'
              this.updateProperty.push('dModel')
            }
          }
          if (this.checked[2] === true) {
            if (values.simType == null) {
                this.$message.error('请选择SIM卡类型！')
                return
            }
          }
          if (this.checked[3] === true) {
            if (values.annualFee == null) {
                this.$message.error('请填写年费信息！')
                return
            }
          }
          if (this.checked[4] === true) {
            if (values.batteryType == null) {
                this.$message.error('请选择电芯类别！')
                return
            }
          }
          if (this.checked[5] === true) {
            if (values.Battery_calibration_type == null) {
                this.$message.error('请选择电量校验类别！')
                return
            }
          }
          this.confirmLoading = true
          var updateDeviceList = this.data2
          DeviceInfoLotUpdate({ deviceType: values.deviceType,
          dModel: values.dModel,
          voltage: values.voltage,
          electricity: values.electricity,
          batteryType: values.batteryType,
          batteryCalType: values.batteryCalType,
          batterySerialQty: values.batterySerialQty,
          updateDeviceList: updateDeviceList,
          updateProperty: this.updateProperty,
          deviceBattertCalibs: this.lists,
          simType: values.simType,
          annualFee: values.annualFee
          })
            .then((res) => {
              if (res.success) {
                this.$message.success('更新成功')
                this.confirmLoading = false
                this.$emit('ok', values)
                this.handleCancel()
              } else {
                this.$message.error('编辑失败：' + JSON.stringify(res.message))
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
    onchangeSelBatterCali() {
       if (this.Battery_calibration_type === '1') {

      } else {
      }
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
    handleCancel() {
      this.form.resetFields()
      this.setInit()
      this.visible = false
    },
    newMember2 () {
            if (this.queryDeviceIds === '') {
                this.$message.error('请填入设备编号!')
                return
            }
            var deviceArr = this.queryDeviceIds.split('\n')
            if (deviceArr.length <= 0) {
               this.$message.error('请填入设备编号!')
               return
            }
            this.confirmLoading = true
            DeviceInfoFromIDs({ deviceNos: deviceArr }).then((res) => {
              if (res.success) {
                this.confirmLoading = false
                res.data.forEach(element => {
                   if (!this.data.find(a => { return a.deviceNo === element.deviceNo })) {
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
                }
                })
                this.queryDeviceIds = ''
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
