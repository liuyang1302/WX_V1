using System.Data;
using System.Net;
using System.Text;
using System.Web;

namespace Wx.Work.Share
{
    public class ShareService : WxServiceBase
    {
        public override string GetResult(HttpContext context)
        {
            base.GetResult(context);
            string _result = string.Empty;
            switch (_type)
            {
                case "股票列表_增加":
                    _result = ShareList();
                    break;

            }
            return _result;
        }

        private string ShareList()
        {
            //string _fist = "sh";
            //string _code = "000001";
            //string _scode = _fist + _code;
            //string _str = GetSearch(_scode);
            //_str = _str.Substring(_str.IndexOf("\"") + 1);

            //string[] _val = _str.Split(',');
            //AddShareList(_scode, _val[0].Trim().Replace(" ", ""));
            //return "";

            //string _fist = "sz";
            //int _code = 000001;
            //int _index = 100000;
            //for (int i = 0; i < _index; i++)
            //{
            //    int _ncode = _code + i;
            //    string _ccode = _fist + _ncode.ToString().PadLeft(6, '0');
            //    string _str = GetSearch(_ccode);
            //    if (string.IsNullOrEmpty(_str)) continue;
            //    _str = _str.Substring(_str.IndexOf("\"") + 1);
            //    if (_str.Length < 30) continue;
            //    string[] _val = _str.Split(',');
            //    AddShareList(_ccode, _val[0].Trim().Replace(" ", ""));
            //}
            //return "OK";

            //string _sql = "select * from 股票列表";
            //string _upsql = "update 股票列表 set 简码 = '{0}' where id = {1}";
            //DataTable _dt = ShareData.Query(_sql);
            //foreach (DataRow dr in _dt.Rows)
            //{
            //    ShareData.ExecNonQuery(string.Format(_upsql, Tools.ToChineseSpell(dr.Str("名称")), dr.Str("id")));
            //}
            //return "OK";
            return "OK";

            //Tools.ToChineseSpell(dr.Str("名称"))

            //string _sql = "select * from 股票列表";
            //DataTable _dt = ShareData.Query(_sql);
            //foreach (DataRow dr in _dt.Rows)
            //{
            //    dr.Str( )
            //}


        }

        public string AddShareList(string p_code, string p_name)
        {
            if (string.IsNullOrEmpty(p_code))
            {
                string _max = "select max(编码) as 编码 from 股票列表 ";
                DataTable _maxdt = ShareData.Query(_max);
                if (_maxdt != null && _maxdt.Rows.Count > 0)
                    return _maxdt.Rows[0]["编码"].ToString();
                return "";
            }

            string _sql = "select * from 股票列表 where 编码 = '" + p_code + "'";
            DataTable _dt = ShareData.Query(_sql);
            if (_dt != null && _dt.Rows.Count > 0)
                return "0";
            _sql = string.Format("insert into 股票列表(编码,名称) values ('{0}','{1}')", p_code, p_name);
            int i = ShareData.ExecNonQuery(_sql);
            return i.ToString();
        }

        private string GetSearch(string p_code)
        {
            if (string.IsNullOrEmpty(p_code))
                return "";

            //string _result = string.Empty;
            //string _url = string.Format("http://hq.sinajs.cn/list={0}", p_code);
            //HttpWebRequest myHttpWebRequest = System.Net.WebRequest.Create(_url) as HttpWebRequest;
            //myHttpWebRequest.KeepAlive = false;
            //myHttpWebRequest.AllowAutoRedirect = false;
            //myHttpWebRequest.UserAgent = "Mozilla/5.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 2.0.50727)";
            //myHttpWebRequest.Timeout = 10000;
            //myHttpWebRequest.ContentType = "application/x-www-form-urlencoded;charset=utf-8";
            //using (HttpWebResponse res = (HttpWebResponse)myHttpWebRequest.GetResponse())
            //{
            //    if (res.StatusCode == HttpStatusCode.OK || res.StatusCode == HttpStatusCode.PartialContent)//返回为200或206
            //    {
            //        string dd = res.ContentEncoding;
            //        System.IO.Stream strem = res.GetResponseStream();
            //        System.IO.StreamReader r = new System.IO.StreamReader(strem);
            //        string _str = r.ReadToEnd();

            //        if (string.IsNullOrEmpty(_str))
            //            return "";

            //        _result = _str;
            //    }
            //}
            //return _result;

            string _url = string.Format("http://hq.sinajs.cn/list={0}", p_code);
            WebClient _wc = new WebClient();
            _wc.Encoding = Encoding.Default;
            string _str = _wc.DownloadString(_url);
            return _str;
        }




    }
}
