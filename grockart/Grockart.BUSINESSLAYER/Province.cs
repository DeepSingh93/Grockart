using Grockart.BUSINESSLAYER;
using Grockart.CUSTOM_RESPONSE_CLASSES;
using Grockart.DATALAYER;
using Grockart.LOGGER;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grockart.BUSINESSLAYER
{
    public class Province : IProvince
    {
        private readonly int ID;
        private readonly string _Name;
        private readonly IUserProfile UserProfileObj;
        public Province(int ID, string Name)
        {
            this.ID = ID;
            this._Name = Name;
        }
        public Province(string Name)
        {
            this._Name = Name;
        }
        public Province(int ID)
        {
            this.ID = ID;
        }

        public Province(IUserProfile UserProfileObj)
        {
            this.UserProfileObj = UserProfileObj;
        }

        public static List<IProvince> GetProvinceList()
        {
            List<IProvince> ListOfProvince = new List<IProvince>();
            try
            {
                DataSet OutputDataset = ProvinceDataLayer.GetDatasetOfProvinces();
                DataView dvOutputDataset = new DataView(OutputDataset.Tables[0]);
                DataTable dtOutputDataset = dvOutputDataset.ToTable(true, "province");
                foreach (DataRow dr in dtOutputDataset.Rows)
                {
                    ListOfProvince.Add(new Province(dr["Province"].ToString()));
                }
                return ListOfProvince;
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Fatal.Instance(), ex);
                throw ex;
            }
        }
        public Dictionary<int, string> GetCityList(string ProvinceName)
        {
            try
            {
                Dictionary<int, string> OutputDictionary = new Dictionary<int, string>();
                if (new Security(UserProfileObj).AuthenticateUser())
                {
                    DataSet OutputDataset = ProvinceDataLayer.GetDatasetOfProvinces();
                    DataView DVTable = OutputDataset.Tables[0].DefaultView;
                    DVTable.Sort = "province asc";
                    DataTable dtSorted = DVTable.ToTable();
                    DataRow[] DrFiltered = dtSorted.Select("province = '" + ProvinceName + "'");
                    foreach (DataRow dr in DrFiltered)
                    {
                        OutputDictionary.Add(int.Parse(dr["cid"].ToString()), dr["city"].ToString());
                    }
                }
                return OutputDictionary;
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Fatal.Instance(), ex);
                throw ex;
            }

        }
        public int GetID()
        {
            return ID;
        }

        public string Name()
        {
            return _Name;
        }
    }
}
