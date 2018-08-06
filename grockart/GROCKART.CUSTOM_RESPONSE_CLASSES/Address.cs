using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grockart.CUSTOM_RESPONSE_CLASSES
{
    public class Address : IAddress
    {
        public readonly int AddressID;
        public readonly int CityID;
        public readonly string AddressName;
        public readonly string City;
        public readonly string Province;
        public readonly string AptNum;
        public readonly string StreetName;
        public readonly string PostalCode;
        public readonly string PhoneNum;
        public Address(string AddressName, string StreetName, string AptNum, string PostalCode, string PhoneNum, string City, string Province)
        {
            this.AddressName = AddressName;
            this.StreetName = StreetName;
            this.AptNum = AptNum;
            this.PostalCode = PostalCode;
            this.PhoneNum = PhoneNum;
            this.City = City;
            this.Province = Province;
        }
        public Address(int AddressID, string AddressName, string StreetName, string AptNum, string PostalCode, string PhoneNum, string City, string Province, int CID)
        {
            this.AddressID = AddressID;
            this.AddressName = AddressName;
            this.StreetName = StreetName;
            this.AptNum = AptNum;
            this.PostalCode = PostalCode;
            this.PhoneNum = PhoneNum;
            this.City = City;
            this.Province = Province;
            this.CityID = CID;
        }
        public Address(string AddressName, string StreetName, string AptNum, string PostalCode, string PhoneNum, int CityID)
        {
            this.AddressName = AddressName;
            this.StreetName = StreetName;
            this.AptNum = AptNum;
            this.PostalCode = PostalCode;
            this.PhoneNum = PhoneNum;
            this.CityID = CityID;
        }

        public Address(int AddressID)
        {
            this.AddressID = AddressID;
        }

        public string GetAddresstName()
        {
            CheckNulls(AddressName, "Address Name");
            return AddressName;
        }
        public int GetAddressID()
        {
            CheckNulls(AddressID.ToString(), "Address ID");
            return AddressID;
        }
        public int GetCityID()
        {
            CheckNulls(CityID.ToString(), "City ID");
            return CityID;
        }
        public string GetCity()
        {
            CheckNulls(City, "City Name");
            return City;
        }
        public string GetProvince()
        {
            CheckNulls(Province, "Province Name");
            return Province;
        }
        public string GetAptNum()
        {
            CheckNulls(AptNum, "Apt Number");
            return AptNum;
        }
        public string GetStreetName()
        {
            CheckNulls(StreetName, "Street Name");
            return StreetName;
        }
        public string GetPostalCode()
        {
            CheckNulls(PostalCode, "Postal Code");
            return PostalCode;
        }
        public string GetPhoneNum()
        {
            CheckNulls(PhoneNum, "Phone Number");
            return PhoneNum;
        }
        public void CheckNulls(string Input, object InputType)
        {
            if (Input == null || Input.Length == 0)
            {
                throw new ArgumentException("Invalid Argument : " + InputType.ToString() + " = null");
            }
        }
    }
}
