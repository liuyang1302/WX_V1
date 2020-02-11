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
    /// 微信公众平台接口调用返回码以及返回信息实体类
    /// </summary>
    public class ErrInfo
    {
        /// <summary>
        /// 返回码
        /// </summary>
        public long ErrCode { get; set; }

        /// <summary>
        /// 返回信息
        /// </summary>
        public string ErrMsg { get; set; }
    }
}