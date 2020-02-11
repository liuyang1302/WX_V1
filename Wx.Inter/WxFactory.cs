using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using Wx.Core;
using Wx.Inter.Domain;

namespace Wx.Inter
{
    public class WxFactory
    {
        public WxFactory()
        {
            if (WxResource.Users == null)
            {
                LoadUsers();
            }
        }


        public string WxTextBranchFactory(TextReceiveMessage trm)
        {
            string _result = string.Empty;
            switch (trm.Content)
            {
                case "1":
                    _result = ResultStr(trm, WxResource.InterWxAccBill, "随手记");
                    break;
                case "2":
                    _result = ResultStr(trm, WxResource.InterWxAccount, "记一笔");
                    break;
                case "3":
                    _result = ResultStr(trm, WxResource.InterWxIncome, "收一笔");
                    break;
                case "4":
                    _result = ResultStr(trm, WxResource.InterWxReport, "报一报");
                    break;
                case "5":
                    _result = ResultStr(trm, WxResource.InterWxQues, "答答题,提提高");
                    break;
                case "11":
                    _result = ResultStr(trm, WxResource.InterWxSms, "查短信");
                    break;
                case "12":
                    _result = ResultStr(trm, WxResource.InterWpCode, "电子码");
                    break;
                case "IP":
                    _result = Tools.GetExtenalIpAddress();
                    break;
                case "0":
                    _result = ResultStr(trm, WxResource.InterWxSchool, "汐汐学习");
                    break;
                case "a":
                case "00":
                    _result = ResultStr(trm, WxResource.InterWxHisInfo, "客户信息");
                    break;
            }
            if (!string.IsNullOrEmpty(_result))
                return _result;
            if (trm.Content.IndexOf("注册 ") == 0)
            {
                _result = RegUser(trm);
            }
            else
            {
                //直接记账处理
                _result = SaveOutBill(trm);
                if (_result != string.Empty)
                {
                    return _result;
                }
            }

            return _result;
        }


        #region 私有
        /// <summary>
        /// 返回的链接字符串
        /// </summary>
        /// <param name="trm"></param>
        /// <param name="url"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        private string ResultStr(TextReceiveMessage trm, string url, string content)
        {
            string _nickName = string.Empty;
            if (WxResource.Users != null)
            {
                var _query = WxResource.Users.FirstOrDefault(r => r.OpenId == trm.FromUserName);
                if (_query != null) _nickName = _query.NickName;
            }
            string _reurl = string.Format(url, trm.FromUserName, _nickName);
            return string.Format(WxResource.PostInterString, _reurl, content);
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        private void LoadUsers()
        {
            DataTable _dt = DataAgent.WxUser.LoadAllUser();
            if (_dt == null || _dt.Rows.Count == 0) return;
            WxResource.Users = new List<User>();
            foreach (DataRow _dr in _dt.Rows)
            {
                WxResource.Users.Add(new User() { OpenId = _dr.Str("OpenId"), NickName = _dr.Str("NickName") });
            }
        }

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="trm"></param>
        /// <returns></returns>
        private string RegUser(TextReceiveMessage trm)
        {
            bool _result = DataAgent.WxUser.SaveWxUser(trm.FromUserName, trm.Content.Replace("注册 ", ""));
            if (_result)
            {
                LoadUsers();
                return "注册成功！";
            }
            return "注册失败！";
        }

        /// <summary>
        /// 自动根据“名称 金额”保存记账记录
        /// </summary>
        /// <param name="trm"></param>
        /// <returns></returns>
        private string SaveOutBill(TextReceiveMessage trm)
        {
            string _result = string.Empty;
            string _content = trm.Content;
            if (string.IsNullOrEmpty(_content))
                return _result;
            string[] _jzs = new string[] { _content };
            if (_content.Contains("\r\n"))
            {
                _jzs = _content.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            }
            foreach (string _jz in _jzs)
            {
                string _jzcontent = MatchMoney(_jz);
                if (string.IsNullOrEmpty(_jzcontent)) continue;
                char _char = _jzcontent.Contains(" ") ? ' ' : '=';
                string[] _jzvals = _jzcontent.Split(_char);
                bool _is = DataAgent.OutBill.SaveOutBill(trm.FromUserName, _jzvals[0], _jzvals[1]);
                if (!_is)
                {
                    return _jzcontent + " 保存失败，请进入查看记账记录！";
                }
                _result = ResultStr(trm, WxResource.InterWxReport, "保存成功，请进入查看记账记录！");
            }
            return _result;
        }

        private string MatchMoney(string p_content)
        {
            if (!(p_content.Contains(" ") || p_content.Contains("=")))
                return string.Empty;

            if (!(p_content.Split(' ').Length == 2 || p_content.Split('=').Length == 2))
                return string.Empty;

            Regex regex = new Regex("^.*[\\s|=][0-9]+(.[0-9]{1,2})?");
            Match match = regex.Match(p_content);
            //匹配成功，返回匹配之后的结果
            if (match.Success)
                return match.Value;
            //匹配失败，返回原字符串
            return string.Empty;
        }

        #endregion

        #region 公共
        public static string WxTextFactory(TextReceiveMessage trm)
        {
            return new WxFactory().WxTextBranchFactory(trm);
        }

        #endregion

    }
}
