using System.Data;
using System.Linq;
using System.Web;
using Wx.Core;

namespace Wx.Work.WxQues
{
    public class WxQuesServiceHome : WxServiceBase
    {
        public override string GetResult(HttpContext context)
        {
            base.GetResult(context);
            string _result = string.Empty;
            string _quesType = context.Request.Params["QuesType"];

            //总数
            DataTable _dt = DataAgent.Ques.LoadExam(_openid);
            int _havecount = 0;
            int _errorcount = 0;
            if (_dt != null && _dt.Rows.Count > 0)
            {
                _havecount = _dt.AsEnumerable().Sum(r => r.ToInt("HaveCount"));
                _errorcount = _dt.AsEnumerable().Sum(r => r.ToInt("ErrorCount"));
            }
            _result = _errorcount + "=" + _havecount;

            //项目集合
            _dt = DataAgent.Ques.LoadCourse(_quesType);
            foreach (DataRow _dr in _dt.Rows)
            {
                _result += "|" + _dr.Str("ID") + "=" + _dr.Str("CourseName");
            }
            return _result;
        }
    }
}
