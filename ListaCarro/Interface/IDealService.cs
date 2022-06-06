using ListaCarro.Models;
using System.Net.Http;

namespace ListaCarro.Interface
{
    public interface IDealService
    {
        public HttpResponseMessage Buyment(Invoice deal);
    }
}
