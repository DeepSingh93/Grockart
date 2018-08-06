using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using Grockart.BUSINESSLAYER;
using Grockart.CUSTOM_RESPONSE_CLASSES;
using Grockart.LOGGER;
using Grockart.STORAGE;
public partial class api_orders_OrderPlacedIndividualOrders : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        bool HasOrders = false;
        bool IsAuthenticated = false;
        string ResponseString = "";
        List<IOrderBuilderResponse> ListOfOrders = null;
        try
        {
            if (CookieProxy.Instance().HasKey("t"))
            {
                IUserProfile UserProfileObj = new UserProfile();
                UserProfileObj.SetToken(CookieProxy.Instance().GetValue("t").ToString());
                // authenticate incoming token
                new Security(UserProfileObj).AuthenticateUser();
                IOrder OrderObj = new Order();
                OrderTypeTemplate Order = new IndividualOrderTemplate(UserProfileObj, OrderObj);
                ListOfOrders = Order.FetchOrderCreatedID();
                ResponseString = "SUCCESS";

                IsAuthenticated = true;
                if (ListOfOrders.Count == 0)
                {
                    HasOrders = false;
                }
                else
                {
                    HasOrders = true;
                }
            }
            else
            {
                ResponseString = "INVALID";
            }

        }
        catch (Exception ex)
        {
            Logger.Instance().Log(Warn.Instance(), ex);
            ResponseString = "Unable to fetch the orders this time, please try again later";
        }
        finally
        {
            var JSONResponse = new
            {
                HasOrders,
                IsAuthenticated,
                Response = ResponseString,
                ListOfOrders
            };

            Response.Write(new JavaScriptSerializer().Serialize(JSONResponse));
        }
    }
}