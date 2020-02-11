using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Wx.Work
{
    public interface IWxFactory
    {
        WxServiceBase Services(HttpContext context);

        string Result(HttpContext context);
    }
}
