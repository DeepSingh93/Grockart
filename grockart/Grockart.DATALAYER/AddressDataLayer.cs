using Grockart.CUSTOM_RESPONSE_CLASSES;
using Grockart.LOGGER;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grockart.DATALAYER
{
    public class AddressDataLayer : CRUDTemplate<IAddress>
    {
        private readonly ICommands Commands = MySQLCommands.Instance();
        private readonly IUserProfile UserProfileObj;
        private string Source;
        public AddressDataLayer(IUserProfile UserProfileObj)
        {
            this.UserProfileObj = UserProfileObj;
        }
        public override List<IAddress> Select()
        {
            Source = "sp_FetchAddress";
            try
            {
                Object[] param =
                {
                    new MySqlParameter("@paramToken", UserProfileObj.GetToken())
                };
                DataSet Output = Commands.ExecuteQuery(Source, CommandType.StoredProcedure, param);
                List<IAddress> AddressDetails = new List<IAddress>();
                foreach (DataRow dr in Output.Tables[0].Rows)
                {
                    IAddress AddressObject = new Address(
                        AddressID: int.Parse(dr["aid"].ToString()),
                        AddressName: dr["addressName"].ToString(),
                        StreetName: dr["streetName"].ToString(),
                        AptNum: dr["appt"].ToString(),
                        PostalCode: dr["postalcode"].ToString(),
                        PhoneNum: dr["phone"].ToString(),
                        City: dr["city"].ToString(),
                        Province: dr["province"].ToString(),
                        CID: int.Parse(dr["cid"].ToString())
                    );
                    AddressDetails.Add(AddressObject);
                }
                return AddressDetails;
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Fatal.Instance(), ex);
                throw ex;
            }
        }
        public override int Delete(IAddress AddressObj)
        {
            Source = "sp_RemoveAddress";
            int AddressID = AddressObj.GetAddressID();
            try
            {
                Object[] param =
                {
                    new MySqlParameter("@paramAID", AddressID),
                    new MySqlParameter("@paramToken", UserProfileObj.GetToken())
                };
                return Commands.ExecuteNonQuery(Source, CommandType.StoredProcedure, param);
            }
            catch (MySqlException mse)
            {
                Logger.Instance().Log(Fatal.Instance(), mse);
                throw mse;
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Fatal.Instance(), ex);
                throw ex;
            }
        }
        public override int Insert(IAddress AddressObj)
        {
            Source = "sp_AddAddress";
            string Token = UserProfileObj.GetToken();
            int CID = AddressObj.GetCityID();
            string AptNum = AddressObj.GetAptNum();
            string StreetName = AddressObj.GetStreetName();
            string PostalCode = AddressObj.GetPostalCode();
            string PhoneNum = AddressObj.GetPhoneNum();
            string AddressName = AddressObj.GetAddresstName();
            try
            {
                Object[] param =
                {
                    new MySqlParameter("@paramToken", Token),
                    new MySqlParameter("@paramCID", CID),
                    new MySqlParameter("@paramApt", AptNum),
                    new MySqlParameter("@paramStreet", StreetName),
                    new MySqlParameter("@paramPostal", PostalCode),
                    new MySqlParameter("@paramPhone", PhoneNum),
                    new MySqlParameter("@paramAddressName", AddressName)
                };
                return Commands.ExecuteNonQuery(Source, System.Data.CommandType.StoredProcedure, param);
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Fatal.Instance(), ex);
                throw ex;
            }
        }
        public override int Update(IAddress AddressObj)
        {
            Source = "sp_ModifyAddress";
            int AddressID = AddressObj.GetAddressID();
            string Token = UserProfileObj.GetToken();
            string CityName = AddressObj.GetCity();
            string ProvinceName = AddressObj.GetProvince();
            // int UserID = AddressObj.GetUserID();
            string AptNum = AddressObj.GetAptNum();
            string StreetName = AddressObj.GetStreetName();
            string PostalCode = AddressObj.GetPostalCode();
            string PhoneNum = AddressObj.GetPhoneNum();
            try
            {
                Object[] param =
                {
                    new MySqlParameter("@paramAID", AddressID),
                    new MySqlParameter("@paramToken", Token),
                    new MySqlParameter("@paramCity", CityName),
                    new MySqlParameter("@paramProvince", ProvinceName),
                    //new MySqlParameter("@paramUID", UserID),
                    new MySqlParameter("@paramApt", AptNum),
                    new MySqlParameter("@paramStreet", StreetName),
                    new MySqlParameter("@paramPostal", PostalCode),
                    new MySqlParameter("@paramPhone", PhoneNum)
                };
                return Commands.ExecuteNonQuery(Source, CommandType.StoredProcedure, param);
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Fatal.Instance(), ex);
                throw ex;
            }
        }
    }
}
