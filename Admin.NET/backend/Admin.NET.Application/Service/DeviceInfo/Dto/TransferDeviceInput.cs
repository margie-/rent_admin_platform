using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.NET.Application
{
    public class TransferDeviceInput
    {
        /// <summary>
        /// 所属门店
        /// </summary>
        public virtual string OwnedOrg { get; set; }

        //批量转移的设备ID transferDeviceList
        public virtual List<string> TransferDeviceList { get; set; } = new List<string>();

    }
}
