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
    public class OrderCreatorDataLayer
    {
        public DataSet CreateOrderID(IAddress AddressObj, ICardDetails CardObj, IUserProfile UserProfileObj)
        {
            string Source = "sp_CreateOrderID";
            try
            {
                object[] paramToken =
                {
                    new MySqlParameter("@aID", AddressObj.GetAddressID()),
                    new MySqlParameter("@caID", CardObj.GetCardID()),
                    new MySqlParameter("@paramToken", UserProfileObj.GetToken())
                };
                return MySQLCommands.Instance().ExecuteQuery(Source, CommandType.StoredProcedure, paramToken);
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Fatal.Instance(), ex);
                throw ex;
            }
        }

        public void InsertValuesToDatabase(int Oid, int Pbsid, int Quantity, double Price, double TaxAmount)
        {
            string Source = "sp_insertOrderByRow";
            try
            {
                object[] paramToken =
                {
                    new MySqlParameter("@paramoID", Oid),
                    new MySqlParameter("@parampbsID", Pbsid),
                    new MySqlParameter("@paramQuantity", Quantity),
                    new MySqlParameter("@paramPrice",Price),
                    new MySqlParameter("@paramTaxAmount", TaxAmount)
                };
                MySQLCommands.Instance().ExecuteQuery(Source, CommandType.StoredProcedure, paramToken);
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Fatal.Instance(), ex);
                throw ex;
            }
        }
    }
}
