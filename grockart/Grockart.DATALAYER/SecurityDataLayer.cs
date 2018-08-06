using MySql.Data.MySqlClient;
using System;
using System.Data;
using Grockart.CUSTOM_RESPONSE_CLASSES;
using Grockart.LOGGER;
using System.Collections.Generic;

namespace Grockart.DATALAYER
{
    public class SecurityDataLayer : ISecurityDataLayer
    {
        private string Source;
        protected readonly ICommands Commands = MySQLCommands.Instance();
        private readonly IUserProfile UserProfileObj;
        public SecurityDataLayer(IUserProfile UserProfileObj)
        {
            this.UserProfileObj = UserProfileObj;
        }
        public void AddTokenToDatabase()
        {
            Source = "sp_addToken";
            string Email = UserProfileObj.GetEmail();
            string Token = UserProfileObj.GetToken();
            try
            {
                object[] paramToken =
                {
                    new MySqlParameter("@paramToken", Token),
                    new MySqlParameter("@paramEmail", Email),
                };
                Commands.ExecuteQuery(Source, CommandType.StoredProcedure, paramToken);
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Fatal.Instance(), ex);
                throw ex;
            }
        }

        public List<string> GetTokenList()
        {
            DataSet output = null;
            List<string> outputList = new List<string>();
            string Email = UserProfileObj.GetEmail();
            try
            {
                Source = "sp_getToken";
                object[] parameters =
                {
                    new MySqlParameter("@paramEmail", Email),
                };
                output = Commands.ExecuteQuery(Source, CommandType.StoredProcedure, parameters);
                foreach (DataRow dr in output.Tables[0].Rows)
                {
                    outputList.Add(dr["token"].ToString());
                }
                return outputList;
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Info.Instance(), ex);
                throw ex;
            }
        }

        public DataSet GetUserToken()
        {
            Source = "sp_authToken";
            string Token = UserProfileObj.GetToken();
            try
            {
                object[] parameters =
                {
                    new MySqlParameter("@paramToken", Token)
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

        public void RemoveToken()
        {
            // this function won't throw any exceptions because this is just removing the token
            // values without blocking the user input
            // but log the warning level at FATAL level if any exception is thrown
            Source = "sp_removeToken";
            string Token = UserProfileObj.GetToken();
            try
            {
                object[] paramToken =
                {
                    new MySqlParameter("@paramToken", Token)
                };
                Commands.ExecuteQuery(Source, CommandType.StoredProcedure, paramToken);
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Fatal.Instance(), ex);
            }
        }
    }
}
