using System.Data;
using System.Web;
using Wx.Core;

namespace Wx.Work.WxQues
{
    public class WxQuesServiceInfo : WxServiceBase
    {
        private string courseId;
        private string infoId;
        private string answer;
        private string questype;
        private bool iserror;

        public override string GetResult(HttpContext context)
        {
            base.GetResult(context);
            string _result = string.Empty;
            courseId = context.Request.Params["CourseId"];
            infoId = context.Request.Params["InfoId"];
            answer = context.Request.Params["Answer"];
            questype = context.Request.Params["QuesType"];
            iserror = context.Request.Params["IsError"] != null && context.Request.Params["IsError"].ToUpper() == "TRUE";

            if (_type == "错题记录")
            {
                _result = SaveError();
            }
            else if (!string.IsNullOrEmpty(questype))
            {

            }
            else
            {
                _result = LoadInfo();
            }

            return _result;
        }

        public string LoadInfo()
        {
            //题目总数|已做|做错|题目ID#$&题目编号#$&题目内容#$&题目答案|选项编号1#$%选项内容1#$&选项编号2#$%选项内容2
            string _result = string.Empty;

            //答题提交处理
            if (!iserror && !string.IsNullOrEmpty(answer))
            {
                SubmitInfo();
            }

            DataRow _dr;
            DataTable _dt;

            //总题目数量
            _result = DataAgent.Ques.LoadQuInfoSum(courseId);

            //|已做|做错|位置
            _dt = DataAgent.Ques.LoadExam(_openid, courseId);
            if (_dt == null || _dt.Rows.Count == 0)
            {
                _result += "|0|0";
            }
            else
            {
                _dr = _dt.Rows[0];
                _result += "|" + DefualtZ(_dr.Str("HaveCount")) + "|" + DefualtZ(_dr.Str("ErrorCount"));
                if (!iserror && string.IsNullOrEmpty(infoId)) //历史做题位置
                    infoId = _dr.Str("Record");
            }
            if (string.IsNullOrEmpty(infoId))
            {
                //下一题ID
                infoId = "0";
            }
            if (iserror)
                infoId = DataAgent.Ques.LoadQuErrorNextId(_openid, courseId, infoId);
            else
                infoId = DataAgent.Ques.LoadQuInfoNextId(courseId, infoId);

            if (infoId == "" || infoId == "0")
                return "此类无题";

            //题目信息
            _dr = DataAgent.Ques.LoadQuInfoItem(infoId);
            if (_dr == null)
            {
                _result = "未找到题目!";
                return _result;
            }
            _result += "|" + _dr.Str("ID") + "#$&" + _dr.Str("InfoCode") + "#$&" + _dr.Str("Content") + "#$&" + _dr.Str("Answer") + "|";

            //选项信息
            _dt = DataAgent.Ques.LoadChose(infoId);
            foreach (DataRow item in _dt.Rows)
            {
                _result += item.Str("ChoseId") + "#$%" + item.Str("Chose") + "#$&";
            }

            return _result;
        }

        public void SubmitInfo()
        {
            string haveCount = "1";
            string errorCount = "0";
            DataRow _dr = DataAgent.Ques.LoadQuInfoItem(infoId);
            if (answer != _dr.Str("Answer"))
            {
                return;
                //errorCount = "1";
                //DataAgent.Ques.SaveError(_openid, courseId, infoId);
            }
            DataAgent.Ques.SaveExam(_openid, courseId, haveCount, errorCount, infoId);
        }

        public string DefualtZ(string val)
        {
            if (string.IsNullOrEmpty(val))
                return "0";
            return val;
        }

        private string SaveError()
        {
            string _result = string.Empty;
            string haveCount = "1";
            string errorCount = "1";
            DataAgent.Ques.SaveError(_openid, courseId, infoId);
            DataAgent.Ques.SaveExam(_openid, courseId, haveCount, errorCount, infoId);
            return _result;
        }

        //按大类别做错题
        private string LoadTypeError()
        {
            string _result = string.Empty;
            return _result;

        }
    }
}
