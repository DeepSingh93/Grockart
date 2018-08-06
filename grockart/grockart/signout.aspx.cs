using Grockart.BUSINESSLAYER;
using System;
using Grockart.STORAGE;
using Grockart.CUSTOM_RESPONSE_CLASSES;
using Grockart.LOGGER;

public partial class signout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string LoginMessage = "";
        
        try
        {
            if (CookieProxy.Instance().HasKey("LoginMessage"))
            {
                LoginMessage = CookieProxy.Instance().GetValue("LoginMessage").ToString();
            }
            // remove the session
            SessionProxy.Instance().RemoveKey("USER.AUTHENTICATED");

            // remove the cookies
            CookieProxy.Instance().RemoveKey("t");
            CookieProxy.Instance().RemoveKey("um");

            // redirect to login
            if (Request.QueryString["r"] != null)
            {
                // set the redirect cookie
                CookieProxy.Instance().SetValue("InternalRedirect", Request.QueryString["r"], DateTime.Now.AddSeconds(10));
                Response.Redirect("/InternalRedirect");
            }
            UserProfile UserProfileObj = new UserProfile();
            if (CookieProxy.Instance().HasKey("t"))
            {
                UserProfileObj.SetToken(CookieProxy.Instance().GetValue("t").ToString());
                new Security(UserProfileObj).RemoveTokenFromDB();
            }
        }
        catch (Exception ex)
        {
            Logger.Instance().Log(Warn.Instance(), ex);
        }
        finally
        {
            if(LoginMessage != "")
            {
                CookieProxy.Instance().SetValue("LoginMessage", LoginMessage, DateTime.Now.AddDays(2));
            }
        }
        Response.Redirect("/login");
    }
}