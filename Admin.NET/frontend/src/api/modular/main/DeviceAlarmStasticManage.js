import { axios } from '@/utils/request'

/**
 * 查询报警统计日报表
 *
 * @author Chris
 */
export function DeviceAlarmStasticPage (parameter) {
  return axios({
    url: '/DeviceAlarmStastic/page',
    method: 'get',
    params: parameter
  })
}

/**
 * 报警统计日报表列表
 *
 * @author Chris
 */
export function DeviceAlarmStasticList (parameter) {
  return axios({
    url: '/DeviceAlarmStastic/list',
    method: 'get',
    params: parameter
  })
}

/**
 * 添加报警统计日报表
 *
 * @author Chris
 */
export function DeviceAlarmStasticAdd (parameter) {
  return axios({
    url: '/DeviceAlarmStastic/add',
    method: 'post',
    data: parameter
  })
}

/**
 * 编辑报警统计日报表
 *
 * @author Chris
 */
export function DeviceAlarmStasticEdit (parameter) {
  return axios({
    url: '/DeviceAlarmStastic/edit',
    method: 'post',
    data: parameter
  })
}

/**
 * 删除报警统计日报表
 *
 * @author Chris
 */
export function DeviceAlarmStasticDelete (parameter) {
  return axios({
    url: '/DeviceAlarmStastic/delete',
    method: 'post',
    data: parameter
  })
}
