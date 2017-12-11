using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;


//NON ANCORA FINITO VEDI LISTA TOY E DATA REQUEST

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
        private decimal status { get; set; }


        private List<Toy> Toys = new List<Toy>();

        [BsonElement(BsonType.BsonDateTimeOptionsAttribute)]
        private int requestDate { get; }

    }
}