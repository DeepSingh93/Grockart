using Grockart.BUSINESSLAYER;
using Grockart.CUSTOM_RESPONSE_CLASSES;
using Grockart.LOGGER;
using Grockart.STORAGE;
using MySql.Data.MySqlClient;
using System;
using System.Web.Script.Serialization;

public partial class api_CancelOrder : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        APIResponse ResponseAPI = APIResponse.NOT_OK;
        try
        {
            if (CookieProxy.Instance().HasKey("t"))
            {
                IUserProfile UserProfileObj = new UserProfile(CookieProxy.Instance().GetValue("t").ToString());
                IOrder OrderObj = new Order();
                OrderObj.SetOrderID(int.Parse(Request.Form["oid"]));
                ResponseAPI = new OrderBusinessLayerTemplate(UserProfileObj).Cancel(OrderObj);
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