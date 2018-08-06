using Grockart.CUSTOM_RESPONSE_CLASSES;
using Grockart.DATALAYER;
using Grockart.LOGGER;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Grockart.BUSINESSLAYER
{
    public static class Menu
    {
        public static MenuResponse FetchProductMenu()
        {
            MenuResponse resp = new MenuResponse();
            try
            {
                DataSet MenuDS = new ProductMenu().GetMenu();
                resp.Menu = MenuDS;
                resp.IsMenuAvailable = true;
            }
            catch (Exception ex)
            {
                resp.IsMenuAvailable = false;
                Logger.Instance().Log(Fatal.Instance(), ex);
            }
            return resp;
        }

        public static string FetchSerializedProductMenu()
        {
            int CategoryCount = 0;
            int filteredCategoryCount = 0;
            Dictionary<string, string> filteredSubCategory = null;
            MenuResponse output = FetchProductMenu();
            List<object> OutputList = new List<object>();
            if (output.IsMenuAvailable)
            {
                DataView dv = new DataView(output.Menu.Tables[0]);
                DataTable DistinctColumn = dv.ToTable(true, "CategoryName");
                CategoryCount = DistinctColumn.Rows.Count;
                foreach (DataRow dr in DistinctColumn.Rows)
                {
                    DataView dvFiltered = new DataView(output.Menu.Tables[0])
                    {
                        RowFilter = "CategoryName = '" + dr[0].ToString() + "'"
                    };
                    filteredCategoryCount = dvFiltered.Count;
                    filteredSubCategory = new Dictionary<string, string>();
                    foreach (DataRowView drFiltered in dvFiltered)
                    {
                        filteredSubCategory.Add(drFiltered["pbsid"].ToString(), drFiltered["ProductName"].ToString());
                    }
                    var itemToInsert = new
                    {
                        CategoryName = dr[0].ToString(),
                        SubCategoryCount = filteredCategoryCount,
                        HasSubCategory = true,
                        SubCategoryList = filteredSubCategory
                    };
                    OutputList.Add(itemToInsert);

                }
            }
            var objmenu = new
            {
                CategoryCount,
                menu = OutputList
            };
            return new JavaScriptSerializer().Serialize(objmenu);
        }
    }
}
