using System;
using System.Text.RegularExpressions;
using Grockart.DATALAYER;
using Grockart.CRYPTOGRAPHY;
using Grockart.CUSTOM_RESPONSE_CLASSES;
using System.Collections.Generic;
using Grockart.LOGGER;
using System.Data;

using MySql.Data.MySqlClient;
using System.Web.Script.Serialization;

namespace Grockart.BUSINESSLAYER
{
    public class UserActions
    {
        private readonly IUserProfile UserProfileObj;
        public UserActions()
        {

        }
        public UserActions(IUserProfile UserProfileObj)
        {
            this.UserProfileObj = UserProfileObj;
        }
        public LoginUserReponse LoginUserAction(IUserProfile UserProfileObj)
        {
            bool IsLoggedIn = false;
            string Email = UserProfileObj.GetEmail();
            string Password = UserProfileObj.GetPassword();
            string Token = "";
            string ErrorText = "";
            string DbSalt = "";
            string DbHashPassword = "";
            string HashPassword = "";
            try
            {
                DataSet output = new UserActionsDataLayer(UserProfileObj).GetHashedPassword();
                if (output.Tables[0].Rows.Count > 0)
                {
                    DbSalt = output.Tables[0].Rows[0]["salt"].ToString();
                    DbHashPassword = output.Tables[0].Rows[0]["password"].ToString();
                    HashPassword = SHA256.Instance().hash(Password + DbSalt);
                    if (DbHashPassword == HashPassword)
                    {
                        Token = SHA256.Instance().hash(Email + Password + DateTime.Now.ToString());
                        // create a long token
                        Token += SHA256.Instance().hash(Email + Password + DateTime.Now.AddSeconds(200).ToString());
                        UserProfileObj.SetToken(Token);
                        // update the token value to database so as to authenticate the user for all events
                        new Security(UserProfileObj).AddTokenToDB();
                        IsLoggedIn = true;
                    }
                    else
                    {
                        IsLoggedIn = false;
                        Logger.Instance().Log(Warn.Instance(), new WarnDebug("Authentication failed for email : " + Email.ToString()));
                        ErrorText = "Invalid Email ID and password combination";
                    }
                }
                else
                {
                    IsLoggedIn = false;
                    ErrorText = "Invalid Email ID and password combination";
                }
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Fatal.Instance(), ex);
                IsLoggedIn = false;
                ErrorText = "Unable to login to the system, please try again later. This event has been logged";
                throw ex;
            }
            LoginUserReponse LoginResponse = new LoginUserReponse();
            LoginResponse.SetIsLoggedIn(IsLoggedIn);
            LoginResponse.SetErrorText(ErrorText);
            LoginResponse.SetToken(Token);
            return LoginResponse;

        }
        public APIResponse RecoverPasswordAction()
        {
            string Email = UserProfileObj.GetEmail();
            try
            {
                string FPToken = SHA256.Instance().GetUniqueKey(100);
                APIResponse ApiResponseObj = new UserActions(UserProfileObj).RecoverPasswordAction();
                if (ApiResponseObj == APIResponse.OK)
                {
                    // send the mail
                }
                return APIResponse.OK;
            }
            catch (MySqlException mse)
            {
                Logger.Instance().Log(Warn.Instance(), mse);
                throw mse;
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Warn.Instance(), ex);
                throw ex;
            }
        }
        public UserProfileMenuResponse GetProfileMenu(string CookieMenu)
        {
            UserProfileMenuResponse ProfileMenu = new UserProfileMenuResponse();
            bool ShouldFetchProfileFromServer = false;
            string Token = UserProfileObj.GetToken();
            try
            {
                // check if token exists
                if (Token == null)
                {
                    ProfileMenu.IsProfileAvailable = false;
                    return ProfileMenu;
                }
                else
                {
                    bool response = new Security(UserProfileObj).AuthenticateUser();
                    if (response == false)
                    {
                        ProfileMenu.IsProfileAvailable = false;
                        return ProfileMenu;
                    }
                    else
                    {
                        if (CookieMenu == null)
                        {
                            ShouldFetchProfileFromServer = true;
                        }
                        else
                        {
                            ProfileMenu = new JavaScriptSerializer().Deserialize<UserProfileMenuResponse>(CookieMenu);
                            if (ProfileMenu.IsProfileAvailable == false)
                            {
                                ShouldFetchProfileFromServer = true;
                            }
                        }
                    }
                }
                // get the profile menu
                if (CookieMenu == null)
                {
                    ShouldFetchProfileFromServer = true;
                }
                else
                {
                    ProfileMenu = new JavaScriptSerializer().Deserialize<UserProfileMenuResponse>(CookieMenu);
                    if (ProfileMenu.ShouldReupdate)
                    {
                        ShouldFetchProfileFromServer = true;
                    }
                }
                if (ShouldFetchProfileFromServer)
                {
                    ProfileMenu.SetUserProfile(new NormalUserTemplate(UserProfileObj).FetchParticularProfile(UserProfileObj));
                    ProfileMenu.IsProfileAvailable = true;
                }
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Fatal.Instance(), ex);
                ProfileMenu.IsProfileAvailable = false;
                throw ex;
            }

            return ProfileMenu;
        }

    }
}