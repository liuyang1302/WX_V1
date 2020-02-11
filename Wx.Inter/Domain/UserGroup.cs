/*
 * 微信公众平台C#版SDK
 * 版权: --刘洋
 * 日志: 2017-04-12 创建
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wx.Inter.Domain
{
    /// <summary>
    /// 用户分组
    /// </summary>
    public class Groups
    {
        /// <summary>
        /// 公众平台分组信息列表 
        /// </summary>
        public List<Group> groups { get; set; }
    }

    /// <summary>
    /// 分组信息
    /// </summary>
    public class Group
    {
        /// <summary>
        /// 分组id，由微信分配 
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// 分组名字，UTF8编码 
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 分组内用户数量 
        /// </summary>
        public int count { get; set; }

        /// <summary>
        /// 创建分组数据包
        /// </summary>
        /// <returns></returns>
        public string ToCreateJsonString()
        {
            string s = "{\"group\":{\"name\":\"" + name + "\"}}";
            return s;
        }

        /// <summary>
        /// 修改分组信息数据包
        /// </summary>
        /// <returns></returns>
        public string ToModifyJsonString()
        {
            string s = "{\"group\":{\"id\":" + id + ",\"name\":\"" + name + "\"}}";
            return s;
        }
    }
}
