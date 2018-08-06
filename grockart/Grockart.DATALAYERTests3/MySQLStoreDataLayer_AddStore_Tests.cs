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
    public class MySQLStoreDataLayer_AddStore_Tests
    {
        [TestMethod()]
        public void AddStore_1()
        {
            int ExpectedOutput = 1;
            int GotOutput = 0;
            CRUDTemplate<IStores> StoresTemplateObj = new StoresTemplate();
            Stores StoresObj = new Stores();
            StoresObj.SetStoreName("Test_Store");
            StoresObj.SetStoreLogo("images\test.png");
            try
            {
                GotOutput = StoresTemplateObj.Insert(StoresObj);
            }
            catch (Exception)
            {
                GotOutput = -2;
            }
            Assert.AreEqual(ExpectedOutput, GotOutput);
            // Deleting newely added Store
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
            StoresTemplateObj.Delete(StoresObj);
        }
        [TestMethod()]
        public void AddStore_2()
        {
            int ExpectedOutput = -2;
            int GotOutput = 0;
            CRUDTemplate<IStores> StoresTemplateObj = new StoresTemplate();
            Stores StoresObj = new Stores();
            StoresObj.SetStoreName(null);
            StoresObj.SetStoreLogo("images\test.png");
            try
            {
                GotOutput = StoresTemplateObj.Insert(StoresObj);
            }
            catch (Exception)
            {
                GotOutput = -2;
            }
            Assert.AreEqual(ExpectedOutput, GotOutput);
        }
        [TestMethod()]
        public void AddStore_3()
        {
            int ExpectedOutput = -2;
            int GotOutput = 0;
            CRUDTemplate<IStores> StoresTemplateObj = new StoresTemplate();
            Stores StoresObj = new Stores();
            StoresObj.SetStoreName("");
            StoresObj.SetStoreLogo("images\test.png");
            try
            {
                GotOutput = StoresTemplateObj.Insert(StoresObj);
            }
            catch (Exception)
            {
                GotOutput = -2;
            }
            Assert.AreEqual(ExpectedOutput, GotOutput);
        }
        [TestMethod()]
        public void AddStore_4()
        {
            int ExpectedOutput = -2;
            int GotOutput = 0;
            CRUDTemplate<IStores> StoresTemplateObj = new StoresTemplate();
            Stores StoresObj = new Stores();
            StoresObj.SetStoreName("Test_Store");
            StoresObj.SetStoreLogo(null);
            try
            {
                GotOutput = StoresTemplateObj.Insert(StoresObj);
            }
            catch (Exception)
            {
                GotOutput = -2;
            }
            Assert.AreEqual(ExpectedOutput, GotOutput);
        }
        [TestMethod()]
        public void AddStore_5()
        {
            int ExpectedOutput = -2;
            int GotOutput = 0;
            CRUDTemplate<IStores> StoresTemplateObj = new StoresTemplate();
            Stores StoresObj = new Stores();
            StoresObj.SetStoreName("Test_Store");
            StoresObj.SetStoreLogo("");
            try
            {
                GotOutput = StoresTemplateObj.Insert(StoresObj);
            }
            catch (Exception)
            {
                GotOutput = -2;
            }
            Assert.AreEqual(ExpectedOutput, GotOutput);
        }
    }
}
