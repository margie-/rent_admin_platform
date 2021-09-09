import { axios } from '@/utils/request'

/**
 * 查询里程统计
 *
 * @author Chris
 */
export function MileStatisticsPage (parameter) {
  return axios({
    url: '/MileStatistics/page',
    method: 'get',
    params: parameter
  })
}

/**
 * 里程统计列表
 *
 * @author Chris
 */
export function MileStatisticsList (parameter) {
  return axios({
    url: '/MileStatistics/list',
    method: 'get',
    params: parameter
  })
}

/**
 * 添加里程统计
 *
 * @author Chris
 */
export function MileStatisticsAdd (parameter) {
  return axios({
    url: '/MileStatistics/add',
    method: 'post',
    data: parameter
  })
}

/**
 * 编辑里程统计
 *
 * @author Chris
 */
export function MileStatisticsEdit (parameter) {
  return axios({
    url: '/MileStatistics/edit',
    method: 'post',
    data: parameter
  })
}

/**
 * 删除里程统计
 *
 * @author Chris
 */
export function MileStatisticsDelete (parameter) {
  return axios({
    url: '/MileStatistics/delete',
    method: 'post',
    data: parameter
  })
}
