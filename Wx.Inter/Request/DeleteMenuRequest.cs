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
using Wx.Inter.Interface;
using Wx.Inter.Response;

namespace Wx.Inter.Request
{
    /// <summary>
    /// 删除菜单请求信息
    /// </summary>
    public class DeleteMenuRequest : RequestBase<DeleteMenuResponse>, IMpRequest<DeleteMenuResponse>
    {
        public string Method
        {
            get
            {
                return "GET";
            }
        }

        /// <summary>
        /// 需要POST发送的数据
        /// </summary>
        public string SendData { get; set; }

        /// <summary>
        /// 调用接口凭证 
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// AppId信息
        /// </summary>
        public AppIdInfo AppIdInfo
        {
            get;
            set;
        }

        /// <summary>
        /// 获取Api请求地址
        /// </summary>
        /// <returns></returns>
        public string GetReqUrl()
        {
            string urlFormat = "https://api.weixin.qq.com/cgi-bin/menu/delete?access_token={0}";
            string url = string.Format(urlFormat, AccessToken);
            return url;
        }

        public IDictionary<string, string> GetParameters()
        {
            return new Dictionary<string, string>();
        }

        public void Validate()
        {

        }

        public DeleteMenuResponse ParseHtmlToResponse(string body)
        {
            DeleteMenuResponse response = new DeleteMenuResponse();
            response.Body = body;

            if (response.HasError())
            {
                response.ErrInfo = response.GetErrInfo();
            }
            else
            {
               
            }
            return response;
        }
    }
}