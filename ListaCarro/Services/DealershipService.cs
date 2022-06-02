using ListaCarro.Interface;
using ListaCarro.Models;
using MongoDB.Driver;
using System.Collections.Generic;

namespace ListaCarro.Services
{
    public class DealershipService : IDealershipService
    {
        private readonly IMongoCollection<Dealership> _dealership;

        public DealershipService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _dealership = database.GetCollection<Dealership>("dealership");
        }

        public List<Dealership> GetAll()
        {
            return _dealership.Find(dealersjip => true).ToList();
        }

        public Dealership Get(string id)
        {
            return _dealership.Find<Dealership>(dealership => dealership.Id == id).FirstOrDefault();
        }

        public Dealership Create(Dealership dealership)
        {
            _dealership.InsertOne(dealership);
            return dealership;
        }

        public long Delete(string id)
        {
            var dealership = _dealership.DeleteOne(dealership => dealership.Id == id);
            return dealership.DeletedCount;
        }


        public long Update(string id, Dealership dealership)
        {
            return _dealership.ReplaceOne(dealership => dealership.Id == id, dealership).ModifiedCount;
        }
    }
}
