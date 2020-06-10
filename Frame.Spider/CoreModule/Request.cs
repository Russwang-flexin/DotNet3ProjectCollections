using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Frame.Spider
{
    public class Request
    {
        public HttpWebRequest WebRequest { get; set; }
        public Func<HtmlAgilityPack.HtmlDocument, BaseFieldsItem> Callback { get; set; }
    }
}
