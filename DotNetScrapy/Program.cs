using Frame.Spider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace DotNetScrapy
{
    class Program
    {
        static void Main(string[] args)
        {
            //TuShareSpider spiderTemplete = new TuShareSpider();
            //spiderTemplete.RequestParameter.EncodingStr = "gbk";
            //SpiderManager.Instance.Start();


            JsonDataToDB jsonDataToDB = new JsonDataToDB();
            var t = jsonDataToDB.Database.EnsureCreated();
            if (t) 
            {
                var text = File.ReadAllText(@"C:\Users\viruser.v-desktop\Desktop\StockInfo.json");
                var dic = JsonConvert.DeserializeObject<Dictionary<string, string>>(text);
                foreach (var item in dic)
                {
                    jsonDataToDB.RowsDataModelas.Add(new RowsDataModel() { code = item.Key, name = item.Value });
                }
                var res = jsonDataToDB.SaveChanges();
            }
        }
    }

    public class TuShareSpider : FrameSpider
    {
        public override string DisplayName { get; set; } = "TuShareSpider";

        public TuShareSpider() : base()
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
            //response.DocumentNode.SelectNodes ...
            return new BaseFieldsItem();
        }
    }
}