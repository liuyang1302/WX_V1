using System;
using System.Diagnostics;
using System.Threading;
using System.Web;
using Wx.Core;

namespace Wx.Work.School
{
    public class SchoolVoiceInfo : WxServiceBase
    {
        public override string GetResult(HttpContext context)
        {
            DateTime _now = DateTime.Now;
            string _result = string.Empty;
            string _mediaId = context.Request.Params["MediaId"];
            string _accessToken = context.Request.Params["AccessToken"];

            if (string.IsNullOrEmpty(_mediaId) || string.IsNullOrEmpty(_accessToken))
                return "OK";

            Logger.WriteTxtLog(_mediaId + "|" + _accessToken);
            string fileName = System.AppDomain.CurrentDomain.BaseDirectory;
            if (!fileName.EndsWith("\\")) fileName += "\\";
            string _amr = fileName + "VoiceAmr\\";
            string _mp3 = fileName + "VoiceMp3\\";

            //下载文件
            string _url = string.Format("http://file.api.weixin.qq.com/cgi-bin/media/get?access_token={0}&media_id={1}", _accessToken, _mediaId);
            string _outName = string.Empty;
            string _errHtml = string.Empty;
            WebUtils _atWeb = new WebUtils();
            bool _isSuc = _atWeb.DownloadFile(_url, _amr, out _outName, out _errHtml);
            _outName = _outName.Substring(_outName.LastIndexOf('\\'));
            _mp3 = _mp3 + _outName.Replace(".amr", ".mp3");

            //转换文件
            string _val = ConvertToMp3(_amr + _outName, _mp3);

            //读取文件
            FileIO _fr = new FileIO();
            _fr.OpenReadFile(_mp3);
            string _content = _fr.ReadToEnd();
            _result = _content;
            return _result;
        }

        public string ConvertToMp3(string pathBefore, string pathLater)
        {
            string fileName = System.AppDomain.CurrentDomain.BaseDirectory;
            if (!fileName.EndsWith("\\")) fileName += "\\";
            string c = fileName + @"ffmpeg.exe -i " + pathBefore + " " + pathLater;
            string str = RunCmd(c);
            return str;
        }

        private string RunCmd(string c)
        {
            try
            {
                ProcessStartInfo info = new ProcessStartInfo("cmd.exe");
                info.RedirectStandardOutput = false;
                info.UseShellExecute = false;
                Process p = Process.Start(info);
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardInput = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                p.Start();
                p.StandardInput.WriteLine(c);
                p.StandardInput.AutoFlush = true;
                Thread.Sleep(1000);
                p.StandardInput.WriteLine("exit");
                p.WaitForExit();
                string outStr = p.StandardOutput.ReadToEnd();
                p.Close();

                return outStr;
            }
            catch (Exception ex)
            {
                return "error" + ex.Message;
            }
        }
    }
}
