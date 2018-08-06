using System;
using System.Web.Script.Serialization;
using Grockart.BUSINESSLAYER;
using Grockart.CUSTOM_RESPONSE_CLASSES;
using Grockart.STORAGE;

public partial class api_UserProfile : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        IUserProfile UserProfileObj = new UserProfile();
        UserProfileMenuResponse ProfileMenu = new UserProfileMenuResponse();
        try
        {
            ProfileMenu.IsProfileAvailable = false;
            if (CookieProxy.Instance().HasKey("t"))
            {
                UserProfileObj.SetToken(CookieProxy.Instance().GetValue("t").ToString());
                if (CookieProxy.Instance().HasKey("um"))
                {
                    ProfileMenu = new UserActions(UserProfileObj).GetProfileMenu(CookieProxy.Instance().GetValue("um").ToString());
                }
                else
                {
                    ProfileMenu = new UserActions(UserProfileObj).GetProfileMenu(null);

                }
                if (ProfileMenu.ShouldReupdate)
                {
                    RemoveProfileCookie();
                    ProfileMenu = new UserActions(null).GetProfileMenu(null);
                }
                CookieProxy.Instance().SetValue("um", new JavaScriptSerializer().Serialize(ProfileMenu), DateTime.Now.AddDays(2));
            }
        }
        catch (Exception ex)
        {
            ProfileMenu.IsProfileAvailable = false;
        }

        Response.Write(new JavaScriptSerializer().Serialize(ProfileMenu));
    }

    private void RemoveProfileCookie()
    {
        CookieProxy.Instance().RemoveKey("um");
    }
}