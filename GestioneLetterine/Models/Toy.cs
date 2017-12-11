using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace GestioneLetterine.Models
{
    public class Toy
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ID { get; }

        [BsonElement("name")]
        private string Name { get; }

        [BsonElement("cost")]
        private decimal Cost { get; }

        [BsonElement("amount")]
        private int Amount { get; set; }

    }
}