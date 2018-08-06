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

public partial class api_DeleteUserAddress : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        APIResponse ResponseAPI = APIResponse.NOT_OK;
        try
        {
            if (CookieProxy.Instance().HasKey("t"))
            {
                IUserProfile UserProfileObj = new UserProfile(CookieProxy.Instance().GetValue("t").ToString());
                IAddress AddressObj = new Address(int.Parse(Request.Form["aid"]));
                CRUDBusinessLayerTemplate<IAddress> AddressCRUD = new AddressBusinessLayerTemplate(UserProfileObj);
                ResponseAPI = AddressCRUD.Delete(AddressObj);
            }
            else
            {
                ResponseAPI = APIResponse.NOT_AUTHENTICATED;
            }
        }
        catch (NullReferenceException)
        {
            ResponseAPI = APIResponse.NOT_AUTHENTICATED;
        }
        catch (Exception)
        {
            ResponseAPI = APIResponse.NOT_OK;
        }
        finally
        {
            if (ResponseAPI == APIResponse.NOT_AUTHENTICATED)
            {
                CookieProxy.Instance().SetValue("LoginMessage", "For security reasons, please relogin".ToString(), DateTime.Now.AddDays(2));
            }

            var ResponseObj = new
            {
                Response = ResponseAPI.ToString()
            };

            Response.Write(new JavaScriptSerializer().Serialize(ResponseObj));
        }
    }
}