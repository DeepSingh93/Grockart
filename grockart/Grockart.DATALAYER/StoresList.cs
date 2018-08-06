using Grockart.LOGGER;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Grockart.DATALAYER
{
    public class StoresList
    {
        public DataSet FetchOtherStoresList(int PBSID)
        {
            string Source = "sp_FetchOtherStoresThanLowestProductStoreByPBSID";
            try
            {
                object[] param =
                {
                    new MySqlParameter("@paramPBSID", PBSID)
                };
                return MySQLCommands.Instance().ExecuteQuery(Source, CommandType.StoredProcedure, param);
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
