using Furion.DatabaseAccessor;
using Furion.DatabaseAccessor.Extensions;
using Furion.DependencyInjection;
using Furion.DynamicApiController;
using Furion.Extras.Admin.NET;
using Furion.Extras.Admin.NET.Service;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniExcelLibs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Threading.Tasks;

//using Furion.DatabaseAccessor;
//using Furion.DatabaseAccessor.Extensions;
//using Furion.DataEncryption;
//using Furion.DependencyInjection;
//using Furion.DynamicApiController;
//using Furion.Extras.Admin.NET;
//using Furion.FriendlyException;
//using Mapster;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using MiniExcelLibs;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Threading.Tasks;
//using Yitter.IdGenerator;
//using System.Linq.Dynamic.Core;



namespace Admin.NET.Application
{
    /// <summary>
    /// 设备信息服务
    /// </summary>
    [ApiDescriptionSettings("自己的业务", Name = "DeviceInfo", Order = 100)]
    public class DeviceInfoService : IDeviceInfoService, IDynamicApiController, ITransient
    {
        private readonly IRepository<DeviceInfo> _rep;
        private readonly ISIMInfoService _simInfoService;
        private readonly IDeviceBattertCalibService _deviceBattertCalibService;
        private readonly ISysOrgService _sysOrgService;
        private readonly IUserManager _userManager;
        public DeviceInfoService(
            IRepository<DeviceInfo> rep, 
            ISIMInfoService simInfoService,
            IDeviceBattertCalibService deviceBattertCalibService,
            ISysOrgService sysOrgService,
            IUserManager userManager
        )
        {
            _rep = rep;
            _simInfoService = simInfoService;
            _deviceBattertCalibService = deviceBattertCalibService;
            _sysOrgService = sysOrgService;
            _userManager = userManager;
        }

        

        /// <summary>
        /// 分页查询设备信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("/DeviceInfo/page")]
        public async Task<dynamic> Page([FromQuery] DeviceInfoInput input)
        {
            string pid      = input.OwnedOrg.ToString();
            var sysOrgRep   = Db.GetRepository<SysOrg>();
            var entities    = await _rep.DetachedEntities
                                     .Join(sysOrgRep.DetachedEntities,n=>n.OwnedOrg,o=>o.Id,(n,o)=> new DeviceInfoDto {
                                         DeviceName = n.DeviceName,
                                         DeviceNo = n.DeviceNo,
                                         DeviceType = n.DeviceType,
                                         DModel = n.DModel,
                                         Voltage = n.Voltage,
                                         Electricity = n.Electricity,
                                         BatteryType = n.BatteryType,
                                         ICCID = n.ICCID,
                                         FWVersion = n.FWVersion,
                                         OwnedOrg = n.OwnedOrg.ToString(),
                                         OwnedOrgName = o.Name,
                                         DeviceStatus = n.DeviceStatus,
                                         ManufactureDate = n.ManufactureDate,
                                         LastLoationDtime = n.LastLoationDtime,
                                         BlueToothID = n.BlueToothID,
                                         ActiveDtime = n.ActiveDtime,
                                         ExpiredDtime = n.ExpiredDtime,
                                         CarNo = n.CarNo,
                                         CarOwerName = n.CarOwerName,
                                         CarOwnerPhone = n.CarOwnerPhone,
                                         IconId = n.IconId,
                                         TenantId = n.TenantId,
                                         Id = n.Id
                                     })
                                     .Where(!string.IsNullOrEmpty(input.DeviceName),    u => u.DeviceName == input.DeviceName)
                                     .Where(!string.IsNullOrEmpty(input.DeviceNo),      u => u.DeviceNo == input.DeviceNo)
                                     .Where(!string.IsNullOrEmpty(input.DeviceType),    u => u.DeviceType == input.DeviceType)
                                     .Where(!string.IsNullOrEmpty(input.BatteryType),   u => u.BatteryType == input.BatteryType)
                                     .Where(!string.IsNullOrEmpty(input.Voltage),u=>u.Voltage == input.Voltage)
                                     .Where(!string.IsNullOrEmpty(input.Electricity),   u=>u.Electricity == input.Electricity)
                                     .Where(!string.IsNullOrEmpty(pid),u => u.OwnedOrg == pid )
                                     .Where(!string.IsNullOrEmpty(input.DeviceStatus), u => u.DeviceStatus == input.DeviceStatus)
                                     .OrderBy(PageInputOrder.OrderBuilder<DeviceInfoInput>(input))
                                     //.Select(u => u.Adapt<DeviceInfoDto>())
                                     .ToPagedListAsync(input.PageNo, input.PageSize);
            var result = XnPageResult<DeviceInfoDto>.PageResult(entities);
            //await DtoMapper(result.Rows);
            return result;
        }

        /// <summary>
        /// 增加设备信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("/DeviceInfo/add")]
        public async Task Add(AddDeviceInfoInput input)
        {
            var entity = input.Adapt<DeviceInfo>();
            await entity.InsertAsync();
        }

        /// <summary>
        /// 删除设备信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("/DeviceInfo/delete")]
        public async Task Delete(DeleteDeviceInfoInput input)
        {
            var entity = await _rep.FirstOrDefaultAsync(u => u.Id == input.Id);
            await entity.DeleteAsync();
        }

        /// <summary>
        /// 更新设备信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("/DeviceInfo/edit")]
        public async Task Update(UpdateDeviceInfoInput input)
        {
            var entity = input.Adapt<DeviceInfo>();
            await entity.UpdateAsync(true);
        }

        /// <summary>
        /// 获取设备信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("/DeviceInfo/detail")]
        public async Task<DeviceInfo> Get([FromQuery] QueryeDeviceInfoInput input)
        {
            return await _rep.DetachedEntities.FirstOrDefaultAsync(u => u.Id == input.Id);
        }

        /// <summary>
        /// 获取设备信息列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("/DeviceInfo/list")]
        public async Task<dynamic> List([FromQuery] DeviceInfoInput input)
        {
            return await _rep.DetachedEntities.ToListAsync();
        } 
        


        private async Task DtoMapper(ICollection<DeviceInfoDto> rows)
        {
            foreach (var item in rows)
            {
            }
        }

        /// <summary>
        ///  [HttpGet("/DeviceInfo/page")]
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("/DeviceInfo/page2")]
        public async Task<dynamic> Page2([FromQuery] DeviceQueryInfoInput input)
        {
            var entities = await _rep.DetachedEntities
                                    .Where(!string.IsNullOrEmpty(input.DeviceName), u => u.DeviceName == input.DeviceName)
                                    .Where(!string.IsNullOrEmpty(input.DeviceNo), u => u.DeviceNo == input.DeviceNo)
                                    .Where(!string.IsNullOrEmpty(input.DeviceType), u => u.DeviceType == input.DeviceType)
                                    .Where(!string.IsNullOrEmpty(input.BatteryType), u => u.BatteryType == input.BatteryType)
                                    .Where( u => u.OwnedOrg == input.OwnedOrg)
                                    .Where(!string.IsNullOrEmpty(input.DeviceStatus), u => u.DeviceStatus == input.DeviceStatus)
                                    //.OrderBy(PageInputOrder.OrderBuilder<DeviceQueryInfoInput>(input))
                                    .ToPagedListAsync(input.PageNo, input.PageSize);
            var result = XnPageResult<DeviceInfo>.PageResult<DeviceInfoDto>(entities);
            await DtoMapper(result.Rows);
            return result;
        }

        /// <summary>
        /// 设备导出
        /// </summary>
        /// <returns></returns>
        [HttpGet("/DeviceInfo/export")]
        public async Task<IActionResult> ExportDevice([FromQuery] DeviceInfoInput input)
        {
            string pid = input.OwnedOrg.ToString();
            var sysOrgRep = Db.GetRepository<SysOrg>();
            var entities = await _rep.DetachedEntities
                                     .Join(sysOrgRep.DetachedEntities, n => n.OwnedOrg, o => o.Id, (n, o) => new { n, o })
                                     .Where(!string.IsNullOrEmpty(input.DeviceName), u => u.n.DeviceName == input.DeviceName)
                                     .Where(!string.IsNullOrEmpty(input.DeviceNo), u => u.n.DeviceNo == input.DeviceNo)
                                     .Where(!string.IsNullOrEmpty(input.DeviceType), u => u.n.DeviceType == input.DeviceType)
                                     .Where(!string.IsNullOrEmpty(input.BatteryType), u => u.n.BatteryType == input.BatteryType)
                                     .Where(!string.IsNullOrEmpty(input.Voltage), u => u.n.Voltage == input.Voltage)
                                     .Where(!string.IsNullOrEmpty(input.Electricity), u => u.n.Electricity == input.Electricity)
                                     .Where(!string.IsNullOrEmpty(pid), u => u.n.OwnedOrg == long.Parse(pid) || u.o.Pids.Contains($"[{pid.Trim()}]"))
                                     .Where(!string.IsNullOrEmpty(input.DeviceStatus), u => u.n.DeviceStatus == input.DeviceStatus)
                                     //.OrderBy(PageInputOrder.OrderBuilder<DeviceInfoInput>(input))
                                     .Select(u => u.n.Adapt<DeviceInfoDto>())
                                    //.OrderBy(" Id Desc ")
                                    .ToListAsync();
            var memoryStream = new MemoryStream();
            memoryStream.SaveAs(entities);
            memoryStream.Seek(0, SeekOrigin.Begin);
            return await Task.FromResult(new FileStreamResult(memoryStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
            {
                FileDownloadName = "deviceList.xlsx"
            });
        }

        /// <summary>
        /// 设备批量转移
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("/DeviceInfo/transfer")]
        public async Task Transfer(TransferDeviceInput input)
        {
            var Devicelist = Db.GetRepository<DeviceInfo>().Where(n => input.TransferDeviceList.Contains(n.DeviceNo));
            foreach(var d in Devicelist) 
            {
                d.OwnedOrg          = long.Parse(input.OwnedOrg);
                await d.UpdateAsync(true);
            }
           
        }

        /// <summary>
        /// 设备批量更新
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("/DeviceInfo/lotupdate")]
        public async Task LotUpdate(LotUpdateDeviceInfoInput input)
        {
            bool b_1 = false;   //更新DeviceInfo
            bool b_2 = false;   //更新SimInfo 
            bool b_3 = false;   //更新电池校准信息
            var DeviceList = await Db.GetRepository<DeviceInfo>().Where(n => input.UpdateDeviceList.Contains(n.DeviceNo)).ToListAsync();
            Type type = typeof(LotUpdateDeviceInfoInput);
            foreach (var d in DeviceList) 
            {
                
                if(input.UpdateProperty.Contains("simType") || input.UpdateProperty.Contains("annualFee") ) 
                {
                    SIMInfo simInfo = await _simInfoService.GetSimInfoByDeviceNO(d.DeviceNo);
                    if(simInfo != null) 
                    {
                        if (input.UpdateProperty.Contains("simType"))
                        {
                            simInfo.SimType = input.SimType;
                        }
                        if (input.UpdateProperty.Contains("annualFee"))
                        {
                            simInfo.AnnualFee = input.AnnualFee;
                        }
                        b_2 = true;
                        await simInfo.UpdateAsync();
                    }
                    else 
                    {
                        await _simInfoService.Add(new AddSIMInfoInput() { 
                            DeviceNo    = d.DeviceNo,
                            SimType     = input.SimType,
                            AnnualFee   = input.AnnualFee
                        });
                    }
                    
                }
                foreach ( string pro in input.UpdateProperty) 
                {
                    switch (pro)
                    {
                        case "deviceType":
                            d.DeviceType = input.DeviceType;
                            b_1 = true;
                            break;
                        case "dModel":
                            d.DModel = input.DModel;
                            d.Voltage = input.Voltage;
                            d.Electricity = input.Electricity;
                            b_1 = true;
                            break;
                        case "batteryType":
                            d.BatteryType = input.BatteryType;
                            b_1 = true;
                            break;
                        case "batteryCalType":
                            d.BatteryCalType = input.BatteryCalType;
                            d.BatterySerialQty = input.BatterySerialQty;
                            b_1 = true;
                            b_3 = true;
                            break;
                    }
                }
                if (b_1)
                {
                    await d.UpdateAsync(true);
                }
                if (b_3) 
                {
                    //var  _deviceBattertCalibService.GetFromDeviceNo(d.DeviceNo);
                    if(d.BatteryCalType == "2") 
                    {
                        await _deviceBattertCalibService.DeleteByDevice(d.DeviceNo);
                        for(int i=0;i<input.DeviceBattertCalibs.Count;i++) 
                        {
                             _deviceBattertCalibService.Add(
                                new AddDeviceBattertCalibInput()
                                {
                                    DeviceNo        = d.DeviceNo,
                                    BatterySeries   = (i+1).ToString(),
                                    ElectronicPer_s = input.DeviceBattertCalibs[i].ElectronicPer_s,
                                    ElectronicVol_s = input.DeviceBattertCalibs[i].ElectronicVol_s,
                                    InfoSourceType  = "2"
                                });
                        }
                    }
                        
                    
                }
               
                
            }
        }


        
        public async Task SendCommand(DeviceCommandInfos input)
        {
            
        }

        /// <summary>
        ///  [HttpGet("/DeviceInfo/export")]
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("/DeviceInfo/getfromIds")]
        public async Task<dynamic> GetDevicesByIds(DevicesIDs input)
        {
            List<string> l_ids = input.deviceNos;
            if(input == null || input.deviceNos.Count <= 0) 
            {
                l_ids = null;
            }
            var sysOrgRep = Db.GetRepository<SysOrg>();
            var entities = await _rep.DetachedEntities
                                     .Join(sysOrgRep.DetachedEntities, n => n.OwnedOrg, o => o.Id, (n, o) => new DeviceInfoDto
                                     {
                                         DeviceName = n.DeviceName,
                                         DeviceNo   = n.DeviceNo,
                                         DeviceType = n.DeviceType,
                                         DModel= n.DModel,
                                         Voltage = n.Voltage,
                                         Electricity = n.Electricity,
                                         BatteryType = n.BatteryType,
                                         ICCID  = n.ICCID,
                                         FWVersion = n.FWVersion,
                                         OwnedOrg = n.OwnedOrg.ToString(),
                                         OwnedOrgName = o.Name,
                                         DeviceStatus = n.DeviceStatus,
                                         ManufactureDate = n.ManufactureDate,
                                         LastLoationDtime = n.LastLoationDtime,
                                         BlueToothID = n.BlueToothID,
                                         ActiveDtime = n.ActiveDtime,
                                         ExpiredDtime = n.ExpiredDtime,
                                         CarNo = n.CarNo,
                                         CarOwerName = n.CarOwerName,
                                         CarOwnerPhone = n.CarOwnerPhone,
                                         IconId = n.IconId,
                                         TenantId = n.TenantId,
                                         Id = n.Id
                                     })
                                     //.Join(sysOrgRep.DetachedEntities,n=>n.OwnedOrg,o=>o.Id,(n,o)=> new { n,o })
                                     .Where(l_ids  != null && input.deviceNos.Count > 0, u => l_ids.Contains(u.DeviceNo))
                                     .Select(u => u.Adapt<DeviceInfoDto>())
                                     .ToListAsync();
                                     //.ToPagedListAsync(1, 100);
            //var result = XnPageResult<DeviceInfoDto>.PageResult(entities);
            return entities;
        }


        public long GetCountFromOrg(long OrgId) 
        {
            var devices =  _rep.DetachedEntities.Where(u => u.OwnedOrg == OrgId).ToList();
            if(devices == null || devices.Count ==0 ) 
            {
                return 0;
            }
            else 
            {
                return devices.Count;
            }
        }
       
        /// <summary>
        /// 获取组织机构树
        /// </summary>
        /// <returns></returns>
        [HttpGet("/DeviceInfo/dtree")]
        public async Task<dynamic> GetDOrgTree()
        {
            var orgs = await _sysOrgService.GetOrgs2();
            List<DeviceTreeNode> orgs2 = new List<DeviceTreeNode>();
            if (orgs != null && orgs.Count >0  ) 
            {
                foreach(var org in orgs) 
                {
                    DeviceTreeNode node = new DeviceTreeNode();
                    node.Id = org.Id;
                    node.ParentId = org.ParentId;
                    node.Title = org.Title;
                    node.Value = org.Id.ToString();
                    node.Weight = org.Weight;
                    node.All_DeviceCount = 0;
                    node.Pids = org.Pids;
                    node.Pid = org.Pid;
                    node.Cur_DeviceCount =  GetCountFromOrg(org.Id);
                    orgs2.Add(node);
                }
                long l_parentID = 0;
                if (!_userManager.SuperAdmin) { 
                    bool b_flag;
                    foreach (var org in orgs)
                    {
                        l_parentID = org.Id;
                        b_flag = true;
                        foreach (var org_2 in orgs)
                        {
                            if (org_2.Id != l_parentID && !org_2.Pids.Contains(l_parentID.ToString()))
                            {
                                b_flag = false;
                                break;
                            }
                        }
                        if (b_flag)
                        {
                            break;
                        }
                    }
                }
                //return new TreeBuildUtil<OrgTreeNode>().Build(orgs, l_parentID);
                if (!_userManager.SuperAdmin) 
                {
                    orgs2 = new TreeBuildUtil<DeviceTreeNode>().Build(orgs2, l_parentID);
                }
                else 
                {
                    orgs2 = new TreeBuildUtil<DeviceTreeNode>().Build(orgs2);
                }
               
                orgs2 = DeviceTreeNode.SetPlusInfo(orgs2);
            }


            return orgs2;
            //return new TreeBuildUtil<OrgTreeNode>().Build(orgs);
        }

    }
}
