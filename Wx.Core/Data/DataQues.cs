using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wx.Core.Data
{
    public class DataQues
    {
        #region 成员

        private string _loadCourse = "SELECT ID,CourseName from WX_QU_COURSE";
        private string _saveCourse = "INSERT INTO WX_QU_COURSE (CourseName) VALUES ('{0}')";
        private string _loadQuInfo = "SELECT * FROM WX_QU_INFO WHERE CourId = {0}";
        private string _loadQuInId = "SELECT * FROM WX_QU_INFO WHERE ID = {0}";
        private string _loadQuIsum = "SELECT Count(*) AS QCount FROM WX_QU_INFO WHERE CourId = {0}";
        private string _loadQuImin = "SELECT min(ID) AS QMinID FROM WX_QU_INFO WHERE CourId = {0}";
        private string _loadQuNext = "SELECT min(ID) AS QMinID FROM WX_QU_INFO WHERE CourId = {0} AND ID > {1}";
        private string _saveQuInfo = "INSERT INTO WX_QU_INFO (InfoCode,Content,CourId,Answer) VALUES ('{0}','{1}','{2}','{3}')";
        private string _loadChoses = "SELECT * FROM WX_QU_CHOSE WHERE InfoId = {0}";
        private string _saveChoses = "INSERT INTO WX_QU_CHOSE (InfoId,ChoseId,Chose) VALUES ('{0}','{1}','{2}')";
        private string _loadQuExam = "SELECT * FROM WX_QU_EXAM WHERE OpenId = '{0}'";
        private string _loadQuExcu = "SELECT * FROM WX_QU_EXAM WHERE OpenId = '{0}' AND CourseId = {1}";
        private string _saveQuExam = "INSERT INTO WX_QU_EXAM (OpenId,CourseId,HaveCount,ErrorCount,Record) VALUES ('{0}','{1}','{2}','{3}','{4}')";
        private string _loadErrors = "SELECT * FROM WX_QU_ERROR A, WX_QU_INFO B WHERE A.INFOID = B.ID AND A.OPENID = '{0}' AND CourseId = {1}";
        private string _loadErrord = "SELECT * FROM WX_QU_ERROR WHERE OPENID = '{0}' AND CourseId = {1} AND InfoId = {2}";
        private string _saveErrors = "INSERT INTO WX_QU_ERROR (OpenId,CourseId,InfoId) VALUES ('{0}','{1}','{2}')";
        private string _loadErNext = "SELECT min(InfoId) AS QMinID FROM WX_QU_ERROR WHERE OPENID = '{0}' AND CourseId = {1} AND InfoId > {2}";

        #endregion

        /// <summary>
        /// 获取科目信息
        /// </summary>
        /// <returns></returns>
        public DataTable LoadCourse()
        {
            return DataAccess.Query(_loadCourse);
        }

        /// <summary>
        /// 按类型获取科目信息
        /// </summary>
        /// <param name="questype">类型</param>
        /// <returns></returns>
        public DataTable LoadCourse(string questype)
        {
            return DataAccess.Query(_loadCourse + " WHERE QuesType='" + questype + "'");
        }


        /// <summary>
        /// 保存科目信息
        /// </summary>
        /// <param name="courseName">科目名称</param>
        /// <returns></returns>
        public bool SaveCourse(string courseName)
        {
            return DataAccess.ExecNonQuery(string.Format(_saveCourse, courseName)) > 0;
        }

        /// <summary>
        /// 获取题目信息
        /// </summary>
        /// <param name="courId">科目ID</param>
        /// <returns></returns>
        public DataTable LoadQuInfo(string courId)
        {
            return DataAccess.Query(string.Format(_loadQuInfo, courId));
        }

        public DataTable LoadQuInfo(string courId, string InfoCode)
        {
            return DataAccess.Query(string.Format(_loadQuInfo, courId) + " AND InfoCode='" + InfoCode + "'");
        }

        /// <summary>
        /// 获取题目数量
        /// </summary>
        /// <param name="courId"></param>
        /// <returns></returns>
        public string LoadQuInfoSum(string courId)
        {
            DataTable _dt = DataAccess.Query(string.Format(_loadQuIsum, courId));
            if (_dt == null || _dt.Rows.Count == 0)
                return "0";
            return _dt.Rows[0].Str("QCount");
        }

        /// <summary>
        /// 获取科目最小ID
        /// </summary>
        /// <param name="courId"></param>
        /// <returns></returns>
        public string LoadQuInfoId(string courId)
        {
            DataTable _dt = DataAccess.Query(string.Format(_loadQuImin, courId));
            if (_dt == null || _dt.Rows.Count == 0)
                return "1";
            return _dt.Rows[0].Str("QMinID");
        }

        /// <summary>
        /// 载入下一个ID
        /// </summary>
        /// <param name="courId"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        public string LoadQuInfoNextId(string courId, string Id)
        {
            DataTable _dt = DataAccess.Query(string.Format(_loadQuNext, courId, Id));
            if (_dt == null || _dt.Rows.Count == 0 || _dt.Rows[0].Str("QMinID") == "")
            {
                _dt = DataAccess.Query(string.Format(_loadQuNext, courId, "0"));
            }
            if (_dt == null || _dt.Rows.Count == 0)
                return "1";
            return _dt.Rows[0].Str("QMinID");
        }

        /// <summary>
        /// 载入下一个错误ID
        /// </summary>
        /// <param name="openid"></param>
        /// <param name="courId"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        public string LoadQuErrorNextId(string openid, string courId, string Id)
        {
            DataTable _dt = DataAccess.Query(string.Format(_loadErNext, openid, courId, Id));
            if (_dt == null || _dt.Rows.Count == 0 || _dt.Rows[0].Str("QMinID") == "")
            {
                _dt = DataAccess.Query(string.Format(_loadErNext, openid, courId, "0"));
            }
            if (_dt == null || _dt.Rows.Count == 0)
                return "0";
            return _dt.Rows[0].Str("QMinID");
        }


        /// <summary>
        /// 获取当前科目信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public DataRow LoadQuInfoItem(string Id)
        {
            DataTable _dt = DataAccess.Query(string.Format(_loadQuInId, Id));
            if (_dt == null || _dt.Rows.Count == 0)
                return null;
            return _dt.Rows[0];
        }


        /// <summary>
        /// 保存题目信息
        /// </summary>
        /// <param name="InfoCode">题目编码</param>
        /// <param name="Content">题目内容</param>
        /// <param name="CourId">科目ID</param>
        /// <param name="Answer">题目答案</param>
        /// <returns></returns>
        public bool SaveQuInfo(string InfoCode, string Content, string CourId, string Answer)
        {
            return DataAccess.ExecNonQuery(string.Format(_saveQuInfo, InfoCode, Content, CourId, Answer)) > 0;
        }

        /// <summary>
        /// 获取选项信息
        /// </summary>
        /// <param name="infoId">题目ID</param>
        /// <returns></returns>
        public DataTable LoadChose(string infoId)
        {
            return DataAccess.Query(string.Format(_loadChoses, infoId));
        }

        /// <summary>
        /// 保存选项信息
        /// </summary>
        /// <param name="infoId">题目ID</param>
        /// <param name="choseId">选项编号</param>
        /// <param name="chose">选项内容</param>
        /// <returns></returns>
        public bool SaveChose(string infoId, string choseId, string chose)
        {
            return DataAccess.ExecNonQuery(string.Format(_saveChoses, infoId, choseId, chose)) > 0;
        }

        /// <summary>
        /// 获取用户记录
        /// </summary>
        /// <param name="openid"></param>
        /// <returns></returns>
        public DataTable LoadExam(string openid)
        {
            return DataAccess.Query(string.Format(_loadQuExam, openid));
        }

        /// <summary>
        /// 获取用户记录
        /// </summary>
        /// <param name="openid"></param>
        /// <param name="courseid"></param>
        /// <returns></returns>
        public DataTable LoadExam(string openid, string courseid)
        {
            return DataAccess.Query(string.Format(_loadQuExcu, openid, courseid));
        }

        /// <summary>
        /// 保存用户记录
        /// </summary>
        /// <param name="openId">用户标识</param>
        /// <param name="haveCount">答题数量</param>
        /// <param name="errorCount">错误数量</param>
        /// <param name="record">答题记录</param>
        /// <returns></returns>
        public bool SaveExam(string openId, string courseId, string haveCount, string errorCount, string record)
        {
            if (string.IsNullOrEmpty(haveCount) && string.IsNullOrEmpty(errorCount) && string.IsNullOrEmpty(record))
                return false;

            DataTable _dt = LoadExam(openId, courseId);
            if (_dt == null || _dt.Rows.Count == 0)
            {
                DataAccess.ExecNonQuery(string.Format(_saveQuExam, openId, courseId, "0", "0", "0"));
            }

            string _update = "UPDATE WX_QU_EXAM SET ";
            if (!string.IsNullOrEmpty(haveCount))
            {
                _update += " HaveCount = HaveCount +" + haveCount;
            }
            if (!string.IsNullOrEmpty(errorCount))
            {
                _update += ", ErrorCount = ErrorCount + " + errorCount;
            }
            if (!string.IsNullOrEmpty(record))
            {
                _update += ", Record = " + record;
            }
            _update += " WHERE OpenID = '" + openId + "' AND CourseId = " + courseId;
            return DataAccess.ExecNonQuery(_update) > 0;
        }

        /// <summary>
        /// 获取答错题目
        /// </summary>
        /// <param name="openId"></param>
        /// <returns></returns>
        public DataTable LoadError(string openId, string courseId)
        {
            return DataAccess.Query(string.Format(_loadErrors, openId, courseId));
        }

        /// <summary>
        /// 保存答错题目
        /// </summary>
        /// <param name="openId"></param>
        /// <param name="infoId"></param>
        /// <returns></returns>
        public bool SaveError(string openId, string courseId, string infoId)
        {
            DataTable _dt = DataAccess.Query(string.Format(_loadErrord, openId, courseId, infoId));
            if (_dt != null && _dt.Rows.Count > 0)
                return true;
            return DataAccess.ExecNonQuery(string.Format(_saveErrors, openId, courseId, infoId)) > 0;
        }

    }
}
