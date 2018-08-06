using Grockart.BUSINESSLAYER;

using Grockart.CUSTOM_RESPONSE_CLASSES;
using Grockart.LOGGER;
using Grockart.STORAGE;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class api_FetchProductByStore : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string ResponseValue = "";
        string ResponseString = "";
        List<IProductByStore> ProductByStore = null;
        try
        {
            UserProfile UserProfileObj = new UserProfile();
            UserProfileObj.SetToken(CookieProxy.Instance().GetValue("t").ToString());
            ProductByStore = new ProductByStoreBusinessLayerTemplate(UserProfileObj).Select();
            if (null == ProductByStore)
            {
                ResponseValue = APIResponse.NOT_OK.ToString();
                ResponseString = "NOT_AUTHENTICATED";
                CookieProxy.Instance().SetValue("LoginMessage", "Not Authorized, please login with correct credentials".ToString(), DateTime.Now.AddDays(2));
            }
            else
            {
                Logger.Instance().Log(Info.Instance(), new LogInfo(new AdminUserTemplate().FetchParticularProfile(UserProfileObj).GetEmail() + " fetched store list "));
                ResponseValue = APIResponse.OK.ToString();
                ResponseString = "SUCCESS";
            }
        }
        catch (NullReferenceException nex)
        {
            CookieProxy.Instance().SetValue("LoginMessage", "Not Authorized, please login with correct credentials. If you believe this is an error, please check logs".ToString(), DateTime.Now.AddDays(2));
            Logger.Instance().Log(Warn.Instance(), nex);
            ResponseValue = APIResponse.NOT_OK.ToString();
            ResponseString = "NOT_AUTHENTICATED";
        }
        catch (Exception ex)
        {
            Logger.Instance().Log(Warn.Instance(), ex);
            ResponseValue = APIResponse.NOT_OK.ToString();
            ResponseString = "Unable to fetch the list of stores, please check logs";
        }
        finally
        {
            var output = new
            {
                Code = ResponseValue,
                Response = ResponseString,
                ProductByStoreList = ProductByStore
            };
            Response.Write(new JavaScriptSerializer().Serialize(output));
        }
    }
}
