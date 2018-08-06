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
    public class ProductTemplate_AddProductOnly_Tests
    {
        [TestMethod()]
        public void AddProductOnly_1()
        {
            int ExpectedOutput = 1;
            int GotOutput = 0;
            CRUDTemplate<IProduct> ProductTemplateObj = new ProductTemplate();
            ProductsOnly ProductsOnlyObj = new ProductsOnly();
            ProductsOnlyObj.SetProductName("Test_Product");
            ProductsOnlyObj.SetProductImage("images\test.png");
            try
            {
                GotOutput = ProductTemplateObj.Insert(ProductsOnlyObj);
            }
            catch (Exception)
            {
                GotOutput = -2;
            }
            Assert.AreEqual(ExpectedOutput, GotOutput);

            // deleting the Product by product id
            List<IProduct> Output = ProductTemplateObj.Select();
            foreach (IProduct Product in Output)
            {
                if ("Test_Product" == Product.GetProductImage())
                {
                    int ProductId = Product.GetProductId();
                    ProductsOnlyObj.SetProductId(ProductId);
                    break;
                }
            }
            ProductTemplateObj.Delete(ProductsOnlyObj);
        }
    }
}
