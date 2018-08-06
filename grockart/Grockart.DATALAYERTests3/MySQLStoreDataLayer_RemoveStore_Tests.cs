using Grockart.CUSTOM_RESPONSE_CLASSES;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grockart.DATALAYER
{
    [TestClass()]
    public class MySQLStoreDataLayer_RemoveStore_Tests
    {
        [TestMethod()]
        public void RemoveStore_1()
        {
            int ExpectedOutput = 1;
            int GotOutput = 0;
            CRUDTemplate<IStores> StoresTemplateObj = new StoresTemplate();
            Stores StoresObj = new Stores();
            StoresObj.SetStoreName("Test_Store");
            StoresObj.SetStoreLogo("images\test.png");
            StoresTemplateObj.Insert(StoresObj);
            List<IStores> Output = StoresTemplateObj.Select();
            foreach (Stores Store in Output)
            {
                if ("Test_Store" == Store.GetStoreName())
                {
                    int StoreID = Store.GetStoreID();
                    StoresObj.SetStoreID(StoreID);
                    break;
                }
            }
            GotOutput = StoresTemplateObj.Delete(StoresObj);
            Assert.AreEqual(ExpectedOutput, GotOutput);
        }
        [TestMethod()]
        public void RemoveStore_2()
        {
            int ExpectedOutput = 0;
            int GotOutput = -1;
            CRUDTemplate<IStores> StoresTemplateObj = new StoresTemplate();
            Stores StoresObj = new Stores();
            StoresObj.SetStoreID(-1);
            try
            {
                GotOutput = StoresTemplateObj.Delete(StoresObj);
            }
            catch (Exception)
            {
                GotOutput = -2;
            }
            Assert.AreEqual(ExpectedOutput, GotOutput);
        }
        [TestMethod()]
        public void RemoveStore_3()
        {
            int ExpectedOutput = 0;
            int GotOutput = -1;
            CRUDTemplate<IStores> StoresTemplateObj = new StoresTemplate();
            Stores StoresObj = new Stores();
            StoresObj.SetStoreID(100);
            try
            {
                GotOutput = StoresTemplateObj.Delete(StoresObj);
            }
            catch (Exception)
            {
                GotOutput = -2;
            }
            Assert.AreEqual(ExpectedOutput, GotOutput);
        }
    }
}
