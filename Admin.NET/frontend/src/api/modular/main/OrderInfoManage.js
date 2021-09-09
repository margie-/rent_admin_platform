import { axios } from '@/utils/request'

/**
 * 查询续费记录
 *
 * @author Chris
 */
export function OrderInfoPage (parameter) {
  return axios({
    url: '/OrderInfo/page',
    method: 'get',
    params: parameter
  })
}

/**
 * 续费记录列表
 *
 * @author Chris
 */
export function OrderInfoList (parameter) {
  return axios({
    url: '/OrderInfo/list',
    method: 'get',
    params: parameter
  })
}

/**
 * 添加续费记录
 *
 * @author Chris
 */
export function OrderInfoAdd (parameter) {
  return axios({
    url: '/OrderInfo/add',
    method: 'post',
    data: parameter
  })
}

/**
 * 编辑续费记录
 *
 * @author Chris
 */
export function OrderInfoEdit (parameter) {
  return axios({
    url: '/OrderInfo/edit',
    method: 'post',
    data: parameter
  })
}

/**
 * 删除续费记录
 *
 * @author Chris
 */
export function OrderInfoDelete (parameter) {
  return axios({
    url: '/OrderInfo/delete',
    method: 'post',
    data: parameter
  })
}
