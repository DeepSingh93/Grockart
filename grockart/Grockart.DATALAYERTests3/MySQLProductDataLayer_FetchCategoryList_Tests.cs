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
   public class MySQLProductDataLayer_FetchCategoryList_Tests
    {
        /*
         * Input : None
         * Output : List of all available categories
         * Function Definition : This function returns back the list of all available categories
         * 
         * Cases covered 
         * 1. Fetching Category List successfully
         */
         /* Input: None
          * Output: List of Categories
         */
        [TestMethod()]
        public void FetchCategoryListTest_1()
        {
            CRUDTemplate<ICategory> ProductByCategoryObj = new CategoryTemplate();
            List<ICategory> Output = ProductByCategoryObj.Select();
            Assert.AreEqual(Output.Count > 0, true);
        }
    }
}
