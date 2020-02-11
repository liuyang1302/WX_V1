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
using Wx.Inter.Domain;
using Wx.Inter.Interface;
using Wx.Core;

namespace Wx.Inter.Request
{
    /// <summary>
    /// 创建分组请求
    /// </summary>
    public class CreateGroupRequest : RequestBase<CreateGroupResponse>, IMpRequest<CreateGroupResponse>
    {
        public string Method
        {
            get
            {
                return "POST";
            }
        }

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
        /// 需要POST发送的数据
        /// </summary>
        public string SendData { get; set; }


        /// <summary>
        /// 获取Api请求地址
        /// </summary>
        /// <returns></returns>
        public string GetReqUrl()
        {
            string urlFormat = "https://api.weixin.qq.com/cgi-bin/groups/create?access_token={0}";
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

        public CreateGroupResponse ParseHtmlToResponse(string body)
        {
            CreateGroupResponse response = new CreateGroupResponse();
            response.Body = body;

            if (response.HasError())
            {
                response.ErrInfo = response.GetErrInfo();
            }
            else
            {
                response.GroupInfo = new Group()
                {
                    id = Tools.GetJosnValue(body, "id"),
                    name = Tools.GetJosnValue(body, "name")
                };
            }
            return response;
        }
    }
}