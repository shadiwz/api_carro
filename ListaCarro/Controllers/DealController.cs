using ListaCarro.Interface;
using ListaCarro.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace ListaCarro.Controllers
{
    [ApiController]
    [Route("deal")]
    public class DealController : ControllerBase
    {
        private IDealService _dioService;

        public DealController(IDealService dioService)
        {
            _dioService = dioService;
        }

        [HttpPost]
        public HttpResponseMessage Buyment(Invoice deal)
        {
            return _dioService.Buyment(deal);
        }
    }
}
