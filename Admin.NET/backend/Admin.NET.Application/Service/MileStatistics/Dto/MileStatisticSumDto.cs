using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.NET.Application
{
    /// <summary>
    /// 里程统计汇总信息
    /// </summary>
    public class MileStatisticSumDto
    {
        /// <summary>
        ///设备名称
        /// </summary>
        public string DeviceName { get; set; }
        /// <summary>
        /// 设备编号
        /// </summary>
        public string DeviceNo { get; set; }
        /// <summary>
        /// 总里程数
        /// </summary>
        public decimal SumMileCount { get; set; }
        /// <summary>
        /// 每公里油耗
        /// </summary>
        public decimal PerOilUsed { get; set; }
        /// <summary>
        /// 当日公里数
        /// </summary>
        public decimal CurDayMileCount { get; set; }


        /// <summary>
        /// 当日油耗
        /// </summary>
        public decimal DayOilUsed { get; set; }

        /// <summary>
        /// 当月公里数
        /// </summary>
        public decimal CurMonMileCount { get; set; }


        /// <summary>
        ///当月油耗
        /// </summary>
        public decimal MonOilUsed { get; set; }


        /// <summary>
        /// 当年公里数
        /// </summary>
        public decimal CurYearMileCount { get; set; }


        /// <summary>
        /// 当年油耗
        /// </summary>
        public decimal YearOilUsed { get; set; }

        /// <summary>
        /// 最后定位时间
        /// </summary>
        public string LastLoationDtime { get; set; }

    }
}
