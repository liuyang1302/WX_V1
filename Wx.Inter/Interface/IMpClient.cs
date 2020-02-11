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

namespace Wx.Inter.Interface
{
    /// <summary>
    /// 微信公众平台客户端接口
    /// </summary>
    public interface IMpClient
    {
        /// <summary>
        /// 执行微信公众平台API请求
        /// </summary>
        /// <typeparam name="T">领域对象</typeparam>
        /// <param name="request">具体的微信公众平台请求</param>
        /// <returns>领域对象</returns>
        T Execute<T>(IMpRequest<T> request) where T : MpResponse;
    }
}
