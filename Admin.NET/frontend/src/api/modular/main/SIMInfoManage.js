import { axios } from '@/utils/request'

/**
 * 查询SIM信息
 *
 * @author Chris
 */
export function SIMInfoPage (parameter) {
  return axios({
    url: '/SIMInfo/page',
    method: 'get',
    params: parameter
  })
}

/**
 * SIM信息列表
 *
 * @author Chris
 */
export function SIMInfoList (parameter) {
  return axios({
    url: '/SIMInfo/list',
    method: 'get',
    params: parameter
  })
}

/**
 * 添加SIM信息
 *
 * @author Chris
 */
export function SIMInfoAdd (parameter) {
  return axios({
    url: '/SIMInfo/add',
    method: 'post',
    data: parameter
  })
}

/**
 * 编辑SIM信息
 *
 * @author Chris
 */
export function SIMInfoEdit (parameter) {
  return axios({
    url: '/SIMInfo/edit',
    method: 'post',
    data: parameter
  })
}

/**
 * 删除SIM信息
 *
 * @author Chris
 */
export function SIMInfoDelete (parameter) {
  return axios({
    url: '/SIMInfo/delete',
    method: 'post',
    data: parameter
  })
}
