using Grockart.CUSTOM_RESPONSE_CLASSES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grockart.BUSINESSLAYER
{
    public class MaintenanceMode
    {
        private readonly SettingsFromDB SettingsFromDBObj = new SettingsFromDB();
        public APIResponse EnableMaintenanceMode()
        {
            // >0 signifies the number of rows returned, if = 0 then no rows updated/returned
            if(SettingsFromDBObj.UpdateSettingsFromDB(new Settings("MAINTENANCE", "1")) > 0)
            {
                return APIResponse.OK;
            }
            return APIResponse.NOT_OK;
        }

        public APIResponse DisableMaintenanceMode()
        {
            
            if (SettingsFromDBObj.UpdateSettingsFromDB(new Settings("MAINTENANCE", "0")) > 0)
            {
                return APIResponse.OK;
            }
            return APIResponse.NOT_OK;
        }

        public APIResponse IsMaintenanceModeEnabled()
        {
            if(SettingsFromDBObj.FetchSettingsFromDB(new Settings("MAINTENANCE")).GetSettingsValue() == "1")
            {
                return APIResponse.OK;
            }
            return APIResponse.NOT_OK;
        }

    }
}
