using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Wx.Core;

namespace Wx.Work.Htn
{
    public class HtnProServiceMain : WxServiceBase
    {
        public override string GetResult(HttpContext context)
        {
            base.GetResult(context);

            string _result = string.Empty;

            if (_type == "Main_TopScroll") //验证是否老用户
            {
                _result = TopScroll();
            }

            return _result;
        }

        public string TopScroll()
        {
            string _result = string.Empty;
            List<HtnEntity> _list = new List<HtnEntity>();
            _list.Add(new HtnEntity() { Id = "1", Pic = "http://image.360kad.com/group2/M00/55/F1/CgAgFVrpfrSAa4qWAAFZAz07KlY048.jpg" });
            _list.Add(new HtnEntity() { Id = "2", Pic = "http://image.360kad.com/group2/M00/55/A7/CgAgFFrpFzKAOw9YAAF3WlpHNYA465.jpg" });
            _list.Add(new HtnEntity() { Id = "3", Pic = "http://image.360kad.com/group2/M00/55/A1/CgAgFVrpERGAYg4vAAEgW6v_r9Y393.jpg" });
            _list.Add(new HtnEntity() { Id = "4", Pic = "http://image.360kad.com/group2/M00/53/EE/CgAgFFri1_KAaTTWAAFbc9evGk8354.jpg" });
            _result = AtJson.ToJsJson(_list);
            return _result;
        }
    }
}
