/*
 * 微信公众平台C#版SDK
 * 版权: --刘洋
 * 日志: 2017-04-12 创建
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wx.Inter.Domain
{
    /// <summary>
    /// AppId信息
    /// </summary>
    public class AppIdInfo
    {
        /// <summary>
        /// AppID
        /// </summary>
        public string AppID { get; set; }

        /// <summary>
        /// AppSecret
        /// </summary>
        public string AppSecret { get; set; }

        /// <summary>
        /// 回调地址
        /// </summary>
        public string CallBack { get; set; }
    }

    /// <summary>
    /// 默认AppId信息
    /// </summary>
    public class DefAppIdInfo : AppIdInfo
    {
        public DefAppIdInfo()
        {
            AppID = WxResource.AppId;
            AppSecret = WxResource.AppSecret;
        }
    }
}
