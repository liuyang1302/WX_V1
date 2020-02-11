<%@ WebHandler Language="C#" Class="Process" %>

using System;
using System.Web;

public class Process : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        Wx.Inter.WxProcess.Process(context);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}