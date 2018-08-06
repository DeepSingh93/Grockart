using Grockart.LOGGER;
using System;
using System.Data;

namespace Grockart.DATALAYER
{
    public class ProductMenu
    {
        public DataSet GetMenu()
        {
            string Source = "sp_getMenu";
            try
            {
                DataSet output = MySQLCommands.Instance().ExecuteQuery(Source, CommandType.StoredProcedure, null);
                return output;
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Fatal.Instance(), ex);
                throw ex;
            }
        }
    }
}
