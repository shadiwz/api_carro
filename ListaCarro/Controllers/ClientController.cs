using ListaCarro.Interface;
using ListaCarro.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ListaCarro.Controllers
{
    [ApiController]
    [Route("client")]    
    public class ClientController : ControllerBase
    {
        private IClientService _clientService;

        public ClientController(IClientService clientService) 
        { 
            _clientService = clientService; 
        }
        
        [HttpGet]
        public List<Client> GetAll()
        {
            return _clientService.GetAll();
        }
        
        [HttpGet]
        [Route("{clientId}")]
        public Client GetById(string clientId) 
        { 
            return _clientService.Get(clientId);
        }

        [HttpPost]
        public Client Post(Client client)
        {
            return _clientService.Create(client);
        }

        [HttpDelete]
        [Route("{clientId}")]
        public long DeleteById(string clientId) 
        { 
            return _clientService.Delete(clientId); 
        }

        [HttpPut]
        [Route("{clientId}")]
        public long UpdateById(string clientId, [FromBody] Client client) 
        {
            return _clientService.Update(clientId, client); 
        }
    }
}
