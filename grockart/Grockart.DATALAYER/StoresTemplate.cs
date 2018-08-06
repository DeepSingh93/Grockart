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
    public class StoresTemplate : CRUDTemplate<IStores>
    {
        private readonly ICommands Commands = MySQLCommands.Instance();
        private string Source;

        public override List<IStores> Select()
        {
            Source = "sp_FetchStores";
            // To fetch Stores list
            try
            {
                DataSet Output = Commands.ExecuteQuery(Source, CommandType.StoredProcedure, null);
                List<IStores> StoreList = new List<IStores>();
                foreach (DataRow dr in Output.Tables[0].Rows)
                {
                    IStores StoreObj = new Stores();
                    StoreObj.SetStoreID(int.Parse(dr["sID"].ToString()));
                    StoreObj.SetStoreName(dr["storeName"].ToString());
                    StoreObj.SetStoreLogo(dr["storeLogo"].ToString());
                    StoreList.Add(StoreObj);
                }
                return StoreList;
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Fatal.Instance(), ex);
                throw ex;
            }

        }
        public override int Delete(IStores StoreObj)
        {
            Source = "sp_RemoveStore";
            try
            {
                object[] param =
                {
                    new MySqlParameter("@paramSID", StoreObj.GetStoreID())
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
        public override int Insert(IStores StoreObj)
        {
            try
            {
                Source = "sp_AddStore";
                object[] param =
                {
                    new MySqlParameter("@paramStoreName", StoreObj.GetStoreName()),
                    new MySqlParameter("@paramStoreLogo", StoreObj.GetStoreLogo())
                };
                return Commands.ExecuteNonQuery(Source, CommandType.StoredProcedure, param);
            }
            catch (Exception ex)
            {
                Logger.Instance().Log(Fatal.Instance(), ex);
                throw ex;
            }
        }
        public override int Update(IStores StoreObj)
        {
            try
            {
                Source = "sp_ModifyStore";

                object[] param =
                {
                    new MySqlParameter("@paramSID", StoreObj.GetStoreID()),
                    new MySqlParameter("@paramStoreNewName", StoreObj.GetStoreName()),
                    new MySqlParameter("@paramStoreNewLogo", StoreObj.GetStoreLogo())
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
