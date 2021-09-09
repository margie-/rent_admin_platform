import { axios } from '@/utils/request'

/**
 * 查询设备信息
 *
 * @author Chris
 */
export function DeviceInfoPage (parameter) {
  return axios({
    url: '/DeviceInfo/page',
    method: 'get',
    params: parameter
  })
}

/**
 * 设备信息列表
 *
 * @author Chris
 */
export function DeviceInfoList (parameter) {
  return axios({
    url: '/DeviceInfo/list',
    method: 'get',
    params: parameter
  })
}

/**
 * 添加设备信息
 *
 * @author Chris
 */
export function DeviceInfoAdd (parameter) {
  return axios({
    url: '/DeviceInfo/add',
    method: 'post',
    data: parameter
  })
}

/**
 * 编辑设备信息
 *
 * @author Chris
 */
export function DeviceInfoEdit (parameter) {
  return axios({
    url: '/DeviceInfo/edit',
    method: 'post',
    data: parameter
  })
}

/**
 * 删除设备信息
 *
 * @author Chris
 */
export function DeviceInfoDelete (parameter) {
  return axios({
    url: '/DeviceInfo/delete',
    method: 'post',
    data: parameter
  })
}
