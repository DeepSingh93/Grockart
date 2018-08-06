using MySql.Data.MySqlClient;
using System;
using System.Data;
using Grockart.CUSTOM_RESPONSE_CLASSES;
using Grockart.LOGGER;
using System.Collections.Generic;


namespace Grockart.DATALAYER
{
    public class UserActionsDataLayer
    {
        private readonly IUserProfile UserProfileObj;
        private string Source;
        private readonly ICommands Commands = MySQLCommands.Instance();
        public UserActionsDataLayer(IUserProfile UserProfileObj)
        {
            this.UserProfileObj = UserProfileObj;
        }
        public DataSet GetHashedPassword()
        {
            Source = "sp_getSaltPass";
            String Email = UserProfileObj.GetEmail();
            try
            {
                object[] parameters =
                {
                        new MySqlParameter("@paramEmail", Email)
                };
                DataSet output = Commands.ExecuteQuery(Source, CommandType.StoredProcedure, parameters);
                return output;
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Warn.Instance(), ex);
                throw ex;
            }
        }
        
        public APIResponse RecoverPassword(string FPToken, string Email)
        {
            Source = "sp_addFPToken";
            try
            {
                if (null == FPToken || null == Email)
                {
                    throw new ArgumentException("Parameter : Null, Function : ForgotPassword");
                }
                object[] param =
                {
                    new MySqlParameter("@paramFPToken", FPToken),
                    new MySqlParameter("@paramEmail", Email),
                    new MySqlParameter("@paramTimeStamp", DateTime.Now)
                };
                Commands.ExecuteQuery(Source, CommandType.StoredProcedure, param);
                return APIResponse.OK;
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
