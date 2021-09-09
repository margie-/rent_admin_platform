import { axios } from '@/utils/request'

/**
 * 查询设备电池校准信息
 *
 * @author Chris
 */
export function DeviceBattertCalibPage (parameter) {
  return axios({
    url: '/DeviceBattertCalib/page',
    method: 'get',
    params: parameter
  })
}

/**
 * 设备电池校准信息列表
 *
 * @author Chris
 */
export function DeviceBattertCalibList (parameter) {
  return axios({
    url: '/DeviceBattertCalib/list',
    method: 'get',
    params: parameter
  })
}

/**
 * 添加设备电池校准信息
 *
 * @author Chris
 */
export function DeviceBattertCalibAdd (parameter) {
  return axios({
    url: '/DeviceBattertCalib/add',
    method: 'post',
    data: parameter
  })
}

/**
 * 编辑设备电池校准信息
 *
 * @author Chris
 */
export function DeviceBattertCalibEdit (parameter) {
  return axios({
    url: '/DeviceBattertCalib/edit',
    method: 'post',
    data: parameter
  })
}

/**
 * 删除设备电池校准信息
 *
 * @author Chris
 */
export function DeviceBattertCalibDelete (parameter) {
  return axios({
    url: '/DeviceBattertCalib/delete',
    method: 'post',
    data: parameter
  })
}
