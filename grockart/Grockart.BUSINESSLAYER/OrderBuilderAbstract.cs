using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grockart.BUSINESSLAYER
{
    public abstract class OrderBuilderAbstract
    {
        public abstract List<String> BuildOrderStores();
        public abstract int BuildOrderId();
        public abstract DateTime BuildOrderDate();
        public abstract int BuildOrderItemCount();
        public abstract double BuildOrderAmount();
        public abstract string BuildOrderStatus();
    }
}
