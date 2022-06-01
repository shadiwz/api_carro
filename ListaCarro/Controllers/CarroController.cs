using ListaCarro.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ListaCarro.Controllers
{
    [ApiController]
    [Route("listaCarro")]
    public class CarroController : ControllerBase
    {
        private ICarroService _carroService;

        public CarroController(ICarroService carroService)
        {
            _carroService = carroService;
        }

        [HttpPost]
        public HttpResponseMessage Post(Car carro)
        {
            var carroResult = _carroService.Create(carro);
            return carroResult;
        }
        
        [HttpGet]
        public List<Car> Get()
        {
            return _carroService.Get();
        }
        [HttpGet]
        [Route("{carroId}")]
        public Car GetById(string carroId)
        {
            return _carroService.Get(carroId);
        }
        [HttpDelete]
        [Route("{carroId}")]
        public long DeleteById(string carroId)
        {
            return _carroService.Remove(carroId);
        }
        [HttpPut]
        [Route("{carroId}")]
        public long UpdateById(string carroId, [FromBody] Car carro)
        {
            return _carroService.Update(carroId, carro);
        }
    }
}
