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

public partial class api_ClearCart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        APIResponse ResponseENUM = APIResponse.NOT_OK;
        string ResponseString = "";
        try
        {
            CookieProxy.Instance().RemoveKey("Cart");
            ResponseENUM = APIResponse.OK;
            ResponseString = "SUCCESS";
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
}