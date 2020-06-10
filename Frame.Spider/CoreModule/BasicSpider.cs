using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Frame.Spider
{
    public interface BasicSpider
    {
        public string DisplayName { get; set; }

        public HttpRequestParameter RequestParameter { get; }

        public void OnHandleSpiderStartAsync();
        public IEnumerable<Uri> StartUrls { get; set; }
        public BaseFieldsItem Parse(HtmlAgilityPack.HtmlDocument response);
    }
}
