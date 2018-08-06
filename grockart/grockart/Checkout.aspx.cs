using System;
using Grockart.BUSINESSLAYER;
using Grockart.STORAGE;
using Grockart.CUSTOM_RESPONSE_CLASSES;
using Grockart.LOGGER;
using System.Collections.Generic;

public partial class Checkout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                PopulateProvinceList();
                PopulateRegex();
            }
            if (CookieProxy.Instance().HasKey("t") == false)
            {
                CookieProxy.Instance().SetValue("LoginMessage", "You need to login to view this page", DateTime.Now.AddSeconds(10));
                Response.Redirect("/login?r=/checkout", false);
            }
            else
            {
                IUserProfile UserProfileObj = new UserProfile(CookieProxy.Instance().GetValue("t").ToString());
                if (new Security(UserProfileObj).AuthenticateUser() == false)
                {
                    CookieProxy.Instance().SetValue("LoginMessage", "Relogin required to proceed", DateTime.Now.AddSeconds(10));
                    Response.Redirect("/Signout?r=/checkout", false);
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

    private void PopulateRegex()
    {
        try
        {
            REGEX_POSTAL_CODE.Value = new SettingsFromDB().FetchSettingsFromDB(new Settings("REGEX_POSTAL_CODE")).GetSettingsValue();
        }
        catch (Exception)
        {
            REGEX_POSTAL_CODE.Value = "";
        }
        //throw new NotImplementedException();
    }

    private void PopulateProvinceList()
    {
        try
        {
            List<IProvince> GetProvinceList = Province.GetProvinceList();

            ddl_province.Items.Add("Select Province");
            foreach (Province ProvinceItem in GetProvinceList)
            {
                ddl_province.Items.Add(ProvinceItem.Name());
            }
            AbleToAddAddress.Visible = true;
            unableToAddAddress.Visible = false;
            ddl_city.Items.Add("Select City (Please select province first)");
            ddl_city.Style.Add("opacity", "0.3");
            ddl_city.Disabled = true;

        }
        catch (Exception)
        {
            AbleToAddAddress.Visible = false;
            unableToAddAddress.Visible = true;
        }
    }
}