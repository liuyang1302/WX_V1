using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Wx.Core;

namespace Wx.Work.School
{
    public class SchoolRead : WxServiceBase
    {
        private string _ltype;
        private string _typeid;
        public override string GetResult(HttpContext context)
        {
            base.GetResult(context);
            string _result = string.Empty;
            _ltype = context.Request.Params["ltype"];
            _typeid = context.Request.Params["typeid"];
            switch (_ltype)
            {
                case "分类目录":
                    _result = 分类目录();
                    break;
                case "项目列表":
                    _result = 项目列表();
                    break;
            }

            return _result;
        }

        private string 分类目录()
        {
            string _result = string.Empty;
            string _sql = "select * from 阅读分类";
            DataTable _dt = SchoolData.Query(_sql);
            foreach (DataRow dr in _dt.Rows)
            {
                _result += dr.Str("ID") + "," + dr.Str("大类") + "," + dr.Str("小类") + "|";
            }
            return _result.TrimEnd('|');
        }

        private string 项目列表()
        {
            string _result = string.Empty;
            string _sql = "SELECT B.* FROM 阅读对应 A, 阅读项目 B WHERE A.项目ID = B.ID AND A.分类ID = " + _typeid;
            DataTable _dt = SchoolData.Query(_sql);
            foreach (DataRow dr in _dt.Rows)
            {
                _result += dr.Str("ID") + "|" + 
                    dr.Str("类别") + "|" + dr.Str("类型") + "|" + dr.Str("朝代") + "|" +
                    dr.Str("作者") + "|" + dr.Str("名称") + "|" + dr.Str("内容") + "|" +
                    dr.Str("朗读") + "$";
            }
            return _result.TrimEnd('$');
        }
    }
}
