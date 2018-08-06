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

public partial class api_GetTaxValue : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ITaxResult TaxResultObj = null;
        try
        {
            Cart CartObj = new JavaScriptSerializer().Deserialize<Cart>(CookieProxy.Instance().GetValue("Cart").ToString());
            IAddress AddressObj = new Address(int.Parse(Request.Form["aid"].ToString()));
            IUserProfile UserProfileObj = new UserProfile(CookieProxy.Instance().GetValue("t").ToString());
            TaxResultObj = new TaxManagement().CalculateTaxFromCartItems(CartObj, AddressObj, UserProfileObj);
        }
        catch (Exception)
        {
            TaxResultObj = new TaxResult(false);
        }
        finally
        {

            var ResultObj = new
            {
                Response = TaxResultObj
            };
            Response.Write(new JavaScriptSerializer().Serialize(ResultObj));
        }
    }
}