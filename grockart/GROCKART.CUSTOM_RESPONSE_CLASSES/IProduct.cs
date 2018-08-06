using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grockart.CUSTOM_RESPONSE_CLASSES
{
    public interface IProduct
    {
        void SetProductId(int ProductId);
        int GetProductId();
        void SetProductName(string ProductName);
        string GetProductName();
        void SetProductImage(string ProductImage);
        string GetProductImage();
        void SetProductQuantity(int ProductQuantity);
        int GetProductQuantity();
    }
}
