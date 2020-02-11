using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Wx.Core;
using Wx.Core.Data;

namespace Wx.Work.WxBill
{
    public class WxBillServiceAccess : WxServiceBase
    {
        private string _params;
        public override string GetResult(HttpContext context)
        {
            base.GetResult(context);
            _params = context.Request.Params["Params"];
            string _result = string.Empty;
            switch (_type)
            {
                case "支出数据载入":
                    _result = GetOutBillSum();
                    break;
                case "支出数据保存":
                    _result = SaveOutBillSum();
                    break;
            }
            return _result;
        }

        /// <summary>
        /// 获取支出月花销
        /// </summary>
        /// <returns></returns>
        public string GetOutBillSum()
        {
            string _result = string.Empty;
            DateTime _now = DateTime.Now;
            DateTime _msdate = Tools.FirstDayOfMonth(_now);
            DateTime _medate = Tools.LastDayOfMonth(_now);
            DataTable _outdt = DataAgent.OutBill.LoadOutBill(_openid, _msdate, _medate);
            _result = _outdt.AsEnumerable().Sum(r => Convert.ToDecimal(r["ItemMoney"])).ToString("0.00");
            return _result;
        }

        /// <summary>
        /// 保存支出花销
        /// </summary>
        /// <returns></returns>
        public string SaveOutBillSum()
        {
            string _result = string.Empty;
            string[] _items = _params.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            if (_items.Length <= 2)
                return "未填写指出项目！";

            string _date = string.IsNullOrEmpty(_items[0].Split('=')[1]) ? DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") :
                Convert.ToDateTime(_items[0].Split('=')[1]).ToString("yyyy-MM-dd HH:mm:ss"); //时间
            string _note = _items[1].Split('=')[1]; //备注
            if (_note == "记账备注") _note = string.Empty;

            List<OutBillEntity> _list = new List<OutBillEntity>();
            foreach (var item in _items)
            {
                if (!item.Contains(";")) continue;
                string[] _vals = item.Split(';');
                _list.Add(new OutBillEntity() { OpenId = _openid, ItemName = _vals[0].Split('=')[1], ItemMoney = _vals[1].Split('=')[1], ItemDate = _date, SubContent = _note });
            }

            bool _is = DataAgent.OutBill.SaveOutBill(_list);
            if (_is)
                _result = "记账操作成功！";
            else
                _result = "记账操作失败！";

            return _result;
        }
    }
}
