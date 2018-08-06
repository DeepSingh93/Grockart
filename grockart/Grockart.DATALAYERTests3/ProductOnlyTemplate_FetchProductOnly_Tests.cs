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
    public class ProductTemplate_FetchProductOnly_Tests
    {
        [TestMethod()]
        public void FetchProductOnly_1()
        {
            CRUDTemplate<IProduct> ProductOnlyObj = new ProductTemplate();
            List<IProduct> Output = ProductOnlyObj.Select();
            Assert.AreEqual(Output.Count > 0, true);
        }
    }
}
