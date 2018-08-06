using System;
using System.Collections.Generic;

namespace Grockart.CUSTOM_RESPONSE_CLASSES
{
    public class SettingsList
    {
        private List<Settings> LocalSettingsList;
        public SettingsList()
        {
            LocalSettingsList = new List<Settings>();
        }
        public List<Settings> GetSettingsList()
        {
            return LocalSettingsList;
        }
        public void AddSettings(Settings SettingsObj)
        {
            LocalSettingsList.Add(SettingsObj);
        }
        public void SetSettingsList(List<Settings> value)
        {
            LocalSettingsList = value;
        }
    }
    public class Settings
    {
        private string SettingsKey;
        private string SettingsValue;
        public Settings(string SettingsKey)
        {
            SetSettingsKey(SettingsKey);
        }
        public Settings(string SettingsKey, string SettingsValue)
        {
            SetSettingsKey(SettingsKey);
            SetSettingsValue(SettingsValue);
        }

        public Settings()
        {
        }

        public string GetSettingsKey()
        {
            if(SettingsKey == null)
            {
                throw new ArgumentException("Invalid Argument : SettingsValue = null");
            }
            return SettingsKey;
        }
        public void SetSettingsKey(string value)
        {
            SettingsKey = value;
        }
        public string GetSettingsValue()
        {
            if(SettingsValue == null)
            {
                throw new ArgumentException("Invalid Argument : SettingsKey = null");
            }
            return SettingsValue;
        }
        public void SetSettingsValue(string value)
        {
            SettingsValue = value;
        }
    }
}
