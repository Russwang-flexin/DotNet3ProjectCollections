using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Frame.Spider
{

    public enum ReQequestMethodType
    {
        Get,
        Post,
    }


    public class Headers
    {
        public string UserAgent { get; set; }
        public string ContentType { get; set; }

        public string Accept { get; set; }
        public bool KeepAlive { get; set; } = true;
        public bool AllowAutoRedirect { get; set; } = false;
        public Version httpVersion { get; set; } = HttpVersion.Version11;
    }

    /// <summary>
    /// 请求参数类
    /// </summary>
    public class HttpRequestParameter
    {
        public HttpRequestParameter()
        {
            Encoding = Encoding.UTF8;
        }

        public ReQequestMethodType Method { get; set; }

        public IEnumerable<Uri> Url { get; set; }

        public HttpCookieType Cookie { get; set; }

        public Encoding Encoding { get; set; }

        public IDictionary<string, string> Parameters { get; set; }

        public Headers headers { get; set; }

        public string RefererUrl { get; set; }

        public static HttpRequestParameter Default
        {
            get
            {
                return new HttpRequestParameter()
                {
                    Method = ReQequestMethodType.Get,
                };
            }
        }
    }
}
