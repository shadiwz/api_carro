using MongoDB.Driver;
using System.Collections.Generic;

namespace ListaCarro.Service
{
    public class CarroService : ICarroService
    {
        private readonly IMongoCollection<Car> _carro;

        public CarroService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _carro = database.GetCollection<Car>(settings.CollectionName);
        }
        public List<Car> Get()
        {
            return _carro.Find(carro => true).ToList();
        }
        public Car Get(string id)
        {
            return _carro.Find<Car>(carro => carro.Id == id).FirstOrDefault();
        }
        public Car Create(Car carro)
        {
            _carro.InsertOne(carro);
            return carro;
        }
        public long Update(string id, Car carroIn)
        {
            return _carro.ReplaceOne(carro => carro.Id == id, carroIn).ModifiedCount;
        }
       
        public long Remove(string id)
        {
            var carro = _carro.DeleteOne(carro => carro.Id == id);
            return carro.DeletedCount;
        }
    }
}