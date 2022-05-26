using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace ListaCarro.Models
{
    public class Client
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string id { get; set; }
        public string name { get; set; }
        public string CPF { get; set; }
        public double Wallet { get; set; }
        public List<Dealership> Dealerships { get; set; }
        public List<Car> Cars { get; set; } 
    }
}
