using System;
using System.Data;
using System.Linq;
using System.Web;
using Wx.Core;

namespace Wx.Work.WxBill
{
    /// <summary>
    /// 报表处理
    /// </summary>
    public class WxBillServiceReport : WxServiceBase
    {
        private string _sdate;
        private string _edate;
        private string _itemid;
        public override string GetResult(HttpContext context)
        {
            string _result = string.Empty;
            base.GetResult(context);
            _sdate = context.Request.Params["SDate"];
            _edate = context.Request.Params["EDate"];
            _itemid = context.Request.Params["ItemID"];

            switch (_type)
            {
                case "报表支出明细":
                    _result = GetOutBillDetail();
                    break;
                case "删除支出明细":
                    _result = DelOutBillDetail();
                    break;
                case "报表收入明细":
                    _result = GetInBillDetail();
                    break;
                case "删除收入明细":
                    _result = DelInBillDetail();
                    break;
                case "报表收支报表":
                    _result = GetOutBillReport();
                    break;
            }

            return _result;
        }

        /// <summary>
        /// 报表支出明细
        /// </summary>
        /// <returns></returns>
        public string GetOutBillDetail()
        {
            string _result = string.Empty;
            DataTable _dt = DataAgent.OutBill.LoadOutBill(_openid, Convert.ToDateTime(_sdate), Convert.ToDateTime(_edate));
            if (_dt == null || _dt.Rows.Count == 0)
                return "范围内无数据";

            decimal _sum = _dt.AsEnumerable().Sum(r => r.ToDecimal("ItemMoney"));
            _result = "范围内支出=" + _sum.ToString("0.00");

            foreach (DataRow _dr in _dt.Rows)
            {
                _result += "|ID=" + _dr.Str("ID") + ";ItemName=" + _dr.Str("ItemName") + ";ItemMoney=" + _dr.ToDecimal("ItemMoney").ToString("0.00") +
                    ";ItemDate=" + Convert.ToDateTime(_dr.Str("ItemDate")).ToString("yyyy-MM-dd") + ";ItemTime=" + Convert.ToDateTime(_dr.Str("ItemDate")).ToString("HH:mm");

            }

            return _result;
        }

        /// <summary>
        /// 删除支出明细
        /// </summary>
        /// <returns></returns>
        public string DelOutBillDetail()
        {
            string _result = string.Empty;
            if (string.IsNullOrEmpty(_itemid))
                return "记录ID为空！";
            bool _is = DataAgent.OutBill.DeleteOutBill(_itemid);
            _result = _is ? "删除成功！" : "删除失败！";
            return _result;
        }

        /// <summary>
        /// 报表收入明细
        /// </summary>
        /// <returns></returns>
        public string GetInBillDetail()
        {
            string _result = string.Empty;
            DataTable _dt = DataAgent.InBill.LoadInBill(_openid, Convert.ToDateTime(_sdate), Convert.ToDateTime(_edate));
            if (_dt == null || _dt.Rows.Count == 0)
                return "范围内无数据";

            decimal _sum = _dt.AsEnumerable().Sum(r => r.ToDecimal("ItemMoney"));
            _result = "范围内收入=" + _sum.ToString("0.00");

            foreach (DataRow _dr in _dt.Rows)
            {
                _result += "|ID=" + _dr.Str("ID") + ";ItemType=" + _dr.Str("ItemType") + ";ItemMoney=" + _dr.ToDecimal("ItemMoney").ToString("0.00") +
                    ";ItemDate=" + Convert.ToDateTime(_dr.Str("ItemDate")).ToString("yyyy-MM-dd") + ";ItemNote=" + _dr.Str("ItemNote");

            }
            return _result;
        }

        /// <summary>
        /// 删除收入明细
        /// </summary>
        /// <returns></returns>
        public string DelInBillDetail()
        {
            string _result = string.Empty;
            if (string.IsNullOrEmpty(_itemid))
                return "记录ID为空！";
            bool _is = DataAgent.InBill.DeleteInBill(_itemid);
            _result = _is ? "删除成功！" : "删除失败！";
            return _result;
        }

        public string GetOutBillReport()
        {
            string _result = string.Empty;

            return _result;
        }

    }
}
