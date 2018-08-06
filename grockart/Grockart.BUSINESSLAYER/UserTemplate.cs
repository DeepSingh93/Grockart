using Grockart.CUSTOM_RESPONSE_CLASSES;
using Grockart.LOGGER;
using System;
using System.Collections.Generic;
using System.Data;

namespace Grockart.BUSINESSLAYER
{
    public abstract class UserTemplate<T>
    {
        public abstract List<T> FetchList();
        public abstract APIResponse Remove();
        public abstract APIResponse Add();
        public IUserProfile FetchParticularProfile(IUserProfile UserProfileObj)
        {
            try
            {
                string Token = UserProfileObj.GetToken();
                DATALAYER.UserTemplate<IUserProfile> UserDataLayerTemplate = new DATALAYER.NormalUserTemplate(UserProfileObj);
                DataSet output = UserDataLayerTemplate.FetchProfile(UserProfileObj);
                if (output.Tables[0].Rows.Count > 0)
                {
                    UserProfile profile = new UserProfile();
                    profile.SetFirstName(output.Tables[0].Rows[0]["firstname"].ToString());
                    profile.SetLastName(output.Tables[0].Rows[0]["lastname"].ToString());
                    profile.SetEmail(output.Tables[0].Rows[0]["email"].ToString());
                    profile.SetIsAdmin(output.Tables[0].Rows[0]["roleName"].ToString() == "ADMIN" ? true : false);
                    profile.SetAmountOwe(0);
                    profile.SetAmountPaid(0);
                    profile.SetToken(Token);
                    return profile;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                // log the exception
                Logger.Instance().Log(Fatal.Instance(), ex);
                throw ex;
            }
        }
    }
}
