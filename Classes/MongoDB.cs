using GestioneLetterine.Classes;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneLetterine.Classes
{
    public class MongoDB : IDatabase
    {
        private IMongoDatabase Database
        {
            get
            {
                return MongoConnection.Instance.Database;
            }
        }

        public IEnumerable<Toy> GetAllToys()
        {
            IMongoCollection<Toy> toysCollection = Database.GetCollection<Toy>("toys");
            return toysCollection.Find(new BsonDocument()).ToList();
        }

        public IEnumerable<Request> GetAllRequests()
        {
            IMongoCollection<Request> requestsCollection = Database.GetCollection<Request>("orders");
            return requestsCollection.Find(new BsonDocument()).SortByDescending(t => t.RequestDate).ToList();
        }

        public User GetUser(User user)
        {
            IMongoCollection<User> usersCollection = Database.GetCollection<User>("users");
            User userToReturn = usersCollection.Find(userInCollection => userInCollection.Email == user.Email)
                                                           .FirstOrDefault();
            if (userToReturn != null &&
                userToReturn.GetSHA512(userToReturn.Password) == user.GetSHA512(user.Password))
            {
                return userToReturn;
            }
            else
            {
                return null;
            }
        }

        public Request GetRequest(string id)
        {
            IMongoCollection<Request> requestsCollection = Database.GetCollection<Request>("orders");
            return requestsCollection.Find(order => order.Id == id).FirstOrDefault();
        }

        public bool UpdateRequest(string id, RequestStatus status)
        {
            IMongoCollection<Request> requestsCollection = Database.GetCollection<Request>("orders");
            var filter = Builders<Request>.Filter.Eq("_id", ObjectId.Parse(id));
            var update = Builders<Request>.Update
                .Set("status", status);
            try
            {
                requestsCollection.UpdateOne(filter, update);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<Toy> GetAllOrderedToys(Request order)
        {
            IMongoCollection<Toy> toysCollection = Database.GetCollection<Toy>("toys");
            return toysCollection.Find(new BsonDocument()).ToList()
                                        .Where(toy => order.Toys.Any(orderToy => orderToy.Name == toy.Name))
                                        .ToList();
        }
    }
}
