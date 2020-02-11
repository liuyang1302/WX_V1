using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wx.Core.Data
{
    public class DataOutBill
    {
        #region 成员
        private string _subSql = "INSERT INTO WX_WC_NOTE VALUES ({0},'{1}')";
        private string _selSql = "SELECT * FROM WX_WC_OUTBILL WHERE OpenId = '{0}'";
        private string _seldsql = "SELECT * FROM WX_WC_OUTBILL WHERE OpenId = '{0}' AND ITEMDATE >= #{1}# AND ITEMDATE<=#{2}# order by ITEMDATE DESC,ID DESC";
        private string _insertSql = "INSERT INTO WX_WC_OUTBILL (OpenId,ITEMNAME,ITEMMONEY,ITEMDATE,SUBID) VALUES ('{0}','{1}','{2}','{3}',{4})";
        private string _delSql = "DELETE FROM WX_WC_OUTBILL WHERE ID = {0}";

        private string _querySql = "SELECT * FROM WX_WC_OUTBILL WHERE OpenId = '{0}' AND ItemName = '{1}' AND ITEMMONEY ={2} AND ITEMDATE = #{3}# ";

        #endregion

        #region 私有
        /// <summary>
        /// 获取最大描述ID
        /// </summary>
        /// <returns></returns>
        private string LoadMaxSubId()
        {
            string _sql = "SELECT MAX(SUBID) AS ID FROM WX_WC_OUTBILL";
            DataTable _dt = DataAccess.Query(_sql);
            if (_dt == null || _dt.Rows.Count == 0) return "1";
            int _id = Convert.ToInt32(_dt.Rows[0][0].ToString()) + 1;
            return _id.ToString();
        }
        #endregion

        #region 公共

        /// <summary>
        /// 获取用户记账明细
        /// </summary>
        /// <param name="OpenId"></param>
        /// <returns></returns>
        public DataTable LoadOutBill(string OpenId)
        {
            if (string.IsNullOrEmpty(OpenId)) return null;
            DataTable _dt = DataAccess.Query(string.Format(_selSql, OpenId));
            return _dt;
        }

        /// <summary>
        /// 获取用户时间段内的记账明细
        /// </summary>
        /// <param name="OpenId"></param>
        /// <param name="p_start"></param>
        /// <param name="p_end"></param>
        /// <returns></returns>
        public DataTable LoadOutBill(string OpenId, string p_start, string p_end)
        {
            if (string.IsNullOrEmpty(OpenId) ||
                string.IsNullOrEmpty(p_start) ||
                string.IsNullOrEmpty(p_end))
                return null;
            DataTable _dt = DataAccess.Query(string.Format(_seldsql, OpenId, p_start, p_end));
            return _dt;
        }

        public DataTable LoadOutBill(string OpenId, DateTime p_start, DateTime p_end)
        {
            return LoadOutBill(OpenId, p_start.ToString("yyyy-MM-dd 00:00:00"), p_end.ToString("yyyy-MM-dd 23:59:59"));
        }

        /// <summary>
        /// 获取用户总支出
        /// </summary>
        /// <param name="OpenId"></param>
        /// <returns></returns>
        public decimal LoadOutBillMoney(string OpenId)
        {
            DataTable _dt = LoadOutBill(OpenId);
            if (_dt == null) return 0.00M;
            return _dt.AsEnumerable().Sum(r => Convert.ToDecimal(r["ItemMoney"]));
        }

        /// <summary>
        /// 获取用户时间段内的支出
        /// </summary>
        /// <param name="OpenId"></param>
        /// <param name="p_start"></param>
        /// <param name="p_end"></param>
        /// <returns></returns>
        public decimal LoadOutBillMoney(string OpenId, string p_start, string p_end)
        {
            DataTable _dt = LoadOutBill(OpenId, p_start, p_end);
            if (_dt == null) return 0.00M;
            return _dt.AsEnumerable().Sum(r => Convert.ToDecimal(r["ItemMoney"]));
        }

        /// <summary>
        /// 保存记账记录
        /// </summary>
        /// <param name="_entity"></param>
        /// <returns></returns>
        public bool SaveOutBill(OutBillEntity _entity)
        {
            int _result = 0;

            if (string.IsNullOrEmpty(_entity.SubID)
                && !string.IsNullOrEmpty(_entity.SubContent))
                _entity.SubID = LoadMaxSubId();
            if (string.IsNullOrEmpty(_entity.SubID)) _entity.SubID = "null";

            string _sql = string.Format(_insertSql, _entity.OpenId,
                _entity.ItemName, _entity.ItemMoney, _entity.ItemDate, _entity.SubID);
            _result = DataAccess.ExecNonQuery(_sql);
            if (_result <= 0) return _result > 0;

            if (!string.IsNullOrEmpty(_entity.SubContent))
            {
                _sql = string.Format(_subSql, _entity.SubID, _entity.SubContent);
                _result = DataAccess.ExecNonQuery(_sql);
            }

            return _result > 0;
        }


        /// <summary>
        /// 批量保存记账
        /// </summary>
        /// <param name="_entitys"></param>
        /// <returns></returns>
        public bool SaveOutBill(List<OutBillEntity> _entitys)
        {
            //循环保存遇到错误直接返回
            bool _result = false;
            if (_entitys.Count == 0)
                return _result;
            if (!string.IsNullOrEmpty(_entitys[0].SubContent) && string.IsNullOrEmpty(_entitys[0].SubID))
            {
                _entitys[0].SubID = LoadMaxSubId();
            }

            foreach (var item in _entitys)
            {
                item.SubID = _entitys[0].SubID;
                _result = SaveOutBill(item);
                if (!_result) return _result;
            }
            return _result;
        }

        /// <summary>
        /// 保存记账记录
        /// </summary>
        /// <param name="OpenId">用户标识</param>
        /// <param name="ItemName">项目名称</param>
        /// <param name="ItemMoney">项目金额</param>
        /// <param name="ItemDate">记录时间</param>
        /// <param name="SubID">备注ID</param>
        /// <param name="SubContent">备注内容</param>
        /// <returns></returns>
        public bool SaveOutBill(string OpenId, string ItemName, string ItemMoney, string ItemDate, string SubID, string SubContent = "")
        {
            OutBillEntity _entiry = new OutBillEntity();
            _entiry.OpenId = OpenId;
            _entiry.ItemName = ItemName;
            _entiry.ItemMoney = ItemMoney;
            _entiry.ItemDate = ItemDate;
            _entiry.SubID = SubID;
            _entiry.SubContent = SubContent;
            return SaveOutBill(_entiry);
        }

        /// <summary>
        /// 保存记账记录
        /// </summary>
        /// <param name="OpenId">用户标识</param>
        /// <param name="ItemName">项目名称</param>
        /// <param name="ItemMoney">项目金额</param>
        /// <returns></returns>
        public bool SaveOutBill(string OpenId, string ItemName, string ItemMoney)
        {
            return SaveOutBill(OpenId, ItemName, ItemMoney, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), string.Empty);
        }

        /// <summary>
        /// 删除记账记录
        /// </summary>
        /// <param name="OpenId"></param>
        /// <returns></returns>
        public bool DeleteOutBill(string ItemId)
        {
            int _result = DataAccess.ExecNonQuery(string.Format(_delSql, ItemId));
            return _result > 0;
        }


        /// <summary>
        /// 来自短信的自动记账
        /// </summary>
        /// <param name="OpenId">用户标识</param>
        /// <param name="Date">记账时间</param>
        /// <param name="Msg">短信内容</param>
        /// <returns></returns>
        public bool SaveSmsOutBill(string OpenId, string Date, string Msg)
        {
            //您尾号5370卡12月8日08:05POS支出(消费)30元，余额11,683.44元。【工商银行】

            if (Msg.IndexOf("您尾号") != 0)
                return false;
            Msg = Msg.Replace("您尾号", "");
            int _index = Msg.IndexOf("卡") + 1;

            string _name = Msg.Substring(0, _index);
            Msg = Msg.Substring(_index);

            //处理时间
            _index = Msg.IndexOf(":") + 3;
            string _date = Msg.Substring(0, _index);
            Msg = Msg.Substring(_index);
            if (!_date.Contains("月"))
                _date = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + _date.Replace("日", " ");
            else
                _date = DateTime.Now.Year + "-" + _date.Replace("月", "-").Replace("日", " ");

            //处理金额
            _index = Msg.IndexOf(")") + 1;
            if (_index == 0)
                _index = Msg.IndexOf("）") + 1;
            int _end = Msg.IndexOf("元");
            string _money = Msg.Substring(_index, _end - _index);

            //处理名称
            _name += "  " + Msg.Substring(0, _index);

            DataTable _dt = DataAccess.Query(string.Format(_querySql, OpenId, _name, _money, _date));
            if (_dt != null && _dt.Rows.Count > 0)
                return true;

            OutBillEntity _entity = new Data.OutBillEntity();
            _entity.OpenId = OpenId;
            _entity.ItemName = _name;
            _entity.ItemMoney = _money;
            _entity.ItemDate = _date;
            _entity.SubContent = Msg;

            SaveOutBill(_entity);

            return true;

        }
        #endregion
    }

    public class OutBillEntity
    {
        /// <summary>
        /// 用户标识
        /// </summary>
        public string OpenId { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        public string ItemName { get; set; }
        /// <summary>
        /// 项目金额
        /// </summary>
        public string ItemMoney { get; set; }
        /// <summary>
        /// 记录时间
        /// </summary>
        public string ItemDate { get; set; }
        /// <summary>
        /// 备注ID
        /// </summary>
        public string SubID { get; set; }
        /// <summary>
        /// 备注内容
        /// </summary>
        public string SubContent { get; set; }
    }
}
