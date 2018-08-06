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
    public class MySQLProductDataLayer_FetchProductList_Tests
    { /*
         * Input : None
         * Output : List of all available products
         * Function Definition : This function returns back the list of all available products
         * 
         * Cases covered 
         * 1. Fetching Product List successfully
         */

      /* Input: None
       * Output: List of Products
      */
        [TestMethod()]
        public void FetchProductListTest_1()
        {
            CRUDTemplate<IProductByStore> ProductByStoreObj = new ProductByStoreTemplate();
            List<IProductByStore> Output = ProductByStoreObj.Select();
            Assert.AreEqual(Output.Count > 0, true);
        }
    }
}
