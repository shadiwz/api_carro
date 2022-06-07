using ListaCarro.Interface;
using ListaCarro.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;

namespace ListaCarro.Controllers
{
    [ApiController]
    [Route("dealership")]
    public class DealershipController : ControllerBase
    {
        private IDealershipService _dealershipService;

        public DealershipController(IDealershipService dealershipService)
        {
            _dealershipService = dealershipService;
        }

        [HttpPost]
        public Dealership Post(Dealership dealership)
        {
            var dealerResult = _dealershipService.Create(dealership);
            return dealerResult;
        }
        
        [HttpGet]
        public List<Dealership> Get()
        {
            return _dealershipService.GetAll();
        }

        [HttpGet]
        [Route("{dealershipId}")]
        public Dealership GetById(string dealershipId)
        {
            return _dealershipService.Get(dealershipId);
        }

        [HttpDelete]
        [Route("{dealershipId}")]
        public long DeleteById(string dealershipId) 
        {
            return _dealershipService.Delete(dealershipId);
        }

        [HttpPut]
        [Route("{dealershipId}")]
        public long UpdateById(string dealershipId, [FromBody] Dealership dealership)
        {
            return _dealershipService.Update(dealershipId, dealership);
        }

        [HttpPost]
        [Route("client")]
        public HttpResponseMessage Register(string id, string clientId)
        {
            return _dealershipService.ClientRegister(id, clientId);
        }

        [HttpPost]
        [Route("car")]
        public HttpResponseMessage CarRegister(string id, string carId)
        {
            return _dealershipService.CarRegister(id, carId);
        }
    }
}
