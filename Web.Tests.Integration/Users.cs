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
    public class Users
    {
        private IMongoDatabase db;
        private const string USERNAME = "test-user";
        private const string USERPASSWORD = "test-user";

        [TestInitialize]
        public void Initialize()
        {
            MongoClientSettings settings = new MongoClientSettings();
            MongoClient client = new MongoClient(MongoDBConfig.ConnectionString);
            db = client.GetDatabase(MongoDBConfig.DBName);
            IMongoCollection<User> collection = db.GetCollection<User>("users");
            collection.InsertOne(new User
            {
                Username = USERNAME,
                Password = USERPASSWORD
            });
        }

        [TestMethod]
        public void Get_User_Should_Return_Test_User()
        {
            var db = new xmasDB();
            var test = new User
            {
                Username = USERNAME,
                Password = USERPASSWORD
            };
            var user = db.GetUser(test);
            Assert.IsNotNull(user);
        }
    }
}
