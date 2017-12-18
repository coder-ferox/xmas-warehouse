using GestioneLetterine.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Tests
{
    [TestClass]
    public class MongoDBTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Get_User_Should_Throw_Exception_When_User_Is_Null()
        {
            Mock<IDatabase> mock = new Mock<IDatabase>();

            mock.Setup(m => m.GetUser(It.Is<User>(user => user == null))).Throws<ArgumentNullException>();

            mock.Object.GetUser(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Get_All_Order_Toys_Should_Throw_Exception_When_Order_Is_Null()
        {
            Mock<IDatabase> mock = new Mock<IDatabase>();

            mock.Setup(m => m.GetAllOrderedToys(It.Is<Request>(order => order == null))).Throws<ArgumentNullException>();

            mock.Object.GetAllOrderedToys(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Get_Order_Should_Throw_Exception_When_Id_Is_Null()
        {
            Mock<IDatabase> mock = new Mock<IDatabase>();

            mock.Setup(m => m.GetRequest(It.Is<string>(id => id == null))).Throws<ArgumentNullException>();

            mock.Object.GetRequest(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Get_Order_Should_Throw_Exception_When_Id_Is_Empty()
        {
            Mock<IDatabase> mock = new Mock<IDatabase>();

            mock.Setup(m => m.GetRequest(It.Is<string>(id => id == string.Empty))).Throws<ArgumentException>();

            mock.Object.GetRequest("");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Get_Order_Should_Throw_Exception_When_Id_Is_WhiteSpace()
        {
            Mock<IDatabase> mock = new Mock<IDatabase>();

            mock.Setup(m => m.GetRequest(It.Is<string>(id => string.IsNullOrWhiteSpace(id)))).Throws<ArgumentException>();

            mock.Object.GetRequest("  ");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Update_Order_Should_Throw_Exception_When_Id_Is_Null()
        {
            Mock<IDatabase> mock = new Mock<IDatabase>();

            mock.Setup(m => m.UpdateRequest(It.Is<string>(id => id == null), It.IsAny<RequestStatus>())).Throws<ArgumentNullException>();

            mock.Object.UpdateRequest(null, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Update_Order_Should_Throw_Exception_When_Id_Is_Empty()
        {
            Mock<IDatabase> mock = new Mock<IDatabase>();

            mock.Setup(m => m.UpdateRequest(It.Is<string>(id => id == string.Empty), It.IsAny<RequestStatus>())).Throws<ArgumentException>();

            mock.Object.UpdateRequest("", 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Update_Order_Should_Throw_Exception_When_Id_Is_WhiteSpace()
        {
            Mock<IDatabase> mock = new Mock<IDatabase>();

            mock.Setup(m => m.UpdateRequest(It.Is<string>(id => string.IsNullOrWhiteSpace(id)), It.IsAny<RequestStatus>())).Throws<ArgumentException>();

            mock.Object.UpdateRequest("  ", 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Update_Order_Should_Throw_Exception_When_Status_Is_Out_Of_Range()
        {
            Mock<IDatabase> mock = new Mock<IDatabase>();

            mock.Setup(m => m.UpdateRequest(It.IsAny<string>(), It.Is<RequestStatus>(s => s == (RequestStatus)(-1)))).Throws<ArgumentOutOfRangeException>();

            mock.Object.UpdateRequest("  ", (RequestStatus)(-1));

        }
    }
}
