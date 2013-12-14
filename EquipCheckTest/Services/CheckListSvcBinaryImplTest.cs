using EquipCheck.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using EquipCheck.Domain;

namespace EquipCheckAppTest
{
    /// <summary>
    /// This is a test class for CheckListSvcBinaryImplTest and is intended
    /// to contain all CheckListSvcBinaryImplTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CheckListSvcBinaryImplTest
    {
        CheckListSvcBinaryImpl target;
        CheckList expectedCheckList;
        UserSvcBinaryImpl userSvc;
        EquipCheckAppUser user;

        // Method for initializing test fields.
        [TestInitialize()]
        public void MyTestInitialize()
        {
            target = new CheckListSvcBinaryImpl();

            expectedCheckList = new CheckList();
            expectedCheckList.CheckListName = "TestCheckList1";
            expectedCheckList.CheckListDesc = "TestCheckList1Desc";
            expectedCheckList.TripName = "TestTripName";
            expectedCheckList.TripDesc = "TestTripDesc";
            expectedCheckList.TripDate = "TestTripDate";
            expectedCheckList.CheckListItemSummary = "TestCheckList1Summary";

            userSvc = new UserSvcBinaryImpl();
            user = new EquipCheckAppUser();
            user.Username = "TestUser3";
            user.Password = "testuser3!";
            userSvc.StoreEquipCheckAppUser(user);
            user = userSvc.GetLocalUser(user);
        }

        /// <summary>
        /// A test for StoreCheckList and GetCheckList methods
        ///</summary>
        [TestMethod()]
        public void StoreGetCheckListTest()
        {
            target.StoreCheckList(user, expectedCheckList);
            List<CheckList> checkLists = target.GetCheckLists(user);
            for (int i = 0; i < checkLists.Count; i++)
            {
                if (checkLists[i].CheckListName.Equals("TestCheckList1")
                    && checkLists[i].CheckListDesc.Equals("TestCheckList1Desc")
                    && checkLists[i].CheckListItemSummary.Equals("TestCheckList1Summary"))
                {
                    CheckList actualCheckList = checkLists[i];
                    Assert.AreEqual(expectedCheckList.CheckListName, actualCheckList.CheckListName);
                    Assert.AreEqual(expectedCheckList.CheckListDesc, actualCheckList.CheckListDesc);
                    Assert.AreEqual(expectedCheckList.CheckListItemSummary, actualCheckList.CheckListItemSummary);
                    break;
                }
            }

            if (checkLists.Count == 0)
            {
                Assert.Fail();
            }
        }

        /// <summary>
        /// A test for GetEquipmentList
        ///</summary>
        [TestMethod()]
        public void NotGetCheckListTest()
        {
            List<CheckList> checkLists = target.GetCheckLists(user);
            for (int i = 0; i < checkLists.Count; i++)
            {
                if (checkLists[i].CheckListName.Equals("InvalidTestCheckList"))
                {
                    Assert.Fail();
                    break;
                }
            }
        }
    }
}
