using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebOS.FallHub.Core
{
    /// <summary>
    /// web url,links data retrive
    /// </summary>
    public class Weblink
    {
        /// <summary>
        /// Index the url as a md5 code if url has indexed, then return it
        /// </summary>
        /// <param name="url"></param>
        /// <returns>return { url}</returns>
        public static dynamic WebIndex(string url,string title="")
        {
            dynamic obj = new {sUrl=url,sHashCode="",sTitle=title };
            var jsData = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            string err = string.Empty;
            var ar = Utilities.RequestManager.RequestByRest(LocalData.RemoteUrls["index"], jsData, Utilities.RequestManager.MethodType.POST, "text/json", Encoding.UTF8, out err);
            dynamic outar = Newtonsoft.Json.JsonConvert.DeserializeObject(ar);
            return outar;
        }
    }
}
