using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Driver;

namespace GestioneLetterine.Models
{
    public class MongoDB
    {
        private IMongoDatabase database
        {
            get
            {
                return MongoConnection.Instance.Database;
            }
        }

        public IEnumerable<Toy> GetAllToysInWarehouse()
        {
            IMongoCollection<Toy> categoryCollection = database.GetCollection<Toy>("toy");
            return categoryCollection.Find(new BsonDocument()).ToList();
        }



    }
}