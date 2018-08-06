using Grockart.CUSTOM_RESPONSE_CLASSES;
using Grockart.BUSINESSLAYER;
using Grockart.STORAGE;
using Grockart.LOGGER;
using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;


public partial class api_FetchCategoryList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string ResponseValue = "";
        string ResponseString = "";
        List<ICategory> Categories = null;
        try
        {
            UserProfile UserProfileObj = new UserProfile();
            UserProfileObj.SetToken(CookieProxy.Instance().GetValue("t").ToString());
            Categories = new CategoryBusinessLayerTemplate(UserProfileObj).Select();
            if(null == Categories)
            {
                ResponseValue = APIResponse.NOT_OK.ToString();
                ResponseString = "NOT_AUTHENTICATED";
                CookieProxy.Instance().SetValue("LoginMessage", "Not Authorized, please login with correct credentials".ToString(), DateTime.Now.AddDays(2));
                Logger.Instance().Log(Info.Instance(), new LogInfo(new AdminUserTemplate().FetchParticularProfile(UserProfileObj).GetEmail() + " fetched category list"));
            }
            else
            {
                Logger.Instance().Log(Info.Instance(), new LogInfo(new AdminUserTemplate().FetchParticularProfile(UserProfileObj).GetEmail() + " fetched category list "));
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
            ResponseString = "Unable to fetch the list of categories, please check logs";
        }
        finally
        {
            var output = new
            {
                Code = ResponseValue,
                Response = ResponseString,
                CategoriesList = Categories
            };
            Response.Write(new JavaScriptSerializer().Serialize(output));
        }
    }
}