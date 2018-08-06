using Grockart.CUSTOM_RESPONSE_CLASSES;
using Grockart.LOGGER;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grockart.DATALAYER
{
    public class OrderDataLayer : CRUDTemplate<IOrder>
    {
        private readonly ICommands Commands = MySQLCommands.Instance();
        private readonly IUserProfile UserProfileObj;
        private string Source;
        public OrderDataLayer(IUserProfile UserProfileObj)
        {
            this.UserProfileObj = UserProfileObj;
        }
        public override List<IOrder> Select()
        {
            Source = "sp_FetchOrder";
            string Token = UserProfileObj.GetToken();
            try
            {
                Object[] param =
                {
                    new MySqlParameter("@paramToken", Token)
                };
                DataSet Output = Commands.ExecuteQuery(Source, CommandType.StoredProcedure, param);
                List<IOrder> OrderDetailsList = new List<IOrder>();
                foreach (DataRow dr in Output.Tables[0].Rows)
                {
                    IOrder Order = new Order();
                    Order.SetStatusID(Int32.Parse(dr["sID"].ToString()));
                    Order.SetOrderID(Int32.Parse(dr["oID"].ToString()));
                    Order.SetOrderDate(DateTime.Parse(dr["date"].ToString()));
                    Order.SetStatusName(dr["statusName"].ToString());
                    Order.SetOrderType(dr["oTypeName"].ToString());
                    OrderDetailsList.Add(Order);
                }
                return OrderDetailsList;
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Fatal.Instance(), ex);
                throw ex;
            }
        }
        public override int Delete(IOrder OrderObj)
        {
            Source = "sp_RemoveOrder";
            int OrderID = OrderObj.GetOrderID();
            try
            {
                Object[] param =
                {
                    new MySqlParameter("@paramOID", OrderID)
                };
                return Commands.ExecuteNonQuery(Source, CommandType.StoredProcedure, param);
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
        public int Cancel(IOrder OrderObj)
        {
            Source = "sp_CancelOrder";
            int OrderID = OrderObj.GetOrderID();
            try
            {
                Object[] param =
                {
                    new MySqlParameter("@paramOID", OrderID),
                    new MySqlParameter("@paramToken", UserProfileObj.GetToken()),
                };
                return Commands.ExecuteNonQuery(Source, CommandType.StoredProcedure, param);
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
        public override int Insert(IOrder OrderObj)
        {
            Source = "sp_AddOrder";
            string Token = UserProfileObj.GetToken();
            string StatusName = OrderObj.GetStatusName();
            string OrderType = OrderObj.GetOrderType();
            DateTime OrderDate = OrderObj.GetOrderDate();
            try
            {
                Object[] param =
                {
                    new MySqlParameter("@paramToken", Token),
                    new MySqlParameter("@paramStatusName", StatusName),
                    new MySqlParameter("@paramOrderType", OrderType),
                    new MySqlParameter("@paramOrderDate", OrderDate)
                };
                return Commands.ExecuteNonQuery(Source, System.Data.CommandType.StoredProcedure, param);
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Fatal.Instance(), ex);
                throw ex;
            }
        }
        public override int Update(IOrder OrderObj)
        {
            Source = "sp_ModifyOrder";
            int OrderID = OrderObj.GetStatusID();
            string StatusName = OrderObj.GetStatusName();
            string Token = UserProfileObj.GetToken();
            string OrderType = OrderObj.GetOrderType();
            DateTime OrderDate = OrderObj.GetOrderDate();
            try
            {
                Object[] param =
                {
                    new MySqlParameter("@paramOrderID", OrderID),
                    new MySqlParameter("@paramToken", Token),
                    new MySqlParameter("@paramStatusName", StatusName),
                    new MySqlParameter("@paramOrderType", OrderType),
                    new MySqlParameter("@paramOrderDate", OrderDate)
                };
                return Commands.ExecuteNonQuery(Source, CommandType.StoredProcedure, param);
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Fatal.Instance(), ex);
                throw ex;
            }
        }
    }
}
