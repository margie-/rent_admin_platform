import { axios } from '@/utils/request'

/**
 * 查询围栏报警统计
 *
 * @author Chris
 */
export function FenceStaticsPage (parameter) {
  return axios({
    url: '/FenceStatics/page',
    method: 'get',
    params: parameter
  })
}

/**
 * 围栏报警统计列表
 *
 * @author Chris
 */
export function FenceStaticsList (parameter) {
  return axios({
    url: '/FenceStatics/list',
    method: 'get',
    params: parameter
  })
}

/**
 * 添加围栏报警统计
 *
 * @author Chris
 */
export function FenceStaticsAdd (parameter) {
  return axios({
    url: '/FenceStatics/add',
    method: 'post',
    data: parameter
  })
}

/**
 * 编辑围栏报警统计
 *
 * @author Chris
 */
export function FenceStaticsEdit (parameter) {
  return axios({
    url: '/FenceStatics/edit',
    method: 'post',
    data: parameter
  })
}

/**
 * 删除围栏报警统计
 *
 * @author Chris
 */
export function FenceStaticsDelete (parameter) {
  return axios({
    url: '/FenceStatics/delete',
    method: 'post',
    data: parameter
  })
}
