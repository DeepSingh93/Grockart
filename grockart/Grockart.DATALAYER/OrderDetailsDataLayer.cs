using Grockart.CUSTOM_RESPONSE_CLASSES;
using Grockart.LOGGER;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Grockart.DATALAYER
{
    public class OrderDetailsDataLayer : IOrderDetailsDataLayer
    {
        private string Source;
        private IUserProfile UserProfileObj;
        private IOrder OrderObj;
        private readonly ICommands Commands = MySQLCommands.Instance();
        public OrderDetailsDataLayer(IUserProfile UserProfileObj, IOrder OrderObj)
        {
            this.UserProfileObj = UserProfileObj;
            this.OrderObj = OrderObj;
        }
        public DataSet FetchOrderDetailsByTypeAndStatus()
        {
            Source = "sp_FetchOrderDetailsByTypeAndStatus";
            string Token = UserProfileObj.GetToken();
            string OrderType = OrderObj.GetOrderType();
            string OrderStatus = OrderObj.GetStatusName();
            try
            {
                Object[] param =
                {
                    new MySqlParameter("@paramToken", Token),
                    new MySqlParameter("@paramOrderType", OrderType),
                    new MySqlParameter("@paramStatus", OrderStatus)
                };
                return Commands.ExecuteQuery(Source, CommandType.StoredProcedure, param);
            }
            catch (MySqlException mse)
            {
                Logger.Instance().Log(Fatal.Instance(), mse);
                throw mse;
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Fatal.Instance(), ex);
                throw ex;
            }
        }
        public DataSet FetchOrderDetailsByType()
        {
            Source = "sp_FetchOrderDetailsByType";
            string Token = UserProfileObj.GetToken();
            string OrderType = OrderObj.GetOrderType();
            try
            {
                Object[] param =
                {
                    new MySqlParameter("@paramToken", Token),
                    new MySqlParameter("@paramOrderType", OrderType)
                };
                return Commands.ExecuteQuery(Source, CommandType.StoredProcedure, param);
            }
            catch (MySqlException mse)
            {
                Logger.Instance().Log(Fatal.Instance(), mse);
                throw mse;
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Fatal.Instance(), ex);
                throw ex;
            }
        }
        public DataSet FetchOrderDetailsByID()
        {
            Source = "sp_GetOrderDetails";
            string Token = UserProfileObj.GetToken();
            int OrderID = OrderObj.GetOrderID();
            try
            {
                Object[] param =
                {
                    new MySqlParameter("@paramOID", OrderID),
                    new MySqlParameter("@paramToken", Token)
                };
                return Commands.ExecuteQuery(Source, CommandType.StoredProcedure, param);
            }
            catch (MySqlException mse)
            {
                Logger.Instance().Log(Fatal.Instance(), mse);
                throw mse;
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Fatal.Instance(), ex);
                throw ex;
            }
        }
    }
}
