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
    /// access_token实体类
    /// </summary>
    public class AccessTokenInfo
    {
        /// <summary>
        /// access_token
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// 凭证有效时间，单位：秒 
        /// </summary>
        public long ExpiresIn { get; set; }
    }
}
