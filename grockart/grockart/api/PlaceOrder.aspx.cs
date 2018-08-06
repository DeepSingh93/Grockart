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

public partial class api_PlaceOrder : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        APIResponse ResponseAPI = APIResponse.NOT_OK;
        IOrderCreaterStatus OrderStatus = null;
        try
        {
            ICart CartObj = new JavaScriptSerializer().Deserialize<Cart>(CookieProxy.Instance().GetValue("Cart").ToString());
            IAddress AddressObj = new Address(int.Parse(Request.Form["aid"].ToString()));
            ICardDetails CardObj = new CardDetails(int.Parse(Request.Form["cID"].ToString()));
            IUserProfile UserProfileObj = new UserProfile(CookieProxy.Instance().GetValue("t").ToString());
            OrderStatus = new OrderCreator().CreateOrder(AddressObj, CardObj, UserProfileObj, CartObj);
            if(OrderStatus.GetIsOrderCreated() == true)
            {
                // empty the cart
                CookieProxy.Instance().RemoveKey("Cart");
                ResponseAPI = APIResponse.OK;
            }
            else
            {
                ResponseAPI = APIResponse.NOT_OK;
            }
        }
        catch (Exception)
        {
            ResponseAPI = APIResponse.NOT_OK;
        }
        finally
        {
            var ResponseObj = new
            {
                Response = ResponseAPI.ToString(),
                data = OrderStatus
            };
            Response.Write(new JavaScriptSerializer().Serialize(ResponseObj));
        }

    }
}