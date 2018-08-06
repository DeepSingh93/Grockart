using MySql.Data.MySqlClient;
using System;
using System.Data;
using Grockart.CUSTOM_RESPONSE_CLASSES;
using Grockart.LOGGER;
using System.Collections.Generic;

namespace Grockart.DATALAYER
{
    public class AdminUserTemplate : UserTemplate<IUserProfile>
    {
        private readonly IUserProfile UserProfileObj;
        private string Source;
        private readonly ICommands Commands = MySQLCommands.Instance();
        public AdminUserTemplate(IUserProfile UserProfileObj)
        {
            this.UserProfileObj = UserProfileObj;
        }
        public override APIResponse Add()
        {
            string Email = UserProfileObj.GetEmail();
            try
            {
                Source = "sp_AddAdmin";

                Object[] paramToken =
                {
                    new MySqlParameter("@paramEmail", Email)
                };
                Commands.ExecuteQuery(Source, CommandType.StoredProcedure, paramToken);
                return APIResponse.OK;
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Fatal.Instance(), ex);
                throw ex;
            }
        }

        public override List<IUserProfile> FetchList()
        {
            Source = "sp_GetAdminList";
            string Token = UserProfileObj.GetToken();
            try
            {
                Object[] paramToken =
                {
                    new MySqlParameter("@paramToken", Token.ToString())
                };
                // Connection : Get the current connection string
                // Commands : Get the current commands MySQL Connection can perform
                DataSet Output = Commands.ExecuteQuery(Source, CommandType.StoredProcedure, paramToken);
                List<IUserProfile> ProductList = new List<IUserProfile>();
                foreach (DataRow dr in Output.Tables[0].Rows)
                {
                    UserProfile Profile = new UserProfile
                    (
                        FirstName: dr["firstName"].ToString(),
                        LastName: dr["lastName"].ToString(),
                        Email: dr["email"].ToString(),
                        IsAdmin: true
                    );
                    ProductList.Add(Profile);
                }
                return ProductList;
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Fatal.Instance(), ex);
                throw ex;
            }
        }

        public override APIResponse Remove()
        {
            string Email = UserProfileObj.GetEmail();
            Source = "sp_RemoveAdmin";
            try
            {
                Object[] paramToken =
                {
                    new MySqlParameter("@paramEmail", Email)
                };
                Commands.ExecuteQuery(Source, CommandType.StoredProcedure, paramToken);
                return APIResponse.OK;
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Fatal.Instance(), ex);
                throw ex;
            }
        }
    }
}
