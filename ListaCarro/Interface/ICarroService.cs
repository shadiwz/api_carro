using System.Collections.Generic;

namespace ListaCarro.Service
{
    public interface ICarroService
    {
        List<Car> Get();
        Car Get(string id);
        Car Create(Car carro);
        long Update(string id, Car carro);
        long Remove(string id);
    }
}