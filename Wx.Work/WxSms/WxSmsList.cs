using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Wx.Core;

namespace Wx.Work.WxSms
{
    public class WxSmsList : WxServiceBase
    {
        public override string GetResult(HttpContext context)
        {
            base.GetResult(context);
            string _result = string.Empty;
            string _ctype = context.Request.Params["CType"];
            string _sdate = context.Request.Params["SDate"];
            string _edate = context.Request.Params["EDate"];

            DataTable _dt = DataAgent.Sms.LoadSmsList(_openid, _ctype, _sdate, _edate);
            _result = TrData(_dt);

            return _result;
        }
    }
}
