import { axios } from '@/utils/request'

/**
 * 查询设备退押记录
 *
 * @author Chris
 */
export function ReturnListPage (parameter) {
  return axios({
    url: '/ReturnList/page',
    method: 'get',
    params: parameter
  })
}

/**
 * 设备退押记录列表
 *
 * @author Chris
 */
export function ReturnListList (parameter) {
  return axios({
    url: '/ReturnList/list',
    method: 'get',
    params: parameter
  })
}

/**
 * 添加设备退押记录
 *
 * @author Chris
 */
export function ReturnListAdd (parameter) {
  return axios({
    url: '/ReturnList/add',
    method: 'post',
    data: parameter
  })
}

/**
 * 编辑设备退押记录
 *
 * @author Chris
 */
export function ReturnListEdit (parameter) {
  return axios({
    url: '/ReturnList/edit',
    method: 'post',
    data: parameter
  })
}

/**
 * 删除设备退押记录
 *
 * @author Chris
 */
export function ReturnListDelete (parameter) {
  return axios({
    url: '/ReturnList/delete',
    method: 'post',
    data: parameter
  })
}
