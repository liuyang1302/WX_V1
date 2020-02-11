using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Wx.Core;

public partial class WxService_WxQuesInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadCou();
            lbcourseselect.SelectedIndexChanged += Lbcourseselect_SelectedIndexChanged;
        }
    }

    private void Lbcourseselect_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable _dt = DataAgent.Ques.LoadQuInfo(lbcourseselect.SelectedValue);
        GridView1.DataSource = _dt;
        GridView1.DataBind();
    }

    private void LoadCou()
    {
        DataTable _cdt = DataAgent.Ques.LoadCourse();
        lbcourse.Items.Clear();
        lbcourseselect.Items.Clear();
        foreach (DataRow _dr in _cdt.Rows)
        {
            lbcourse.Items.Add(new ListItem() { Value = _dr.Str("ID"), Text = _dr.Str("CourseName") });
        }
        foreach (DataRow _dr in _cdt.Rows)
        {
            lbcourseselect.Items.Add(new ListItem() { Value = _dr.Str("ID"), Text = _dr.Str("CourseName") });
        }

        DataTable _dt = DataAgent.Ques.LoadQuInfo("1");
        GridView1.DataSource = _dt;
        GridView1.DataBind();
        //GridView1.Columns[2].HeaderStyle.Width = new Unit(200);
    }

    protected void OnSaveCourseClick(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(tbcourse.Text))
            return;
        bool _is = DataAgent.Ques.SaveCourse(tbcourse.Text);
        LoadCou();
    }

    protected void OnSaveInfoClick(object sender, EventArgs e)
    {
        string _content = tbcontent.Text;
        if (string.IsNullOrEmpty(_content)) return;


        bool _is = DataAgent.Ques.SaveQuInfo(tbcode.Text, _content, lbcourseselect.SelectedValue, lbanswer.SelectedValue);
        if (!_is)
        {
            tbsave.Text = "题目保存不成功!";
            return;
        }

        DataTable _dt = DataAgent.Ques.LoadQuInfo(lbcourseselect.SelectedValue, tbcode.Text);
        string _id = _dt.Rows[0].Str("ID");

        if (!string.IsNullOrEmpty(tbA.Text))
        {
            _is = DataAgent.Ques.SaveChose(_id, "A", tbA.Text);
            if (!_is)
            {
                tbsave.Text = "选项A保存不成功!";
                return;
            }
        }
        if (!string.IsNullOrEmpty(tbB.Text))
        {
            _is = DataAgent.Ques.SaveChose(_id, "B", tbB.Text);
            if (!_is)
            {
                tbsave.Text = "选项B保存不成功!";
                return;
            }
        }
        if (!string.IsNullOrEmpty(tbC.Text))
        {
            _is = DataAgent.Ques.SaveChose(_id, "C", tbC.Text);
            if (!_is)
            {
                tbsave.Text = "选项C保存不成功!";
                return;
            }
        }
        if (!string.IsNullOrEmpty(tbD.Text))
        {
            _is = DataAgent.Ques.SaveChose(_id, "D", tbD.Text);
            if (!_is)
            {
                tbsave.Text = "选项D保存不成功!";
                return;
            }
        }
        if (!string.IsNullOrEmpty(tbE.Text))
        {
            _is = DataAgent.Ques.SaveChose(_id, "E", tbE.Text);
            if (!_is)
            {
                tbsave.Text = "选项E保存不成功!";
                return;
            }
        }
        if (!string.IsNullOrEmpty(tbF.Text))
        {
            _is = DataAgent.Ques.SaveChose(_id, "F", tbF.Text);
            if (!_is)
            {
                tbsave.Text = "选项F保存不成功!";
                return;
            }
        }
        tbsave.Text = "保存成功!";

        tbcode.Text = "";
        tbcontent.Text = "";
        tbA.Text = "";
        tbB.Text = "";
        tbC.Text = "";
        tbD.Text = "";
        tbE.Text = "";
        tbF.Text = "";

        DataTable _source = DataAgent.Ques.LoadQuInfo(lbcourseselect.SelectedValue);
        GridView1.DataSource = _source;
        GridView1.DataBind();
    }
}