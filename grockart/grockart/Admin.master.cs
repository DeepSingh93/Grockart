using System;
using Grockart.BUSINESSLAYER;
using Grockart.STORAGE;
using Grockart.CUSTOM_RESPONSE_CLASSES;
using Grockart.LOGGER;
public partial class Admin : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            UserProfile UserProfileObj = new UserProfile();
            if (CookieProxy.Instance().HasKey("t"))
            {
                UserProfileObj.SetToken(CookieProxy.Instance().GetValue("t").ToString());
                // check if the current user is admin or not
                bool AuthAdminResponseObj = new Security(UserProfileObj).AuthenticateAdmin();
                if (AuthAdminResponseObj == false)
                {
                    CookieProxy.Instance().SetValue("LoginMessage", "Not Authorized, please login with correct credentials".ToString(), DateTime.Now.AddDays(2));
                    Response.Redirect("/signout.aspx", false);
                }
                else
                {
                    UserTemplate<IUserProfile> Template = new AdminUserTemplate();
                    userName.Text = Template.FetchParticularProfile(UserProfileObj).GetFirstName();
                }
            }
            else
            {
                Logger.Instance().Log(Warn.Instance(), new LogDebug("An attempt was made to access the admin panel but failed."));
                CookieProxy.Instance().SetValue("LoginMessage", "Not Authorized, please login with correct credentials".ToString(), DateTime.Now.AddDays(2));
                Response.Redirect("/signout.aspx", false);
            }
        }
        catch (NullReferenceException)
        {
            Logger.Instance().Log(Warn.Instance(), new LogDebug("Unable to authenticate the token, token invalid or not found"));
            CookieProxy.Instance().SetValue("LoginMessage", "Unable to authenticate, please login with correct credentails.".ToString(), DateTime.Now.AddDays(2));
            Response.Redirect("/signout.aspx", false);
        }
        catch (Exception ex)
        {
            Logger.Instance().Log(Warn.Instance(), ex);
            if (CookieProxy.Instance().HasKey("LoginMessage") == false)
            {
                CookieProxy.Instance().SetValue("LoginMessage", "An error occured while authenticating, this event has been logged".ToString(), DateTime.Now.AddDays(2));
            }
            Response.Redirect("/signout.aspx");
        }
    }
}
