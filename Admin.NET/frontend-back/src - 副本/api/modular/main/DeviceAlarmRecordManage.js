import { axios } from '@/utils/request'

/**
 * 查询设备警报
 *
 * @author Chris
 */
export function DeviceAlarmRecordPage (parameter) {
  return axios({
    url: '/DeviceAlarmRecord/page',
    method: 'get',
    params: parameter
  })
}

/**
 * 设备警报列表
 *
 * @author Chris
 */
export function DeviceAlarmRecordList (parameter) {
  return axios({
    url: '/DeviceAlarmRecord/list',
    method: 'get',
    params: parameter
  })
}

/**
 * 添加设备警报
 *
 * @author Chris
 */
export function DeviceAlarmRecordAdd (parameter) {
  return axios({
    url: '/DeviceAlarmRecord/add',
    method: 'post',
    data: parameter
  })
}

/**
 * 编辑设备警报
 *
 * @author Chris
 */
export function DeviceAlarmRecordEdit (parameter) {
  return axios({
    url: '/DeviceAlarmRecord/edit',
    method: 'post',
    data: parameter
  })
}

/**
 * 删除设备警报
 *
 * @author Chris
 */
export function DeviceAlarmRecordDelete (parameter) {
  return axios({
    url: '/DeviceAlarmRecord/delete',
    method: 'post',
    data: parameter
  })
}
