import { axios } from '@/utils/request'

/**
 * 查询合同管理
 *
 * @author Chris
 */
export function ContractListPage (parameter) {
  return axios({
    url: '/ContractList/page',
    method: 'get',
    params: parameter
  })
}

/**
 * 合同管理列表
 *
 * @author Chris
 */
export function ContractListList (parameter) {
  return axios({
    url: '/ContractList/list',
    method: 'get',
    params: parameter
  })
}

/**
 * 添加合同管理
 *
 * @author Chris
 */
export function ContractListAdd (parameter) {
  return axios({
    url: '/ContractList/add',
    method: 'post',
    data: parameter
  })
}

/**
 * 编辑合同管理
 *
 * @author Chris
 */
export function ContractListEdit (parameter) {
  return axios({
    url: '/ContractList/edit',
    method: 'post',
    data: parameter
  })
}

/**
 * 删除合同管理
 *
 * @author Chris
 */
export function ContractListDelete (parameter) {
  return axios({
    url: '/ContractList/delete',
    method: 'post',
    data: parameter
  })
}
