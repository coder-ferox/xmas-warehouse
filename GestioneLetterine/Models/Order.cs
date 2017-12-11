using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;



namespace GestioneLetterine.Models
{
    public class Order
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ID { get; }

        [BsonElement("kid")]
        private string Kid { get; }

        [BsonElement("status")]
        private decimal Status { get; set; }

        [BsonElement("toys")]
        private List<Toy> Toys = new List<Toy>();

        [BsonDateTimeOptionsAttribute()]
        private DateTime RequestDate { get; }

    }
}