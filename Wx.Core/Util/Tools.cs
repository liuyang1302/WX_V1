using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Wx.Core
{
    /// <summary>
    /// 辅助工具类
    /// </summary>
    public class Tools
    {
        /// <summary>
        /// 获取Json string某节点的值。
        /// </summary>
        /// <param name="json"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetJosnValue(string jsonStr, string key)
        {
            string result = string.Empty;
            if (!string.IsNullOrWhiteSpace(jsonStr))
            {
                key = "\"" + key.Trim('"') + "\"";
                int index = jsonStr.IndexOf(key) + key.Length + 1;
                if (index > key.Length + 1)
                {
                    //先截逗号，若是最后一个，截“｝”号，取最小值

                    int end = jsonStr.IndexOf(',', index);
                    if (end == -1)
                    {
                        end = jsonStr.IndexOf('}', index);
                    }
                    //index = json.IndexOf('"', index + key.Length + 1) + 1;
                    result = jsonStr.Substring(index, end - index);
                    //过滤引号或空格
                    result = result.Trim(new char[] { '"', ' ', '\'' });
                }
            }
            return result;
        }

        /// <summary>
        /// datetime转换成unixtime
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static long ConvertDateTimeInt(System.DateTime time)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            return (long)(time - startTime).TotalSeconds;
        }

        /// <summary>
        /// 将Unix时间戳转换为DateTime类型时间
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static System.DateTime ConvertIntDateTime(double d)
        {
            System.DateTime time = System.DateTime.MinValue;
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            time = startTime.AddSeconds(d);
            return time;
        }

        /// <summary>
        /// Json序列化对象
        /// </summary>
        /// <typeparam name="ObjType"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToJsonString<ObjType>(ObjType obj) where ObjType : class
        {
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            string s = jsonSerializer.Serialize(obj);
            return s;
        }

        /// <summary>
        /// 取得某月的第一天
        /// </summary>
        /// <param name="datetime">要取得月份第一天的时间</param>
        /// <returns></returns>
        public static DateTime FirstDayOfMonth(DateTime datetime)
        {
            return datetime.AddDays(1 - datetime.Day);
        }

        /// <summary>
        /// 取得某月的最后一天
        /// </summary>
        /// <param name="datetime">要取得月份最后一天的时间</param>
        /// <returns></returns>
        public static DateTime LastDayOfMonth(DateTime datetime)
        {
            return datetime.AddDays(1 - datetime.Day).AddMonths(1).AddDays(-1);
        }

        /// <summary>
        /// 取得某周的第一天
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static DateTime FirstDayOfWeek(DateTime datetime)
        {
            int weeknow = Convert.ToInt32(datetime.DayOfWeek);
            int daydiff = (-1) * weeknow + 1;
            return DateTime.Now.AddDays(daydiff);
        }

        /// <summary>
        /// 取得某周的最后一天
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static DateTime LastDayOfWeek(DateTime datetime)
        {
            int weeknow = Convert.ToInt32(datetime.DayOfWeek);
            int dayadd = 7 - weeknow;
            return DateTime.Now.AddDays(dayadd);
        }

        /// <summary>
        /// 获取外网IP地址
        /// </summary>
        /// <returns></returns>
        public static string GetLocalIp()
        {
            string result = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (null == result || result == String.Empty)
            {
                result = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            if (null == result || result == String.Empty)
            {
                result = System.Web.HttpContext.Current.Request.UserHostAddress;
            }
            return result;
        }

        public static string GetExtenalIpAddress_0()
        {
            string IP = "未获取到外网ip";
            try
            {
                //从网址中获取本机ip数据    
                System.Net.WebClient client = new System.Net.WebClient();
                client.Encoding = System.Text.Encoding.Default;
                string str = client.DownloadString("http://1111.ip138.com/ic.asp");
                client.Dispose();

                //提取外网ip数据 [218.104.71.178]    
                int i1 = str.IndexOf("["), i2 = str.IndexOf("]");
                IP = str.Substring(i1 + 1, i2 - 1 - i1);
            }
            catch (Exception) { }

            return IP;
        }

        /// <summary>  
        /// 获取外网ip地址  
        /// </summary>  
        public static string GetExtenalIpAddress()
        {
            String url = "http://hijoyusers.joymeng.com:8100/test/getNameByOtherIp";
            string IP = "未获取到外网ip";
            try
            {
                //从网址中获取本机ip数据    
                System.Net.WebClient client = new System.Net.WebClient();
                client.Encoding = System.Text.Encoding.Default;
                string str = client.DownloadString(url);
                client.Dispose();

                if (!str.Equals("")) IP = str;
                else IP = GetExtenalIpAddress_0();
            }
            catch (Exception) { }

            return IP;
        }

        private static readonly CodeConverter _converter = new CodeConverter();

        /// <summary>
        /// 获取一个字符串的拼音码
        /// </summary>
        /// <param name="p_inputValue">需要转换的字符串</param>
        /// <returns>转换后的拼音码</returns>
        public static string ToChineseSpell(string p_inputValue)
        {
            return _converter.GetSpellCode(p_inputValue);
        }

        /// <summary>
        /// 获取一个字符串的五笔码
        /// </summary>
        /// <param name="p_inputValue">需要转换的字符串</param>
        /// <returns>转换后的五笔码</returns>
        public static string ToWuBi(string p_inputValue)
        {
            return _converter.GetWBCode(p_inputValue);
        }


    }
}
