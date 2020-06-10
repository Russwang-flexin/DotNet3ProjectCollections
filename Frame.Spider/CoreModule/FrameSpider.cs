using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text;

namespace Frame.Spider
{
    /// <summary>
    /// 用户新增爬虫继承的父类
    /// </summary>
    public abstract class FrameSpider : BasicSpider
    {
        public FrameSpider()
        {
            OnHandleSpiderStartAsync();
        }

        public HttpRequestParameter RequestParameter { get; set; } = HttpRequestParameter.Default;
        public abstract string DisplayName { get; set; }

        public abstract IEnumerable<Uri> StartUrls { get; set; }


        public void OnHandleSpiderStartAsync()
        {
            if (StartUrls == null)
            {
                throw new ArgumentException("StartUrls Is Null");
            }
            SpiderRegistry.Instance.RegistrySpier(this);

        }
        public abstract BaseFieldsItem Parse(HtmlDocument response);
    }
}
