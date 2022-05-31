using ListaCarro.Models;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace ListaCarro
{
    public class Car
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Brand { get; set; }

        public string Model { get; set; }

        public double Price { get; set; }

        public int Discount { get; set; }

        public int Year { get; set; }

        public double Mileage { get; set; }

        public string Buyer { get; set; }

        public string Dealership { get; set; }

        public bool Bougth { get; set; }
    }
    public enum Color
    {
        Branco,
        Prata,
        Preto
    } 
}
