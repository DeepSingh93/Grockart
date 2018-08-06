using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grockart.CUSTOM_RESPONSE_CLASSES
{
    public interface IOrderBuilderResponse
    {
        void SetStoreLogo(List<string> StoreLogo);
        List<string> GetStoreLogo();
        void SetOrderID(int OrderID);
        int GetOrderID();
        void SetOrderDate(DateTime OrderDate);
        DateTime GetOrderDate();
        void SetOrderItemCount(int OrderItemCount);
        int GetOrderItemCount();
        void SetOrderAmount(double OrderAmount);
        double GetOrderAmount();
        void SetOrderStatus(string OrderStatus);
        string GetOrderStatus();
    }
}
