using ListaCarro.Interface;
using ListaCarro.Models;
using MongoDB.Driver;
using System.Collections.Generic;

namespace ListaCarro.Services
{
    public class ClientService : IClientService
    {
        private readonly IMongoCollection<Client> _client;

        public ClientService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _client = database.GetCollection<Client>("client");
        }

        public List<Client> GetAll()
        {
            return _client.Find(client => true).ToList();
        }

        public Client Get(string id)
        {
            return _client.Find<Client>(client => client.id == id).FirstOrDefault();
        }

        public Client Create(Client client)
        {
            _client.InsertOne(client);
            return client;
        }

        public long Delete(string id)
        {
            var client = _client.DeleteOne(id);
            return client.DeletedCount;
        }

        public long Update(string id, Client client)
        {
            return _client.ReplaceOne(client => client.id == id, client).ModifiedCount;
        }
    }
}
