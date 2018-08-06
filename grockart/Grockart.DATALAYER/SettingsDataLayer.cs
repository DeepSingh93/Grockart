
using Grockart.CUSTOM_RESPONSE_CLASSES;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Grockart.DATALAYER
{
    public class ConfigurableBusinessLogic
    {
        protected readonly ICommands Commands = MySQLCommands.Instance();
        public Settings FetchSettingsFromDB(Settings SettingsObj)
        {
            try
            {
                string SettingsKey = SettingsObj.GetSettingsKey();
                string Source = "sp_FetchSettings";
                object[] parameters =
                {
                    new MySqlParameter("@paramSettingKey", SettingsKey)
                };
                DataSet Output = Commands.ExecuteQuery(Source, CommandType.StoredProcedure, parameters);
                SettingsObj.SetSettingsValue(Output.Tables[0].Rows[0]["setting_value"].ToString());
                return SettingsObj;
            }
            catch (Exception ex)
            {
                LOGGER.Logger.Instance().Log(LOGGER.Fatal.Instance(), ex);
                throw ex;
            }
        }

        public SettingsList FetchAllSettingsFromDB()
        {
            try
            {
                string Source = "sp_FetchAllSettings";
                DataSet Output = Commands.ExecuteQuery(Source, CommandType.StoredProcedure, null);
                SettingsList SettingsList = new SettingsList();
                foreach (DataRow dr in Output.Tables[0].Rows)
                {
                    Settings SettingsObj = new Settings();
                    SettingsObj.SetSettingsKey(dr["setting_key"].ToString());
                    SettingsObj.SetSettingsValue(dr["setting_value"].ToString());
                    SettingsList.AddSettings(SettingsObj);

                }
                return SettingsList;
            }
            catch (Exception ex)
            {
                LOGGER.Logger.Instance().Log(LOGGER.Fatal.Instance(), ex);
                throw ex;
            }
        }

        public int RemoveSettingsFromDB(Settings SettingsObj)
        {
            try
            {
                string Source = "sp_RemoveSettings";
                object[] parameters =
                {
                    new MySqlParameter("@paramSettingKey", SettingsObj.GetSettingsKey())
                };
                int Output = Commands.ExecuteNonQuery(Source, CommandType.StoredProcedure, null);
                return Output;
            }
            catch (Exception ex)
            {
                LOGGER.Logger.Instance().Log(LOGGER.Fatal.Instance(), ex);
                throw ex;
            }
        }

        public int UpdateSettingsFromDB(Settings SettingsObj)
        {
            try
            {
                string Source = "sp_UpdateSettings";
                object[] parameters =
                {
                    new MySqlParameter("@paramSettingKey", SettingsObj.GetSettingsKey()),
                    new MySqlParameter("@paramSettingValue", SettingsObj.GetSettingsValue())
                };
                return Commands.ExecuteNonQuery(Source, CommandType.StoredProcedure, parameters);
                
            }
            catch (Exception ex)
            {
                LOGGER.Logger.Instance().Log(LOGGER.Fatal.Instance(), ex);
                throw ex;
            }
        }
    }
}
