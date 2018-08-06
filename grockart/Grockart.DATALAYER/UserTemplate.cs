using Grockart.CUSTOM_RESPONSE_CLASSES;
using Grockart.LOGGER;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace Grockart.DATALAYER
{
    public abstract class UserTemplate<T>
    {
        public abstract List<T> FetchList();
        public abstract APIResponse Remove();
        public abstract APIResponse Add();
        public DataSet FetchProfile(IUserProfile UserProfileObj)
        {
            string Source = "sp_getUserProfile";
            string Token = UserProfileObj.GetToken();
            try
            {
                object[] parameters =
                {
                    new MySqlParameter("@paramToken",Token)
                };
                DataSet output = MySQLCommands.Instance().ExecuteQuery(Source, CommandType.StoredProcedure, parameters);
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
