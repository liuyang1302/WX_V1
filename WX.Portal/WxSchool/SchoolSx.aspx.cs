using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WxSchool_SchoolSx : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        openid.InnerHtml = Request.QueryString["OpenID"];
        nickname.InnerHtml = Request.QueryString["NickName"];
        courseid.InnerHtml = Request.QueryString["CourseId"];
        coursename.InnerHtml = Request.QueryString["CourseName"];
        questype.InnerHtml = Request.QueryString["QuesType"];
    }
}