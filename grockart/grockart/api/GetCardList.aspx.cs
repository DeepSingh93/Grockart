using Grockart.BUSINESSLAYER;
using Grockart.CUSTOM_RESPONSE_CLASSES;
using Grockart.STORAGE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class api_GetCardList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        bool isAuthenticated = false;
        List<ICardDetails> CardList = new List<ICardDetails>();

        try
        {
            if (CookieProxy.Instance().HasKey("t"))
            {
                IUserProfile UserProfileObj = new UserProfile();
                UserProfileObj.SetToken(CookieProxy.Instance().GetValue("t").ToString());
                CRUDBusinessLayerTemplate<ICardDetails> CardObj = new CardDetailsBusinessLayerTemplate(UserProfileObj);
                CardList = CardObj.Select();
                isAuthenticated = true;
            }
            else
            {
                isAuthenticated = false;
            }
        }
        catch (NullReferenceException)
        {
            isAuthenticated = false;
            CookieProxy.Instance().SetValue("LoginMessage", "For security reasons, please relogin", DateTime.Now.AddDays(2));

        }
        catch (Exception)
        {
            isAuthenticated = false;
            CookieProxy.Instance().SetValue("LoginMessage", "An error occured, this event has been logged. Please try again later", DateTime.Now.AddDays(2));
        }
        finally
        {
            var JSONResponse = new
            {
                isAuthenticated,
                CardList
            };

            Response.Write(new JavaScriptSerializer().Serialize(JSONResponse));
        }
    }
}