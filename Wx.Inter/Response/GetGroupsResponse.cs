/*
 * 微信公众平台C#版SDK
 * 版权: --刘洋
 * 日志: 2017-04-12 创建
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wx.Inter.Domain;

namespace Wx.Inter.Response
{
    /// <summary>
    /// 查询所有分组回应信息
    /// </summary>
    public class GetGroupsResponse : MpResponse
    {
        /// <summary>
        /// 分组列表信息
        /// </summary>
        public Groups Groups { get; set; }
    }
}