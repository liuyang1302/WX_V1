/*
 * 微信公众平台C#版SDK
 * 版权: --刘洋
 * 日志: 2017-04-12 创建
*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Wx.Core;
using Wx.Inter.Domain;
using Wx.Inter.Interface;

namespace Wx.Inter
{
    /// <summary>
    /// 微信接口入口
    /// </summary>
    public class WxProcess
    {
        public static void Process(HttpContext context)
        {
            string _postString = string.Empty;
            if (context.Request.HttpMethod.ToUpper() == "POST")
            {
                string _result = string.Empty;
                ReceiveMessageBase _rmb = MessageHandler.ConvertMsgToObject(WxResource.Token);
                if (_rmb is TextReceiveMessage)
                {
                    TextReceiveMessage _trm = _rmb as TextReceiveMessage;
                    _postString = WxFactory.WxTextFactory(_trm);
                    if (string.IsNullOrEmpty(_postString))
                    {
                        context.Response.Write("success");
                        return;
                    }
                    Logger.WriteTxtLog(_trm.ToUserName + "|" + _trm.FromUserName + "|" + _trm.Content);
                    MessageHandler.SendTextReplyMessage(_rmb.ToUserName, _rmb.FromUserName, _postString);
                }
                else if (_rmb is VoiceReceiveMessage) //语音
                {
                    MessageHandler.DownloadMediaFileS(_rmb);
                }
            }
            else //获取开发者身份
            {
                GetInterfaceRole(context);
            }
        }

        /// <summary>
        /// 获取开发者身份
        /// </summary>
        public static void GetInterfaceRole(HttpContext context)
        {
            string token = "LIUCHENXI515";
            if (string.IsNullOrEmpty(token))
            {
                return;
            }

            string echoString = context.Request.QueryString["echoStr"];
            string signature = context.Request.QueryString["signature"];
            string timestamp = context.Request.QueryString["timestamp"];
            string nonce = context.Request.QueryString["nonce"];

            if (!string.IsNullOrEmpty(echoString))
            {
                context.Response.Write(echoString);
                context.Response.End();
            }
        }
    }
}
