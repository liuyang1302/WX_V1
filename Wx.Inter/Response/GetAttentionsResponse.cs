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
    /// 获取关注者列表请求回应信息
    /// </summary>
    public class GetAttentionsResponse : MpResponse 
    {
        /// <summary>
        /// 关注者列表数据
        /// </summary>
        public Attentions Attentions { get; set; }
    }
}