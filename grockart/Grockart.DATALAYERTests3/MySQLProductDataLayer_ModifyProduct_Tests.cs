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
    public class MySQLProductDataLayer_ModifyProduct_Tests
    {
        CRUDTemplate<IProductByStore> ProductByStoreTemplate = new ProductByStoreTemplate();
        [TestMethod()]
        public void ModifyProduct_1()
        {
            int ExpectedOutput = 1;
            int GotOutput = 0;
            ProductByStore ProductByStoreObj = new ProductByStore();
            ProductByStoreObj.SetProductByStoreID(433);
            ProductByStoreObj.SetStoreID(6);
            ProductByStoreObj.SetCategoryID(22);
            ProductByStoreObj.SetProductID(23);
            ProductByStoreObj.SetPrice(30);
            ProductByStoreObj.SetQuantity(25);
            ProductByStoreObj.SetQuantityPerUnit("test_gram");
            try
            {
                GotOutput = ProductByStoreTemplate.Update(ProductByStoreObj);
            }
            catch (Exception)
            {
                GotOutput = -2;
            }
            Assert.AreEqual(ExpectedOutput, GotOutput);
            // Modfying Product to its original values
            ProductByStoreObj.SetProductByStoreID(433);
            ProductByStoreObj.SetStoreID(5);
            ProductByStoreObj.SetCategoryID(17);
            ProductByStoreObj.SetProductID(21);
            ProductByStoreObj.SetPrice(20);
            ProductByStoreObj.SetQuantity(12);
            ProductByStoreObj.SetQuantityPerUnit("gm");
            ProductByStoreTemplate.Update(ProductByStoreObj);
        }
        [TestMethod()]
        public void ModifyProduct_2()
        {
            int ExpectedOutput = -2;
            int GotOutput = 0;
            ProductByStore ProductByStoreObj = new ProductByStore();
            ProductByStoreObj.SetProductByStoreID(433);
            ProductByStoreObj.SetStoreID(-1);
            ProductByStoreObj.SetCategoryID(22);
            ProductByStoreObj.SetProductID(23);
            ProductByStoreObj.SetPrice(30);
            ProductByStoreObj.SetQuantity(25);
            ProductByStoreObj.SetQuantityPerUnit("test_gram");
            try
            {
                GotOutput = ProductByStoreTemplate.Update(ProductByStoreObj);
            }
            catch (Exception)
            {
                GotOutput = -2;
            }
            Assert.AreEqual(ExpectedOutput, GotOutput);
        }
        [TestMethod()]
        public void ModifyProduct_3()
        {
            int ExpectedOutput = -2;
            int GotOutput = 0;
            ProductByStore ProductByStoreObj = new ProductByStore();
            ProductByStoreObj.SetProductByStoreID(433);
            ProductByStoreObj.SetStoreID(100);
            ProductByStoreObj.SetCategoryID(22);
            ProductByStoreObj.SetProductID(23);
            ProductByStoreObj.SetPrice(30);
            ProductByStoreObj.SetQuantity(25);
            ProductByStoreObj.SetQuantityPerUnit("test_gram");
            try
            {
                GotOutput = ProductByStoreTemplate.Update(ProductByStoreObj);
            }
            catch (Exception)
            {
                GotOutput = -2;
            }
            Assert.AreEqual(ExpectedOutput, GotOutput);
        }
        [TestMethod()]
        public void ModifyProduct_4()
        {
            int ExpectedOutput = -2;
            int GotOutput = 0;
            ProductByStore ProductByStoreObj = new ProductByStore();
            ProductByStoreObj.SetProductByStoreID(433);
            ProductByStoreObj.SetStoreID(5);
            ProductByStoreObj.SetCategoryID(-1);
            ProductByStoreObj.SetProductID(23);
            ProductByStoreObj.SetPrice(30);
            ProductByStoreObj.SetQuantity(25);
            ProductByStoreObj.SetQuantityPerUnit("test_gram");
            try
            {
                GotOutput = ProductByStoreTemplate.Update(ProductByStoreObj);
            }
            catch (Exception)
            {
                GotOutput = -2;
            }
            Assert.AreEqual(ExpectedOutput, GotOutput);
        }
        [TestMethod()]
        public void ModifyProduct_5()
        {
            int ExpectedOutput = -2;
            int GotOutput = 0;
            ProductByStore ProductByStoreObj = new ProductByStore();
            ProductByStoreObj.SetProductByStoreID(433);
            ProductByStoreObj.SetStoreID(5);
            ProductByStoreObj.SetCategoryID(100);
            ProductByStoreObj.SetProductID(23);
            ProductByStoreObj.SetPrice(30);
            ProductByStoreObj.SetQuantity(25);
            ProductByStoreObj.SetQuantityPerUnit("test_gram");
            try
            {
                GotOutput = ProductByStoreTemplate.Update(ProductByStoreObj);
            }
            catch (Exception)
            {
                GotOutput = -2;
            }
            Assert.AreEqual(ExpectedOutput, GotOutput);
        }
        [TestMethod()]
        public void ModifyProduct_6()
        {
            int ExpectedOutput = -2;
            int GotOutput = 0;
            ProductByStore ProductByStoreObj = new ProductByStore();
            ProductByStoreObj.SetProductByStoreID(433);
            ProductByStoreObj.SetStoreID(5);
            ProductByStoreObj.SetCategoryID(22);
            ProductByStoreObj.SetProductID(-1);
            ProductByStoreObj.SetPrice(30);
            ProductByStoreObj.SetQuantity(25);
            ProductByStoreObj.SetQuantityPerUnit("test_gram");
            try
            {
                GotOutput = ProductByStoreTemplate.Update(ProductByStoreObj);
            }
            catch (Exception)
            {
                GotOutput = -2;
            }
            Assert.AreEqual(ExpectedOutput, GotOutput);
        }
        [TestMethod()]
        public void ModifyProduct_7()
        {
            int ExpectedOutput = -2;
            int GotOutput = 0;
            ProductByStore ProductByStoreObj = new ProductByStore();
            ProductByStoreObj.SetProductByStoreID(433);
            ProductByStoreObj.SetStoreID(5);
            ProductByStoreObj.SetCategoryID(22);
            ProductByStoreObj.SetProductID(1000);
            ProductByStoreObj.SetPrice(30);
            ProductByStoreObj.SetQuantity(25);
            ProductByStoreObj.SetQuantityPerUnit("test_gram");
            try
            {
                GotOutput = ProductByStoreTemplate.Update(ProductByStoreObj);
            }
            catch (Exception)
            {
                GotOutput = -2;
            }
            Assert.AreEqual(ExpectedOutput, GotOutput);
        }
        [TestMethod()]
        public void ModifyProduct_8()
        {
            int ExpectedOutput = -2;
            int GotOutput = 0;
            ProductByStore ProductByStoreObj = new ProductByStore();
            ProductByStoreObj.SetProductByStoreID(433);
            ProductByStoreObj.SetStoreID(5);
            ProductByStoreObj.SetCategoryID(22);
            ProductByStoreObj.SetProductID(23);
            ProductByStoreObj.SetPrice(-1);
            ProductByStoreObj.SetQuantity(25);
            ProductByStoreObj.SetQuantityPerUnit("test_gram");
            try
            {
                GotOutput = ProductByStoreTemplate.Update(ProductByStoreObj);
            }
            catch (Exception)
            {
                GotOutput = -2;
            }
            Assert.AreEqual(ExpectedOutput, GotOutput);
        }
        [TestMethod()]
        public void ModifyProduct_9()
        {
            int ExpectedOutput = -2;
            int GotOutput = 0;
            ProductByStore ProductByStoreObj = new ProductByStore();
            ProductByStoreObj.SetProductByStoreID(433);
            ProductByStoreObj.SetStoreID(5);
            ProductByStoreObj.SetCategoryID(22);
            ProductByStoreObj.SetProductID(23);
            ProductByStoreObj.SetPrice(30);
            ProductByStoreObj.SetQuantity(-1);
            ProductByStoreObj.SetQuantityPerUnit("test_gram");
            try
            {
                GotOutput = ProductByStoreTemplate.Update(ProductByStoreObj);
            }
            catch (Exception)
            {
                GotOutput = -2;
            }
            Assert.AreEqual(ExpectedOutput, GotOutput);
        }
        [TestMethod()]
        public void ModifyProduct_10()
        {
            int ExpectedOutput = -2;
            int GotOutput = 0;
            ProductByStore ProductByStoreObj = new ProductByStore();
            ProductByStoreObj.SetProductByStoreID(433);
            ProductByStoreObj.SetStoreID(5);
            ProductByStoreObj.SetCategoryID(22);
            ProductByStoreObj.SetProductID(23);
            ProductByStoreObj.SetPrice(30);
            ProductByStoreObj.SetQuantity(25);
            ProductByStoreObj.SetQuantityPerUnit(null);
            try
            {
                GotOutput = ProductByStoreTemplate.Update(ProductByStoreObj);
            }
            catch (Exception)
            {
                GotOutput = -2;
            }
            Assert.AreEqual(ExpectedOutput, GotOutput);
        }
        [TestMethod()]
        public void ModifyProduct_11()
        {
            int ExpectedOutput = -2;
            int GotOutput = 0;
            ProductByStore ProductByStoreObj = new ProductByStore();
            ProductByStoreObj.SetProductByStoreID(433);
            ProductByStoreObj.SetStoreID(5);
            ProductByStoreObj.SetCategoryID(22);
            ProductByStoreObj.SetProductID(23);
            ProductByStoreObj.SetPrice(30);
            ProductByStoreObj.SetQuantity(25);
            ProductByStoreObj.SetQuantityPerUnit("");
            try
            {
                GotOutput = ProductByStoreTemplate.Update(ProductByStoreObj);
            }
            catch (Exception)
            {
                GotOutput = -2;
            }
            Assert.AreEqual(ExpectedOutput, GotOutput);
        }
    }
}
