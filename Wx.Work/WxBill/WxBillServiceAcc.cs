using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Wx.Core;

namespace Wx.Work.WxBill
{
    public class WxBillServiceAcc : WxServiceBase
    {
        public override string GetResult(HttpContext context)
        {
            string _result = string.Empty;

            base.GetResult(context);

            if (_type == "记账首页")
            {
                _result = GetBill();
            }
            else if (_type == "用户注册")
            {
                _result = GetUser(context);
            }
            else if (_type == "外网IP")
            {
                _result = Tools.GetExtenalIpAddress();
            }

            return _result;
        }

        private string GetBill()
        {
            string _result = string.Empty;

            DateTime _now = DateTime.Now;

            //当前用户所有费用明细
            DataTable _idt = DataAgent.InBill.LoadInBill(_openid);
            DataTable _odt = DataAgent.OutBill.LoadOutBill(_openid);

            //总集合
            EnumerableRowCollection<DataRow> _irs = _idt.AsEnumerable();
            EnumerableRowCollection<DataRow> _ors = _odt.AsEnumerable();

            //总金额
            decimal _isum = _irs.Sum(r => r.ToDecimal("ItemMoney"));   //总收入
            decimal _osum = _ors.Sum(r => r.ToDecimal("ItemMoney"));   //总支出
            decimal _ssum = _isum - _osum;                             //总结余
            _result += "总收入=" + _isum.ToString("0.00");
            _result += ";总支出=" + _osum.ToString("0.00");
            _result += ";总结余=" + _ssum.ToString("0.00");

            //年处理
            DateTime _sydate = Convert.ToDateTime(_now.ToString("yyyy") + "-01-01 00:00:00");
            DateTime _eydate = Convert.ToDateTime(_now.ToString("yyyy") + "-12-31 23:59:59");
            List<DataRow> _iyrs = _irs.Where(r => r.ToDateTime("ItemDate") >= _sydate && r.ToDateTime("ItemDate") <= _eydate).ToList();
            List<DataRow> _oyrs = _ors.Where(r => r.ToDateTime("ItemDate") >= _sydate && r.ToDateTime("ItemDate") <= _eydate).ToList();
            decimal _iysum = _iyrs.Sum(r => r.ToDecimal("ItemMoney"));   //年总收入
            decimal _oysum = _oyrs.Sum(r => r.ToDecimal("ItemMoney"));   //年总支出
            _result += "|" + _sydate.ToString("MM月dd日") + "-" + _eydate.ToString("MM月dd日");
            _result += ";年总收入=" + _iysum.ToString("0.00");
            _result += ";年总支出=" + _oysum.ToString("0.00");

            //月处理
            DateTime _smdate = Tools.FirstDayOfMonth(_now);
            DateTime _emdate = Tools.LastDayOfMonth(_now);
            List<DataRow> _imrs = _irs.Where(r => r.ToDateTime("ItemDate") >= _smdate && r.ToDateTime("ItemDate") <= _emdate).ToList();
            List<DataRow> _omrs = _ors.Where(r => r.ToDateTime("ItemDate") >= _smdate && r.ToDateTime("ItemDate") <= _emdate).ToList();
            decimal _imsum = _imrs.Sum(r => r.ToDecimal("ItemMoney"));   //月总收入
            decimal _omsum = _omrs.Sum(r => r.ToDecimal("ItemMoney"));   //月总支出
            _result += "|" + _smdate.ToString("MM月dd日") + "-" + _emdate.ToString("MM月dd日");
            _result += ";月总收入=" + _imsum.ToString("0.00");
            _result += ";月总支出=" + _omsum.ToString("0.00");

            //周处理
            DateTime _swdate = Convert.ToDateTime(Tools.FirstDayOfWeek(_now).ToString("yyyy-MM-dd 00:00:00"));
            DateTime _ewdate = Convert.ToDateTime(Tools.LastDayOfWeek(_now).ToString("yyyy-MM-dd 23:59:59"));
            List<DataRow> _iwrs = _irs.Where(r => r.ToDateTime("ItemDate") >= _swdate && r.ToDateTime("ItemDate") <= _ewdate).ToList();
            List<DataRow> _owrs = _ors.Where(r => r.ToDateTime("ItemDate") >= _swdate && r.ToDateTime("ItemDate") <= _ewdate).ToList();
            decimal _iwsum = _iwrs.Sum(r => r.ToDecimal("ItemMoney"));   //周总收入
            decimal _owsum = _owrs.Sum(r => r.ToDecimal("ItemMoney"));   //周总支出
            _result += "|" + _swdate.ToString("MM月dd日") + "-" + _ewdate.ToString("MM月dd日");
            _result += ";周总收入=" + _iwsum.ToString("0.00");
            _result += ";周总支出=" + _owsum.ToString("0.00");

            //日处理
            DateTime _sddate = Convert.ToDateTime(_now.ToString("yyyy-MM-dd 00:00:00"));
            DateTime _eddate = Convert.ToDateTime(_now.ToString("yyyy-MM-dd 23:59:59"));
            List<DataRow> _idrs = _irs.Where(r => r.ToDateTime("ItemDate") >= _sddate && r.ToDateTime("ItemDate") <= _eddate).ToList();
            List<DataRow> _odrs = _ors.Where(r => r.ToDateTime("ItemDate") >= _sddate && r.ToDateTime("ItemDate") <= _eddate).ToList();
            decimal _idsum = _idrs.Sum(r => r.ToDecimal("ItemMoney"));   //日总收入
            decimal _odsum = _odrs.Sum(r => r.ToDecimal("ItemMoney"));   //日总支出
            _result += "|" + _sddate.ToString("yyyy年MM月dd日");
            _result += ";日总收入=" + _idsum.ToString("0.00");
            _result += ";日总支出=" + _odsum.ToString("0.00");

            return _result;
        }


        private string GetUser(HttpContext context)
        {
            string _pwd = context.Request.Params["Password"];

            DataTable _dt = DataAgent.WxUser.LoadWxUser(_openid, _pwd);
            if (_dt != null && _dt.Rows.Count > 0)
            {
                return "登录成功";
            }

            _dt = DataAgent.WxUser.LoadWxUser(_openid);
            if (_dt != null && _dt.Rows.Count > 0)
            {
                return "密码错误";
            }

            bool _is = DataAgent.WxUser.SaveWxUser(_openid, _openid, _pwd);
            return _is ? "注册成功" : "注册失败";
        }

    }
}
