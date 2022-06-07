using ListaCarro.Interface;
using ListaCarro.Models;
using ListaCarro.Service;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace ListaCarro.Services
{
    public class DealershipService : IDealershipService
    {
        private readonly IMongoCollection<Dealership> _dealership;
        private readonly IClientService _clientService;
        private readonly ICarroService _carroService;

        public DealershipService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _clientService = new ClientService(settings);
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

        public HttpResponseMessage ClientRegister(string id, string clientId)
        { 
            var content = new HttpResponseMessage();
            var clientSearch = _clientService.Get(clientId);
            var dealershipSearch = Get(id);

            clientSearch.Dealerships.Add(id);
            dealershipSearch.Clients.Add(clientId);

            _clientService.Update(clientId, clientSearch);
            Update(id, dealershipSearch);
            content.Content = new StringContent("Record made");
            content.StatusCode = HttpStatusCode.OK;
            return content;
        }

        public HttpResponseMessage CarRegister(string id, string carId)
        {
            var content = new HttpResponseMessage();
            var carSearch = _carroService.Get(carId);
            var dealershipSearch = Get(id);

            carSearch.Dealership = id;
            dealershipSearch.Cars.Add(carId);

            _carroService.Update(carId, carSearch);
            Update(id, dealershipSearch);

            content.Content = new StringContent("registered car");
            content.StatusCode = HttpStatusCode.OK;
            return content;
        }
    }
}
