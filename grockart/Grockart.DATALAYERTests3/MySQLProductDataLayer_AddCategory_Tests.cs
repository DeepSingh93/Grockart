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
    public class MySQLProductDataLayer_AddCategory_Tests
    {
        /*
        * Input : string CategoryName
        * Output : API_RESPONSE (OK, NOT_OK)
        * Function Definition : This function adds the new Category to DB
        * 
        * Cases covered 
        * 1. When the input CategoryName is valid
        * 2. When the input CategoryName is null
        * 3. When the input CategoryName is empty
        */

        /* Input: Valid CategoryName
         * Output: APIResponse.OK
        */
        CRUDTemplate<ICategory> CategoryTemplate = new CategoryTemplate();
        [TestMethod()]
        public void AddCategory_1()
        {
            int ExpectedOutput = 1;
            int GotOutput = 0;
            Category CategoryObj = new Category();
            CategoryObj.SetCategoryName("TestCategory_Add");
            try
            {
                GotOutput = CategoryTemplate.Insert(CategoryObj);
            }
            catch (Exception)
            {
                GotOutput = -2;
            }
            Assert.AreEqual(ExpectedOutput, GotOutput);

            // deleting the category by categoryid
            List<ICategory> Output = CategoryTemplate.Select();
            foreach (Category Category in Output)
            {
                if ("TestCategory_Add" == Category.GetCategoryName())
                {
                    int CategoryID = Category.GetCategoryId();
                    CategoryObj.SetCategoryId(CategoryID);
                    break;
                }
            }

            GotOutput = CategoryTemplate.Delete(CategoryObj);
        }
        /* Input: Null CategoryName
         * Output: Exception thrown (APIResponse.NOT_OK)
        */
        [TestMethod()]
        public void AddCategory_2()
        {
            int ExpectedOutput = -2;
            int GotOutput = -1;
            Category CategoryObj = new Category();
            CategoryObj.SetCategoryName(null);
            try
            {
                GotOutput = CategoryTemplate.Insert(CategoryObj);
            }
            catch (Exception)
            {
                GotOutput = -2;
            }
            Assert.AreEqual(ExpectedOutput, GotOutput);
        }
        /* Input: Empty CategoryName
         * Output: Exception thrown (APIResponse.NOT_OK)
        */
        [TestMethod()]
        public void AddCategory_3()
        {
            int ExpectedOutput = -2;
            int GotOutput = -1;
            Category CategoryObj = new Category();
            CategoryObj.SetCategoryName("");
            try
            {
                GotOutput = CategoryTemplate.Insert(CategoryObj);
            }
            catch (Exception)
            {
                GotOutput = -2;
            }
            Assert.AreEqual(ExpectedOutput, GotOutput);
        }
    }
}
