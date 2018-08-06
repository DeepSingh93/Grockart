using MySql.Data.MySqlClient;
using System;
using System.Data;
using Grockart.CUSTOM_RESPONSE_CLASSES;
using Grockart.LOGGER;
using System.Collections.Generic;

namespace Grockart.DATALAYER
{

    public class NormalUserTemplate : UserTemplate<IUserProfile>
    {
        private readonly IUserProfile UserProfileObj;
        private string Source;
        private readonly ICommands Commands = MySQLCommands.Instance();
        private string Query;
        public NormalUserTemplate(IUserProfile UserProfileObj)
        {
            this.UserProfileObj = UserProfileObj;
        }
        public NormalUserTemplate(IUserProfile UserProfileObj, string Query)
        {
            this.UserProfileObj = UserProfileObj;
            this.Query = Query;
        }
        public override APIResponse Add()
        {
            Source = "sp_registerUser";
            try
            {
                string FirstName = UserProfileObj.GetFirstName();
                string LastName = UserProfileObj.GetLastName();
                string Password = UserProfileObj.GetPassword();
                string HashedPassword = UserProfileObj.GetHashedPassword();
                string Token = UserProfileObj.GetToken();
                string RoleType = UserProfileObj.GetRoleType();
                string Email = UserProfileObj.GetEmail();
                string Salt = UserProfileObj.GetSalt();

                object[] parameters =
                    {
                        new MySqlParameter("@paramFirstName", FirstName),
                        new MySqlParameter("@paramLastName", LastName),
                        new MySqlParameter("@paramEmail", Email),
                        new MySqlParameter("@paramPwd", HashedPassword),
                        new MySqlParameter("@paramSalt", Salt),
                        new MySqlParameter("@paramToken", Token),
                        new MySqlParameter("@paramRoleType", RoleType)
                };
                DataSet sqlOutput = Commands.ExecuteQuery(Source, CommandType.StoredProcedure, parameters);
                // now check the status
                return APIResponse.OK;
            }
            catch (MySqlException mse)
            {
                Logger.Instance().Log(Info.Instance(), mse);
                throw mse;
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Warn.Instance(), ex);
                throw ex;
            }
        }

        public override List<IUserProfile> FetchList()
        {
            Source = "sp_searchUserList";
            string Token = UserProfileObj.GetToken();
            if (null == Query || Query.ToString().Length == 0)
            {
                throw new ArgumentException("Invalid parameter : Given Query Value is null");
            }
            try
            {
                Object[] param =
                {
                    new MySqlParameter("@paramToken", Token.ToString()),
                    new MySqlParameter("@paramSearchQuery", Query)
                };
                DataSet Output = Commands.ExecuteQuery(Source, CommandType.StoredProcedure, param);
                List<IUserProfile> UserList = new List<IUserProfile>();
                foreach (DataRow dr in Output.Tables[0].Rows)
                {
                    UserProfile Profile = new UserProfile
                    (
                        FirstName: dr["firstName"].ToString(),
                        LastName: dr["lastName"].ToString(),
                        Email: dr["email"].ToString(),
                        IsAdmin: dr["roleName"].ToString().ToLower() == "admin" ? true : false
                    );
                    UserList.Add(Profile);
                }
                return UserList;
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Fatal.Instance(), ex);
                throw ex;
            }
        }

        public override APIResponse Remove()
        {
            Source = "sp_RemoveUser";
            try
            {
                string Email = UserProfileObj.GetEmail();
                object[] param =
                {
                    new MySqlParameter("@paramEmail", Email)
                };
                Commands.ExecuteQuery(Source, CommandType.StoredProcedure, param);
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
