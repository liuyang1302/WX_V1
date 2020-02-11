/*
 * 微信公众平台C#版SDK
 * 版权: --刘洋
 * 日志: 2017-04-12 创建
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wx.Inter.Response;
using System.Web.Script.Serialization;
using Wx.Inter.Interface;
using Wx.Inter.Domain;

namespace Wx.Inter.Request
{
    /// <summary>
    /// 菜单查询请求
    /// </summary>
    public class GetMenuRequest : RequestBase<GetMenuResponse>, IMpRequest<GetMenuResponse>
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
            string urlFormat = "https://api.weixin.qq.com/cgi-bin/menu/get?access_token={0}";
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

        public GetMenuResponse ParseHtmlToResponse(string body)
        {
            GetMenuResponse response = new GetMenuResponse();
            response.Body = body;

            if (response.HasError())
            {
                response.ErrInfo = response.GetErrInfo();
            }
            else
            {
                JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                MenuGroup mg = jsonSerializer.Deserialize<MenuGroup>(response.Body);
                response.Menu = mg;
            }
            return response;
        }
    }
}
