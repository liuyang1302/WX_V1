/*
 * 微信公众平台C#版SDK
 * 版权: --刘洋
 * 日志: 2017-04-12 创建
*/
using System.Data;
using Wx.Core;
using Wx.Inter.Domain;
using Wx.Inter.Interface;
using Wx.Inter.Request;
using Wx.Inter.Response;

namespace Wx.Inter
{
    /// <summary>
    /// 微信SDK功能代理
    /// </summary>
    public class WxAgent
    {
        public static string GetAccessToken()
        {
            return WxAccToken.AccessTokenStr;
        }

        /// <summary>
        /// 获取用户基本信息
        /// </summary>
        /// <param name="OpenID"></param>
        /// <returns></returns>
        public static User GetWxUser(string OpenID)
        {
            IMpClient mpClient = new MpClient();
            GetUserInfoRequest request = new GetUserInfoRequest() { AppIdInfo = new DefAppIdInfo(), AccessToken = WxAccToken.AccessTokenStr, OpenId = OpenID };
            GetUserInfoResponse response = mpClient.Execute(request);
            if (response.IsError)
            {
                Logger.WriteTxtLog(string.Format("获取USER发生错误，错误编码为：{0}，错误消息为：{1}", response.ErrInfo.ErrCode, response.ErrInfo.ErrMsg));
                return null;
            }
            return response.UserInfo;
        }

        public static User GetDataUser(string OpenID)
        {
            User _user = new User() { OpenId = OpenID, NickName = string.Empty };
            DataTable _dt = DataAgent.WxUser.LoadWxUser(OpenID);
            if (_dt != null && _dt.Rows.Count == 1)
            {
                _user = new User();
                DataRow _dr = _dt.Rows[0];
                _user.SubScribe = _dr.Str("SubScribe");
                _user.OpenId = OpenID;
                _user.NickName = _dr.Str("NickName");
                _user.Sex = _dr.Str("Sex");
                _user.Language = _dr.Str("Language");
                _user.City = _dr.Str("City");
                _user.Province = _dr.Str("Province");
                _user.Country = _dr.Str("Country");
                _user.HeadImgUrl = _dr.Str("HeadImgUrl");
                _user.SubscribeTime = _dr.Str("SubscribeTime");
            }
            return _user;

            //以下获取基本信息个人订阅号接口未授权
            //_user = GetWxUser(OpenID);
            //if (_user == null) return null;
            //DataAgent.WxUser.SaveWxUser(_user.SubScribe, _user.OpenId, _user.NickName, _user.Sex, _user.Language, _user.City, _user.Province, _user.Country, _user.HeadImgUrl, _user.SubscribeTime);
            //return _user;
        }
    }
}
