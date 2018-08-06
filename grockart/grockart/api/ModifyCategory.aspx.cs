using Grockart.CUSTOM_RESPONSE_CLASSES;
using Grockart.BUSINESSLAYER;
using Grockart.STORAGE;
using Grockart.LOGGER;
using System;
using System.Web.Script.Serialization;
using MySql.Data.MySqlClient;



public partial class api_ModifyCategory : System.Web.UI.Page
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
                Category CategoryObj = new Category();
                UserProfileObj.SetToken(CookieProxy.Instance().GetValue("t").ToString());
                CategoryObj.SetCategoryId(int.Parse(Request.Form["c"]));
                CategoryObj.SetCategoryName(Request.Form["cn"]);
                APIResponse Response = new CategoryBusinessLayerTemplate(UserProfileObj).Update(CategoryObj);
                ResponseValue = Response.ToString();
                if (Response == APIResponse.NOT_OK)
                {
                    ResponseString = "Unable to modify the category, please check logs";
                }
                else
                {
                    Logger.Instance().Log(Info.Instance(), new LogInfo(new AdminUserTemplate().FetchParticularProfile(UserProfileObj).GetEmail() + " modified category ID " + Request.Form["c"].ToString() + " to " + Request.Form["cn"]));
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
            ResponseString = "Unable to delete category, please delete the products first linked to category before deleting category";
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