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
using Wx.Inter.Domain;
using Wx.Inter.Interface;

namespace Wx.Inter.Request
{
    /// <summary>
    /// 查询所有分组请求
    /// </summary>
    public class GetGroupsRequest : RequestBase<GetGroupsResponse>, IMpRequest<GetGroupsResponse>
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
            string urlFormat = "https://api.weixin.qq.com/cgi-bin/groups/get?access_token={0}";
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

        public GetGroupsResponse ParseHtmlToResponse(string body)
        {
            GetGroupsResponse response = new GetGroupsResponse();
            response.Body = body;

            if (response.HasError())
            {
                response.ErrInfo = response.GetErrInfo();
            }
            else
            {
                JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                Groups mg = jsonSerializer.Deserialize<Groups>(response.Body);
                response.Groups = mg;
            }
            return response;
        }
    }
}