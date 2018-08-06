using Grockart.BUSINESSLAYER;
using Grockart.CUSTOM_RESPONSE_CLASSES;
using Grockart.LOGGER;
using Grockart.STORAGE;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Settings : System.Web.UI.Page
{
    SettingsList ListOfSettings = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            // populate the maintenance mode settings
            ListOfSettings = new SettingsFromDB().FetchAllSettingsFromDB();
            PopulateAndSetMaintenanceMode();
            PopulateHomePageMode();
            txt_regex_password.Text = ReturnDBValue("REGEX_PASSWORD");
            txt_max_qty.Text = ReturnDBValue("MAX_QTY");
            txt_Maintenance_text.Text = ReturnDBValue("LOGIN_MAINTENANCE_MESSAGE");
            txt_regex_invalid_password_text.Text = ReturnDBValue("REGEX_PASSWORD_ERROR_TEXT");
            txt_regex_email.Text = ReturnDBValue("REGEX_EMAIL");
            txt_regex_postalcode.Text = ReturnDBValue("REGEX_POSTAL_CODE");
        }
    }

    private void PopulateHomePageMode()
    {
        try
        {
            // populate the dropdown values
            DropDownEnableHomePage.Items.Insert(0, new ListItem("Disabled", "0"));
            DropDownEnableHomePage.Items.Insert(1, new ListItem("Enabled", "1"));

            string MaintenanceValue = "0";
            // set the dropdown values
            foreach (Settings SettingObj in ListOfSettings.GetSettingsList())
            {
                if (SettingObj.GetSettingsKey() == "HOME_PAGE")
                {
                    MaintenanceValue = SettingObj.GetSettingsValue();
                    break;
                }
            }
            DropDownEnableHomePage.SelectedValue = MaintenanceValue;
            TextStatus.Visible = false;
            DropDownEnableHomePage.Visible = true;
        }
        catch (Exception ex)
        {
            Logger.Instance().Log(Warn.Instance(), ex);
            DropDownEnableHomePage.Visible = false;
            TextStatus.Visible = true;
            TextStatus.BackColor = System.Drawing.Color.FromArgb(Int32.Parse("FF6E6E", NumberStyles.HexNumber));
            TextStatus.ForeColor = System.Drawing.Color.White;
        }
    }

    private string ReturnDBValue(string Key)
    {
        string Value = "";
        foreach (Settings SettingObj in ListOfSettings.GetSettingsList())
        {
            if (SettingObj.GetSettingsKey() == Key)
            {
                return SettingObj.GetSettingsValue();
            }
        }
        return Value;
    }

    private void PopulateAndSetMaintenanceMode()
    {
        try
        {
            // populate the dropdown values
            dropdown_maintenance_mode.Items.Insert(0, new ListItem("Disabled", "0"));
            dropdown_maintenance_mode.Items.Insert(1, new ListItem("Enabled", "1"));

            string MaintenanceValue = "0";
            // set the dropdown values
            foreach (Settings SettingObj in ListOfSettings.GetSettingsList())
            {
                if (SettingObj.GetSettingsKey() == "MAINTENANCE")
                {
                    MaintenanceValue = SettingObj.GetSettingsValue();
                    break;
                }
            }
            dropdown_maintenance_mode.SelectedValue = MaintenanceValue;
            TextStatus.Visible = false;
            dropdown_maintenance_mode.Visible = true;
        }
        catch (Exception ex)
        {
            Logger.Instance().Log(Warn.Instance(), ex);
            dropdown_maintenance_mode.Visible = false;
            TextStatus.Visible = true;
            TextStatus.BackColor = System.Drawing.Color.FromArgb(Int32.Parse("FF6E6E", NumberStyles.HexNumber));
            TextStatus.ForeColor = System.Drawing.Color.White;
        }

    }

    protected void Btn_Update_maintenance_Click(object sender, EventArgs e)
    {
        try
        {
            new SettingsFromDB().UpdateSettingsFromDB(new Settings("MAINTENANCE", dropdown_maintenance_mode.SelectedValue.ToString()));
            TextStatus.Text = "UPDATED";
            TextStatus.BackColor = System.Drawing.Color.FromArgb(Int32.Parse("26A69A", NumberStyles.HexNumber));
            TextStatus.ForeColor = System.Drawing.Color.White;
            TextStatus.Visible = true;
            Logger.Instance().Log(Info.Instance(), new WarnDebug(new NormalUserTemplate().FetchParticularProfile(new UserProfile(CookieProxy.Instance().GetValue("t").ToString())).GetEmail() + " changed maintance mode to value : " + dropdown_maintenance_mode.SelectedValue.ToString()));
        }
        catch (Exception ex)
        {
            Logger.Instance().Log(Warn.Instance(), ex);
            TextStatus.Visible = true;
            TextStatus.Text = ex.Message.ToString();
            TextStatus.BackColor = System.Drawing.Color.FromArgb(Int32.Parse("FF6E6E", NumberStyles.HexNumber));
            TextStatus.ForeColor = System.Drawing.Color.White;
        }
    }



    protected void Btn_Update_maintenance_text_Click_Click(object sender, EventArgs e)
    {
        try
        {
            new SettingsFromDB().UpdateSettingsFromDB(new Settings("LOGIN_MAINTENANCE_MESSAGE", txt_Maintenance_text.Text.ToString()));
            TextStatus.Text = "UPDATED";
            TextStatus.BackColor = System.Drawing.Color.FromArgb(Int32.Parse("26A69A", NumberStyles.HexNumber));
            TextStatus.ForeColor = System.Drawing.Color.White;
            TextStatus.Visible = true;
            Logger.Instance().Log(Info.Instance(), new WarnDebug(new NormalUserTemplate().FetchParticularProfile(new UserProfile(CookieProxy.Instance().GetValue("t").ToString())).GetEmail() + " changed maintance login text to : " + txt_Maintenance_text.Text.ToString()));
        }
        catch (Exception ex)
        {
            Logger.Instance().Log(Warn.Instance(), ex);
            TextStatus.Visible = true;
            TextStatus.Text = ex.Message.ToString();
            TextStatus.BackColor = System.Drawing.Color.FromArgb(Int32.Parse("FF6E6E", NumberStyles.HexNumber));
            TextStatus.ForeColor = System.Drawing.Color.White;
        }
    }

    protected void Btn_max_qty_Click(object sender, EventArgs e)
    {
        try
        {
            int ParsedIntegerValue = 0;
            bool CheckIfInt = false;
            CheckIfInt = int.TryParse(txt_max_qty.Text.ToString(), out ParsedIntegerValue);
            if (CheckIfInt)
            {
                if (ParsedIntegerValue > 0)
                {
                    TextStatus.Text = "UPDATED";
                    TextStatus.BackColor = System.Drawing.Color.FromArgb(Int32.Parse("26A69A", NumberStyles.HexNumber));
                    TextStatus.ForeColor = System.Drawing.Color.White;
                    TextStatus.Visible = true;
                    new SettingsFromDB().UpdateSettingsFromDB(new Settings("MAX_QTY", ParsedIntegerValue.ToString()));
                    Logger.Instance().Log(Info.Instance(), new WarnDebug(new NormalUserTemplate().FetchParticularProfile(new UserProfile(CookieProxy.Instance().GetValue("t").ToString())).GetEmail() + " updated the maximum value of quantity to  : " + ParsedIntegerValue.ToString()));
                }
                else
                {
                    TextStatus.Text = "VALUE SHOULD BE GREATER THAN 0";
                    TextStatus.BackColor = System.Drawing.Color.FromArgb(Int32.Parse("FF6E6E", NumberStyles.HexNumber));
                    TextStatus.ForeColor = System.Drawing.Color.White;
                    TextStatus.Visible = true;
                }
            }
            else
            {
                TextStatus.Text = "VALUE IS NOT INTEGER";
                TextStatus.BackColor = System.Drawing.Color.FromArgb(Int32.Parse("FF6E6E", NumberStyles.HexNumber));
                TextStatus.ForeColor = System.Drawing.Color.White;
                TextStatus.Visible = true;
            }
        }
        catch (Exception ex)
        {
            TextStatus.Visible = true;
            TextStatus.Text = ex.Message.ToString();
            TextStatus.BackColor = System.Drawing.Color.FromArgb(Int32.Parse("FF6E6E", NumberStyles.HexNumber));
            TextStatus.ForeColor = System.Drawing.Color.White;
        }
    }

    protected void Update_Regex_Password_Click(object sender, EventArgs e)
    {
        try
        {
            TextStatus.Text = "UPDATED";
            TextStatus.BackColor = System.Drawing.Color.FromArgb(Int32.Parse("26A69A", NumberStyles.HexNumber));
            TextStatus.ForeColor = System.Drawing.Color.White;
            TextStatus.Visible = true;
            new SettingsFromDB().UpdateSettingsFromDB(new Settings("REGEX_PASSWORD", txt_regex_password.Text.ToString()));
            Logger.Instance().Log(Info.Instance(), new WarnDebug(new NormalUserTemplate().FetchParticularProfile(new UserProfile(CookieProxy.Instance().GetValue("t").ToString())).GetEmail() + " updated REGEX Password to  : " + txt_regex_password.Text.ToString()));

        }
        catch (Exception ex)
        {
            TextStatus.Visible = true;
            TextStatus.Text = ex.Message.ToString();
            TextStatus.BackColor = System.Drawing.Color.FromArgb(Int32.Parse("FF6E6E", NumberStyles.HexNumber));
            TextStatus.ForeColor = System.Drawing.Color.White;
        }
    }

    protected void Btn_update_txt_Regex_invalid_password_Click(object sender, EventArgs e)
    {
        try
        {
            TextStatus.Text = "UPDATED";
            TextStatus.BackColor = System.Drawing.Color.FromArgb(Int32.Parse("26A69A", NumberStyles.HexNumber));
            TextStatus.ForeColor = System.Drawing.Color.White;
            TextStatus.Visible = true;
            new SettingsFromDB().UpdateSettingsFromDB(new Settings("REGEX_PASSWORD_ERROR_TEXT", txt_regex_invalid_password_text.Text.ToString()));
            Logger.Instance().Log(Info.Instance(), new WarnDebug(new NormalUserTemplate().FetchParticularProfile(new UserProfile(CookieProxy.Instance().GetValue("t").ToString())).GetEmail() + " updated REGEX Password Error Text to  : " + txt_regex_invalid_password_text.Text.ToString()));
        }
        catch (Exception ex)
        {
            TextStatus.Visible = true;
            TextStatus.Text = ex.Message.ToString();
            TextStatus.BackColor = System.Drawing.Color.FromArgb(Int32.Parse("FF6E6E", NumberStyles.HexNumber));
            TextStatus.ForeColor = System.Drawing.Color.White;
        }
    }

    protected void Btn_update_regex_email_Click(object sender, EventArgs e)
    {
        try
        {
            TextStatus.Text = "UPDATED";
            TextStatus.BackColor = System.Drawing.Color.FromArgb(Int32.Parse("26A69A", NumberStyles.HexNumber));
            TextStatus.ForeColor = System.Drawing.Color.White;
            TextStatus.Visible = true;
            new SettingsFromDB().UpdateSettingsFromDB(new Settings("REGEX_EMAIL", txt_regex_invalid_password_text.Text.ToString()));
            Logger.Instance().Log(Info.Instance(), new WarnDebug(new NormalUserTemplate().FetchParticularProfile(new UserProfile(CookieProxy.Instance().GetValue("t").ToString())).GetEmail() + " updated REGEX Email to  : " + txt_regex_invalid_password_text.Text.ToString()));
        }
        catch (Exception ex)
        {
            TextStatus.Visible = true;
            TextStatus.Text = ex.Message.ToString();
            TextStatus.BackColor = System.Drawing.Color.FromArgb(Int32.Parse("FF6E6E", NumberStyles.HexNumber));
            TextStatus.ForeColor = System.Drawing.Color.White;
        }
    }

    protected void Btn_Update_Home_Page_Click(object sender, EventArgs e)
    {
        try
        {
            TextStatus.Text = "UPDATED";
            TextStatus.BackColor = System.Drawing.Color.FromArgb(Int32.Parse("26A69A", NumberStyles.HexNumber));
            TextStatus.ForeColor = System.Drawing.Color.White;
            TextStatus.Visible = true;
            new SettingsFromDB().UpdateSettingsFromDB(new Settings("HOME_PAGE", DropDownEnableHomePage.Text.ToString()));
            Logger.Instance().Log(Info.Instance(), new WarnDebug(new NormalUserTemplate().FetchParticularProfile(new UserProfile(CookieProxy.Instance().GetValue("t").ToString())).GetEmail() + " updated HOME Page value to  : " + DropDownEnableHomePage.Text.ToString()));
        }
        catch (Exception ex)
        {
            TextStatus.Visible = true;
            TextStatus.Text = ex.Message.ToString();
            TextStatus.BackColor = System.Drawing.Color.FromArgb(Int32.Parse("FF6E6E", NumberStyles.HexNumber));
            TextStatus.ForeColor = System.Drawing.Color.White;
        }
    }

    protected void Btn_update_regex_postalcode_Click(object sender, EventArgs e)
    {
        try
        {
            TextStatus.Text = "UPDATED";
            TextStatus.BackColor = System.Drawing.Color.FromArgb(Int32.Parse("26A69A", NumberStyles.HexNumber));
            TextStatus.ForeColor = System.Drawing.Color.White;
            TextStatus.Visible = true;
            new SettingsFromDB().UpdateSettingsFromDB(new Settings("REGEX_POSTAL_CODE", txt_regex_postalcode.Text.ToString()));
            Logger.Instance().Log(Info.Instance(), new WarnDebug(new NormalUserTemplate().FetchParticularProfile(new UserProfile(CookieProxy.Instance().GetValue("t").ToString())).GetEmail() + " updated HOME Page value to  : " + DropDownEnableHomePage.Text.ToString()));
        }
        catch (Exception ex)
        {
            TextStatus.Visible = true;
            TextStatus.Text = ex.Message.ToString();
            TextStatus.BackColor = System.Drawing.Color.FromArgb(Int32.Parse("FF6E6E", NumberStyles.HexNumber));
            TextStatus.ForeColor = System.Drawing.Color.White;
        }
    }
}