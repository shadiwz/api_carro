using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

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
        public HttpResponseMessage Create(Car carro)
        {
            var content = new HttpResponseMessage();
            try
            {
                if(carro == null)
                {
                    content.StatusCode = HttpStatusCode.BadRequest;
                    content.Content = new StringContent("Carro can't be null");
                }
                if(carro.Year < 2002)
                {
                    content.StatusCode = HttpStatusCode.BadRequest;
                    throw new Exception("Car not accept");
                }

                if(carro.Mileage >= 1000.00)
                {
                    content.StatusCode = HttpStatusCode.BadRequest;
                    throw new Exception("Car used more than allowed");
                }

                _carro.InsertOne(carro);
                return content;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
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