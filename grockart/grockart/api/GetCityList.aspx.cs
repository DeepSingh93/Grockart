using Grockart.BUSINESSLAYER;
using Grockart.CUSTOM_RESPONSE_CLASSES;
using Grockart.STORAGE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class api_GetCityList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        bool HasCityList = false;
        Dictionary<int, string> CityList = new Dictionary<int, string>();
        CityList ListOfCities = new CityList();
        try
        {
            if (CookieProxy.Instance().HasKey("t"))
            {
                ListOfCities.ListOfCities = new List<City>();
                IUserProfile UserProfileObj = new UserProfile();
                UserProfileObj.SetToken(CookieProxy.Instance().GetValue("t").ToString());
                CityList = new Province(UserProfileObj).GetCityList(Request.Form["province"]);
                foreach (KeyValuePair<int, string> pair in CityList)
                {
                    ListOfCities.ListOfCities.Add(new City(pair.Key, pair.Value));
                }
                HasCityList = true;
            }
            else
            {
                HasCityList = true;
            }

        }
        catch (Exception)
        {
            HasCityList = false;
        }
        finally
        {
            var output = new
            {
                HasCityList,
                ListOfCities
            };
            Response.Write(new JavaScriptSerializer().Serialize(output));
        }
    }

    internal class CityList
    {
        public List<City> ListOfCities;
    }

    internal class City
    {
        public int CityID { get; set; }
        public string CityName { get; set; }
        public City(int CityID, string CityName)
        {
            this.CityID = CityID;
            this.CityName = CityName;
        }
    }
}