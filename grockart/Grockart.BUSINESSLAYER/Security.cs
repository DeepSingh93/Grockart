using Grockart.LOGGER;
using Grockart.DATALAYER;
using System;
using System.Collections.Generic;

using Grockart.CUSTOM_RESPONSE_CLASSES;
using System.Data;

namespace Grockart.BUSINESSLAYER
{
    public class Security : ISecurity
    {
        private readonly IUserProfile UserProfileObj;
        private readonly SecurityDataLayer SecurityObjDataLayer;
        private readonly UserTemplate<IUserProfile> UserTemplate = new AdminUserTemplate();
        public Security(IUserProfile UserProfileObj)
        {
            this.UserProfileObj = UserTemplate.FetchParticularProfile(UserProfileObj);
            SecurityObjDataLayer = new SecurityDataLayer(UserProfileObj);
        }
        public bool AuthenticateAdmin()
        {
            try
            {
                if (UserProfileObj.GetIsAdmin() == false)
                {
                    Logger.Instance().Log(Warn.Instance(), new LogInfo(UserProfileObj.GetEmail().ToString() + " tried to access the admin panel but failed. "));
                }
                return UserProfileObj.GetIsAdmin();
            }
            catch (ArgumentException AEX)
            {
                Logger.Instance().Log(Warn.Instance(), new WarnDebug("Anonymous user tried to access the Admin panel, but failed"));
                throw AEX;
            }
            catch (NullReferenceException nex)
            {
                Logger.Instance().Log(Fatal.Instance(), new LogInfo("Unable to authenticate Admin, got exception : " + nex.Message.ToString()));
                throw nex;
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Fatal.Instance(), ex);
                throw ex;
            }
        }
        public bool AuthenticateUser()
        {
            try
            {
                if(new MaintenanceMode().IsMaintenanceModeEnabled() == APIResponse.OK)
                {
                    // maintenance mode : ALL AUTH DISABLED
                    return false;
                }
                DataSet Response = SecurityObjDataLayer.GetUserToken();
                if (Response == null || Response.Tables[0].Rows.Count == 0 || int.Parse(Response.Tables[0].Rows[0][0].ToString()) == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Fatal.Instance(), ex);
                throw ex;
            }
        }
        public List<string> GetTokenList()
        {
            try
            {
                List<string> Result = SecurityObjDataLayer.GetTokenList();
                return Result;
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Warn.Instance(), ex);
                throw ex;
            }
        }
        public void RemoveTokenFromDB()
        {
            SecurityObjDataLayer.RemoveToken();
        }
        public void AddTokenToDB()
        {
            SecurityObjDataLayer.AddTokenToDatabase();
        }
    }
}
