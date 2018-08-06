using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grockart.CUSTOM_RESPONSE_CLASSES
{
    public interface IOrder
    {
        void SetStatusID(int StatusID);
        int GetStatusID();
        void SetOrderDate(DateTime OrderDate);
        DateTime GetOrderDate();
        void SetOrderID(int OrderID);
        int GetOrderID();
        void SetStatusName(string StatusName);
        string GetStatusName();
        void SetOrderType(string OrderType);
        string GetOrderType();
    }
}
