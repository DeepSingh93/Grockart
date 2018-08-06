using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Script.Serialization;
using Grockart.BUSINESSLAYER;

using Grockart.CUSTOM_RESPONSE_CLASSES;
using Grockart.LOGGER;

using Grockart.LOGGER;
using Grockart.STORAGE;

public partial class api_FetchProducts : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        ProductResponse ProductResponseObj = null;
        try
        {
            if(Request.QueryString["k"] != null)
            {
                ProductResponseObj = new ProductsList().FetchProducts(HttpUtility.UrlDecode(Request.QueryString["k"].ToString()));
                Logger.Instance().Log(Info.Instance(), new LogInfo("Product Searched : " + HttpUtility.UrlDecode(Request.QueryString["k"].ToString())));
            } 
            else
            {
                ProductResponseObj = new ProductsList().FetchProducts();
            }
            
        }
        catch (Exception ex)
        {
            ProductResponseObj = new ProductResponse
            {
                HasProducts = false,
                responseString = "Unable to view products this time, please try again later"
            };
            Logger.Instance().Log(Warn.Instance(), ex);
            
        }
        finally
        {
            Response.Write(new JavaScriptSerializer().Serialize(ProductResponseObj));
        }

    }
}