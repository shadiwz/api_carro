using ListaCarro.Models;
using System.Collections.Generic;
using System.Net.Http;

namespace ListaCarro.Interface
{
    public interface IDealershipService
    {
        List<Dealership> GetAll();
        Dealership Get(string id);
        Dealership Create(Dealership dealership);
        long Update(string id, Dealership dealership);
        long Delete(string id);
        HttpResponseMessage Register(string id, string clientId);
    }
}
