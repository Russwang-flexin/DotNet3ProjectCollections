using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// 爬虫的一个console Demo
/// </summary>
namespace Frame.Spider
{
    class Program
    {
        static void Main(string[] args)
        {
            SpiderTemplete spiderTemplete = new SpiderTemplete();
            SpiderManager.Instance.Start();
        }
    }

    public class SpiderTemplete : FrameSpider
    {
        public override string DisplayName { get; set; } = "thsf10_spider";

        public SpiderTemplete() : base()
        {

        }

        List<Uri> urls = new List<Uri>()
        {
            new Uri("http://basic.10jqka.com.cn/000001/"),
            new Uri("http://basic.10jqka.com.cn/000003/"),
            new Uri("http://basic.10jqka.com.cn/000004/"),
            new Uri("http://basic.10jqka.com.cn/000005/"),
            new Uri("http://basic.10jqka.com.cn/000006/"),
            new Uri("http://basic.10jqka.com.cn/000007/"),
            new Uri("http://basic.10jqka.com.cn/000008/"),
        };
        public override IEnumerable<Uri> StartUrls { get { return urls; } set { } }

        public override BaseFieldsItem Parse(HtmlAgilityPack.HtmlDocument response)
        {
            // 解析数据逻辑
            Console.WriteLine(response);
            return new BaseFieldsItem();
        }
    }
}
