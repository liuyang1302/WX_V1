using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Web;
using Wx.Core;

namespace Wx.Work.Htn
{
    public class HtnProServiceUser : WxServiceBase
    {
        public override string GetResult(HttpContext context)
        {
            base.GetResult(context);

            string _result = string.Empty;

            if (_type == "IsUser") //验证是否老用户
            {
                _result = IsUser();
            }
            else if (_type == "RegUser") // 注册绑定新用户
            {
                _result = RegUser();
            }

            return _result;
        }

        public string IsUser()
        {
            //{"session_key":"uhmdvbrzNFFeHqVSovUXMQ==","openid":"o9NIP5S8jX98UDC76D-6KwrtbOJU"}
            string _code = Params["Code"];
            WxOpenInfo _openinfo = new WxOpenInfo(_code);
            if (string.IsNullOrEmpty(_openinfo.OpenId)) { return ""; }
            string _sql = string.Format("SELECT * FROM WX_User WHERE OpenId = '{0}'", _openinfo.OpenId);
            DataTable _dt = HtnData.Query(_sql);
            return _openinfo.OpenId + "|" + HtnData.DataToWx(_dt); ;
        }

        public string RegUser()
        {
            string _openid = Params["OpenId"];
            string _sql = string.Format("SELECT * FROM WX_User WHERE OpenId = '{0}'", _openid);
            DataTable _dt = HtnData.Query(_sql);
            if (_dt != null && _dt.Rows.Count > 0)
            {
                return _openid + "|" + HtnData.DataToWx(_dt);
            }


            string _nickName = Params["nickName"];
            string _suffname = Params["suffname"];
            string _suffphone = Params["suffphone"];
            DataTable _suffdt = null;
            string _suffsql = string.Empty;

            if (!string.IsNullOrEmpty(_suffphone))
            {
                _suffsql = string.Format("select * from htn_sufferer where handphone = '{0}'", _suffphone);
                _suffdt = HtnData.Query(_suffsql);
                if (_suffdt == null || _suffdt.Rows.Count == 0)
                {
                    _suffsql = string.Format("select * from htn_sufferer where sufferername = '{0}'", _suffname);
                    _suffdt = HtnData.Query(_suffsql);
                }
            }
            else if (!string.IsNullOrEmpty(_suffname))
            {
                _suffsql = string.Format("select * from htn_sufferer where sufferername = '{0}'", _suffname);
                _suffdt = HtnData.Query(_suffsql);
            }

            List<OleDbParameter> _sqlparams = new List<OleDbParameter>();
            _sqlparams.Add(new OleDbParameter() { ParameterName = "V001", Value = _nickName });
            _sqlparams.Add(new OleDbParameter() { ParameterName = "V002", Value = Params["gender"] });
            _sqlparams.Add(new OleDbParameter() { ParameterName = "V003", Value = Params["city"] });
            _sqlparams.Add(new OleDbParameter() { ParameterName = "V004", Value = _openid });


            if (_suffdt == null || _suffdt.Rows.Count == 0)
            {
                _sqlparams.Add(new OleDbParameter() { ParameterName = "V005", Value = "" });
                _sqlparams.Add(new OleDbParameter() { ParameterName = "V006", Value = "" });
                _sqlparams.Add(new OleDbParameter() { ParameterName = "V007", Value = "" });
            }
            else
            {
                DataRow _dr = _suffdt.Rows[0];
                _sqlparams.Add(new OleDbParameter() { ParameterName = "V005", Value = _dr.Str("BarCode") });
                _sqlparams.Add(new OleDbParameter() { ParameterName = "V006", Value = (_dr.Str("SuffererName") == "" ? _suffname : _dr.Str("SuffererName")) });
                _sqlparams.Add(new OleDbParameter() { ParameterName = "V007", Value = (_dr.Str("HandPhone") == "" ? _suffphone : _dr.Str("HandPhone")) });

            }

            _sql = "insert into WX_User (nickName, gender, city, OpenId, BarCode, SuffName, SuffPhone) values (:V001, :V002, :V003, :V004, :V005, :V006, :V007 )";

            int i = HtnData.ExecNonQuery(_sql, _sqlparams);

            if (i > 0)
            {
                _sql = string.Format("SELECT * FROM WX_User WHERE OpenId = '{0}'", _openid);
                _dt = HtnData.Query(_sql);
                return _openid + "|" + HtnData.DataToWx(_dt);
            }

            return "";
        }
    }

    public class WxOpenInfo
    {
        public string Code { get; private set; }
        public string Session_Key { get; private set; }
        public string OpenId { get; private set; }

        public WxOpenInfo(string p_code)
        {
            Code = p_code;
            string _openstr = AtWeb.GetWxOpenid(p_code);
            if (string.IsNullOrEmpty(_openstr)) return;
            _openstr = _openstr.Replace("{", "").Replace("}", "").Replace("\"", "");
            string[] _vals = _openstr.Split(',');
            Session_Key = _vals[0].Split(':')[1];
            OpenId = _vals[1].Split(':')[1];
        }
    }
}
