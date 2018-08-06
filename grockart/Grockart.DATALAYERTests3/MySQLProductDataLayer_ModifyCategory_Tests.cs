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
    public class MySQLProductDataLayer_ModifyCategory_Tests
    {
        /*
         * Input : int CategoryID, string CategoryNewName
         * Output : Category Name will be modified  ("1" row affected)
         * Function Definition : This function will modify the name of the Category and will return number of rows affected i.e. "1".
         * 
         * Cases covered 
         * 1. When the input CateoryID and CategoryNewName are valid
         * 2. When CategoryID is invalid and CategoryNewName is valid
         * 3. When CategoryID and CategoryNewName are valid but CategoryID doesnot exist
         * 4. When CategoryID is valid and CategoryNewName is null
         * 5. When CategoryID is valid and CategoryNewName is empty
         */

        /* Input: Valid CateoryID and CategoryNewName
         * Output: "1" row affected
        */
        CRUDTemplate<ICategory> Category = new CategoryTemplate();
        [TestMethod()]
        public void ModifyCategory_1()
        {
            int ExpectedOutput = 1;
            int GotOutput = 0;
            Category CategoryObj = new Category();
            CategoryObj.SetCategoryId(20);
            CategoryObj.SetCategoryName("DAIRY");
            try
            {
                GotOutput = Category.Update(CategoryObj);
            }
            catch (Exception)
            {
                GotOutput = -100;
            }
            Assert.AreEqual(ExpectedOutput, GotOutput);
        }
        /* Input: Invalid CateoryID and valid CategoryNewName
         * Output: "0" rows affected
        */
        [TestMethod()]
        public void ModifyCategory_2()
        {
            int ExpectedOutput = 0;
            int GotOutput = -100;
            Category CategoryObj = new Category();
            CategoryObj.SetCategoryId(-1);
            CategoryObj.SetCategoryName("DAIRY");
            try
            {
                GotOutput = Category.Update(CategoryObj);
            }
            catch (Exception)
            {
                GotOutput = -100;
            }
            Assert.AreEqual(ExpectedOutput, GotOutput);
        }
        /* Input: Valid CateoryID and valid CategoryNewName but CategoryID doesnot exist
         * Output: "0" rows affected
        */
        [TestMethod()]
        public void ModifyCategory_3()
        {
            int ExpectedOutput = 0;
            int GotOutput = -100;
            Category CategoryObj = new Category();
            CategoryObj.SetCategoryId(80);
            CategoryObj.SetCategoryName("DAIRY");
            try
            {
                GotOutput = Category.Update(CategoryObj);
            }
            catch (Exception)
            {
                GotOutput = -100;
            }
            Assert.AreEqual(ExpectedOutput, GotOutput);
        }
        /* Input: Valid CateoryID and null CategoryNewName
         * Output: "0" rows affected
        */
        [TestMethod()]
        public void ModifyCategory_4()
        {
            int ExpectedOutput = -100;
            int GotOutput = 0;
            Category CategoryObj = new Category();
            CategoryObj.SetCategoryId(20);
            CategoryObj.SetCategoryName(null);
            try
            {
                GotOutput = Category.Update(CategoryObj);
            }
            catch (Exception)
            {
                GotOutput = -100;
            }
            Assert.AreEqual(ExpectedOutput, GotOutput);
        }
        /* Input: Valid CateoryID and empty CategoryNewName
         * Output: "0" rows affected
        */
        [TestMethod()]
        public void ModifyCategory_5()
        {
            int ExpectedOutput = -100;
            int GotOutput = 0;
            Category CategoryObj = new Category();
            CategoryObj.SetCategoryId(20);
            CategoryObj.SetCategoryName("");
            try
            {
                GotOutput = Category.Update(CategoryObj);
            }
            catch (Exception)
            {
                GotOutput = -100;
            }
            Assert.AreEqual(ExpectedOutput, GotOutput);
        }
    }
}
