using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace metalAssistor.HttpUtil
{
    class HttpClient
    {
        public static T HttpGet<T>(string url) where T : class, new()
        {
            try
            {
                string retString = "";
                //创建Request对象
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
                request.Timeout = 30000;
                request.ReadWriteTimeout = 30000;
                request.Headers.Add("Authorization", Constant.Authorization);
                request.Headers.Add("appKey", Constant.appKey);
                request.Headers.Add("secret", Constant.secret);
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    //输出响应流
                    Stream stream = response.GetResponseStream();
                    using (StreamReader streamReader = new StreamReader(stream, Encoding.UTF8))
                    {
                        retString = streamReader.ReadToEnd().ToString();
                    }
                }
                //JSON序列化
                return JsonConvert.DeserializeObject<T>(retString);
            }
            catch (Exception e)
            {
                string mse = e.Message;
                return new T();
            }
        }


        /// <summary>
        /// POST请求
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url">请求Url地址</param>
        /// <param name="postParameters">post提交参数</param>
        /// <returns></returns>
        public static T HttpPostDic<T>(string url, Dictionary<string, object> postParameters) where T : class, new()
        {
            try
            {
                string retString = "";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Headers.Add("Authorization", Constant.Authorization);
                request.Headers.Add("appKey", Constant.appKey);
                request.Headers.Add("secret", Constant.secret);
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded;charset:utf-8";
                //POST参数
                StringBuilder paraStrBuilder = new StringBuilder();
                foreach (string key in postParameters.Keys)
                {
                    paraStrBuilder.AppendFormat("{0}={1}&", key, postParameters[key]);
                }
                string para = paraStrBuilder.ToString();
                if (para.EndsWith("&"))
                    para = para.Remove(para.Length - 1, 1);
                //编码要跟服务器编码统一
                byte[] bt = Encoding.UTF8.GetBytes(para);
                string responseData = String.Empty;
                request.ContentLength = bt.Length;
                //GetRequestStream输入流数据
                using (Stream reqStream = request.GetRequestStream())
                {
                    reqStream.Write(bt, 0, bt.Length);
                    reqStream.Close();
                }
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    Stream stream = response.GetResponseStream();
                    using (StreamReader streamReader = new StreamReader(stream, Encoding.UTF8))
                    {
                        retString = streamReader.ReadToEnd().ToString();
                    }
                }
                //反序列化
                return JsonConvert.DeserializeObject<T>(retString);
            }
            catch(Exception e)
            {
                return new T();
            }

        }

        public static ResultMode HttpPostJson(string url, string body)
        {
            try
            {
                string retString = "";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Headers.Add("Authorization", Constant.Authorization);
                request.Headers.Add("appKey", Constant.appKey);
                request.Headers.Add("secret", Constant.secret);
                request.Method = "POST";
                request.Accept = "text/html, application/xhtml+xml, */*";
                request.ContentType = "application/json";
                byte[] buffer = Encoding.UTF8.GetBytes(body);
                request.ContentLength = buffer.Length;

                using (Stream reqStream = request.GetRequestStream())
                {
                    reqStream.Write(buffer, 0, buffer.Length);
                    reqStream.Close();
                }

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    Stream stream = response.GetResponseStream();
                    using (StreamReader streamReader = new StreamReader(stream, Encoding.UTF8))
                    {
                        retString = streamReader.ReadToEnd().ToString();
                    }
                }
                return JsonConvert.DeserializeObject<ResultMode>(retString);
            }
            catch(Exception e)
            {
                return new ResultMode() {Code="500",Msg=e.Message };
            }
        }

        public static T HttpPostFile<T>(string url, List<KeyValue> nvc) where T : class, new()
        {
            try
            {
                string retString = "";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Headers.Add("Authorization", Constant.Authorization);
                request.Headers.Add("appKey", Constant.appKey);
                request.Headers.Add("secret", Constant.secret);
                Console.WriteLine(request.Headers);
                //  log.Debug(string.Format("Uploading {0} to {1}", file, url));
                string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
                byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");

                HttpWebRequest wr = request;
                wr.ContentType = "multipart/form-data; boundary=" + boundary;
                wr.Method = "POST";
                wr.KeepAlive = true;
                wr.Credentials = System.Net.CredentialCache.DefaultCredentials;



                using (Stream rs = wr.GetRequestStream())
                {
                    // 普通参数模板
                    string formdataTemplate = "Content-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}";
                    //带文件的参数模板
                    string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n";
                    foreach (KeyValue keyValue in nvc)
                    {
                        //如果是普通参数
                        if (keyValue.FilePath == null)
                        {
                            rs.Write(boundarybytes, 0, boundarybytes.Length);
                            string formitem = string.Format(formdataTemplate, keyValue.Key, keyValue.Value);
                            byte[] formitembytes = System.Text.Encoding.UTF8.GetBytes(formitem);
                            rs.Write(formitembytes, 0, formitembytes.Length);
                        }
                        //如果是文件参数,则上传文件
                        else
                        {
                            rs.Write(boundarybytes, 0, boundarybytes.Length);

                            string header = string.Format(headerTemplate, keyValue.Key, keyValue.FilePath, keyValue.ContentType);
                            byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(header);
                            rs.Write(headerbytes, 0, headerbytes.Length);

                            using (var fileStream = new FileStream(keyValue.FilePath, FileMode.Open, FileAccess.Read))
                            {
                                byte[] buffer = new byte[4096];
                                int bytesRead = 0;
                                long total = 0;
                                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
                                {

                                    rs.Write(buffer, 0, bytesRead);
                                    total += bytesRead;
                                }
                            }
                        }

                    }

                    byte[] trailer = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");
                    rs.Write(trailer, 0, trailer.Length);

                }

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    Stream stream = response.GetResponseStream();
                    using (StreamReader streamReader = new StreamReader(stream, Encoding.UTF8))
                    {
                        retString = streamReader.ReadToEnd().ToString();
                    }
                }
                //反序列化
                return JsonConvert.DeserializeObject<T>(retString);
            }
            catch
            {
                return new T();
            }

        }
    }
}
