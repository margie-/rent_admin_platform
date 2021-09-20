import Vue from 'vue'
import { logout } from '@/api/modular/system/loginManage'
// import { sysDictTypeTree } from '@/api/modular/system/dictManage'
import { sysMenuChange } from '@/api/modular/system/menuManage'
import { ACCESS_TOKEN, ALL_APPS_MENU, DICT_TYPE_TREE_DATA } from '@/store/mutation-types'
// import { sysFileInfoPreview } from '@/api/modular/system/fileManage'

import { welcome } from '@/utils/util'
import store from '../index'
import router from '../../router'

// import dictData from '@/utils/dictDataTree'

const user = {
  state: {
    token: '',
    name: '',
    welcome: '',
    avatar: '',
    buttons: [], // 按钮权限
    admintype: '', // 是否是超管
    roles: [],
    info: {}
  },

  mutations: {
    SET_TOKEN: (state, token) => {
      state.token = token
    },
    SET_NAME: (state, { name, welcome }) => {
      state.name = name
      state.welcome = welcome
    },
    SET_AVATAR: (state, avatar) => {
      state.avatar = avatar
    },
    SET_ROLES: (state, roles) => {
      state.roles = roles
    },
    SET_INFO: (state, info) => {
      state.info = info
    },
    SET_BUTTONS: (state, buttons) => {
      state.buttons = buttons
    },
    SET_ADMINTYPE: (state, admintype) => {
      state.admintype = admintype
    }
  },

  actions: {
    // 登录
    Login ({ commit }, userInfo) {
      return new Promise((resolve, reject) => {
        // login(userInfo).then(response => {
        //   if (!response.success) {
        //     reject(response.message)
        //     return
        //   }
        //   const result = response.data
        //   Vue.ls.set(ACCESS_TOKEN, result, 7 * 24 * 60 * 60 * 1000)
        //   commit('SET_TOKEN', result)
        //   resolve()
        // // eslint-disable-next-line handle-callback-err
        // }).catch(error => {
        //   // eslint-disable-next-line prefer-promise-reject-errors
        //   reject('后端未启动或代理错误')
        // })
        const abc = {
          'success': true,
          'code': 200,
          'message': '请求成功',
          'data': 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVc2VySWQiOjE0MjMwNzA3MDkxMDU1MSwiVGVuYW50SWQiOjE0MjMwNzA3MDkxODc4MCwiQWNjb3VudCI6InN1cGVyQWRtaW4iLCJOYW1lIjoi6LaF57qn566h55CG5ZGYIiwiU3VwZXJBZG1pbiI6MSwiaWF0IjoxNjMxMzU0MTQ5LCJuYmYiOjE2MzEzNTQxNDksImV4cCI6MTYzMTQ0MDU0OSwiaXNzIjoiZGlsb24iLCJhdWQiOiJkaWxvbiJ9.vdsivrgdV9m4OfxpDrRIUlXc49Kc0WOFQdj5t7_AppE',
          'extras': null,
          'timestamp': 1631354149721
        }
          const result = abc.data
          Vue.ls.set(ACCESS_TOKEN, result, 7 * 24 * 60 * 60 * 1000)
          commit('SET_TOKEN', result)
          resolve()
      })
    },

    // 获取用户信息
    GetInfo ({ commit }) {
      return new Promise((resolve, reject) => {
        // getLoginUser().then(response => {
        //   if (response.success) {
            const userInfo = {
              'success': true,
              'code': 0,
              'message': 'string',
              'data': {
                'id': 0,
                'account': 'string',
                'nickName': 'string',
                'name': 'string',
                'avatar': 'string',
                'birthday': '2021-09-11T14:51:04.699Z',
                'sex': 0,
                'email': 'string',
                'phone': 'string',
                'tel': 'string',
                'adminType': 0,
                'lastLoginIp': 'string',
                'lastLoginTime': '2021-09-11T14:51:04.699Z',
                'lastLoginAddress': 'string',
                'lastLoginBrowser': 'string',
                'lastLoginOs': 'string',
                'loginEmpInfo': {
                  'jobNum': 'string',
                  'orgId': 'string',
                  'orgName': 'string',
                  'extOrgPos': [
                    {
                      'orgId': 0,
                      'orgCode': 'string',
                      'orgName': 'string',
                      'posId': 0,
                      'posCode': 'string',
                      'posName': 'string'
                    }
                  ],
                  'positions': [
                    {
                      'posId': 0,
                      'posCode': 'string',
                      'posName': 'string'
                    }
                  ]
                },
                'apps': [
                  {
                    'id': 0,
                    'name': 'string',
                    'code': 'string',
                    'active': 'string',
                    'sort': 0
                  }
                ],
                'roles': [
                  {
                    'roleType': 1,
                    'id': 0,
                    'code': 'string',
                    'name': 'string'
                  }
                ],
                'permissions': [
                  'string'
                ],
                'menus': [
                  {
                    'id': 0,
                    'pid': 0,
                    'name': 'string',
                    'component': 'string',
                    'redirect': 'string',
                    'meta': {
                      'title': 'string',
                      'icon': 'string',
                      'show': true,
                      'target': 'string',
                      'link': 'string'
                    },
                    'path': 'string',
                    'hidden': true
                  }
                ],
                'dataScopes': [
                  0
                ]
              },
              'extras': 'string',
              'timestamp': 0
            }
            const data = userInfo.data
            commit('SET_ADMINTYPE', data.adminType)
            commit('SET_ROLES', 1)
            commit('SET_BUTTONS', data.permissions)
            commit('SET_INFO', data)
            commit('SET_NAME', { name: data.name, welcome: welcome() })
            // if (data.avatar != null) {
            //   sysFileInfoPreview({ id: data.avatar }).then((res) => {
            //     commit('SET_AVATAR', window.URL.createObjectURL(new Blob([res])))
            //   }).catch((err) => {
            //     this.$message.error('预览错误：' + err.message)
            //   })
            //   // commit('SET_AVATAR', process.env.VUE_APP_API_BASE_URL + '/sysFileInfo/preview?id=' + data.avatar)
            // }
            resolve(data)
          // } else {
          //   // eslint-disable-next-line no-undef
          //   reject(new Error(data.message))
          // }
        // }).catch(error => {
        //   reject(error)
        // })
      })
    },

    // 登出
    Logout ({ commit, state }) {
      return new Promise((resolve) => {
        logout(state.token).then(() => {
          resolve()
        }).catch(() => {
          resolve()
        }).finally(() => {
          commit('SET_TOKEN', '')
          commit('SET_ROLES', [])
          commit('SET_BUTTONS', [])
          commit('SET_ADMINTYPE', '')
          Vue.ls.remove(ACCESS_TOKEN)
          Vue.ls.remove(ALL_APPS_MENU)
          Vue.ls.remove(DICT_TYPE_TREE_DATA)
        })
      })
    },

    // 加载所有字典数据
    dictTypeData () {
      return new Promise((resolve, reject) => {
        // sysDictTypeTree().then((data) => {
        //   if (data.success) {

            // const result = dictData.data
            // Vue.ls.set(DICT_TYPE_TREE_DATA, result)
            resolve()
        //   } else {
        //     // eslint-disable-next-line no-undef
        //     reject(new Error(data.message))
        //   }
        // }).catch(error => {
        //   reject(error)
        // })
      })
    },

    // 切换应用菜单
    MenuChange ({ commit }, application) {
      return new Promise((resolve) => {
        sysMenuChange({ application: application.code }).then((res) => {
          const apps = { 'code': '', 'name': '', 'active': '', 'menu': '' }
          apps.active = true
          apps.menu = res.data
          // eslint-disable-next-line camelcase
          const all_app_menu = Vue.ls.get(ALL_APPS_MENU)
          // eslint-disable-next-line camelcase
          const new_false_all_app_menu = []
          // 先去除所有默认的，以为此时切换的即将成为前端缓存默认的应用
          all_app_menu.forEach(item => {
            if (item.active) {
              item.active = false
            }
            new_false_all_app_menu.push(item)
          })
          // 此时缓存中全部都是不默认的应用
          Vue.ls.set(ALL_APPS_MENU, new_false_all_app_menu)
          apps.name = application.name
          apps.code = application.code
          const applocationR = []
          applocationR.push(apps)
          Vue.ls.set(ALL_APPS_MENU, applocationR)
          resolve(res)
          const antDesignmenus = res.data
          store.dispatch('GenerateRoutes', { antDesignmenus }).then(() => {
            router.addRoutes(store.getters.addRouters)
          })
          // 切换应用刷新整体界面，暂且取消
          // window.location.reload()
        }).catch(() => {
          resolve()
        })
      })
    }

  }
}

export default user
