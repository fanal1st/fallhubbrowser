using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;

namespace WebOS.Utilities
{
    /// <summary>
    /// url request helper ,rest style request
    /// </summary>
    public static class RequestManager
    {
        public enum MethodType
        {
            POST,
            GET,
            PUT,
            DELETE
        }

        public static string RequestByRest(string url, string Data, MethodType method, string contentType, Encoding encoding,out string err , int timeOut = 15000)
        {
            err = string.Empty;
            string str = string.Empty;
            try
            {
                if (method == MethodType.GET)
                {
                    url = url + Data;
                }
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Timeout = timeOut;
                if (method == MethodType.POST)
                {
                    request.KeepAlive = false;
                    request.Method = "Post";
                    request.ServicePoint.Expect100Continue = false;
                    byte[] bytes = encoding.GetBytes(Data);
                    request.ContentLength = bytes.Length;
                    if (!string.IsNullOrEmpty(contentType))
                    {
                        request.ContentType = contentType;
                    }
                    Stream requestStream = request.GetRequestStream();
                    requestStream.Write(bytes, 0, bytes.Length);
                    requestStream.Close();
                }

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (StreamReader reader = new StreamReader(response.GetResponseStream(), encoding))
                {
                    str = reader.ReadToEnd().ToString();
                    reader.Close();
                }
                response.Close();
             
            }
            catch (Exception ex)
            {
                err = ex.Message;
            }
            return str;
        }



    }
}
