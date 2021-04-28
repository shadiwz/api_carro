using ListaCarro.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public Carro Post(Carro carro)
        {
            var carroResult = _carroService.Create(carro);
            return carroResult;
        }
        
        [HttpGet]
        public List<Carro> Get()
        {
            return _carroService.Get();
        }
        [HttpGet]
        [Route("{carroId}")]
        public Carro GetById(string carroId)
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
        public long UpdateById(string carroId, [FromBody] Carro carro)
        {
            return _carroService.Update(carroId, carro);
        }
    }
}
