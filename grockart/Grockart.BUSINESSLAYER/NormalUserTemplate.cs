using Grockart.CUSTOM_RESPONSE_CLASSES;
using System;
using System.Text.RegularExpressions;
using Grockart.DATALAYER;
using Grockart.CRYPTOGRAPHY;
using System.Collections.Generic;
using Grockart.LOGGER;
using System.Data;
using MySql.Data.MySqlClient;

namespace Grockart.BUSINESSLAYER
{
    public class NormalUserTemplate : UserTemplate<IUserProfile>
    {
        private readonly IUserProfile UserProfileObj;
        private DATALAYER.UserTemplate<IUserProfile> UserDataLayerTemplate;
        private string Query;
        public NormalUserTemplate(IUserProfile UserProfileObj, string Query)
        {
            this.UserProfileObj = UserProfileObj;
            this.Query = Query;
           
        }
        public NormalUserTemplate(IUserProfile UserProfileObj)
        {
            this.UserProfileObj = UserProfileObj;
        }


        public NormalUserTemplate()
        {
        }

        public override APIResponse Add()
        {
            try
            {
                string Salt = SHA256.Instance().GetUniqueKey(255);
                string EmailRegex = new ConfigurableBusinessLogic().FetchSettingsFromDB(new Settings(SettingsKey: "REGEX_EMAIL")).GetSettingsValue();
                string PasswordRegex = new ConfigurableBusinessLogic().FetchSettingsFromDB(new Settings(SettingsKey: "REGEX_PASSWORD")).GetSettingsValue();
                Regex rEmail = new Regex(@EmailRegex);
                Regex rPassword = new Regex(@PasswordRegex);
                if (rEmail.IsMatch(UserProfileObj.GetEmail()) == false)
                {
                    throw new ArgumentException("Invalid Argument : Invalid Email format");
                }
                if (rPassword.IsMatch(UserProfileObj.GetPassword()) == false)
                {
                    throw new ArgumentException("Invalid Argument : Invalid Password");
                }
                UserProfileObj.SetSalt(Salt);
                UserProfileObj.SetHashedPassword(SHA256.Instance().hash(UserProfileObj.GetPassword() + UserProfileObj.GetSalt()));
                UserProfileObj.SetToken(SHA256.Instance().hash(UserProfileObj.GetEmail() + UserProfileObj.GetPassword() + DateTime.Now.ToString()));
                UserDataLayerTemplate = new DATALAYER.NormalUserTemplate(UserProfileObj);
                return UserDataLayerTemplate.Add();
            }
            catch (MySqlException mse)
            {
                Logger.Instance().Log(Info.Instance(), mse);
                throw mse;
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Fatal.Instance(), ex);
                throw ex;
            }
        }
        public override List<IUserProfile> FetchList()
        {
            try
            {
                bool AResponse = new Security(UserProfileObj).AuthenticateUser();
                if (AResponse == true)
                {
                    // replacing the spaces of the query with | (used for REGEXP in MySQL)
                    Query = Query.Replace(' ', '|');
                    UserDataLayerTemplate = new DATALAYER.NormalUserTemplate(UserProfileObj, Query);
                    List<IUserProfile> profiles = UserDataLayerTemplate.FetchList();
                    return profiles;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Fatal.Instance(), ex);
                throw ex;
            }
        }
        public override APIResponse Remove()
        {
            try
            {
                bool AResponse = new Security(UserProfileObj).AuthenticateUser();
                if (AResponse == true)
                {
                    UserDataLayerTemplate = new DATALAYER.NormalUserTemplate(UserProfileObj);
                    return UserDataLayerTemplate.Remove();
                }
                else
                {
                    return APIResponse.NOT_AUTHENTICATED;
                }
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Fatal.Instance(), ex);
                throw ex;
            }
            
        }
    }
}
