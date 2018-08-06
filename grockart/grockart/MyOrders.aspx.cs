using System;
using Grockart.BUSINESSLAYER;
using Grockart.STORAGE;
using Grockart.CUSTOM_RESPONSE_CLASSES;
using Grockart.LOGGER;

public partial class MyOrders : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // check whether user is logged in or not
        try
        {
            if (CookieProxy.Instance().HasKey("t") == false)
            {
                CookieProxy.Instance().SetValue("LoginMessage", "You need to login to view this page", DateTime.Now.AddSeconds(10));
                Response.Redirect("/Signout", false);
            }
            else
            {
                IUserProfile UserProfileObj = new UserProfile(CookieProxy.Instance().GetValue("t").ToString());
                if (new Security(UserProfileObj).AuthenticateUser() == false)
                {
                    CookieProxy.Instance().SetValue("LoginMessage", "Relogin required to proceed", DateTime.Now.AddSeconds(10));
                    Response.Redirect("/Signout", false);
                }
            }
        }
        catch (Exception ex)
        {
            Logger.Instance().Log(Warn.Instance(), ex);
            CookieProxy.Instance().SetValue("LoginMessage", "An error occured, this event has been logged", DateTime.Now.AddSeconds(10));
            Response.Redirect("/Signout");
        }
    }
}