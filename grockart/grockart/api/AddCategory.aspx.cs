using Grockart.CUSTOM_RESPONSE_CLASSES;
using Grockart.BUSINESSLAYER;
using Grockart.STORAGE;
using Grockart.LOGGER;
using System;
using System.Web.Script.Serialization;

using MySql.Data.MySqlClient;

public partial class api_AddCategory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string ResponseValue = "";
        string ResponseString = "";
        try
        {
            UserProfile UserProfileObj = new UserProfile();
            Category CategoryObj = new Category();
            UserProfileObj.SetToken(CookieProxy.Instance().GetValue("t").ToString());
            CategoryObj.SetCategoryName(Request.Form["c"].ToString());
            APIResponse Response = new CategoryBusinessLayerTemplate(UserProfileObj).Insert(CategoryObj);
            ResponseValue = Response.ToString();
            if (Response == APIResponse.NOT_OK)
            {
                ResponseString = "Unable to add the category, please check logs";
            }
            else
            {
                Logger.Instance().Log(Info.Instance(), new LogInfo(new AdminUserTemplate().FetchParticularProfile(UserProfileObj).GetEmail() + " added the category ID " + Request.Form["c"].ToString()));
            }
        }
        catch(MySqlException mex)
        {
            Logger.Instance().Log(Warn.Instance(), mex);
            ResponseValue = APIResponse.NOT_OK.ToString();
            ResponseString = "Category already exists, please choose a different category name";
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
            ResponseString = "Unable to add the category, please check logs";
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