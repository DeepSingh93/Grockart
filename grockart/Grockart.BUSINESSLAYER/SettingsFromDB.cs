using Grockart.CUSTOM_RESPONSE_CLASSES;
using Grockart.DATALAYER;

namespace Grockart.BUSINESSLAYER
{
    public class SettingsFromDB
    {
        private readonly ConfigurableBusinessLogic ConfigurableBusinessLogicObj = null;

        public SettingsFromDB()
        {
            ConfigurableBusinessLogicObj = new ConfigurableBusinessLogic();
        }
        public SettingsList FetchAllSettingsFromDB()
        {
            return ConfigurableBusinessLogicObj.FetchAllSettingsFromDB();
        }

        public Settings FetchSettingsFromDB(Settings SettingsObj)
        {
            return ConfigurableBusinessLogicObj.FetchSettingsFromDB(SettingsObj);
        }

        public int RemoveSettingsFromDB(Settings SettingsObj)
        {
            return ConfigurableBusinessLogicObj.RemoveSettingsFromDB(SettingsObj);
        }

        public int UpdateSettingsFromDB(Settings SettingsObj)
        {
            return ConfigurableBusinessLogicObj.UpdateSettingsFromDB(SettingsObj);
        }
    }
}
