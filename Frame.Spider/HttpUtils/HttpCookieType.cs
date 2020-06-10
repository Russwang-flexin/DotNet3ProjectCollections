﻿using System.Net;

namespace Frame.Spider
{
    /// <summary>
    /// Cookie对应类
    /// </summary>
    public class HttpCookieType
    {
        /// <summary>
        /// cookie集合
        /// </summary>
        public CookieCollection CookieCollection { get; set; }
        /// <summary>
        /// Cookie字符串
        /// </summary>
        public string CookieString { get; set; }
    }
}
