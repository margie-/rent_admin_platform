import { axios } from '@/utils/request'

/**
 * 查询换电记录
 *
 * @author Chris
 */
export function ChangeBatteryRecordPage (parameter) {
  return axios({
    url: '/ChangeBatteryRecord/page',
    method: 'get',
    params: parameter
  })
}

/**
 * 换电记录列表
 *
 * @author Chris
 */
export function ChangeBatteryRecordList (parameter) {
  return axios({
    url: '/ChangeBatteryRecord/list',
    method: 'get',
    params: parameter
  })
}

/**
 * 添加换电记录
 *
 * @author Chris
 */
export function ChangeBatteryRecordAdd (parameter) {
  return axios({
    url: '/ChangeBatteryRecord/add',
    method: 'post',
    data: parameter
  })
}

/**
 * 编辑换电记录
 *
 * @author Chris
 */
export function ChangeBatteryRecordEdit (parameter) {
  return axios({
    url: '/ChangeBatteryRecord/edit',
    method: 'post',
    data: parameter
  })
}

/**
 * 删除换电记录
 *
 * @author Chris
 */
export function ChangeBatteryRecordDelete (parameter) {
  return axios({
    url: '/ChangeBatteryRecord/delete',
    method: 'post',
    data: parameter
  })
}
