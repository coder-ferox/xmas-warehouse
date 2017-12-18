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
    public class UserTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void String_To_Hash_Should_Throw_Exception_When_Input_Is_Null()
        {
            User user = new User();
            user.GetSHA512(null);
        }
    }
}
