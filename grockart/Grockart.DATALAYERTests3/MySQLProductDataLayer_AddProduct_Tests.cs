using Grockart.CUSTOM_RESPONSE_CLASSES;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Grockart.DATALAYER
{

    [TestClass()]
    public class MySQLProductDataLayer_AddProduct_Tests
    {
        CRUDTemplate<IProductByStore> ProductByStore = new ProductByStoreTemplate();
        [TestMethod()]
        public void AddProduct_1()
        {
            int ExpectedOutput = 1;
            int GotOutput = 0;
            ProductByStore ProductByStoreObj = new ProductByStore();
            ProductByStoreObj.SetStoreID(5);
            ProductByStoreObj.SetCategoryID(22);
            ProductByStoreObj.SetProductID(23);
            ProductByStoreObj.SetPrice(15);
            ProductByStoreObj.SetQuantity(25);
            ProductByStoreObj.SetQuantityPerUnit("test_gram");
            try
            {
                GotOutput = ProductByStore.Insert(ProductByStoreObj);
            }
            catch (Exception)
            {
                GotOutput = -2;
            }
            Assert.AreEqual(ExpectedOutput, GotOutput);
            // Deleting added Product
            List<IProductByStore> Output = ProductByStore.Select();
            foreach (ProductByStore Product in Output)
            {
                if ("test_gram" == Product.GetCategoryName())
                {
                    int CategoryID = Product.GetCategoryID();
                    ProductByStoreObj.SetProductByStoreID(CategoryID);
                    break;
                }
            }
            GotOutput = ProductByStore.Delete(ProductByStoreObj);
        }
        [TestMethod()]
        public void AddProduct_2()
        {
            int ExpectedOutput = -2;
            int GotOutput = 0;
            ProductByStore ProductByStoreObj = new ProductByStore();
            ProductByStoreObj.SetStoreID(-1);
            ProductByStoreObj.SetCategoryID(22);
            ProductByStoreObj.SetProductID(23);
            ProductByStoreObj.SetPrice(15);
            ProductByStoreObj.SetQuantity(25);
            ProductByStoreObj.SetQuantityPerUnit("test_gram");
            try
            {
                GotOutput = ProductByStore.Insert(ProductByStoreObj);
            }
            catch (Exception)
            {
                GotOutput = -2;
            }
            Assert.AreEqual(ExpectedOutput, GotOutput);
        }
        [TestMethod()]
        public void AddProduct_3()
        {
            int ExpectedOutput = -2;
            int GotOutput = 0;
            ProductByStore ProductByStoreObj = new ProductByStore();
            ProductByStoreObj.SetStoreID(100);
            ProductByStoreObj.SetCategoryID(22);
            ProductByStoreObj.SetProductID(23);
            ProductByStoreObj.SetPrice(15);
            ProductByStoreObj.SetQuantity(25);
            ProductByStoreObj.SetQuantityPerUnit("test_gram");
            try
            {
                GotOutput =ProductByStore.Insert(ProductByStoreObj);
            }
            catch (Exception)
            {
                GotOutput = -2;
            }
            Assert.AreEqual(ExpectedOutput, GotOutput);
        }
        [TestMethod()]
        public void AddProduct_4()
        {
            int ExpectedOutput = -2;
            int GotOutput = 0;
            ProductByStore ProductByStoreObj = new ProductByStore();
            ProductByStoreObj.SetStoreID(5);
            ProductByStoreObj.SetCategoryID(-1);
            ProductByStoreObj.SetProductID(23);
            ProductByStoreObj.SetPrice(15);
            ProductByStoreObj.SetQuantity(25);
            ProductByStoreObj.SetQuantityPerUnit("test_gram");
            try
            {
                GotOutput =ProductByStore.Insert(ProductByStoreObj);
            }
            catch (Exception)
            {
                GotOutput = -2;
            }
            Assert.AreEqual(ExpectedOutput, GotOutput);
        }
        [TestMethod()]
        public void AddProduct_5()
        {
            int ExpectedOutput = -2;
            int GotOutput = 0;
            ProductByStore ProductByStoreObj = new ProductByStore();
            ProductByStoreObj.SetStoreID(5);
            ProductByStoreObj.SetCategoryID(100);
            ProductByStoreObj.SetProductID(23);
            ProductByStoreObj.SetPrice(15);
            ProductByStoreObj.SetQuantity(25);
            ProductByStoreObj.SetQuantityPerUnit("test_gram");
            try
            {
                GotOutput =ProductByStore.Insert(ProductByStoreObj);
            }
            catch (Exception)
            {
                GotOutput = -2;
            }
            Assert.AreEqual(ExpectedOutput, GotOutput);
        }
        [TestMethod()]
        public void AddProduct_6()
        {
            int ExpectedOutput = -2;
            int GotOutput = 0;
            ProductByStore ProductByStoreObj = new ProductByStore();
            ProductByStoreObj.SetStoreID(5);
            ProductByStoreObj.SetCategoryID(22);
            ProductByStoreObj.SetProductID(-1);
            ProductByStoreObj.SetPrice(15);
            ProductByStoreObj.SetQuantity(25);
            ProductByStoreObj.SetQuantityPerUnit("test_gram");
            try
            {
                GotOutput =ProductByStore.Insert(ProductByStoreObj);
            }
            catch (Exception)
            {
                GotOutput = -2;
            }
            Assert.AreEqual(ExpectedOutput, GotOutput);
        }
        [TestMethod()]
        public void AddProduct_7()
        {
            int ExpectedOutput = -2;
            int GotOutput = 0;
            ProductByStore ProductByStoreObj = new ProductByStore();
            ProductByStoreObj.SetStoreID(5);
            ProductByStoreObj.SetCategoryID(22);
            ProductByStoreObj.SetProductID(1000);
            ProductByStoreObj.SetPrice(15);
            ProductByStoreObj.SetQuantity(25);
            ProductByStoreObj.SetQuantityPerUnit("test_gram");
            try
            {
                GotOutput =ProductByStore.Insert(ProductByStoreObj);
            }
            catch (Exception)
            {
                GotOutput = -2;
            }
            Assert.AreEqual(ExpectedOutput, GotOutput);
        }
        [TestMethod()]
        public void AddProduct_8()
        {
            int ExpectedOutput = -2;
            int GotOutput = 0;
            ProductByStore ProductByStoreObj = new ProductByStore();
            ProductByStoreObj.SetStoreID(5);
            ProductByStoreObj.SetCategoryID(22);
            ProductByStoreObj.SetProductID(23);
            ProductByStoreObj.SetPrice(-1);
            ProductByStoreObj.SetQuantity(25);
            ProductByStoreObj.SetQuantityPerUnit("test_gram");
            try
            {
                GotOutput =ProductByStore.Insert(ProductByStoreObj);
            }
            catch (Exception)
            {
                GotOutput = -2;
            }
            Assert.AreEqual(ExpectedOutput, GotOutput);
        }
        [TestMethod()]
        public void AddProduct_9()
        {
            int ExpectedOutput = -2;
            int GotOutput = 0;
            ProductByStore ProductByStoreObj = new ProductByStore();
            ProductByStoreObj.SetStoreID(5);
            ProductByStoreObj.SetCategoryID(22);
            ProductByStoreObj.SetProductID(23);
            ProductByStoreObj.SetPrice(15);
            ProductByStoreObj.SetQuantity(-1);
            ProductByStoreObj.SetQuantityPerUnit("test_gram");
            try
            {
                GotOutput =ProductByStore.Insert(ProductByStoreObj);
            }
            catch (Exception)
            {
                GotOutput = -2;
            }
            Assert.AreEqual(ExpectedOutput, GotOutput);
        }
        [TestMethod()]
        public void AddProduct_10()
        {
            int ExpectedOutput = -2;
            int GotOutput = 0;
            ProductByStore ProductByStoreObj = new ProductByStore();
            ProductByStoreObj.SetStoreID(5);
            ProductByStoreObj.SetCategoryID(22);
            ProductByStoreObj.SetProductID(23);
            ProductByStoreObj.SetPrice(15);
            ProductByStoreObj.SetQuantity(25);
            ProductByStoreObj.SetQuantityPerUnit(null);
            try
            {
                GotOutput =ProductByStore.Insert(ProductByStoreObj);
            }
            catch (Exception)
            {
                GotOutput = -2;
            }
            Assert.AreEqual(ExpectedOutput, GotOutput);
        }
        [TestMethod()]
        public void AddProduct_11()
        {
            int ExpectedOutput = -2;
            int GotOutput = 0;
            ProductByStore ProductByStoreObj = new ProductByStore();
            ProductByStoreObj.SetStoreID(5);
            ProductByStoreObj.SetCategoryID(22);
            ProductByStoreObj.SetProductID(23);
            ProductByStoreObj.SetPrice(15);
            ProductByStoreObj.SetQuantity(25);
            ProductByStoreObj.SetQuantityPerUnit("");
            try
            {
                GotOutput =ProductByStore.Insert(ProductByStoreObj);
            }
            catch (Exception)
            {
                GotOutput = -2;
            }
            Assert.AreEqual(ExpectedOutput, GotOutput);
        }
    }
}
