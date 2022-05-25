using System.Collections.Generic;

namespace ListaCarro.Service
{
    public interface ICarroService
    {
        List<Carro> Get();
        Carro Get(string id);
        Carro Create(Carro carro);
        long Update(string id, Carro carro);
        long Remove(string id);
    }
}