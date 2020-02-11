using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Wx.Core
{
    /// <summary>
    /// Json序列与反序列化
    /// </summary>
    public class AtJson
    {
        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static string ToJsJson(object item)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(item.GetType());
            using (MemoryStream ms = new MemoryStream())
            {
                serializer.WriteObject(ms, item);
                StringBuilder sb = new StringBuilder();
                sb.Append(Encoding.UTF8.GetString(ms.ToArray(), 0, (int)ms.Length));
                return sb.ToString();
            }
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        public static T FromJsonTo<T>(string jsonString)
        {
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
                using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString)))
                {
                    T jsonObject = (T)ser.ReadObject(ms);
                    return jsonObject;
                }
            }
            catch (Exception e)
            {
                Logger.WriteTxtLog(e);
            }
            return default(T);
        }
    }
}
