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

public partial class api_AddToCart : System.Web.UI.Page
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
                bool AlreadyHasProductInCart = false;
                foreach (CartItems Cart in CartObj.CartItems)
                {
                    if (Cart.ProductObj.pbsID == PBSId)
                    {
                        ResponseENUM = APIResponse.NOT_OK;
                        ResponseString = "PRODUCT ALREADY ADDED TO CART, PLEASE MODIFY THE QUANTITY";
                        AlreadyHasProductInCart = true;
                        break;
                    }
                }
                if (AlreadyHasProductInCart == false)
                {
                    ProductByStore PBSPbj = new ProductByStore();
                    PBSPbj.SetProductByStoreID(PBSId);
                    CartItems CartItemsObj = new CartItems
                    {
                        HasQuantity = true,
                        ProductObj = new ProductByStoreBusinessLayerTemplate().Select(PBSPbj)
                    };
                    // reset the quantity to 1, we want the user quantity not the product quantity
                    CartItemsObj.ProductObj.Quantity = 1;
                    CartObj.CartItems.Add(CartItemsObj);
                    CookieProxy.Instance().SetValue("Cart", new JavaScriptSerializer().Serialize(CartObj), DateTime.Now.AddDays(5));
                    ResponseENUM = APIResponse.OK;
                    ResponseString = "SUCCESS";
                }
            }
            else
            {
                CartObj = new Cart
                {
                    CartItems = new List<CartItems>()
                };
                int PBSId = int.Parse(Request.Form["pbsid"].ToString());
                CartItems CartItemsObj = new CartItems
                {
                    HasQuantity = true,
                    ProductObj = new ProductByStoreBusinessLayerTemplate().Select(new ProductByStore()
                    {
                        ProductByStoreID = PBSId
                    })
                };
                // reset the quantity to 1, we want the user quantity (user has initially selected the quantity) not the product quantity
                CartItemsObj.ProductObj.Quantity = 1;
                CartObj.CartItems.Add(CartItemsObj);
                CookieProxy.Instance().SetValue("Cart", new JavaScriptSerializer().Serialize(CartObj), DateTime.Now.AddDays(5));
                ResponseENUM = APIResponse.OK;
                ResponseString = "SUCCESS";
            }


        }
        catch (Exception ex)
        {
            Logger.Instance().Log(Warn.Instance(), ex);
            ResponseENUM = APIResponse.NOT_OK;
            ResponseString = "ERROR";
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


