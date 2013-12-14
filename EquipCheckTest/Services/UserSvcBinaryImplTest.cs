using EquipCheck.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using EquipCheck.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;

namespace EquipCheckAppTest
{
    /// <summary>
    /// Class to test the UserSvcBinaryImpl class local connections.
    ///</summary>
    [TestClass()]
    public class UserSvcBinaryImplTest
    {
        UserSvcBinaryImpl target = null;
        
        // Method for initializing test fields.
        [TestInitialize()]
        public void MyTestInitialize()
        {
            target = new UserSvcBinaryImpl();
        }
        
        /// <summary>
        /// A test for StoreGetUserLocal
        ///</summary>
        [TestMethod()]
        public void StoreGetUserLocalTest()
        {
            EquipCheckAppUser expectedUser = new EquipCheckAppUser();
            expectedUser.Username = "TestUser1";
            expectedUser.Password = "testuser1!";
            target.StoreEquipCheckAppUser(expectedUser);

            EquipCheckAppUser actualUser = target.GetLocalUser(expectedUser);
            Assert.AreEqual(expectedUser.Username, actualUser.Username);
            Assert.AreEqual(expectedUser.Password, actualUser.Password);
        }

        /// <summary>
        /// A test for StoreGetUserLocal
        ///</summary>
        [TestMethod()]
        public void NotGetUserLocalTest()
        {
            EquipCheckAppUser expectedUser = new EquipCheckAppUser();
            expectedUser.Username = "InvalidUser";
            expectedUser.Password = "InvalidPassword";

            EquipCheckAppUser actualUser = target.GetLocalUser(expectedUser);
            Assert.IsNull(actualUser);
        }
    }
}
