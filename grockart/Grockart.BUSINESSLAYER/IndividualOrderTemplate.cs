using Grockart.CUSTOM_RESPONSE_CLASSES;
using Grockart.DATALAYER;
using Grockart.LOGGER;
using System;
using System.Collections.Generic;

namespace Grockart.BUSINESSLAYER
{
    public class IndividualOrderTemplate : OrderTypeTemplate
    {
        private IUserProfile UserProfileObj;
        private IOrder OrderObj;
        public IndividualOrderTemplate(IUserProfile UserProfileObj, IOrder OrderObj)
        {
            this.UserProfileObj = UserProfileObj;
            this.OrderObj = OrderObj;
            this.OrderObj.SetOrderType("Individual");
        }
        public override List<IOrderBuilderResponse> FetchAllOrders()
        {
            try
            {
                OrderDetailsTemplate AllOrders = new AllOrdersTemplate(UserProfileObj, OrderObj);
                return AllOrders.BuildOrder();
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Fatal.Instance(), ex);
                throw ex;
            }
        }
        public override List<IOrderBuilderResponse> FetchCancelledOrderID()
        {
            try
            {
                OrderObj.SetStatusName("Cancelled");
                OrderDetailsTemplate CancelledOrders = new CancelledOrdersTemplate(UserProfileObj, OrderObj);
                return CancelledOrders.BuildOrder();
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Fatal.Instance(), ex);
                throw ex;
            }
        }
        public override List<IOrderBuilderResponse> FetchShippedOrderID()
        {
            try
            {
                OrderObj.SetStatusName("Shipped");
                OrderDetailsTemplate ShippedOrders = new ShippedOrdersTemplate(UserProfileObj, OrderObj);
                return ShippedOrders.BuildOrder();
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Fatal.Instance(), ex);
                throw ex;
            }
        }
        public override List<IOrderBuilderResponse> FetchUnpaidOrderID()
        {
            try
            {
                OrderObj.SetStatusName("Unpaid");
                OrderDetailsTemplate UnpaidOrders = new UnpaidOrdersTemplate(UserProfileObj, OrderObj);
                return UnpaidOrders.BuildOrder();
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Fatal.Instance(), ex);
                throw ex;
            }
        }
        public override List<IOrderBuilderResponse> FetchOrderCreatedID()
        {
            try
            {
                OrderObj.SetStatusName("Order_Created");
                OrderDetailsTemplate OrderCreated = new OrderCreatedTemplate(UserProfileObj, OrderObj);
                return OrderCreated.BuildOrder();
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Fatal.Instance(), ex);
                throw ex;
            }
        }
    }
}

