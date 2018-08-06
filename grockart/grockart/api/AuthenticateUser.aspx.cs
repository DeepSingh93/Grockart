using Grockart.BUSINESSLAYER;
using Grockart.CUSTOM_RESPONSE_CLASSES;
using Grockart.LOGGER;
using Grockart.STORAGE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class api_AuthenticateUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        bool IsAuthenticated = false;
        try
        {
            if (CookieProxy.Instance().HasKey("t"))
            {
                IUserProfile UserProfileObj = new UserProfile(CookieProxy.Instance().GetValue("t").ToString());
                if (new Security(UserProfileObj).AuthenticateUser() == false)
                {
                    IsAuthenticated = false;
                }
                else
                {
                    IsAuthenticated = true;
                }
            }
            else
            {
                IsAuthenticated = false;
            }
        }
        catch (Exception ex)
        {
            Logger.Instance().Log(Warn.Instance(), ex);
            IsAuthenticated = false;
        }
        finally
        {
            var Output = new
            {
                IsAuthenticated
            };
            Response.Write(new JavaScriptSerializer().Serialize(Output));
        }
    }
}