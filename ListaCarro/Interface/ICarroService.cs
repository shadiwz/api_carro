using System.Collections.Generic;
using System.Net.Http;

namespace ListaCarro.Service
{
    public interface ICarroService
    {
        List<Car> Get();
        Car Get(string id);
        HttpResponseMessage Create(Car carro);
        long Update(string id, Car carro);
        long Remove(string id);
    }
}