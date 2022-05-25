using MongoDB.Bson.Serialization.Attributes;
using System;

namespace ListaCarro
{
    public class Carro
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Brand { get; set; }

        public string Model { get; set; }

        public int price { get; set; }
        
        public int Discount { get; set; }

        public int Year { get; set; }

        public double Mileage { get; set; }

        public Color Color { get; set; }    
    }

    public enum Color
    {
        Branco,
        Prata,
        Preto
    }
}
