using Grockart.BUSINESSLAYER;
using Grockart.CUSTOM_RESPONSE_CLASSES;
using Grockart.STORAGE;
using System;
using System.Collections.Generic;
using System.Web.UI;
using Grockart.LOGGER;


public partial class Register : System.Web.UI.Page
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
            if (SessionProxy.Instance().GetValue("USER.AUTHENTICATED") != null)
            {
                Response.Redirect("/Login");
            }
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
            UserTemplate<IUserProfile> NormalUserTemplate = new NormalUserTemplate(UserProfileObj);
            APIResponse response = NormalUserTemplate.Add();
            if (response == APIResponse.OK)
            {
                // get the token
                List<string> Token = new Security(UserProfileObj).GetTokenList();
                string sToken = Token[Token.Count - 1].ToString();
                CookieProxy.Instance().SetValue("t", sToken, DateTime.Now.AddYears(1));
                Response.Redirect("/Products");
            }
            else
            {
                SetWarningLabel("Email already exists, please register with different email");
            }
        }
        catch (MySql.Data.MySqlClient.MySqlException mse)
        {
            if (mse.Number == 1062)
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