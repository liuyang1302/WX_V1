using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Wx.Core;
using Wx.Core.School;

public partial class WxSchool_SchoolEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadCou();
            lbtype.SelectedIndexChanged += Lbcourseselect_SelectedIndexChanged;
        }
    }

    private void Lbcourseselect_SelectedIndexChanged(object sender, EventArgs e)
    {
        string _sql = "select * from 题目内容 where 类型 = " + lbtype.SelectedValue;
        DataTable _dt = SchoolData.Query(_sql);
        GridView1.DataSource = _dt;
        GridView1.DataBind();
    }

    private void LoadCou()
    {
        string _sql = "select * from 分类目录";
        DataTable _cdt = SchoolData.Query(_sql);
        lbtype.Items.Clear();
        foreach (DataRow _dr in _cdt.Rows)
        {
            lbtype.Items.Add(new ListItem() { Value = _dr.Str("ID"), Text = _dr.Str("名称") });
        }

        _sql = "select * from 题目内容 order by id desc";
        DataTable _dt = SchoolData.Query(_sql);
        GridView1.DataSource = _dt;
        GridView1.DataBind();
    }

    protected void OnSaveInfoClick(object sender, EventArgs e)
    {
        string _content = tbcontent.Text;
        if (string.IsNullOrEmpty(_content)) return;

        string _sql = "insert into 题目内容(类型,题目,答案) values('{0}','{1}','{2}')";
        _sql = string.Format(_sql, lbtype.SelectedValue, _content, tbsave.Text);
        int _index = SchoolData.ExecNonQuery(_sql);
        if (_index > 0)
        {
            tbsave.Text = "";
            tbcontent.Text = "";
        }
        else
        {
            return;
        }

        _sql = "select * from 题目内容 order by id desc";
        DataTable _dt = SchoolData.Query(_sql);
        GridView1.DataSource = _dt;
        GridView1.DataBind();
    }

    protected void lbcourseselect_SelectedIndexChanged(object sender, EventArgs e)
    {
        string _sql = "select * from 题目内容 where 类型 = " + lbtype.SelectedValue;
        DataTable _dt = SchoolData.Query(_sql);
        GridView1.DataSource = _dt;
        GridView1.DataBind();
    }

    protected void OnSaveBactInfoClick(object sender, EventArgs e)
    {
        string _val = tbcontent.Text;
        string[] _vals = _val.Split(new string[] { ";" }, StringSplitOptions.None);
        foreach (string _v in _vals)
        {
            string _sql = _v.Replace("\n", "");
            if (string.IsNullOrEmpty(_sql)) continue;
            int _index = SchoolData.ExecNonQuery(_sql);
            if (_index != 1)
            {
                tbsave.Text = "错误" + _v;
                return;
            }
        }
        tbsave.Text = "成功";
    }
}