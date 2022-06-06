using MongoDB.Bson.Serialization.Attributes;
using System;

namespace ListaCarro.Models
{
    public class Invoice
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string CarId { get; set; }
        public string ClientId { get; set; }
        public DateTime Date { get; set; }
    }
}
