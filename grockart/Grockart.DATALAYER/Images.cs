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
    public class Images
    {
        public string FetchProductImage(int ProductByStoreID)
        {
            string Source = "sp_FetchProductImageFromProductByStoreTable";
            try
            {
                Object[] param =
                {
                    new MySqlParameter("@paramPBSID", ProductByStoreID)
                };
                return MySQLCommands.Instance().ExecuteQuery(Source, CommandType.StoredProcedure, param).Tables[0].Rows[0]["productImage"].ToString();
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Fatal.Instance(), ex);
                throw ex;
            }
        }
        public string FetchStoreImageByPBSID(int PBSID)
        {
            string Source = "sp_FetchStoreLogoFromPBSID";
            try
            {
                object[] param =
                {
                    new MySqlParameter("@paramPBSID", PBSID)
                };
                return MySQLCommands.Instance().ExecuteQuery(Source, CommandType.StoredProcedure, param).Tables[0].Rows[0]["storeLogo"].ToString();
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Fatal.Instance(), ex);
                throw ex;
            }
        }
    }
}
