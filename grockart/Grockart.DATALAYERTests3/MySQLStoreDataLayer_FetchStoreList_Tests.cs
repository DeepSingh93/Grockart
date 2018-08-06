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
    public class MySQLStoreDataLayer_FetchStoreList_Tests
    {/*
         * Input : none
         * Output : The list of Stores
         * Function Definition : This function returns back the list of Stores
         * 
         * Cases covered 
         * 1. Succesfully fetching list of Stores
         */
        /*Successfully fetching list of Stores.
         * If fetching is successful then the row count received from DB will be greater than 0
        */
        [TestMethod()]
        public void FetchStoreTest_1()
        {
            CRUDTemplate<IStores> StoresObj = new StoresTemplate();
            List<IStores> Output = StoresObj.Select();
          Assert.AreEqual(Output.Count > 0, true);
        }
    }
}
