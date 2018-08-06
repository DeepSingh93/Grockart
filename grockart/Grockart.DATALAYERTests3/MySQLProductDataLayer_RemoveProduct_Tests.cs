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
    public class MySQLProductDataLayer_RemoveProduct_Tests
    {
        CRUDTemplate<IProductByStore> ProductByStoreTemplate = new ProductByStoreTemplate();
        [TestMethod()]
        public void RemoveProduct_1()
        {
            int ExpectedOutput = 0;
            int GotOutput = -1;
            ProductByStore ProductByStoreObj = new ProductByStore();
            ProductByStoreObj.SetProductByStoreID(-1);
            try
            {
                GotOutput = ProductByStoreTemplate.Delete(ProductByStoreObj);
            }
            catch (Exception)
            {
                GotOutput = -2;
            }
            Assert.AreEqual(ExpectedOutput, GotOutput);
        }
        /* Input: Valid CategoryID
         * Ouput: CategoryID doesnot exist
        */
        [TestMethod()]
        public void RemoveProduct_2()
        {
            int ExpectedOutput = 0;
            int GotOutput = -1;
            ProductByStore ProductByStoreObj = new ProductByStore();
            ProductByStoreObj.SetProductByStoreID(100);
            try
            {
                GotOutput = ProductByStoreTemplate.Delete(ProductByStoreObj);
            }
            catch (Exception)
            {
                GotOutput = -2;
            }
            Assert.AreEqual(ExpectedOutput, GotOutput);
        }
    }
}
