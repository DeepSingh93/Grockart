using Grockart.BUSINESSLAYER;
using Grockart.STORAGE;
using Grockart.CUSTOM_RESPONSE_CLASSES;
using Grockart.LOGGER;
using System;
using System.Web.Script.Serialization;

using System.Collections.Generic;

public partial class api_FetchUserList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        List<IUserProfile> UserList = null;
        try
        {
            UserProfile UserProfileObj = new UserProfile();
            UserProfileObj.SetToken(CookieProxy.Instance().GetValue("t").ToString());
            UserTemplate<IUserProfile> Profile = new NormalUserTemplate(UserProfileObj, Request.Form["s"]);
            UserList = Profile.FetchList();
            if (UserList == null)
            {
                CookieProxy.Instance().SetValue("LoginMessage", "Unable to authenticate the token, please relogin or check logs", DateTime.Now.AddDays(2));
            }
            Logger.Instance().Log(Info.Instance(), new LogInfo(new AdminUserTemplate().FetchParticularProfile(UserProfileObj).GetEmail() + " searched for user " + Request.Form["s"]));

        }
        catch (Exception ex)
        {
            CookieProxy.Instance().SetValue("LoginMessage", "An Error occured while processing the request, please check logs", DateTime.Now.AddDays(2));
            Logger.Instance().Log(Warn.Instance(), ex);
        }
        finally
        {
            Response.Write(new JavaScriptSerializer().Serialize(UserList));
        }

    }
}