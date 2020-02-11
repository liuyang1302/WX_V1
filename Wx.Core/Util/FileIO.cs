using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Wx.Core
{
    public class FileIO
    {
        #region 成员
        private FileStream fsw;
        private StreamWriter sw;
        private FileStream fsr;
        private StreamReader sr;
        private string Charset = "UTF-8";
        #endregion

        #region 构造

        public FileIO()
        {

        }

        public FileIO(string charset)
        {
            Charset = charset;
        }
        #endregion

        #region 基础
        /// <summary>
        /// 创建路径
        /// </summary>
        /// <param name="filePath"></param>
        private void CreateDir(string filePath)
        {
            string dirPath = System.IO.Path.GetDirectoryName(filePath);
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
        }

        /// <summary>
        /// 打开写入文件
        /// </summary>
        /// <param name="filePath"></param>
        public void OpenWriteFile(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    CreateDir(filePath);
                    File.Create(filePath).Close();
                    fsw = new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                    sw = new StreamWriter(fsw, Encoding.GetEncoding(Charset));
                }
                else
                {
                    fsw = new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                    sw = new StreamWriter(fsw, Encoding.GetEncoding(Charset));
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// 关闭写入文件
        /// </summary>
        public void CloseWriteFile()
        {
            if (fsw != null)
            {
                fsw.Close();
            }
        }

        /// <summary>
        /// 写入文件内容
        /// </summary>
        /// <param name="s"></param>
        public void WriteLine(string s)
        {
            if (sw != null)
            {
                sw.WriteLine(s);
                sw.Flush();
            }
        }


        /// <summary>
        /// 打开读取文件
        /// </summary>
        /// <param name="filePath"></param>
        public void OpenReadFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                CreateDir(filePath);
                File.Create(filePath).Close();
            }
            fsr = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Read, FileShare.ReadWrite);
            sr = new StreamReader(fsr, Encoding.GetEncoding(Charset));
        }

        /// <summary>
        /// 关闭读取文件
        /// </summary>
        public void CloseReadFile()
        {
            if (fsr != null)
                fsr.Close();
        }

        /// <summary>
        /// 读取一行
        /// </summary>
        /// <returns></returns>
        public string ReadLine()
        {
            if (sr.EndOfStream)
                return null;
            return sr.ReadLine();
        }

        /// <summary>
        /// 读取全部
        /// </summary>
        /// <returns></returns>
        public string ReadToEnd()
        {
            if (sr.EndOfStream) { return null; }
            return sr.ReadToEnd();
        }

        /// <summary>
        /// 获取是否到末尾
        /// </summary>
        /// <returns></returns>
        public bool IsEof()
        {
            return sr.EndOfStream;
        }
        #endregion

        #region 静态
        /// <summary>
        /// 读取文件信息
        /// </summary>
        /// <param name="p_fileName"></param>
        /// <returns></returns>
        public static string ReadFile(string p_fileName)
        {
            try
            {
                using (FileStream fs = File.Open(p_fileName, FileMode.OpenOrCreate))
                {
                    StreamReader _sr = new StreamReader(fs, Encoding.UTF8);
                    return _sr.ReadToEnd();
                }
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// 读取文件信息(只读)
        /// </summary>
        /// <param name="p_fileName"></param>
        /// <returns></returns>
        public static string ReadFileCS(string p_fileName)
        {
            try
            {
                string _fileContent = "";
                bool _isreadonly = IsReadOnlyFlag(p_fileName);
                if (_isreadonly)
                {
                    RemoveReadOnlyFlag(p_fileName);
                }
                using (FileStream fs = File.Open(p_fileName, FileMode.OpenOrCreate))
                {
                    StreamReader _sr = new StreamReader(fs);
                    _fileContent = _sr.ReadToEnd();
                }
                if (_isreadonly)
                {
                    AddReadOnlyFlag(p_fileName);
                }
                return _fileContent;
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// 将指定内容新建或追加到文件
        /// </summary>
        /// <param name="p_fileName"></param>
        /// <param name="p_content"></param>
        /// <param name="p_append"></param>
        public static void WriteFile(string p_fileName, string p_content, bool p_append = false)
        {
            try
            {
                string _path = p_fileName.Substring(0, p_fileName.LastIndexOf('\\'));

                if (!Directory.Exists(_path))
                {
                    Directory.CreateDirectory(_path);
                }

                if (p_append)
                {
                    string _val;
                    using (FileStream fs = File.Open(p_fileName, FileMode.OpenOrCreate))
                    {
                        StreamReader _sr = new StreamReader(fs, Encoding.UTF8);
                        _val = _sr.ReadToEnd();
                    }

                    using (FileStream fs = File.Open(p_fileName, FileMode.OpenOrCreate))
                    {

                        StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
                        sw.Write(_val + p_content);
                        sw.Flush();
                    }
                }
                else
                {
                    using (FileStream fs = File.Open(p_fileName, FileMode.Create))
                    {
                        StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
                        sw.Write(p_content);
                        sw.Flush();
                    }
                }
            }
            catch
            { }
        }

        /// <summary>
        /// 将指定内容新建或追加到文件
        /// </summary>
        /// <param name="p_fileName"></param>
        /// <param name="p_content"></param>
        public static void WriteAppend(string p_fileName, string p_content)
        {
            WriteFile(p_fileName, p_content, true);
        }

        /// <summary>
        /// 删除指定文件
        /// </summary>
        /// <param name="p_filaName"></param>
        public static void DeleteFile(string p_filaName)
        {
            if (p_filaName.Contains("*"))
            {
                string[] files = p_filaName.Split('*');
                foreach (string file in files)
                {
                    if (file.Contains(".zip") || string.IsNullOrEmpty(file))
                        continue;
                    File.Delete(file);
                }
            }
            else
            {
                File.Delete(p_filaName);
            }
        }

        /// <summary>
        /// 创建XML文件
        /// </summary>
        public static void CreateXMLFile(string p_filename, string p_content = "")
        {
            string _path = p_filename.Substring(0, p_filename.LastIndexOf('\\'));

            if (!Directory.Exists(_path))
            {
                Directory.CreateDirectory(_path);
            }

            if (!File.Exists(p_filename))
            {
                using (StreamWriter sw = new StreamWriter(p_filename, false, Encoding.UTF8))
                {
                    sw.Write(p_content);
                    sw.Flush();
                }
            }
        }

        /// <summary>
        /// 移除文件的只读属性
        /// </summary>
        /// <param name="p_filePath"></param>
        public static void RemoveReadOnlyFlag(string p_filePath)
        {
            if (!File.Exists(p_filePath))
                return;
            try
            {
                FileAttributes fileAttributes = File.GetAttributes(p_filePath);
                if ((fileAttributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                {
                    fileAttributes &= ~FileAttributes.ReadOnly;
                    File.SetAttributes(p_filePath, fileAttributes);
                }
            }
            catch
            { }
        }

        /// <summary>
        /// 添加文件的只读属性
        /// </summary>
        /// <param name="p_filePath"></param>
        public static void AddReadOnlyFlag(string p_filePath)
        {
            if (!File.Exists(p_filePath))
                return;
            try
            {
                FileAttributes fileAttributes = File.GetAttributes(p_filePath);
                fileAttributes &= FileAttributes.ReadOnly;
                File.SetAttributes(p_filePath, fileAttributes);
            }
            catch
            { }
        }

        /// <summary>
        /// 添加文件的只读属性
        /// </summary>
        /// <param name="p_filePath"></param>
        public static bool IsReadOnlyFlag(string p_filePath)
        {
            if (!File.Exists(p_filePath))
                return false;
            try
            {
                FileAttributes fileAttributes = File.GetAttributes(p_filePath);
                if ((fileAttributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                {
                    return true;
                }
            }
            catch
            { }
            return false;
        }

        /// <summary>
        /// 读取工厂XML文件
        /// </summary>
        /// <returns></returns>
        public static XmlDocument ReadXMLFile(string p_filename)
        {
            CreateXMLFile(p_filename);
            XmlDocument xd = new XmlDocument();
            xd.Load(p_filename);
            return xd;
        }

        /// <summary>
        /// 写入工厂XML文件
        /// </summary>
        /// <param name="P_hienum"></param>
        public static void WriteXMLFile(string p_filename, string p_content = "")
        {
            CreateXMLFile(p_filename);
            XmlDocument xd = new XmlDocument();
            xd.LoadXml(p_content);
            xd.Save(p_filename);
        }

        public static void WriteXMLFile(string p_filename, XmlDocument p_xd)
        {
            CreateXMLFile(p_filename);
            p_xd.Save(p_filename);
        }

        /// <summary>
        /// 判断文件是否存在
        /// </summary>
        /// <param name="p_filename"></param>
        /// <returns></returns>
        public static bool FileExists(string p_filename)
        {
            return File.Exists(p_filename);
        }

        /// <summary>
        /// 获取路径下文件列表
        /// </summary>
        /// <param name="p_path"></param>
        /// <returns></returns>
        public static List<string> GetFiless(string p_path)
        {
            List<string> _list = new List<string>();

            foreach (var item in Directory.GetFiles(p_path))
            {
                _list.Add(item);
            }

            return _list;
        }
        #endregion
    }
}
