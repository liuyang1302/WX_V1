﻿/*
 * 微信公众平台C#版SDK
 * 版权: --刘洋
 * 日志: 2017-04-12 创建
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wx.Core;
using Wx.Inter.Domain;
using Wx.Inter.Interface;
using Wx.Inter.Response;

namespace Wx.Inter.Request
{
    /// <summary>
    ///  通过用户的OpenID查询其所在的GroupID请求信息
    /// </summary>
    public class GetUserGroupRequest : RequestBase<GetUserGroupResponse>, IMpRequest<GetUserGroupResponse>
    {
        public string Method
        {
            get
            {
                return "POST";
            }
        }

        /// <summary>
        /// 要查询的用户的openid 
        /// </summary>
        public string UserId
        {
            get;
            set;
        }

        /// <summary>
        /// 需要POST发送的数据
        /// </summary>
        public string SendData
        {
            get
            {
                return "{\"openid\":\"" + UserId + "\"}";
            }
           set
           {
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
        /// 获取Api请求地址
        /// </summary>
        /// <returns></returns>
        public string GetReqUrl()
        {
            string urlFormat = "https://api.weixin.qq.com/cgi-bin/groups/getid?access_token={0}";
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

        public GetUserGroupResponse ParseHtmlToResponse(string body)
        {
            GetUserGroupResponse response = new GetUserGroupResponse();
            response.Body = body;

            if (response.HasError())
            {
                response.ErrInfo = response.GetErrInfo();
            }
            else
            {
                response.GroupId = Tools.GetJosnValue(body, "groupid");
            }
            return response;
        }
    }
}