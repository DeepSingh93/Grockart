using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grockart.CUSTOM_RESPONSE_CLASSES
{
    public interface IAddress
    {
        int GetAddressID();
        int GetCityID();
        string GetCity();
        string GetProvince();
        string GetAptNum();
        string GetStreetName();
        string GetPostalCode();
        string GetPhoneNum();
        string GetAddresstName();
    }
}
