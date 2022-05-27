using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace ListaCarro.Models
{
    public class Dealership
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Brqand { get; set; }
        public string CEP { get; set; }
        public List<Client> Clients { get; set; }
        public List<Car> Cars { get; set; }
    }
}
