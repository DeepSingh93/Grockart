using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grockart.CUSTOM_RESPONSE_CLASSES
{
    public class ProductsOnly : IProduct
    {
        public int ProductId;
        public string ProductName;
        public string ProductImage;
        public int ProductQuantity;
        public ProductsOnly()
        {
        }
        public void SetProductId(int ProductId)
        {
            this.ProductId = ProductId;
        }
        public int GetProductId()
        {
            return ProductId;
        }
        public void SetProductName(string ProductName)
        {
            this.ProductName = ProductName;
        }
        public string GetProductName()
        {
            CheckNulls(ProductName, "Product Name");
            return ProductName;
        }
        public void SetProductImage(string ProductImage)
        {
            this.ProductImage = ProductImage;
        }
        public string GetProductImage()
        {
            CheckNulls(ProductImage, "Product Image");
            return ProductImage;
        }
        private void CheckNulls(string Input, object InputType)
        {
            if (Input == null || Input.Length == 0)
            {
                throw new ArgumentException("Invalid Argument : " + InputType.ToString() + " = null");
            }
        }

        public void SetProductQuantity(int ProductQuantity)
        {
            this.ProductQuantity = ProductQuantity;
        }

        public int GetProductQuantity()
        {
            return ProductQuantity;
        }
    }
}
