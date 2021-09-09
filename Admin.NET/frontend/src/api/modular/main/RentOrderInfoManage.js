import { axios } from '@/utils/request'

/**
 * 查询订单列表
 *
 * @author Chris
 */
export function RentOrderInfoPage (parameter) {
  return axios({
    url: '/RentOrderInfo/page',
    method: 'get',
    params: parameter
  })
}

/**
 * 订单列表列表
 *
 * @author Chris
 */
export function RentOrderInfoList (parameter) {
  return axios({
    url: '/RentOrderInfo/list',
    method: 'get',
    params: parameter
  })
}

/**
 * 添加订单列表
 *
 * @author Chris
 */
export function RentOrderInfoAdd (parameter) {
  return axios({
    url: '/RentOrderInfo/add',
    method: 'post',
    data: parameter
  })
}

/**
 * 编辑订单列表
 *
 * @author Chris
 */
export function RentOrderInfoEdit (parameter) {
  return axios({
    url: '/RentOrderInfo/edit',
    method: 'post',
    data: parameter
  })
}

/**
 * 删除订单列表
 *
 * @author Chris
 */
export function RentOrderInfoDelete (parameter) {
  return axios({
    url: '/RentOrderInfo/delete',
    method: 'post',
    data: parameter
  })
}
