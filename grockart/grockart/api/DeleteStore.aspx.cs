using Grockart.BUSINESSLAYER;
using Grockart.CUSTOM_RESPONSE_CLASSES;
using Grockart.LOGGER;
using Grockart.STORAGE;
using MySql.Data.MySqlClient;
using System;
using System.Web.Script.Serialization;

public partial class api_DeleteStore : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string ResponseValue = "";
        string ResponseString = "";
        try
        {
            if (CookieProxy.Instance().HasKey("t"))
            {
                UserProfile UserProfileObj = new UserProfile();
                UserProfileObj.SetToken(CookieProxy.Instance().GetValue("t").ToString());

                IStores StoreObj = new Stores();
                StoreObj.SetStoreID(int.Parse(Request.Form["sid"].ToString()));

                APIResponse Response = new StoreBusinessLayerTemplate(UserProfileObj).Delete(StoreObj);
                ResponseValue = Response.ToString();

                if (Response == APIResponse.NOT_OK)
                {
                    ResponseString = "Unable to delete the store, please check logs";
                }
                else
                {
                    ResponseString = "SUCCESS";
                    Logger.Instance().Log(Info.Instance(), new LogInfo(new AdminUserTemplate().FetchParticularProfile(UserProfileObj).GetEmail() + " deleted the store ID " + Request.Form["sid"].ToString()));
                }
            }
            else
            {
                ResponseValue = APIResponse.NOT_OK.ToString();
                ResponseString = "NOT_AUTHENTICATED";
            }

        }
        catch (NullReferenceException nex)
        {
            CookieProxy.Instance().SetValue("LoginMessage", "Not Authorized, please login with correct credentials. If you believe this is an error, please check logs".ToString(), DateTime.Now.AddDays(2));
            Logger.Instance().Log(Warn.Instance(), nex);
            ResponseValue = APIResponse.NOT_OK.ToString();
            ResponseString = "NOT_AUTHENTICATED";
        }
        catch (MySqlException mse)
        {
            Logger.Instance().Log(Warn.Instance(), mse);
            ResponseValue = APIResponse.NOT_OK.ToString();
            ResponseString = "Unable to delete store, please delete the products first linked to store before deleting store";
        }
        catch (Exception ex)
        {
            Logger.Instance().Log(Warn.Instance(), ex);
            ResponseValue = APIResponse.NOT_OK.ToString();
            ResponseString = "Unable to delete the category, please check logs";
        }
        finally
        {
            var output = new
            {
                Code = ResponseValue,
                Response = ResponseString,
            };
            Response.Write(new JavaScriptSerializer().Serialize(output));
        }
    }
}