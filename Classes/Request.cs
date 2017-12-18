using GestioneLetterine.Classes;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneLetterine.Classes
{
    public class Request
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("kid")]
        public string Kid { get; set; }

        [BsonElement("status")]
        private int status;
        public RequestStatus Status
        {
            get
            {
                return (RequestStatus)status;
            }
            set
            {
                status = (int)value;
            }
        }

        [BsonElement("toys")]
        public List<Toy> Toys { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        [BsonElement("requestDate")]
        public DateTime RequestDate { get; set; }

        public decimal? Price
        {
            get
            {
                return Toys.Sum(toy => toy.Cost);
            }
        }

        public RequestStatus GetOrderStatus()
        {
            return (RequestStatus)Status;
        }
    }
}
