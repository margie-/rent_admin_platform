import { axios } from '@/utils/request'

/**
 * 查询设备信息
 *
 * @author Chris
 */
export function DeviceInfoPage (parameter) {
  return axios({
    url: '/DeviceInfo/page',
    method: 'get',
    params: parameter
  })
}

/**
 * 设备信息列表
 *
 * @author Chris
 */
export function DeviceInfoList (parameter) {
  return axios({
    url: '/DeviceInfo/list',
    method: 'get',
    params: parameter
  })
}

/**
 * 添加设备信息
 *
 * @author Chris
 */
export function DeviceInfoAdd (parameter) {
  return axios({
    url: '/DeviceInfo/add',
    method: 'post',
    data: parameter
  })
}

/**
 * 编辑设备信息
 *
 * @author Chris
 */
export function DeviceInfoEdit (parameter) {
  return axios({
    url: '/DeviceInfo/edit',
    method: 'post',
    data: parameter
  })
}

/**
 * 删除设备信息
 *
 * @author Chris
 */
export function DeviceInfoDelete (parameter) {
  return axios({
    url: '/DeviceInfo/delete',
    method: 'post',
    data: parameter
  })
}

/**
 * 导出设备信息
 *
 * @author Chris
 * @date 2021/7/30 01:00
 */
export function DeviceInfoExport (parameter) {
  return axios({
    url: '/DeviceInfo/export',
    method: 'get',
    data: parameter,
    responseType: 'blob'
  })
}

/*
 * 转移设备
 * @author Chris
 * @date 2021/8/9
 */
export function DeviceInfoTransfer (parameter) {
  return axios({
    url: '/DeviceInfo/transfer',
    method: 'post',
    data: parameter
  })
}

/**
 * 查询设备
 */
export function DeviceInfoFromIDs (parameter) {
  return axios({
    url: '/DeviceInfo/getfromIds',
    method: 'post',
    data: parameter
  })
}

/**
 * 批量更新设备
 */
export function DeviceInfoLotUpdate (parameter) {
  return axios({
    url: '/DeviceInfo/lotupdate',
    method: 'post',
    data: parameter
  })
}

export function GetDeviceOTree (parameter) {
  // return axios({
  //   url: '/DeviceInfo/dtree',
  //   method: 'get',
  //   params: parameter,
  // })
  return new Promise((resolve, reject) => {
    const abc = {
      'success': true,
      'code': 200,
      'message': '请求成功',
      'data': [
        {
          'all_DeviceCount': 4,
          'cur_DeviceCount': 1,
          'id': 174827013677125,
          'parentId': 0,
          'title': '之旺[1/4]',
          'value': '174827013677125',
          'weight': 100,
          'pids': '[0],',
          'children': [
            {
              'all_DeviceCount': 3,
              'cur_DeviceCount': 1,
              'id': 174827366686789,
              'parentId': 174827013677125,
              'title': '王伟测试账号[1/3]',
              'value': '174827366686789',
              'weight': 100,
              'pids': '[0],[174827013677125],',
              'children': [
                {
                  'all_DeviceCount': 2,
                  'cur_DeviceCount': 2,
                  'id': 186755437695045,
                  'parentId': 174827366686789,
                  'title': '111[2/2]',
                  'value': '186755437695045',
                  'weight': 100,
                  'pids': '[0],[174827013677125],[174827366686789],',
                  'children': [
                    {
                      'all_DeviceCount': 0,
                      'cur_DeviceCount': 0,
                      'id': 200153472262213,
                      'parentId': 186755437695045,
                      'title': 'sssssss[0/0]',
                      'value': '200153472262213',
                      'weight': 100,
                      'pids': '[0],[174827013677125],[174827366686789],[186755437695045],',
                      'children': [],
                      'pid': 186755437695045
                    },
                    {
                      'all_DeviceCount': 0,
                      'cur_DeviceCount': 0,
                      'id': 196964932288581,
                      'parentId': 186755437695045,
                      'title': '2222[0/0]',
                      'value': '196964932288581',
                      'weight': 100,
                      'pids': '[0],[174827013677125],[174827366686789],[186755437695045],',
                      'children': [],
                      'pid': 186755437695045
                    },
                    {
                      'all_DeviceCount': 0,
                      'cur_DeviceCount': 0,
                      'id': 200154121171013,
                      'parentId': 186755437695045,
                      'title': 'ssssss[0/0]',
                      'value': '200154121171013',
                      'weight': 100,
                      'pids': '[0],[174827013677125],[174827366686789],[186755437695045],',
                      'children': [],
                      'pid': 186755437695045
                    }
                  ],
                  'pid': 174827366686789
                },
                {
                  'all_DeviceCount': 0,
                  'cur_DeviceCount': 0,
                  'id': 200658405277765,
                  'parentId': 174827366686789,
                  'title': '11111[0/0]',
                  'value': '200658405277765',
                  'weight': 100,
                  'pids': '[0],[174827013677125],[174827366686789],',
                  'children': [],
                  'pid': 174827366686789
                }
              ],
              'pid': 174827013677125
            },
            {
              'all_DeviceCount': 0,
              'cur_DeviceCount': 0,
              'id': 174829383766085,
              'parentId': 174827013677125,
              'title': 'A公司[0/0]',
              'value': '174829383766085',
              'weight': 100,
              'pids': '[0],[174827013677125],',
              'children': [
                {
                  'all_DeviceCount': 0,
                  'cur_DeviceCount': 0,
                  'id': 196888284803141,
                  'parentId': 174829383766085,
                  'title': '3333[0/0]',
                  'value': '196888284803141',
                  'weight': 100,
                  'pids': '[0],[174827013677125],[174829383766085],',
                  'children': [],
                  'pid': 174829383766085
                }
              ],
              'pid': 174827013677125
            }
          ],
          'pid': 0
        },
        {
          'all_DeviceCount': 0,
          'cur_DeviceCount': 0,
          'id': 198067753734213,
          'parentId': 0,
          'title': '444[0/0]',
          'value': '198067753734213',
          'weight': 100,
          'pids': '[0],',
          'children': [
            {
              'all_DeviceCount': 0,
              'cur_DeviceCount': 0,
              'id': 198237207265349,
              'parentId': 198067753734213,
              'title': '6666[0/0]',
              'value': '198237207265349',
              'weight': 100,
              'pids': '[0],[198067753734213],',
              'children': [],
              'pid': 198067753734213
            },
            {
              'all_DeviceCount': 0,
              'cur_DeviceCount': 0,
              'id': 198249705594949,
              'parentId': 198067753734213,
              'title': '7777[0/0]',
              'value': '198249705594949',
              'weight': 100,
              'pids': '[0],[198067753734213],',
              'children': [],
              'pid': 198067753734213
            }
          ],
          'pid': 0
        },
        {
          'all_DeviceCount': 0,
          'cur_DeviceCount': 0,
          'id': 198054597918789,
          'parentId': 0,
          'title': '333[0/0]',
          'value': '198054597918789',
          'weight': 100,
          'pids': '[0],',
          'children': [],
          'pid': 0
        }
      ],
      'extras': null,
      'timestamp': 1631628675370
    }
    resolve(abc)
  })
}

export function GetMapDeviceList (parameter) {
  return new Promise((resolve, reject) => {
    const abc = {
      'success': true,
      'code': 200,
      'message': '请求成功',
      'data': {
        'pageNo': 1,
        'pageSize': 20,
        'totalPage': 1,
        'totalRows': 8,
        'rows': [
          {
            'deviceName': '53212200889',
            'deviceNo': '53212200889',
            'fortifiedState': '1',
            'batteryVoltage': 71.68,
            'on_off_state': '1',
            'locType': '3',
            'lastComDtime': null,
            'lastLocDtime': null,
            'gps_grage': 2,
            'gms_grage': 5,
            'cur_lat': 116.46706996,
            'cur_log': 39.99188446,
            'cur_attitude': 0,
            'cur_speed': 0,
            'cur_direction': 0,
            'cur_map_fence_id': 0,
            'cur_waringmark': '11000001000000000000',
            'cur_status': '0',
            'cur_gps_miles': 0,
            'cur_day_miles': 0,
            'cur_soc': 0,
            'acc_on': null,
            'deviceStatus': null,
            'alarmList': [
              {
                'deviceNo': '53212200889',
                'alertDtime': '2021-09-15 15:20:33',
                'alertDate': '2021-09-15',
                'alertPosition_x': 119.187371,
                'alertPosition_y': 25.767005,
                'alertPosition': null,
                'alertType': '1',
                'alertInfo': '超速报警',
                'curSpeed': null,
                'alterStatus': '1',
                'isHandled': null,
                'handleInfo': null,
                'tenantId': null,
                'id': 0,
                'createdTime': null,
                'updatedTime': null,
                'createdUserId': null,
                'createdUserName': null,
                'updatedUserId': null,
                'updatedUserName': null,
                'isDeleted': false
              },
              {
                'deviceNo': '53212200889',
                'alertDtime': '2021-09-15 15:20:33',
                'alertDate': '2021-09-15',
                'alertPosition_x': 31.697666,
                'alertPosition_y': 120.499183,
                'alertPosition': null,
                'alertType': '0',
                'alertInfo': '紧急报警',
                'curSpeed': null,
                'alterStatus': '2',
                'isHandled': null,
                'handleInfo': null,
                'tenantId': null,
                'id': 0,
                'createdTime': null,
                'updatedTime': null,
                'createdUserId': null,
                'createdUserName': null,
                'updatedUserId': null,
                'updatedUserName': null,
                'isDeleted': false
              }
            ]
          },
          {
            'deviceName': '53212200890',
            'deviceNo': '53212200890',
            'fortifiedState': '1',
            'batteryVoltage': 71.68,
            'on_off_state': '1',
            'locType': '3',
            'lastComDtime': null,
            'lastLocDtime': null,
            'gps_grage': null,
            'gms_grage': null,
            'cur_lat': 119.3576,
            'cur_log': 26.226988,
            'cur_attitude': 0,
            'cur_speed': 0,
            'cur_direction': 0,
            'cur_map_fence_id': 0,
            'cur_waringmark': '11000001000000000000',
            'cur_status': '0',
            'cur_gps_miles': 0,
            'cur_day_miles': 0,
            'cur_soc': 0,
            'acc_on': null,
            'deviceStatus': 1,
            'alarmList': [
              {
                'deviceNo': '53212200889',
                'alertDtime': '2021-09-15 15:20:33',
                'alertDate': '2021-09-15',
                'alertPosition_x': 30.697666,
                'alertPosition_y': 120.499183,
                'alertPosition': null,
                'alertType': '1',
                'alertInfo': '超速报警',
                'curSpeed': null,
                'alterStatus': '1',
                'isHandled': null,
                'handleInfo': null,
                'tenantId': null,
                'id': 0,
                'createdTime': null,
                'updatedTime': null,
                'createdUserId': null,
                'createdUserName': null,
                'updatedUserId': null,
                'updatedUserName': null,
                'isDeleted': false
              },
              {
                'deviceNo': '53212200889',
                'alertDtime': '2021-09-15 15:20:33',
                'alertDate': '2021-09-15',
                'alertPosition_x': 31.697666,
                'alertPosition_y': 120.499183,
                'alertPosition': null,
                'alertType': '0',
                'alertInfo': '紧急报警',
                'curSpeed': null,
                'alterStatus': '2',
                'isHandled': null,
                'handleInfo': null,
                'tenantId': null,
                'id': 0,
                'createdTime': null,
                'updatedTime': null,
                'createdUserId': null,
                'createdUserName': null,
                'updatedUserId': null,
                'updatedUserName': null,
                'isDeleted': false
              }
            ]
          },
          {
            'deviceName': '53212200891',
            'deviceNo': '53212200891',
            'fortifiedState': '1',
            'batteryVoltage': 71.68,
            'on_off_state': '1',
            'locType': '3',
            'lastComDtime': null,
            'lastLocDtime': null,
            'gps_grage': null,
            'gms_grage': null,
            'cur_lat': 120.668139,
            'cur_log': 31.183422,
            'cur_attitude': 0,
            'cur_speed': 0,
            'cur_direction': 0,
            'cur_map_fence_id': 0,
            'cur_waringmark': '11000001000000000000',
            'cur_status': '0',
            'cur_gps_miles': 0,
            'cur_day_miles': 0,
            'cur_soc': 0,
            'acc_on': null,
            'deviceStatus': 1,
            'alarmList': [
              {
                'deviceNo': '53212200889',
                'alertDtime': '2021-09-15 15:20:33',
                'alertDate': '2021-09-15',
                'alertPosition_x': 31.697666,
                'alertPosition_y': 120.499183,
                'alertPosition': null,
                'alertType': '1',
                'alertInfo': '超速报警',
                'curSpeed': null,
                'alterStatus': '1',
                'isHandled': null,
                'handleInfo': null,
                'tenantId': null,
                'id': 0,
                'createdTime': null,
                'updatedTime': null,
                'createdUserId': null,
                'createdUserName': null,
                'updatedUserId': null,
                'updatedUserName': null,
                'isDeleted': false
              },
              {
                'deviceNo': '53212200889',
                'alertDtime': '2021-09-15 15:20:33',
                'alertDate': '2021-09-15',
                'alertPosition_x': 31.697666,
                'alertPosition_y': 120.499183,
                'alertPosition': null,
                'alertType': '0',
                'alertInfo': '紧急报警',
                'curSpeed': null,
                'alterStatus': '2',
                'isHandled': null,
                'handleInfo': null,
                'tenantId': null,
                'id': 0,
                'createdTime': null,
                'updatedTime': null,
                'createdUserId': null,
                'createdUserName': null,
                'updatedUserId': null,
                'updatedUserName': null,
                'isDeleted': false
              }
            ]
          },
          {
            'deviceName': '53212200892',
            'deviceNo': '53212200892',
            'fortifiedState': '1',
            'batteryVoltage': 71.68,
            'on_off_state': '1',
            'locType': '3',
            'lastComDtime': null,
            'lastLocDtime': null,
            'gps_grage': null,
            'gms_grage': null,
            'cur_lat': 120.742822,
            'cur_log': 31.41032,
            'cur_attitude': 0,
            'cur_speed': 0,
            'cur_direction': 0,
            'cur_map_fence_id': 0,
            'cur_waringmark': '11000001000000000000',
            'cur_status': '0',
            'cur_gps_miles': 0,
            'cur_day_miles': 0,
            'cur_soc': 0,
            'acc_on': null,
            'deviceStatus': 1,
            'alarmList': [
              {
                'deviceNo': '53212200889',
                'alertDtime': '2021-09-15 15:20:33',
                'alertDate': '2021-09-15',
                'alertPosition_x': 31.697666,
                'alertPosition_y': 120.499183,
                'alertPosition': null,
                'alertType': '1',
                'alertInfo': '超速报警',
                'curSpeed': null,
                'alterStatus': '1',
                'isHandled': null,
                'handleInfo': null,
                'tenantId': null,
                'id': 0,
                'createdTime': null,
                'updatedTime': null,
                'createdUserId': null,
                'createdUserName': null,
                'updatedUserId': null,
                'updatedUserName': null,
                'isDeleted': false
              },
              {
                'deviceNo': '53212200889',
                'alertDtime': '2021-09-15 15:20:33',
                'alertDate': '2021-09-15',
                'alertPosition_x': 31.697666,
                'alertPosition_y': 120.499183,
                'alertPosition': null,
                'alertType': '0',
                'alertInfo': '紧急报警',
                'curSpeed': null,
                'alterStatus': '2',
                'isHandled': null,
                'handleInfo': null,
                'tenantId': null,
                'id': 0,
                'createdTime': null,
                'updatedTime': null,
                'createdUserId': null,
                'createdUserName': null,
                'updatedUserId': null,
                'updatedUserName': null,
                'isDeleted': false
              }
            ]
          }
        ]
      },
      'extras': null,
      'timestamp': 1631690433651
    }
    resolve(abc)
  })
}

export function GetDeviceLocList (parameter) {
  return new Promise((resolve, reject) => {
    const abc = {
      'success': true,
      'code': 200,
      'message': '请求成功',
      'data': {
        'pageNo': 1,
        'pageSize': 100,
        'totalPage': 216,
        'totalRows': 21525,
        'rows': [
          {
            'mobile_no': '53212200889',
            'batteryVoltage': 7.2,
            'latitude': 116.46706996,
            'longitude': 39.99188446,
            'speed': 5,
            'device_time': '2021-09-20 11:49:43',
            'warning_mark': 0,
            'status': 790528,
            'altitude': 0
          },
          {
            'mobile_no': '53212200889',
            'batteryVoltage': 7.195,
            'latitude': 116.47706996,
            'longitude': 39.89188446,
            'speed': 5,
            'device_time': '2021-09-20 12:19:43',
            'warning_mark': 0,
            'status': 790528,
            'altitude': 0
          },
          {
            'mobile_no': '53212200889',
            'batteryVoltage': 7.195,
            'latitude': 116.50706996,
            'longitude': 39.98188446,
            'speed': 5,
            'device_time': '2021-09-20 12:29:43',
            'warning_mark': 0,
            'status': 790528,
            'altitude': 0
          },
          {
            'mobile_no': '53212200889',
            'batteryVoltage': 7.2,
            'latitude': 116.50906996,
            'longitude': 39.99188446,
            'speed': 5,
            'device_time': '2021-09-20 12:39:43',
            'warning_mark': 0,
            'status': 790528,
            'altitude': 0
          },
          {
            'mobile_no': '53212200889',
            'batteryVoltage': 7.2,
            'latitude': 116.51906996,
            'longitude': 40.00188446,
            'speed': 5,
            'device_time': '2021-09-20 12:39:43',
            'warning_mark': 0,
            'status': 790528,
            'altitude': 0
          },
          {
            'mobile_no': '53212200889',
            'batteryVoltage': 7.195,
            'latitude': 116.52906996,
            'longitude': 40.10188446,
            'speed': 5,
            'device_time': '2021-09-20 12:39:43',
            'warning_mark': 0,
            'status': 790528,
            'altitude': 0
          },
          {
            'mobile_no': '53212200889',
            'batteryVoltage': 7.195,
            'latitude': 116.53906996,
            'longitude': 40.03188446,
            'speed': 5,
            'device_time': '2021-09-20 12:39:43',
            'warning_mark': 0,
            'status': 790528,
            'altitude': 0
          },
          {
            'mobile_no': '53212200889',
            'batteryVoltage': 7.2,
            'latitude': 116.53006996,
            'longitude': 40.00188446,
            'speed': 5,
            'device_time': '2021-09-20 12:39:43',
            'warning_mark': 0,
            'status': 790528,
            'altitude': 0
          },
          {
            'mobile_no': '53212200889',
            'batteryVoltage': 7.2,
            'latitude': 116.52906996,
            'longitude': 40.01088446,
            'speed': 5,
            'device_time': '2021-09-20 12:39:43',
            'warning_mark': 0,
            'status': 790528,
            'altitude': 0
          },
          {
            'mobile_no': '53212200889',
            'batteryVoltage': 7.195,
            'latitude': 116.53206996,
            'longitude': 40.01088446,
            'speed': 5,
            'device_time': '2021-09-20 12:39:43',
            'warning_mark': 0,
            'status': 790528,
            'altitude': 0
          },
          {
            'mobile_no': '53212200889',
            'batteryVoltage': 7.195,
            'latitude': 116.52106996,
            'longitude': 40.01088446,
            'speed': 5,
            'device_time': '2021-09-20 12:39:43',
            'warning_mark': 0,
            'status': 790528,
            'altitude': 0
          },
          {
            'mobile_no': '53212200889',
            'batteryVoltage': 7.2,
            'latitude': 116.52906996,
            'longitude': 40.01088446,
            'speed': 5,
            'device_time': '2021-09-20 12:39:43',
            'warning_mark': 0,
            'status': 790528,
            'altitude': 0
          }
        ]
      },
      'extras': null,
      'timestamp': 1631630824701
    }
    resolve(abc)
  })
}
