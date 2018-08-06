using Grockart.CUSTOM_RESPONSE_CLASSES;
using Grockart.DATALAYER;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Grockart.DATALAYER
{
    [TestClass()]
    public class MySQLProductDataLayer_RemoveCategory_Tests
    {
        /*
         * Input : int CategoryID
         * Output : The list of users with admin rights
         * Function Definition : This function returns back the list of users who have admin rights
         * 
         * Cases covered 
         * 1. When the input token is null
         * 2. When the input token has an invalid token (token deleted or token not active)
         * 3. When the input token is valid 
         */

        /* Input: Valid CategoryID
         * Output: Exception thrown because category can't be deleted until there are products linked to the Category
        */
        CRUDTemplate<ICategory> CategoryTemplate = new CategoryTemplate();
        [TestMethod()]
        public void RemoveCategory_1()
        {
            int ExpectedOutput = -100;
            int GotOutput = 0;
            Category CategoryObj = new Category();
            CategoryObj.SetCategoryId(20);
            try
            {
                GotOutput = CategoryTemplate.Delete(CategoryObj);
            }
            catch (Exception)
            {
                GotOutput = -100;
            }
            Assert.AreEqual(ExpectedOutput, GotOutput);
        }
        /* Input: Invalid CategoryID
         * Output: "0" rows affectd or deleted
        */
        [TestMethod()]
        public void RemoveCategory_2()
        {
            int ExpectedOutput = 0;
            int GotOutput = -1;
            Category CategoryObj = new Category();
            CategoryObj.SetCategoryId(-1);
            try
            {
                GotOutput = CategoryTemplate.Delete(CategoryObj);
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
        public void RemoveCategory_3()
        {
            int ExpectedOutput = 0;
            int GotOutput = 0;
            Category CategoryObj = new Category();
            CategoryObj.SetCategoryId(80);
            try
            {
                GotOutput = CategoryTemplate.Delete(CategoryObj);
            }
            catch (Exception)
            {
                GotOutput = -1;
            }
            Assert.AreEqual(ExpectedOutput, GotOutput);
        }
        /* Input: New Category added without any products under it
         * Ouput: "1" row affected or deleted
        */
        [TestMethod()]
        public void RemoveCategory_4()
        {
            int ExpectedOutput = 1;
            int GotOutput = 0;
            Category CategoryObj = new Category();
            CategoryObj.SetCategoryName("TestCategory_Remove");
            CategoryTemplate.Insert(CategoryObj);
            List<ICategory> Output = CategoryTemplate.Select();
            foreach (Category Category in Output)
            {
                if ("TestCategory_Remove" == Category.GetCategoryName())
                {
                    int CategoryID =Category.GetCategoryId();
                    CategoryObj.SetCategoryId(CategoryID);
                    break;
                }
            }
            GotOutput = CategoryTemplate.Delete(CategoryObj);
            Assert.AreEqual(ExpectedOutput, GotOutput);
        }
    }
}
