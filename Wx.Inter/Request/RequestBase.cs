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

namespace Wx.Inter.Request
{
    /// <summary>
    /// 请求基类
    /// </summary>
    public abstract class RequestBase<T> where T : MpResponse 
    {
        /* 测试账号申请地址
         *  http://mp.weixin.qq.com/debug/cgi-bin/sandbox?t=sandbox/login
        */

        /// <summary>
        /// 获取默认AppInfo信息
        /// </summary>
        /// <returns></returns>
        protected AppIdInfo GetDefaultAppIdInfo()
        {
            AppIdInfo info = new AppIdInfo()
            {
                AppID = WxResource.AppId,
                AppSecret = WxResource.AppSecret,
                CallBack = "3"
            };
            return info;
        }

    }
}

