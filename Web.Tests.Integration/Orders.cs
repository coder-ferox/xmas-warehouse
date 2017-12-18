using GestioneLetterine.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xmasDB = GestioneLetterine.Classes.MongoDB;

namespace Web.Tests.Integration
{
    [TestClass]
    public class Orders
    {
        private IMongoDatabase db;
        private ObjectId orderId = ObjectId.GenerateNewId();

        [TestInitialize]
        public void Initialize()
        {
            MongoClientSettings settings = new MongoClientSettings();
            MongoClient client = new MongoClient(MongoDBConfig.ConnectionString);
            db = client.GetDatabase(MongoDBConfig.DBName);
            IMongoCollection<Request> collection = db.GetCollection<Request>("orders");
            collection.InsertOne(new Request
            {
                Id = orderId.ToString()
            });
            collection.InsertOne(new Request());
        }

        [TestMethod]
        public void Get_All_Orders_Should_Return_A_List_That_Contains_2_items()
        {
            var db = new xmasDB();
            var list = db.GetAllRequests();
            Assert.AreEqual(2, list.Count());
        }

        [TestMethod]
        public void Get_Order_Should_Return_Test_Order()
        {
            var db = new xmasDB();
            var order = db.GetRequest(orderId.ToString());
            Assert.IsNotNull(order);
        }

        [TestMethod]
        public void Update_Order_Should_Return_True()
        {
            var db = new xmasDB();
            Assert.IsTrue(db.UpdateRequest(orderId.ToString(), RequestStatus.Done));
        }

    }
}
