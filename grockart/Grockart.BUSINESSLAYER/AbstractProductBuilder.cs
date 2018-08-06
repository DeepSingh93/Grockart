using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grockart.BUSINESSLAYER
{
    public abstract class AbstractProductBuilder<T>
    {
        public abstract void BuildProductDetails();
        public abstract void BuildProductImage();
        public abstract void BuildLowestPriceStoreImage();
        public abstract void BuildOtherStoreDetails();
        public abstract T GetFinalProduct();
    }
}
