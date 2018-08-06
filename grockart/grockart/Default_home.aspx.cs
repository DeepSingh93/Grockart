using System;
using System.Collections.Generic;
using Grockart.BUSINESSLAYER;

using Grockart.CUSTOM_RESPONSE_CLASSES;
using Grockart.LOGGER;
using Grockart.STORAGE;
using MySql.Data.MySqlClient;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if(new SettingsFromDB().FetchSettingsFromDB(new Settings(SettingsKey: "HOME_PAGE")).GetSettingsValue() == "0")
            {
                // home page is disabled from configurable business logic, redirect to product page
                Response.Redirect("/Products", false);
            }
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
                Response.Redirect("/Login");
            }
            Logger.Instance().Log(Debug.Instance(), new LogDebug("A debug text"));
        }
    }

    protected void RegisterButton_Click(object sender, EventArgs e)
    {
        string FirstName = firstName.Value;
        string LastName = lastName.Value;
        string Email = email.Value;
        string Password = password.Value;
        // now get all the parameters via post
        try
        {
            UserProfile UserProfileObj = new UserProfile();
            UserProfileObj.SetFirstName(FirstName);
            UserProfileObj.SetLastName(LastName);
            UserProfileObj.SetEmail(Email);
            UserProfileObj.SetPassword(Password);
            UserProfileObj.SetRoleType("NORMAL");
            UserTemplate<IUserProfile> UserObj = new NormalUserTemplate(UserProfileObj);
            UserObj.Add();
            // get the token
            List<string> Token = new Security(UserProfileObj).GetTokenList();
            string sToken = Token[Token.Count - 1].ToString();
            CookieProxy.Instance().SetValue("t", sToken, DateTime.Now.AddYears(1));
            Response.Redirect("/Products");
        }
        catch (MySqlException mse)
        {
            if(mse.Number == 1062)
            {
                SetWarningLabel("Email already exists, please register with different email");
            }
            else
            {
                SetWarningLabel("An error occured while connecting to tthe DB, this event has been logged");
            }
        }
        catch (Exception)
        {
            SetWarningLabel("An error occured, please try again later<br> This event has been logged");
            registerButton.Visible = false;
        }
    }

    private void SetWarningLabel(string errorText)
    {
        string classValues = validationIssuesBox.Attributes["Class"];
        classValues = classValues.Replace("hideElement", "");
        validationIssuesBox.Attributes["Class"] = classValues;
        validationIssuesBox.InnerHtml = errorText;
    }

}

