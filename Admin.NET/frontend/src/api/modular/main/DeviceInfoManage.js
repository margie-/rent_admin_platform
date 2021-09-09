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

/**
 * 导出设备信息
 *
 * @author Chris
 * @date 2021/7/30 01:00
 */
 export function DeviceInfoExport(parameter) {
  return axios({
    url: '/DeviceInfo/export',
    method: 'get',
    data: parameter,
    responseType: 'blob'
  })
}

/*
 * 转移设备
 * @author Chris
 * @date 2021/8/9
 */
export function DeviceInfoTransfer(parameter) {
  return axios({
    url: '/DeviceInfo/transfer',
    method: 'post',
    data: parameter
  })
}

/**
 * 查询设备
 */
export function DeviceInfoFromIDs(parameter) {
  return axios({
    url: '/DeviceInfo/getfromIds',
    method: 'post',
    data: parameter
  })
}

/**
 * 批量更新设备
 */
 export function DeviceInfoLotUpdate(parameter) {
  return axios({
    url: '/DeviceInfo/lotupdate',
    method: 'post',
    data: parameter
  })
}

export function GetDeviceOTree (parameter) {
  return axios({
    url: '/DeviceInfo/dtree',
    method: 'get',
    params: parameter
  })
}
