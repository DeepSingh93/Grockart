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
    public class TaxManagementDataLayer
    {
        public DataSet GetTaxDetailsFromDB(int AddressID)
        {
            try
            {
                string Source = "sp_FetchTaxDetailsByAddressID";
                object[] parameters =
                       {
                        new MySqlParameter("@paramAddressID", AddressID)
                };
                return MySQLCommands.Instance().ExecuteQuery(Source, CommandType.StoredProcedure, parameters);
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Fatal.Instance(), ex);
                throw ex;
            }

        }
    }
}
