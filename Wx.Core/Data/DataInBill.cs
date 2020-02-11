using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wx.Core.Data
{
    public class DataInBill
    {
        #region 成员
        private string _selSql = "SELECT * FROM WX_WC_INBILL WHERE OpenId = '{0}'";
        private string _seldsql = "SELECT * FROM WX_WC_INBILL WHERE OpenId = '{0}' AND ITEMDATE >= #{1}# AND ITEMDATE<=#{2}# ORDER BY ITEMDATE DESC,ID DESC";
        private string _insertSql = "INSERT INTO WX_WC_INBILL (OpenId,ItemType,ItemMoney,ItemDate,ItemNote) VALUES ('{0}','{1}','{2}','{3}','{4}')";
        private string _delSql = "DELETE FROM WX_WC_INBILL WHERE ID = {0}";
        #endregion

        #region 公共

        /// <summary>
        /// 获取用户记账明细
        /// </summary>
        /// <param name="OpenId"></param>
        /// <returns></returns>
        public DataTable LoadInBill(string OpenId)
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
        public DataTable LoadInBill(string OpenId, string p_start, string p_end)
        {
            if (string.IsNullOrEmpty(OpenId) ||
                string.IsNullOrEmpty(p_start) ||
                string.IsNullOrEmpty(p_end))
                return null;
            DataTable _dt = DataAccess.Query(string.Format(_seldsql, OpenId, p_start, p_end));
            return _dt;
        }

        public DataTable LoadInBill(string OpenId, DateTime p_start, DateTime p_end)
        {
            return LoadInBill(OpenId, p_start.ToString("yyyy-MM-dd 00:00:00"), p_end.ToString("yyyy-MM-dd 23:59:59"));
        }

        /// <summary>
        /// 获取用户总支出
        /// </summary>
        /// <param name="OpenId"></param>
        /// <returns></returns>
        public decimal LoadInBillMoney(string OpenId)
        {
            DataTable _dt = LoadInBill(OpenId);
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
        public decimal LoadInBillMoney(string OpenId, string p_start, string p_end)
        {
            DataTable _dt = LoadInBill(OpenId, p_start, p_end);
            if (_dt == null) return 0.00M;
            return _dt.AsEnumerable().Sum(r => Convert.ToDecimal(r["ItemMoney"]));
        }

        /// <summary>
        /// 保存记账记录
        /// </summary>
        /// <param name="_entity"></param>
        /// <returns></returns>
        public bool SaveInBill(InBillEntity _entity)
        {
            int _result = 0;

            string _sql = string.Format(_insertSql, _entity.OpenId,
                _entity.ItemType, _entity.ItemMoney, _entity.ItemDate, _entity.ItemNote);
            _result = DataAccess.ExecNonQuery(_sql);

            return _result > 0;
        }


        /// <summary>
        /// 批量保存记账
        /// </summary>
        /// <param name="_entitys"></param>
        /// <returns></returns>
        public bool SaveInBill(List<InBillEntity> _entitys)
        {
            //循环保存遇到错误直接返回
            bool _result = false;
            foreach (var item in _entitys)
            {
                _result = SaveInBill(item);
                if (!_result) return _result;
            }
            return _result;
        }

        /// <summary>
        /// 保存记账记录
        /// </summary>
        /// <param name="OpenId">用户标识</param>
        /// <param name="ItemType">项目类别</param>
        /// <param name="ItemMoney">项目金额</param>
        /// <param name="ItemDate">记录时间</param>
        /// <param name="ItemNote">备注</param>
        /// <returns></returns>
        public bool SaveInBill(string OpenId, string ItemType, string ItemMoney, string ItemDate, string ItemNote)
        {
            InBillEntity _entiry = new InBillEntity();
            _entiry.OpenId = OpenId;
            _entiry.ItemType = ItemType;
            _entiry.ItemMoney = ItemMoney;
            _entiry.ItemDate = ItemDate;
            _entiry.ItemNote = ItemNote;
            return SaveInBill(_entiry);
        }

        /// <summary>
        /// 删除收入记录
        /// </summary>
        /// <param name="OpenId"></param>
        /// <returns></returns>
        public bool DeleteInBill(string ItemId)
        {
            int _result = DataAccess.ExecNonQuery(string.Format(_delSql, ItemId));
            return _result > 0;
        }
        #endregion
    }

    public class InBillEntity
    {
        /// <summary>
        /// 用户标识
        /// </summary>
        public string OpenId { get; set; }
        /// <summary>
        /// 项目类别
        /// </summary>
        public string ItemType { get; set; }
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
        public string ItemNote { get; set; }
    }
}
