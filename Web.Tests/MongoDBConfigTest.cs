using GestioneLetterine.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Tests
{
    [TestClass]
    public class MongoDBConfigTest
    {
        [TestMethod]
        public void Username_Should_Have_This_Value()
        {
            Assert.AreEqual("Lucignolo", MongoDBConfig.Username);
        }

        [TestMethod]
        public void Password_Should_Have_This_Value()
        {
            Assert.AreEqual("Unaparolachiave", MongoDBConfig.Password);
        }

        [TestMethod]
        public void Host_Should_Have_This_Value()
        {
            Assert.AreEqual("db12345.it", MongoDBConfig.Host);
        }

        [TestMethod]
        public void Port_Should_Have_This_Value()
        {
            Assert.AreEqual(34567, MongoDBConfig.Port);
        }

        [TestMethod]
        public void DBName_Should_Have_This_Value()
        {
            Assert.AreEqual("ZiggyInTheSnow", MongoDBConfig.DBName);
        }
    }
}
