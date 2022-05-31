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
        public List<string> Dealerships { get; set; }
        public List<string> Cars { get; set; } 
    }
}
