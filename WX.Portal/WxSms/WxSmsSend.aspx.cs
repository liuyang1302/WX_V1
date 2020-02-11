using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WxSms_WxSmsSend : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string queryString = TextArea1.InnerText;
        HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://localhost/WXPortal/WxHandlers/WxSmsService.ashx?Type=Phone");
        request.ContentType = "text/plain";
        request.Method = "POST";
        request.ContentLength = queryString.Length;
        request.Timeout = 20000;
        byte[] bytes = Encoding.UTF8.GetBytes(queryString);
        Stream os = null;
        try
        { // send the Post
            request.ContentLength = bytes.Length;   //Count bytes to send
            os = request.GetRequestStream();
            os.Write(bytes, 0, bytes.Length);         //Send it
        }
        catch (WebException ex)
        {
            throw ex;
        }
        finally
        {
            if (os != null)
            {
                os.Close();
            }
        }
    }
}