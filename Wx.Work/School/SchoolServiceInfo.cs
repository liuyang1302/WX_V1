using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Wx.Core;

namespace Wx.Work.School
{
    public class SchoolServiceInfo : WxServiceBase
    {
        private string _params;
        private string _typeid;
        private string _tindex;
        private string _clean;
        private string _filter;
        private static Dictionary<string, List<int>> _jlc;
        private static Dictionary<string, List<string>> _dic;
        private static List<string> _lsz;
        private static List<string> _lyz;
        private static string _szjstr;

        public override string GetResult(HttpContext context)
        {
            base.GetResult(context);
            _params = context.Request.Params["Params"];
            _typeid = context.Request.Params["TypeId"];
            _tindex = context.Request.Params["TIndex"];
            _clean = context.Request.Params["Clean"];
            _filter = context.Request.Params["Filter"];

            string _result = string.Empty;
            switch (_type)
            {
                case "分类目录":
                    _result = GetflList();
                    break;
                case "语文":
                    _result = GetYwList();
                    break;
                case "数学":
                    _result = GetSxList();
                    break;
                case "下一题":
                    _result = GetSxNext(_typeid, _tindex);
                    break;
                case "生字表":
                    _result = GetSzList();
                    break;
                case "生字":
                    _result = GetSzNext();
                    break;
                case "三字经":
                    _result = GetSzj();
                    break;
                case "查询":
                    _result = GetSearch();
                    break;
                case "语音列表":
                    _result = GetVoices();
                    break;
                case "语音文件":
                    _result = GetVoiceFile(context.Request.Params["FileName"]);
                    break;


            }
            return _result;
        }

        private string GetflList()
        {
            string _result = string.Empty;
            string _sql = "select * from 分类目录";
            DataTable _dt = SchoolData.Query(_sql);
            foreach (DataRow dr in _dt.Rows)
            {
                _result += dr.Str("ID") + "," + dr.Str("名称") + "," + dr.Str("类别") + "|";
            }
            return _result.TrimEnd('|');
        }

        private string GetYwList()
        {
            string _result = string.Empty;
            string _sql = "select * from 分类目录 where 类别 = '语文1'";
            DataTable _dt = SchoolData.Query(_sql);
            foreach (DataRow dr in _dt.Rows)
            {
                _result += dr.Str("ID") + "," + dr.Str("名称") + "," + dr.Str("类别") + "|";
            }
            return _result.TrimEnd('|');
        }

        private string GetSxList()
        {
            string _result = string.Empty;
            string _sql = "select * from 分类目录 where 类别 = '数学1'";
            DataTable _dt = SchoolData.Query(_sql);
            foreach (DataRow dr in _dt.Rows)
            {
                _result += dr.Str("ID") + "," + dr.Str("名称") + "," + dr.Str("类别") + "|";
            }
            return _result.TrimEnd('|');
        }

        /// <summary>
        /// 下一题
        /// </summary>
        /// <param name="p_type"></param>
        /// <param name="p_id"></param>
        /// <returns></returns>
        private string GetSxNext(string p_type, string p_id = "")
        {
            string _result = string.Empty;
            if (_jlc == null)
            {
                _jlc = new Dictionary<string, List<int>>();
            }
            if (_dic == null)
            {
                _dic = new Dictionary<string, List<string>>();
            }

            if (!_dic.ContainsKey(p_type))
            {
                List<string> _list = new List<string>();
                string _sql = string.Empty;
                if (p_type == "5")
                {
                    _sql = "select * from 题目内容 where 类型 in ('3','4')";
                }
                else
                {
                    _sql = "select * from 题目内容 where 类型 = '" + p_type + "'";
                }
                DataTable _dt = SchoolData.Query(_sql);
                foreach (DataRow _dr in _dt.Rows)
                {
                    _list.Add(_dr.Str("ID") + "," + _dr.Str("题目") + "," + _dr.Str("答案"));
                }
                _dic[p_type] = _list;
                _jlc[p_type] = new List<int>();
            }

            if (_jlc[p_type].Count == _dic[p_type].Count)
            {
                _jlc[p_type].Clear();
            }

            int _index = 0;
            for (int i = 0; i < _dic[p_type].Count; i++)
            {
                Random _r = new Random();
                _index = _r.Next(_dic[p_type].Count);
                if (!_jlc[p_type].Contains(_index))
                {
                    _jlc[p_type].Add(_index);
                    _result = _dic[p_type][_index];
                    break;
                }
            }

            _result = _dic[p_type].Count + "|" + _jlc[p_type].Count + "|" + _result;
            return _result;
        }

        /// <summary>
        /// 生字表
        /// </summary>
        /// <returns></returns>
        private string GetSzList()
        {
            string _result = string.Empty;
            string _sql = "select * from 题目内容 where 类型 = '2'";
            DataTable _dt = SchoolData.Query(_sql);
            foreach (DataRow _dr in _dt.Rows)
            {
                _result += _dr.Str("题目") + "," + _dr.Str("答案") + "|";
            }
            return _result.TrimEnd('|');
        }

        /// <summary>
        /// 生字
        /// </summary>
        /// <returns></returns>
        private string GetSzNext()
        {
            string _result = string.Empty;
            if (_clean == "1" && _lyz != null)
            {
                _lyz.Clear();
            }

            if (_lsz == null || _lsz.Count == 0)
            {
                _lsz = new List<string>();
                _lyz = new List<string>();
                string _sql = "select * from 题目内容 where 类型 = '2'";
                DataTable _dt = SchoolData.Query(_sql);
                for (int i = 0; i < _dt.Rows.Count; i++)
                {
                    DataRow _dr = _dt.Rows[i];
                    _lsz.Add((i + 1) + "|" + _dr.Str("题目") + "|" + _dr.Str("答案"));
                }
            }

            int _index = 0;
            if (_lyz.Count > 0)
            {
                _index = _lsz.IndexOf(_lyz.Last());
                _index++;
            }
            if (_index >= _lsz.Count - 1)
            {
                _index = 0;
            }
            _result = _lsz[_index];
            _lyz.Add(_result);
            return _result;
        }

        /// <summary>
        /// 三字经
        /// </summary>
        private string GetSzj()
        {
            if (string.IsNullOrEmpty(_szjstr))
            {
                string _sql = "select * from 三字经 order by id";
                DataTable _dt = SchoolData.Query(_sql);
                for (int i = 0; i < _dt.Rows.Count; i++)
                {
                    DataRow _dr = _dt.Rows[i];
                    _szjstr += _dr.Str("拼音") + "," + _dr.Str("汉字") + "|";
                }
                _szjstr.TrimEnd('|');
            }
            return _szjstr;
        }

        /// <summary>
        /// 百度查询
        /// </summary>
        /// <returns></returns>
        private string GetSearch()
        {
            if (string.IsNullOrEmpty(_filter))
                return "";

            string _result = string.Empty;
            string _nn = System.Web.HttpUtility.UrlEncode(_filter).ToUpper();
            string _url = string.Format("https://hanyu.baidu.com/s?wd={0}&ptype=zici", _nn);
            HttpWebRequest myHttpWebRequest = System.Net.WebRequest.Create(_url) as HttpWebRequest;
            myHttpWebRequest.KeepAlive = false;
            myHttpWebRequest.AllowAutoRedirect = false;
            myHttpWebRequest.UserAgent = "Mozilla/5.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 2.0.50727)";
            myHttpWebRequest.Timeout = 10000;
            myHttpWebRequest.ContentType = "application/x-www-form-urlencoded;charset=utf-8";
            using (HttpWebResponse res = (HttpWebResponse)myHttpWebRequest.GetResponse())
            {
                if (res.StatusCode == HttpStatusCode.OK || res.StatusCode == HttpStatusCode.PartialContent)//返回为200或206
                {
                    string dd = res.ContentEncoding;
                    System.IO.Stream strem = res.GetResponseStream();
                    System.IO.StreamReader r = new System.IO.StreamReader(strem);
                    string _str = r.ReadToEnd();

                    if (string.IsNullOrEmpty(_str))
                        return "";

                    int _index = _str.IndexOf("<div id=\"body-wrapper\">");
                    _str = _str.Substring(_index);
                    _index = _str.IndexOf("<!--body-wapper-->");
                    _str = _str.Substring(0, _index);
                    _str = _str.Replace("class=\"bishun\"", "class=\"bishun_play\"");
                    _str = _str.Replace("src=\"/static/asset/img_wise/video-stroke.png\"", "");
                    _str = _str.Replace("data-gif", "src");
                    _result = _str;
                }
            }

            return _result;
        }

        /// <summary>
        /// 语音列表
        /// </summary>
        /// <returns></returns>
        private string GetVoices()
        {
            string _result = string.Empty;
            string _sql = "select * from 语音记录 order by id desc";
            DataTable _dt = SchoolData.Query(_sql);
            foreach (DataRow _dr in _dt.Rows)
            {
                _result += _dr.ToDateTime("时间").ToString("MM-dd HH:mm:ss") + "=" + _dr.Str("名称") + "|";
            }
            _result = _result.TrimEnd('|');
            return _result;
        }

        private string GetVoiceFile(string p_name)
        {
            if (string.IsNullOrEmpty(p_name))
                return string.Empty;

            string _result = string.Empty;
            string fileName = System.AppDomain.CurrentDomain.BaseDirectory;
            if (!fileName.EndsWith("\\"))
                fileName += "\\";
            fileName += "WxVoice\\" + p_name;

            using (FileStream _file = File.Open(fileName, FileMode.Open))
            {
                byte[] _byte = new byte[_file.Length];
                _file.Read(_byte, 0, (int)_file.Length);
                _result = Convert.ToBase64String(_byte, 0, _byte.Length);
                _file.Close();
            }

            return _result;
        }
    }
}
