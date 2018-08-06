using System;
using Grockart.BUSINESSLAYER;
using Grockart.CUSTOM_RESPONSE_CLASSES;
using Grockart.STORAGE;
using Grockart.LOGGER;
using System.Web.Script.Serialization;


public partial class api_RemoveAdmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ApiAuthResponse AuthResponseObj = new ApiAuthResponse();
        try
        {
            UserProfile UserProfileObj = new UserProfile(Token: CookieProxy.Instance().GetValue("t").ToString(), Email: Request.Form["e"].ToString());
            UserTemplate<IUserProfile> Profile = new AdminUserTemplate(UserProfileObj);
            APIResponse Response = Profile.Remove();
            AuthResponseObj.SetAPIResponse(Response);
            if (Response == APIResponse.NOT_AUTHENTICATED)
            {
                CookieProxy.Instance().SetValue("LoginMessage", "Unable to authenticate the token, please relogin or relogin", DateTime.Now.AddDays(2));
            }

            if (AuthResponseObj.GetAPIResponse() == APIResponse.OK)
            {
                // log the event
                Logger.Instance().Log(Info.Instance(), new LogInfo(new AdminUserTemplate().FetchParticularProfile(UserProfileObj).GetEmail() + " removed " + Request.Form["e"]));
            }
        }
        catch (Exception ex)
        {
            Logger.Instance().Log(Info.Instance(), ex);
        }
        finally
        {
            Response.Write(new JavaScriptSerializer().Serialize(AuthResponseObj));
        }

    }
}