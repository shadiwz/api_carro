using ListaCarro.Models;
using System.Collections.Generic;

namespace ListaCarro.Interface
{
    public interface IClientService
    {
        List<Client> GetAll();
        Client Get(string id);
        Client Create(Client client);
        long Update(string id, Client client);
        long Delete(string id);

        //buyment
    }
}
