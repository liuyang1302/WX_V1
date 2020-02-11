using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Wx.Work.WxBill;

namespace Wx.Work
{
    public class WxBillFactory : IWxFactory
    {
        public string Result(HttpContext context)
        {
            return Services(context).GetResult(context);
        }

        public WxServiceBase Services(HttpContext context)
        {
            string _type = context.Request.Params["Type"];
            WxServiceBase _result = null;
            switch (_type)
            {
                case "记账首页":
                case "用户注册":
                case "外网IP":
                    _result = new WxBillServiceAcc();
                    break;
                case "支出数据载入":
                case "支出数据保存":
                    _result = new WxBillServiceAccess();
                    break;
                case "收入数据载入":
                case "收入数据保存":
                    _result = new WxBillServiceIncome();
                    break;
                case "报表支出明细":
                case "删除支出明细":
                case "报表收入明细":
                case "删除收入明细":
                case "报表收支报表":
                    _result = new WxBillServiceReport();
                    break;
                default:
                    break;
            }
            return _result;
        }
    }
}
