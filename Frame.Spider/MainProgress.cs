using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HtmlAgilityPack;
    
namespace Frame.Spider
{
    public delegate void SpiderRegistryHandler(BasicSpider spider);
    // 使用线程池
    public class SpiderRegistry
    {
        static SpiderRegistry _Instance = null;

        public static SpiderRegistry Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new SpiderRegistry();
                }
                return _Instance;
            }
        }

        public List<BasicSpider> Contanier = new List<BasicSpider>();

        public void RegistrySpier(BasicSpider spider)
        {
            Instance.Contanier.Add(spider);
        }

        public void SpiderCancel(BasicSpider spider)
        {
            Instance.Contanier.Remove(spider);
        }
    }

    public class SpiderManager
    {
        IHttpProvider httpProvider = new HttpProvider();

        static SpiderManager _Instance = null;
        public static SpiderManager Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new SpiderManager();
                }
                return _Instance;
            }
        }
        public void Start()
        {
            Thread t2 = new Thread(ProducerStart);
            Thread t1 = new Thread(CustomStart);
            t2.Start();
            t2.Join();
            t1.Start();
            t1.Join();
        }

        void ProducerStart()
        {
            foreach (var spiders in SpiderRegistry.Instance.Contanier)
            {
                spiders.RequestParameter.Url = spiders.StartUrls;
                var request = httpProvider.Excute(spiders.RequestParameter);
                foreach (var spider in request)
                {
                    spider.Callback = spiders.Parse;
                    spider.RequestParams = spiders.RequestParameter;
                    PriorityQueue<Request>.EnqueueTask(spider);
                    _wh.Set();
                }
            }
        }

        EventWaitHandle _wh = new AutoResetEvent(false);

        void CustomStart()
        {
            ThreadPool.SetMinThreads(1, 1);
            ThreadPool.SetMinThreads(Settings.ThreadPoolCount, Settings.ThreadPoolCount);
            while (true)
            {
                var spider = PriorityQueue<Request>.DeQueue();
                if (spider == default)
                {
                    _wh.WaitOne();
                    continue;
                }
                ThreadPool.QueueUserWorkItem(new WaitCallback(CustomHelper), spider);
                Task.Delay(Settings.TaskDelay);
            }
        }

        void CustomHelper(object request)
        {
            var str = httpProvider.Excute(request as Request);
            Task.WhenAll(str);
            HtmlDocument html = new HtmlDocument();
            html.LoadHtml(str.Result.Body);
            (request as Request)?.Callback?.Invoke(html);
        }
    }

}
