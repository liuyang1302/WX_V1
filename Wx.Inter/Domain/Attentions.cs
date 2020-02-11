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
    /// 关注者列表
    /// </summary>
    public class Attentions
    {
        public int total { get; set; }
        public int count { get; set; }
        public string next_openid { get; set; }
        public AttentionsData data { get; set; }
    }

    /// <summary>
    /// 关注者列表数据
    /// </summary>
    public class AttentionsData
    {
        public List<string> openid { get; set; }
    }
}