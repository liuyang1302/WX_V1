using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Wx.Core;

public partial class WxHtn_HtnConfig : System.Web.UI.Page
{
    private static DataRow _dr;
    private static DataTable _sqldt;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitPage();
        }
    }

    private void InitPage()
    {
        _sqldt = HtnData.Query("SELECT * FROM HTN_SQL");
        ListBox1.DataSource = _sqldt;
        ListBox1.DataTextField = "SQLKEY";
        ListBox1.DataBind();
        ListBox1.AutoPostBack = true;

        List<ListItem> _source = new List<ListItem>();
        _source.Add(new ListItem() { Text = "服务", Value = "服务" });
        _source.Add(new ListItem() { Text = "应用", Value = "应用" });
        DropDownList1.DataSource = _source;
        DropDownList1.DataBind();

        if (_sqldt != null && _sqldt.Rows.Count > 0)
            SelectItem(_sqldt.Rows[0]);

    }

    private void SelectItem(DataRow p_dr)
    {
        _dr = p_dr;
        TextBox1.Text = _dr.Str("SQLKey");
        TextBox2.Text = _dr.Str("SQLVal");
        TextBox3.Text = _dr.Str("SQLPk");
        DropDownList1.SelectedValue = _dr.Str("SQLType");
        CheckBox1.Checked = _dr.Str("SQLIs") == "1";
        CheckBox2.Checked = _dr.Str("SQLUp") == "1";
    }

    protected void OnSelectedIndexChanged(object sender, EventArgs e)
    {
        if (_sqldt == null) return;
        DataRow _dr = _sqldt.Rows[ListBox1.SelectedIndex];
        SelectItem(_dr);
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        _dr = null;
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        DropDownList1.SelectedIndex = 0;
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(TextBox1.Text) || string.IsNullOrEmpty(TextBox2.Text))
            return;

        List<OleDbParameter> _params = new List<OleDbParameter>();
        _params.Add(new OleDbParameter() { ParameterName = "V001", Value = TextBox1.Text });
        _params.Add(new OleDbParameter() { ParameterName = "V002", Value = TextBox2.Text });
        _params.Add(new OleDbParameter() { ParameterName = "V003", Value = DropDownList1.SelectedValue });
        _params.Add(new OleDbParameter() { ParameterName = "V004", Value = CheckBox1.Checked ? "1" : "0" });
        _params.Add(new OleDbParameter() { ParameterName = "V005", Value = TextBox3.Text });
        _params.Add(new OleDbParameter() { ParameterName = "V006", Value = CheckBox2.Checked ? "1" : "0" });

        string _sql = string.Empty;
        if (_dr == null)
        {
            _sql = "INSERT INTO HTN_SQL (SQLKey, SQLVal, SQLType, SQLIs, SQLPk, SQLUp) VALUES (:V001, :V002, :V003, :V004, :V005, :V006)";
        }
        else
        {
            _sql = "UPDATE HTN_SQL SET SQLKey = :V001, SQLVal = :V002, SQLType = :V003, SQLIs = :V004, SQLPk = :V005, SQLUp = :V006 WHERE ID = " + _dr.Str("ID");
        }

        bool _is = HtnData.ExecNonQuery(_sql, _params) == 1;
        if (_is)
        {
            //Response.Write("成功！");
            HtnData.InitSource();
            InitPage();
        }
        else
        {
            //Response.Write("失败！");
        }
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        if (_dr == null) return;
        
    }

}