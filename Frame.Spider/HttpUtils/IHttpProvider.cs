
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Frame.Spider
{
    public interface IHttpProvider
    {
        IEnumerable<Request> Excute(HttpRequestParameter requestParameter);

        Task<HttpResponseParameter> Excute(Request Request);
    }
}
