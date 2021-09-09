using Furion.Extras.Admin.NET;
using Furion.Extras.Admin.NET.Service;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.NET.Application
{
    public class DeviceTreeNode : ITreeNode
   {
        //全部
        public long All_DeviceCount { get; set; }

        //当前组织设备数量
        public long Cur_DeviceCount { get; set; }

        /// <summary>
        /// Id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 父Id
        /// </summary>
        public long ParentId { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 排序，越小优先级越高
        /// </summary>
        public int Weight { get; set; }

        public string Pids { get; set; }

        /// <summary>
        /// 子节点
        /// </summary>
        public List<DeviceTreeNode> Children { get; set; } = new List<DeviceTreeNode>();

        /// <summary>
        /// 上一级Id
        /// </summary>
        public long Pid { get; set; }

        public long GetId()
        {
            return Id;
        }

        public long GetPid()
        {
            return ParentId;
        }

        public void SetChildren(IList children)
        {
            Children = (List<DeviceTreeNode>)children;
        }

       

        public long GetChildCount(DeviceTreeNode node)
        {
            long l_childcount = 0;
            foreach (var child in node.Children)
            {
                l_childcount += child.Cur_DeviceCount;
                if (child.Children != null)
                {
                    l_childcount += GetChildCount(child);
                }
            }
            return l_childcount;
        }


        public long GetCurCount()
        {
            return this.Cur_DeviceCount;
        }
        

        public DeviceTreeNode SetChildrenCount(DeviceTreeNode node)
        {
            //node.All_DeviceCount = node.Cur_DeviceCount;
            foreach (var child in node.Children)
            {
                child.All_DeviceCount = child.Cur_DeviceCount;
                child.All_DeviceCount += GetChildCount(child);
                child.Title = child.Title + "[" + child.Cur_DeviceCount + "/" + child.All_DeviceCount + "]";
                if (child.Children != null && child.Children.Count > 0)
                {
                    SetChildrenCount(child);
                }
            }
            return node;
        }

        public static List<DeviceTreeNode> SetPlusInfo(List<DeviceTreeNode> nodes)
        {
            foreach (var node in nodes)
            {
                node.All_DeviceCount = node.Cur_DeviceCount + node.GetChildCount(node);
                node.Title = node.Title + "[" + node.Cur_DeviceCount + "/" + node.All_DeviceCount + "]";
                node.SetChildrenCount(node);
            }
            return nodes;
        }

    }


}
