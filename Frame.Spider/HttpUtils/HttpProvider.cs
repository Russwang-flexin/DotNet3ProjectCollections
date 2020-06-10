using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Frame.Spider
{
    public class HttpProvider : IHttpProvider
    {
        public IEnumerable<Request> Excute(HttpRequestParameter requestParameter)
        {
            List<Request> request_list = new List<Request>();
            foreach (var url in requestParameter.Url)
            {
                request_list.Add(HttpUtil.Excute(requestParameter, url));
            }
            return request_list;
        }

        public async Task<HttpResponseParameter> Excute(Request Request)
        {
            return await HttpUtil.SetResponse(Request);
        }
    }
}
