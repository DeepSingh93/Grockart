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

public partial class api_GetCart : System.Web.UI.Page
{
    private readonly int GetMaxQty = int.Parse(new SettingsFromDB().FetchSettingsFromDB(new Settings(SettingsKey: "MAX_QTY")).GetSettingsValue());

    protected void Page_Load(object sender, EventArgs e)
    {

        APIResponse ApiResponse = APIResponse.NOT_OK;
        int Quantity = 0;
        Cart CartObj = new Cart();
        try
        {
            if (CookieProxy.Instance().HasKey("Cart"))
            {
                CartObj = new JavaScriptSerializer().Deserialize<Cart>(CookieProxy.Instance().GetValue("Cart").ToString());
                foreach (CartItems Items in CartObj.CartItems)
                {
                    IProductByStore PBSObj = new ProductByStore();
                    PBSObj.SetProductByStoreID(Items.ProductObj.pbsID);
                    Products DBProductQty = new ProductByStoreBusinessLayerTemplate().Select(PBSObj);
                    if (GetMaxQty < DBProductQty.Quantity)
                    {
                        Items.DBQuantity = GetMaxQty;
                    }
                    else
                    {
                        Items.DBQuantity = DBProductQty.Quantity;
                    }
                    if (Items.ProductObj.Quantity < 0)
                    {
                        CartObj.HasValidationErrors = true;
                        Items.ProductObj.Quantity = -1;
                        Items.HasQuantity = false;
                    }
                    else
                    if (DBProductQty.Quantity < Items.ProductObj.Quantity && Items.ProductObj.Quantity <= 0)
                    {
                        CartObj.HasValidationErrors = true;
                        Items.ProductObj.Quantity = -1;
                        Items.HasQuantity = false;
                    }
                    else if (DBProductQty.Quantity < Items.ProductObj.Quantity)
                    {
                        CartObj.HasValidationErrors = true;
                        Items.HasQuantity = false;
                    }
                    Quantity = CartObj.CartItems.Count;
                }
            }
            ApiResponse = APIResponse.OK;
        }
        catch (Exception ex)
        {
            Logger.Instance().Log(Warn.Instance(), ex);
            ApiResponse = APIResponse.NOT_OK;
        }
        finally
        {
            var Cart = new
            {
                Response = ApiResponse.ToString(),
                Quantity,
                Cart = new JavaScriptSerializer().Serialize(CartObj)
            };
            Response.Write(new JavaScriptSerializer().Serialize(Cart));
        }
    }
    
}