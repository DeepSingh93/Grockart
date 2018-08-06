using Grockart.CUSTOM_RESPONSE_CLASSES;
using Grockart.DATALAYER;
using Grockart.LOGGER;
using System;
using System.Collections.Generic;
using System.Data;

namespace Grockart.BUSINESSLAYER
{
    public class OrderBuilder : OrderBuilderAbstract
    {
        private IUserProfile UserProfileObj;
        private IOrder OrderObj;
        public OrderBuilder(IUserProfile UserProfileObj, IOrder OrderObj)
        {
            this.UserProfileObj = UserProfileObj;
            this.OrderObj = OrderObj;
        }
        public override List<String> BuildOrderStores()
        {
            try
            {
                List<string> StoreLogoList = new List<string>();
                IOrderDetailsDataLayer OrderDetailsDataLayerObj = new OrderDetailsDataLayer(UserProfileObj, OrderObj);
                DataSet Output = OrderDetailsDataLayerObj.FetchOrderDetailsByType();
                foreach (DataRow dr in Output.Tables[1].Rows)
                {
                    if (int.Parse(dr["oId"].ToString()) == OrderObj.GetOrderID())
                    {
                        IStores StoreImageObj = new Stores();
                        StoreImageObj.SetStoreLogo(dr["storeLogo"].ToString());
                        StoreLogoList.Add(StoreImageObj.GetStoreLogo());
                    }
                }
                return StoreLogoList;
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Fatal.Instance(), ex);
                throw ex;
            }
        }
        public override int BuildOrderId()
        {
            return OrderObj.GetOrderID();
        }
        public override DateTime BuildOrderDate()
        {
            try
            {
                string OrderDateTimeStr = null;
                OrderDetailsDataLayer OrderDetailsDataLayerObj = new OrderDetailsDataLayer(UserProfileObj, OrderObj);
                DataSet Output = OrderDetailsDataLayerObj.FetchOrderDetailsByType();
                foreach (DataRow dr in Output.Tables[0].Rows)
                {
                    if (int.Parse(dr["oId"].ToString()) == OrderObj.GetOrderID())
                    {
                        OrderDateTimeStr = DateTime.Parse(dr["date"].ToString()).ToString();
                    }
                }
                return DateTime.Parse(OrderDateTimeStr);
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Fatal.Instance(), ex);
                throw ex;
            }
        }
         public override int BuildOrderItemCount()
        {
            try
            {
                int ItemCount = 0;
                OrderDetailsDataLayer OrderDetailsDataLayerObj = new OrderDetailsDataLayer(UserProfileObj, OrderObj);
                DataSet Output = OrderDetailsDataLayerObj.FetchOrderDetailsByType();
                foreach (DataRow dr in Output.Tables[0].Rows)
                {
                    if (int.Parse(dr["oId"].ToString()) == OrderObj.GetOrderID())
                    {
                        ItemCount = int.Parse(dr["Items"].ToString());
                    }
                }
                return ItemCount;
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Fatal.Instance(), ex);
                throw ex;
            }
        }
        public override double BuildOrderAmount()
        {
            try
            {
                double OrderAmount = 0;
                OrderDetailsDataLayer OrderDetailsDataLayerObj = new OrderDetailsDataLayer(UserProfileObj, OrderObj);
                DataSet Output = OrderDetailsDataLayerObj.FetchOrderDetailsByType();
                foreach (DataRow dr in Output.Tables[0].Rows)
                {
                    if (int.Parse(dr["oId"].ToString()) == OrderObj.GetOrderID())
                    {
                        OrderAmount = double.Parse(dr["Amount"].ToString());
                    }
                }
                return OrderAmount;
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Fatal.Instance(), ex);
                throw ex;
            }
        }
        public override string BuildOrderStatus()
        {
            try
            {
                string Status = null;
                OrderDetailsDataLayer OrderDetailsDataLayerObj = new OrderDetailsDataLayer(UserProfileObj, OrderObj);
                DataSet Output = OrderDetailsDataLayerObj.FetchOrderDetailsByType();
                foreach (DataRow dr in Output.Tables[0].Rows)
                {
                    if (int.Parse(dr["oId"].ToString()) == OrderObj.GetOrderID())
                    {
                        Status = dr["statusName"].ToString();
                    }
                }
                return Status;
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Fatal.Instance(), ex);
                throw ex;
            }
        }
    }
}
