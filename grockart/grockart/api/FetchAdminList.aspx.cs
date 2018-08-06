using System;
using Grockart.BUSINESSLAYER;
using Grockart.CUSTOM_RESPONSE_CLASSES;
using System.Web.Script.Serialization;
using Grockart.STORAGE;
using Grockart.LOGGER;

using System.Collections.Generic;

public partial class api_FetchAdminList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        List<IUserProfile> FetchAdminList = null;
        try
        {
            UserProfile UserProfileObj = new UserProfile();
            UserProfileObj.SetToken(CookieProxy.Instance().GetValue("t").ToString());
            UserTemplate<IUserProfile> Profile = new AdminUserTemplate(UserProfileObj);
            FetchAdminList = Profile.FetchList();
            if(FetchAdminList == null)
            {
                CookieProxy.Instance().SetValue("LoginMessage", "Unable to authenticate the token, please relogin or check logs", DateTime.Now.AddDays(2));
            }
            Logger.Instance().Log(Info.Instance(), new LogInfo(new AdminUserTemplate().FetchParticularProfile(UserProfileObj).GetEmail()+ " fetched admin list "));
        }
        catch (Exception ex)
        {
            Logger.Instance().Log(Fatal.Instance(), ex);
        }
        finally
        {
            Response.Write(new JavaScriptSerializer().Serialize(FetchAdminList));
        }
    }
}