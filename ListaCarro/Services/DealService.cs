using ListaCarro.Interface;
using ListaCarro.Models;
using ListaCarro.Service;
using MongoDB.Driver;
using System.Net.Http;

namespace ListaCarro.Services
{
    public class DealService : IDealService
    {
        private readonly IMongoCollection<Client> _client;
        private readonly IMongoCollection<Car> _car;
        private readonly IMongoCollection<Dealership> _dealership;
        private readonly IMongoCollection<Invoice> _deal;
        private readonly IClientService _clientService;
        private readonly ICarroService _carroService;

        public DealService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _clientService = new ClientService(settings);
            _carroService = new CarroService(settings);
            _deal = database.GetCollection<Invoice>("invoice");
        }


        public HttpResponseMessage Buyment(Invoice deal)
        {
            var content = new HttpResponseMessage();
            var clientId = deal.ClientId;
            var clientSearch = _clientService.Get(clientId);
            var carId = deal.CarId;
            var carSearch = _carroService.Get(carId);

            carSearch.Bougth = true;
            clientSearch.Cars.Add(carId);
            deal.CarId = carId;
            deal.ClientId = clientId;
            deal.Date = System.DateTime.Now;

            _clientService.Update(clientId, clientSearch);
            _carroService.Update(carId, carSearch);

            _deal.InsertOne(deal);
            content.Content = new StringContent("Buyment Done");
            content.StatusCode = System.Net.HttpStatusCode.OK;
            return content;
        }
    }
}
