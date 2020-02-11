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
    /// 多媒体文件下载回应信息
    /// </summary>
    public class DownloadMediaResponse : MpResponse
    {
        /// <summary>
        /// 下载文件保存路径
        /// </summary>
        public string SaveFileName { get; set; }
    }
}