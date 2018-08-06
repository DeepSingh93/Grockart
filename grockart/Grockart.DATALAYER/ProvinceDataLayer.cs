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
    public class ProvinceDataLayer 
    {
        public static DataSet GetDatasetOfProvinces()
        {
            try
            {
                List<IProvince> ProvinceList = new List<IProvince>();
                string Source = "sp_getProvinceList";
                Object[] paramToken = null;
                DataSet OutputDataset =  MySQLCommands.Instance().ExecuteQuery(Source, CommandType.StoredProcedure, paramToken);
                return OutputDataset;
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Fatal.Instance(), ex);
                throw ex;
            }
        }
    }
}
