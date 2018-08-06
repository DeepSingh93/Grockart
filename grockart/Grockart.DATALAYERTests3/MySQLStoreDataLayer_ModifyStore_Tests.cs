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
    public class MySQLStoreDataLayer_ModifyStore_Tests
    {
        [TestMethod()]
        public void ModifyStore_1()
        {
            int ExpectedOutput = 1;
            int GotOutput = 0;
            CRUDTemplate<IStores> StoresTemplateObj = new StoresTemplate();
            Stores StoresObj = new Stores();
            StoresObj.SetStoreID(7);
            StoresObj.SetStoreName("Walmart_Test");
            StoresObj.SetStoreLogo("images\\walmart_test.png");
            try
            {
                GotOutput = StoresTemplateObj.Update(StoresObj);
            }
            catch (Exception)
            {
                GotOutput = -2;
            }
            Assert.AreEqual(ExpectedOutput, GotOutput);
            // Modfying Store to its original values
            StoresObj.SetStoreID(7);
            StoresObj.SetStoreName("Walmart");
            StoresObj.SetStoreLogo("images\\walmart.png");
            StoresTemplateObj.Update(StoresObj);
        }
        [TestMethod()]
        public void ModifyStore_2()
        {
            int ExpectedOutput = 0;
            int GotOutput = -1;
            CRUDTemplate<IStores> StoresTemplateObj = new StoresTemplate();
            Stores StoresObj = new Stores();
            StoresObj.SetStoreID(-1);
            StoresObj.SetStoreName("Walmart_Test");
            StoresObj.SetStoreLogo("images\\walmart_test.png");
            try
            {
                GotOutput = StoresTemplateObj.Update(StoresObj);
            }
            catch (Exception)
            {
                GotOutput = -2;
            }
            Assert.AreEqual(ExpectedOutput, GotOutput);
        }
        [TestMethod()]
        public void ModifyStore_3()
        {
            int ExpectedOutput = 0;
            int GotOutput = -1;
            CRUDTemplate<IStores> StoresTemplateObj = new StoresTemplate();
            Stores StoresObj = new Stores();
            StoresObj.SetStoreID(500);
            StoresObj.SetStoreName("Walmart_Test");
            StoresObj.SetStoreLogo("images\\walmart_test.png");
            try
            {
                GotOutput = StoresTemplateObj.Update(StoresObj);
            }
            catch (Exception)
            {
                GotOutput = -2;
            }
            Assert.AreEqual(ExpectedOutput, GotOutput);
        }
        [TestMethod()]
        public void ModifyStore_4()
        {
            int ExpectedOutput = -2;
            int GotOutput = -1;
            CRUDTemplate<IStores> StoresTemplateObj = new StoresTemplate();
            Stores StoresObj = new Stores();
            StoresObj.SetStoreID(7);
            StoresObj.SetStoreName(null);
            StoresObj.SetStoreLogo("images\\walmart_test.png");
            try
            {
                GotOutput = StoresTemplateObj.Update(StoresObj);
            }
            catch (Exception)
            {
                GotOutput = -2;
            }
            Assert.AreEqual(ExpectedOutput, GotOutput);
        }
        [TestMethod()]
        public void ModifyStore_5()
        {
            int ExpectedOutput = -2;
            int GotOutput = -1;
            CRUDTemplate<IStores> StoresTemplateObj = new StoresTemplate();
            Stores StoresObj = new Stores();
            StoresObj.SetStoreID(7);
            StoresObj.SetStoreName("");
            StoresObj.SetStoreLogo("images\\walmart_test.png");
            try
            {
                GotOutput = StoresTemplateObj.Update(StoresObj);
            }
            catch (Exception)
            {
                GotOutput = -2;
            }
            Assert.AreEqual(ExpectedOutput, GotOutput);
        }
        [TestMethod()]
        public void ModifyStore_6()
        {
            int ExpectedOutput = -2;
            int GotOutput = -1;
            CRUDTemplate<IStores> StoresTemplateObj = new StoresTemplate();
            Stores StoresObj = new Stores();
            StoresObj.SetStoreID(7);
            StoresObj.SetStoreName("Walmart_Test");
            StoresObj.SetStoreLogo(null);
            try
            {
                GotOutput = StoresTemplateObj.Update(StoresObj);
            }
            catch (Exception)
            {
                GotOutput = -2;
            }
            Assert.AreEqual(ExpectedOutput, GotOutput);
        }
        [TestMethod()]
        public void ModifyStore_7()
        {
            int ExpectedOutput = -2;
            int GotOutput = -1;
            CRUDTemplate<IStores> StoresTemplateObj = new StoresTemplate();
            Stores StoresObj = new Stores();
            StoresObj.SetStoreID(7);
            StoresObj.SetStoreName("Walmart_Test");
            StoresObj.SetStoreLogo("");
            try
            {
                GotOutput = StoresTemplateObj.Update(StoresObj);
            }
            catch (Exception)
            {
                GotOutput = -2;
            }
            Assert.AreEqual(ExpectedOutput, GotOutput);
        }
    }
}
