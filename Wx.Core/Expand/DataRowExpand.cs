using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wx.Core
{
    public static class DataRowExpand
    {
        public static string Description(this DataRow p_dr)
        {
            StringBuilder _sb = new StringBuilder();
            DataTable _dt = p_dr.Table;
            foreach (DataColumn _column in _dt.Columns)
            {
                _sb.Append(_column.ColumnName + ":" + p_dr.Str(_column.ColumnName) + Environment.NewLine);
            }
            return _sb.ToString();
        }

        public static string Str(this DataRow p_dr, string p_name)
        {
            if (p_dr[p_name] is DBNull)
                return string.Empty;
            return p_dr[p_name].ToString();
        }

        public static string Str(this DataRow p_dr, int p_columnindex)
        {
            if (p_dr[p_columnindex] is DBNull)
                return string.Empty;
            return p_dr[p_columnindex].ToString();
        }

        public static int ToInt(this DataRow p_dr, string p_name)
        {
            int _val = 0;
            int.TryParse(p_dr.Str(p_name), out _val);
            return _val;
        }

        public static double ToDouble(this DataRow p_dr, string p_name)
        {
            double _val = 0;
            double.TryParse(p_dr.Str(p_name), out _val);
            return _val;
        }

        public static decimal ToDecimal(this DataRow p_dr, string p_name)
        {
            decimal _val = 0;
            decimal.TryParse(p_dr.Str(p_name), out _val);
            return _val;
        }

        public static DateTime ToDateTime(this DataRow p_dr, string p_name)
        {
            DateTime _val;
            DateTime.TryParse(p_dr.Str(p_name), out _val);
            return _val;
        }

        public static object DBNullValue(this DataRow p_dr, string p_name)
        {
            string _result = p_dr.Str(p_name);
            if (string.IsNullOrEmpty(_result))
                return DBNull.Value;
            return _result;
        }

        public static void Copy(this DataRow p_dr, DataRow p_ndr)
        {
            DataColumnCollection _odc = p_dr.Table.Columns;
            DataColumnCollection _ndc = p_ndr.Table.Columns;
            foreach (DataColumn _dc in _odc)
            {
                if (!_ndc.Contains(_dc.ColumnName))
                    continue;
                p_ndr[_dc.ColumnName] = p_dr[_dc.ColumnName];
            }
        }
    }
}
