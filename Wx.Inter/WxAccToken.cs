/*
 * 微信公众平台C#版SDK
 * 版权: --刘洋
 * 日志: 2017-04-12 创建
*/
using System;
using Wx.Core;
using Wx.Inter.Domain;
using Wx.Inter.Interface;
using Wx.Inter.Request;
using Wx.Inter.Response;

namespace Wx.Inter
{
    /// <summary>
    /// 处理调用AccessToken
    /// </summary>
    public class WxAccToken
    {
        private static AccessTokenInfo _accessToken;
        private static DateTime _expTime = DateTime.Now;
        

        /// <summary>
        /// 获取AccessToken字符串
        /// </summary>
        public static string AccessTokenStr
        {
            get
            {
                return AccessToken.AccessToken;
            }
        }

        /// <summary>
        /// 获取AccessToken
        /// </summary>
        public static AccessTokenInfo AccessToken
        {
            get
            {
                return GetAccessToken();
            }
        }

        /// <summary>
        /// 获取AccessToken
        /// </summary>
        /// <returns></returns>
        private static AccessTokenInfo GetAccessToken()
        {
            DateTime _now = DateTime.Now;
            //有效时间到 从新获取AccessToken
            if (_accessToken == null || _now >= _expTime)
            {
                IMpClient mpClient = new MpClient();
                AccessTokenGetRequest request = new AccessTokenGetRequest() { AppIdInfo = new DefAppIdInfo() };
                AccessTokenGetResponse response = mpClient.Execute(request);
                if (response.IsError)
                {
                    Logger.WriteTxtLog(string.Format("获取AccessToken发生错误，错误编码为：{0}，错误消息为：{1}", response.ErrInfo.ErrCode, response.ErrInfo.ErrMsg));
                    _accessToken = null;
                    return null;
                }
                _accessToken = response.AccessToken;
                _expTime = _now.AddSeconds(_accessToken.ExpiresIn - 10);
                Logger.WriteTxtLog(string.Format("获取到AccessToken，值为：{0}，有效期：{1}秒", response.AccessToken.AccessToken, response.AccessToken.ExpiresIn));
            }
            return _accessToken;
        }
    }
}
