using MongoDB.Driver;
using System.Collections.Generic;

namespace ListaCarro.Service
{
    public class CarroService : ICarroService
    {
        private readonly IMongoCollection<Carro> _carro;

        public CarroService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _carro = database.GetCollection<Carro>(settings.CollectionName);
        }
        public List<Carro> Get()
        {
            return _carro.Find(carro => true).ToList();
        }
        public Carro Get(string id)
        {
            return _carro.Find<Carro>(carro => carro.Id == id).FirstOrDefault();
        }
        public Carro Create(Carro carro)
        {
            _carro.InsertOne(carro);
            return carro;
        }
        public long Update(string id, Carro carroIn)
        {
            return _carro.ReplaceOne(carro => carro.Id == id, carroIn).ModifiedCount;
        }
        public void Remove(Carro carroIn)
        {
            _carro.DeleteOne(carro => carro.Id == carroIn.Id);
        }
        public long Remove(string id)
        {
            var carro = _carro.DeleteOne(anime => anime.Id == id);
            return carro.DeletedCount;
        }
    }
}