using EquipCheck.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using EquipCheck.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;


namespace EquipCheckAppTest
{
    /// <summary>
    /// Class to test the EquipListSvcBinaryImpl class.
    ///</summary>
    [TestClass()]
    public class EquipListSvcBinaryImplTest
    {
        EquipListSvcBinaryImpl target;
        EquipmentList expectedList1;
        EquipmentList expectedList2;
        UserSvcBinaryImpl userSvc;
        EquipCheckAppUser user;

        // Method for initializing test fields.
        [TestInitialize()]
        public void MyTestInitialize()
        {
            target = new EquipListSvcBinaryImpl();

            expectedList1 = new EquipmentList();
            expectedList1.EquipListName = "TestList1";
            expectedList1.EquipListDesc = "TestList1Desc";
            
            expectedList2 = new EquipmentList();
            expectedList2.EquipListName = "TestList2";
            expectedList2.EquipListDesc = "TestList2Desc";

            userSvc = new UserSvcBinaryImpl();
            user = new EquipCheckAppUser();
            user.Username = "TestUser2";
            user.Password = "testuser2!";
            userSvc.StoreEquipCheckAppUser(user);
            user = userSvc.GetLocalUser(user);
        }
        
        /// <summary>
        ///A test for AddItemToEquipmentList
        ///</summary>
        [TestMethod()]
        public void AddItemToEquipmentListTest()
        {
            EquipmentItem expectedItem = new EquipmentItem();
            expectedItem.EquipItemName = "TestItem1";
            expectedItem.EquipItemDesc = "TestItem1Desc";

            target.StoreEquipmentList(user, expectedList1);
            List<EquipmentList> lists = target.GetEquipmentLists(user);

            for (int i = 0; i < lists.Count; i++)
            {
                if (lists[i].EquipListName.Equals("TestList1")
                    && lists[i].EquipListDesc.Equals("TestList1Desc"))
                {
                    EquipmentList actualList = lists[i];
                    target.AddItemToEquipmentList(user, actualList, expectedItem);
                    break;
                }
            }

            lists = target.GetEquipmentLists(user);

            Console.WriteLine("lists: " + lists.Count);

            List<EquipmentItem> items = null;
            for (int i = 0; i < lists.Count; i++)
            {
                if (lists[i].EquipListName.Equals("TestList1")
                    && lists[i].EquipListDesc.Equals("TestList1Desc"))
                {
                    EquipmentList actualList = lists[i];
                    items = actualList.EquipListItems;

                    for (int j = 0; j < actualList.EquipListItems.Count; i++)
                    {
                        if (items[j].EquipItemName.Equals("TestItem1")
                            && items[j].EquipItemDesc.Equals("TestItem1Desc"))
                        {
                            EquipmentItem actualItem = items[j];
                            Assert.AreEqual(expectedItem.EquipItemName, actualItem.EquipItemName);
                            Assert.AreEqual(expectedItem.EquipItemDesc, actualItem.EquipItemDesc);
                            break;
                        }
                    }
                    break;
                }
            }

            if (lists == null || lists.Count == 0 || items == null || items.Count == 0)
            {
                Assert.Fail();
            }
        }
        
        /// <summary>
        /// A test for StoreEquipmentList and GetEquipmentLists
        ///</summary>
        [TestMethod()]
        public void StoreGetEquipmentListTest()
        {
            target.StoreEquipmentList(user, expectedList2);

            List<EquipmentList> lists = target.GetEquipmentLists(user);
            for (int i = 0; i < lists.Count; i++)
            {
                if (lists[i].EquipListName.Equals("TestList2") 
                    && lists[i].EquipListDesc.Equals("TestList2Desc"))
                {
                    EquipmentList actualList = lists[i];
                    Assert.AreEqual(expectedList2.EquipListName, actualList.EquipListName);
                    Assert.AreEqual(expectedList2.EquipListDesc, actualList.EquipListDesc);
                    break;
                }
            }

            if (lists.Count == 0)
            {
                Assert.Fail();
            }
        }

        /// <summary>
        /// A test for GetEquipmentList
        ///</summary>
        [TestMethod()]
        public void NotGetEquipmentListTest()
        {
            List<EquipmentList> lists = target.GetEquipmentLists(user);
            for (int i = 0; i < lists.Count; i++)
            {
                if (lists[i].EquipListName.Equals("InvalidTestList"))
                {
                    Assert.Fail();
                    break;
                }
            }
        }
    }
}
