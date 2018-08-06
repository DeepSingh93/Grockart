using System;
using System.Collections.Generic;

namespace Grockart.CUSTOM_RESPONSE_CLASSES
{
    public class OrderBuilderResponse : IOrderBuilderResponse
    {
        public List<string> StoreLogo;
        public int OrderID;
        public DateTime OrderDate;
        public int OrderItemCount;
        public double OrderAmount;
        public string OrderStatus;
        public void SetStoreLogo(List<string> StoreLogo)
        {
            this.StoreLogo = StoreLogo;
        }
        public List<string> GetStoreLogo()
        {
            foreach (string Logo in StoreLogo)
            {
                CheckNulls(Logo, "Store Logo");
            }
            return StoreLogo;
        }
        public void SetOrderID(int OrderID)
        {
            this.OrderID = OrderID;
        }
        public int GetOrderID()
        {
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
        public void SetOrderItemCount(int OrderItemCount)
        {
            this.OrderItemCount = OrderItemCount;
        }
        public int GetOrderItemCount()
        {
            CheckNegative(OrderItemCount, "Order Item Count");
            return OrderItemCount;
        }
        public void SetOrderAmount(double OrderAmount)
        {
            this.OrderAmount = OrderAmount;
        }
        public double GetOrderAmount()
        {
            CheckNegative(OrderAmount, "Order Amount");
            return OrderAmount;
        }
        public void SetOrderStatus(string OrderStatus)
        {
            this.OrderStatus = OrderStatus;
        }
        public string GetOrderStatus()
        {
            CheckNulls(OrderStatus, "Order Status");
            return OrderStatus;
        }
        private void CheckNulls(string Input, object InputType)
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
