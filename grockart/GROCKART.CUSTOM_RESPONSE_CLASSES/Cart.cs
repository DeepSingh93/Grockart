using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grockart.CUSTOM_RESPONSE_CLASSES
{
    public interface ICart
    {
        bool getHasValidationErrors();
        List<CartItems> GetCartItems();
    }
    public class Cart : ICart
    {
        public bool HasValidationErrors;
        public List<CartItems> CartItems;

        public List<CartItems> GetCartItems()
        {
            return CartItems;
        }

        public bool getHasValidationErrors()
        {
            return HasValidationErrors;
        }
    }
    public class CartItems
    {
        public bool HasQuantity;
        public Products ProductObj;
        public int DBQuantity;
    }
}
