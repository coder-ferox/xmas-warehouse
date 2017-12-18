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
    public class Toys
    {
        private IMongoDatabase db;

        [TestInitialize]
        public void Initialize()
        {
            MongoClientSettings settings = new MongoClientSettings();
            MongoClient client = new MongoClient(MongoDBConfig.ConnectionString);
            db = client.GetDatabase(MongoDBConfig.DBName);
            IMongoCollection<Toy> collection = db.GetCollection<Toy>("toys");
            collection.InsertOne(new Toy());
            collection.InsertOne(new Toy());
        }

        [TestMethod]
        public void Get_All_Toys_Should_Return_A_List()
        {
            var db = new xmasDB();
            var list = db.GetAllToys();
            Assert.AreEqual(2, list.Count());
        }

    }
}
