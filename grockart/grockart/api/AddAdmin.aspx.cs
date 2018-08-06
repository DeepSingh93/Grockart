using Grockart.BUSINESSLAYER;
using Grockart.STORAGE;
using Grockart.CUSTOM_RESPONSE_CLASSES;
using Grockart.LOGGER;
using System;
using System.Web.Script.Serialization;


public partial class api_AddAdmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ApiAuthResponse AuthResponseObj = new ApiAuthResponse();
        try
        {
            UserProfile UserProfileObj = new UserProfile(Token: CookieProxy.Instance().GetValue("t").ToString(), Email: Request.Form["e"].ToString());
            UserTemplate<IUserProfile> Profile = new AdminUserTemplate(UserProfileObj);
            APIResponse ResponseObj = Profile.Add();
            AuthResponseObj.SetAPIResponse(ResponseObj);
            if (ResponseObj == APIResponse.OK)
            {
                // log the event
                Logger.Instance().Log(Info.Instance(), new LogInfo(Profile.FetchParticularProfile(UserProfileObj).GetEmail() + " added " + Request.Form["e"]));
            }
        }
        catch (Exception ex)
        {
            AuthResponseObj.SetAPIResponse(APIResponse.NOT_OK);
            Logger.Instance().Log(Fatal.Instance(), ex);
        }
        Response.Write(new JavaScriptSerializer().Serialize(AuthResponseObj));

    }
}