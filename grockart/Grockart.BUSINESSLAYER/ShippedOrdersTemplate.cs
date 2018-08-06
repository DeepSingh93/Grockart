using Grockart.CUSTOM_RESPONSE_CLASSES;
using Grockart.DATALAYER;
using Grockart.LOGGER;
using System;
using System.Collections.Generic;
using System.Data;

namespace Grockart.BUSINESSLAYER
{
    public class ShippedOrdersTemplate : OrderDetailsTemplate
    {
        private IUserProfile UserProfileObj;
        private IOrder OrderObj;
        public ShippedOrdersTemplate(IUserProfile UserProfileObj, IOrder OrderObj)
        {
            this.UserProfileObj = UserProfileObj;
            this.OrderObj = OrderObj;
        }
        public override List<IOrderBuilderResponse> BuildOrder()
        {
            try
            {
                List<IOrderBuilderResponse> Orders = new List<IOrderBuilderResponse>();
                // fetching Order IDs
                DataSet OrdersID = new OrderDetailsDataLayer(UserProfileObj, OrderObj).FetchOrderDetailsByTypeAndStatus();
                foreach (DataRow dr in OrdersID.Tables[0].Rows)
                {
                    IOrderBuilderResponse BuilderResponseObj = new OrderBuilderResponse();
                    int OrderId = int.Parse(dr["oId"].ToString());
                    OrderObj.SetOrderID(OrderId);
                    List<string> StoreLogoList = new List<string>();
                    OrderBuilderAbstract OrderBuilderObj = new OrderBuilder(UserProfileObj, OrderObj);
                    StoreLogoList = OrderBuilderObj.BuildOrderStores();
                    DateTime OrderDate = OrderBuilderObj.BuildOrderDate();
                    int CurrentOrderId = OrderBuilderObj.BuildOrderId();
                    int ItemCount = OrderBuilderObj.BuildOrderItemCount();
                    double OrderAmount = OrderBuilderObj.BuildOrderAmount();
                    string Status = OrderBuilderObj.BuildOrderStatus();
                    BuilderResponseObj.SetStoreLogo(StoreLogoList);
                    BuilderResponseObj.SetOrderDate(OrderDate);
                    BuilderResponseObj.SetOrderID(CurrentOrderId);
                    BuilderResponseObj.SetOrderItemCount(ItemCount);
                    BuilderResponseObj.SetOrderAmount(OrderAmount);
                    BuilderResponseObj.SetOrderStatus(Status);
                    Orders.Add(BuilderResponseObj);
                }
                return Orders;
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Fatal.Instance(), ex);
                throw ex;
            }
        }
    }
}
