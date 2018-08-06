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

public partial class api_DeleteCart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        APIResponse ResponseENUM = APIResponse.NOT_OK;
        string ResponseString = "";
        try
        {
            Cart CartObj = null;
            if (CookieProxy.Instance().HasKey("Cart"))
            {
                int PBSId = int.Parse(Request.Form["pbsid"].ToString());
                CartObj = new JavaScriptSerializer().Deserialize<Cart>(CookieProxy.Instance().GetValue("Cart").ToString());
                int Iterator = 0;
                foreach (CartItems Cart in CartObj.CartItems)
                {
                    if (Cart.ProductObj.pbsID == PBSId)
                    {
                        CartObj.CartItems.RemoveAt(Iterator);
                        ResponseENUM = APIResponse.OK;
                        ResponseString = "SUCCESS";
                        break;
                    }
                    Iterator += 1;
                }
                CookieProxy.Instance().SetValue("Cart", new JavaScriptSerializer().Serialize(CartObj), DateTime.Now.AddDays(5));
            }
            else
            {
                ResponseENUM = APIResponse.NOT_OK;
                ResponseString = "AN ERROR OCCURED WHILE READING THE CART, PLEASE CLEAR YOUR COOKIES";
            }

        }
        catch (Exception ex)
        {
            Logger.Instance().Log(Warn.Instance(), ex);
            ResponseENUM = APIResponse.NOT_OK;
            ResponseString = "AN ERROR OCCURED WHILE READING THE CART, PLEASE CLEAR YOUR COOKIES";
        }
        finally
        {
            var ReturnObj = new
            {
                Response = ResponseENUM.ToString(),
                ResponseString
            };
            Response.Write(new JavaScriptSerializer().Serialize(ReturnObj));
        }
    }
    internal class Cart
    {
        public List<CartItems> CartItems;
    }
    internal class CartItems
    {
        public bool HasQuantity;
        public Products ProductObj;
    }
}