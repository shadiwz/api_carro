using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace ListaCarro.Models
{
    public class Dealership
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Brand { get; set; }
        public string CEP { get; set; }
        public List<string> Clients { get; set; }
        public List<string> Cars { get; set; }
    }
}
