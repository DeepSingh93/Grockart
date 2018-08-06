using Grockart.BUSINESSLAYER;
using Grockart.CUSTOM_RESPONSE_CLASSES;
using Grockart.LOGGER;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Script.Serialization;
using System.Web.UI;
using Grockart.STORAGE;

public partial class main : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //get the database version
            try
            {
                string DBVersionString = DBVersion.GetDBVersion;

                if (new MaintenanceMode().IsMaintenanceModeEnabled() == APIResponse.OK)
                {
                    if (Page.TemplateControl.AppRelativeVirtualPath != "~/Login.aspx")
                    {
                        CookieProxy.Instance().SetValue("LoginMessage", new SettingsFromDB().FetchSettingsFromDB(new Settings("LOGIN_MAINTENANCE_MESSAGE")).GetSettingsValue(), DateTime.Now.AddDays(2));
                        Response.Redirect("/signout.aspx?r=/Login", false);
                    }
                }

                // here t is the token (if the user has logged in once from this browser)
                UserProfile UserProfileObj = new UserProfile();
                if (CookieProxy.Instance().HasKey("t"))
                {
                    UserProfileObj.SetToken(CookieProxy.Instance().GetValue("t").ToString());
                    bool response = new Security(UserProfileObj).AuthenticateUser();
                    if (response == true)
                    {
                        loginLabel.Visible = false;
                        registerLabel.Visible = false;
                        userProfile.Visible = true;
                        UserTemplate<IUserProfile> Template = new NormalUserTemplate();
                        userName.Text = Template.FetchParticularProfile(UserProfileObj).GetFirstName();
                    }
                    else
                    {
                        // remove the cookie
                        CookieProxy.Instance().RemoveKey("t");
                        loginLabel.Visible = true;
                        registerLabel.Visible = true;
                        userProfile.Visible = false;
                    }
                    SessionProxy.Instance().SetValue("USER.AUTHENTICATED", response, DateTime.Now);
                }
                // load the menu
                LoadMasterMenu();
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Fatal.Instance(), ex);
                Response.Redirect("~/ErrorPages/Error.aspx?e=500", true);
            }
        }
    }

    private void LoadMasterMenu()
    {
        string serializedMenu = Menu.FetchSerializedProductMenu();
        ScriptManager.RegisterStartupScript(Page, typeof(Page), "LoadMasterMenu", "LoadMenu('" + serializedMenu + "')", true);
    }
}
