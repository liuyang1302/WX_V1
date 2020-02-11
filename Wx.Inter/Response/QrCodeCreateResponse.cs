/*
 * 微信公众平台C#版SDK
 * 版权: --刘洋
 * 日志: 2017-04-12 创建
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wx.Inter.Response
{
    /// <summary>
    /// 创建二维码回应信息
    /// </summary>
    public class QrCodeCreateResponse : MpResponse
    {
        /// <summary>
        /// 获取的二维码ticket，凭借此ticket可以在有效时间内换取二维码。 
        /// </summary>
        public string Ticket { get; set; }

        /// <summary>
        /// 二维码的有效时间，以秒为单位。最大不超过1800
        /// </summary>
        public int ExpireSeconds { get; set; }

        /// <summary>
        /// 二维码链接Url
        /// </summary>
        public string QrCodeUrl
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Ticket))
                {
                    return string.Empty;
                }
                else
                {
                    return "https://mp.weixin.qq.com/cgi-bin/showqrcode?ticket=" + Ticket;
                }
            }
        }

        /// <summary>
        /// 二维码本地存储目录（如果请求中设置了本地存储目录的话，则会生成本地文件路径）
        /// </summary>
        public string LocalFilePath
        {
            get;
            set;
        }
    }
}