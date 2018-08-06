using System;
using Grockart.BUSINESSLAYER;

using Grockart.CUSTOM_RESPONSE_CLASSES;
using Grockart.LOGGER;
using Grockart.STORAGE;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FetchRegexFromDB();
        }
    }
    private void FetchRegexFromDB()
    {
        try
        {
            REGEX_EMAIL.Value = new SettingsFromDB().FetchSettingsFromDB(new Settings(SettingsKey: "REGEX_EMAIL")).GetSettingsValue();
            REGEX_PASSWORD.Value = new SettingsFromDB().FetchSettingsFromDB(new Settings(SettingsKey: "REGEX_PASSWORD")).GetSettingsValue();
            REGEX_PASSWORD_ERROR_TEXT.Value = new SettingsFromDB().FetchSettingsFromDB(new Settings(SettingsKey: "REGEX_PASSWORD_ERROR_TEXT")).GetSettingsValue();
        }
        catch (Exception ex)
        {
            // error occured, cannot register
            // redirect to error page
            Logger.Instance().Log(Fatal.Instance(), new LogInfo("FATAL ERROR WHILE FETCHING REGEX ! LOGIN AND REGISTRATION BLOCKED"));
            Logger.Instance().Log(Fatal.Instance(), ex);
            Response.Redirect("~/ErrorPages/Error.aspx?e=600");
        }
    }
    protected override void OnLoadComplete(EventArgs e)
    {
        base.OnLoadComplete(e);
        if (!Page.IsPostBack)
        {
            if (SessionProxy.Instance().HasKey("USER.AUTHENTICATED"))
            {
                if (CookieProxy.Instance().HasKey("t"))
                {
                    if ((bool)SessionProxy.Instance().GetValue("USER.AUTHENTICATED") == true)
                    {
                        // check if there is any redirect on querystring
                        if (Request.QueryString["r"] != null)
                        {
                            SessionProxy.Instance().SetValue("InternalRedirect", Request.QueryString["r"], DateTime.Now.AddSeconds(10));
                            Response.Redirect("/InternalRedirect");
                        }
                        Response.Redirect("/Products");
                    }
                }
                else
                {
                    Response.Redirect("/Signout");
                }
            }
        }

        // check if there is any loginmessage cookie
        if (CookieProxy.Instance().HasKey("LoginMessage"))
        {
            LoginMessage.InnerText = CookieProxy.Instance().GetValue("LoginMessage").ToString();
            LoginMessage.Visible = true;

            // remove this key
            CookieProxy.Instance().RemoveKey("LoginMessage");
        }
    }

    protected void Login_Click(object sender, EventArgs e)
    {
        try
        {
            // get the email and password
            string _Email = Email.Value;
            string _Password = password.Value;

            UserProfile UserProfileObj = new UserProfile();
            UserProfileObj.SetEmail(_Email);
            UserProfileObj.SetPassword(_Password);

            // now authenticate 
            LoginUserReponse response = new UserActions().LoginUserAction(UserProfileObj);

            if (response.GetIsLoggedIn())
            {
                // set authentication cookies and redirect
                CookieProxy.Instance().SetValue("t", response.GetToken(), DateTime.Now.AddYears(1));

                // check the maintenance mode
                if(new MaintenanceMode().IsMaintenanceModeEnabled() == APIResponse.OK)
                {
                    // maintenance mode enabled, check if admin
                    UserProfileObj.SetToken(response.GetToken());
                    if(new AdminUserTemplate().FetchParticularProfile(UserProfileObj).GetIsAdmin() == true)
                    {
                        Response.Redirect("/admin-settings", true);
                    }
                }

                // check if there is any redirect on querystring
                if (Request.QueryString["r"] != null)
                {
                    CookieProxy.Instance().SetValue("InternalRedirect", Request.QueryString["r"], DateTime.Now.AddSeconds(10));
                    Response.Redirect("/InternalRedirect");
                }

                Response.Redirect("/Products");
            }
            else
            {
                SetWarningLabel(response.GetErrorText());
            }
        }
        catch (Exception)
        {
            SetWarningLabel("Unable to login to the system, this event has been logged");
        }

    }

    private void SetWarningLabel(string validationText)
    {
        LoginMessage.InnerText = validationText;
        LoginMessage.Visible = true;
    }
}