using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Wx.Core;

namespace Wx.Work
{
    public abstract class WxServiceBase
    {
        public string _type;
        public string _openid;
        public string _nickname;
        public NameValueCollection Params;
        public virtual string GetResult(HttpContext context)
        {
            Params = context.Request.Params;
            _type = context.Request.Params["Type"];
            _openid = context.Request.Params["OpenID"];
            _nickname = context.Request.Params["NickName"];
            return string.Empty;
        }

        public string TrData(DataTable p_dt)
        {
            string _result = "";

            if (p_dt == null || p_dt.Rows.Count == 0)
            {
                return "无数据";
            }

            foreach (DataRow _dr in p_dt.Rows)
            {
                if (_result != "") _result += "|";
                foreach (DataColumn _dc in p_dt.Columns)
                {
                    _result += _dc.ColumnName + "=" + _dr.Str(_dc.ColumnName) + ";";
                }
                _result = _result.TrimEnd(';');
            }

            return _result;
        }
    }

    public class WxDefaultService : WxServiceBase
    {
        public override string GetResult(HttpContext context)
        {
            return "OK";
        }
    }
}
