using System;
using System.Web;
using Wx.Core;

namespace Wx.Work.WxBill
{
    public class WxBillServiceIncome : WxServiceBase
    {
        private string _params;
        public override string GetResult(HttpContext context)
        {
            base.GetResult(context);
            _params = context.Request.Params["Params"];
            string _result = string.Empty;
            switch (_type)
            {
                case "收入数据载入":
                    _result = GetInBillSum();
                    break;
                case "收入数据保存":
                    _result = SaveInBillSum();
                    break;
            }
            return _result;
        }

        /// <summary>
        /// 获取收入数据
        /// </summary>
        /// <returns></returns>
        public string GetInBillSum()
        {
            string _result = string.Empty;
            decimal _insum = DataAgent.InBill.LoadInBillMoney(_openid);
            decimal _outsum = DataAgent.OutBill.LoadOutBillMoney(_openid);
            decimal _subsum = _insum - _outsum;
            _result = "结余=" + _subsum.ToString("0.00");
            _result += "|收入=" + _insum.ToString("0.00");
            _result += "|支出=" + _outsum.ToString("0.00");
            return _result;
        }

        /// <summary>
        /// 保存收入数据
        /// </summary>
        /// <returns></returns>
        public string SaveInBillSum()
        {
            //时间|类别|金额|备注
            string _result = string.Empty;
            string[] _items = _params.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            string _date = string.IsNullOrEmpty(_items[0].Split('=')[1]) ? DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") :
               Convert.ToDateTime(_items[0].Split('=')[1]).ToString("yyyy-MM-dd HH:mm:ss"); //时间

            bool _is = DataAgent.InBill.SaveInBill(_openid, _items[1].Split('=')[1], _items[2].Split('=')[1], _date, _items[3].Split('=')[1]);
            if (_is)
                _result = "收入操作成功！";
            else
                _result = "收入操作失败！";

            return _result;
        }

    }
}
