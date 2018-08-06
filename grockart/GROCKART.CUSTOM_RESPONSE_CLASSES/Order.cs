using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grockart.CUSTOM_RESPONSE_CLASSES
{
    public class Order : IOrder
    {
        public int StatusID;
        public int OrderID;
        public DateTime OrderDate;
        public string StatusName;
        public string OrderType;
        public Order()
        {
        }
        public void SetStatusID (int StatusID)
        {
            this.StatusID = StatusID;
        }
        public int GetStatusID()
        {
            return StatusID;
        }
        public void SetOrderID(int OrderID)
        {
            this.OrderID = OrderID;
        }
        public int GetOrderID()
        {
            CheckNegative(OrderID, "Order ID");
            return OrderID;
        }
        public void SetOrderDate(DateTime OrderDate)
        {
            this.OrderDate = OrderDate;
        }
        public DateTime GetOrderDate()
        {
            return OrderDate;
        }
        public void SetStatusName(string StatusName)
        {
            this.StatusName = StatusName;
        }
        public string GetStatusName()
        {
            CheckNulls(StatusName, "Status Name");
            return StatusName;
        }
        public void SetOrderType(string OrderType)
        {
            this.OrderType = OrderType;
        }
        public string GetOrderType()
        {
            CheckNulls(OrderType, "Order Type");
            return OrderType;
        }
        public void CheckNulls(string Input, object InputType)
        {
            if (Input == null || Input.Length == 0)
            {
                throw new ArgumentException("Invalid Argument : " + InputType.ToString() + " = null");
            }
        }
        public void CheckNegative(double Input, object InputType)
        {
            if (Input < 0)
            {
                throw new ArgumentException("Invalid Argument : " + InputType.ToString() + " = negative");
            }
        }
    }
}
