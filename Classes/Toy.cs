using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneLetterine.Classes
{
    public class Toy
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("cost")]
        public decimal? Cost { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("amount")]
        public int? Amount { get; set; }
    }
}
