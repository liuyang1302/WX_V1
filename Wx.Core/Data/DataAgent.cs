using System.Data;
using Wx.Core.Data;

namespace Wx.Core
{
    public class DataAgent
    {
        /// <summary>
        /// 支出数据管理
        /// </summary>
        public static DataOutBill OutBill
        {
            get { return new DataOutBill(); }
        }

        /// <summary>
        /// 收入数据管理
        /// </summary>
        public static DataInBill InBill
        {
            get { return new DataInBill(); }
        }

        /// <summary>
        /// 答题数据管理
        /// </summary>
        public static DataQues Ques
        {
            get { return new DataQues(); }
        }

        /// <summary>
        /// 微信用户管理
        /// </summary>
        public static DataUser WxUser
        {
            get { return new DataUser(); }
        }

        /// <summary>
        /// 消息管理
        /// </summary>
        public static DataSms Sms
        {
            get { return new DataSms(); }
        }
    }
}