
using Grockart.LOGGER;
using System;
using System.Data;
using System.Web.Script.Serialization;

namespace Grockart.CUSTOM_RESPONSE_CLASSES 
{
    public class UserProfile : IUserProfile
    {
        public string FirstName;
        public string LastName;
        public string Email;
        public bool IsAdmin;
        public string Password;
        public string HashedPassword;
        public double AmountOwe;
        public double AmountPaid;
        public string Token;
        public string RoleType;
        public string Salt;
        public UserProfile(string FirstName, string LastName, string Password, string Email, bool IsAdmin, double AmountOwe, double AmountPaid, string RoleType)
        {
            SetFirstName(FirstName);
            SetLastName(LastName);
            SetEmail(Email);
            SetIsAdmin(IsAdmin);
            SetAmountOwe(AmountOwe);
            SetAmountPaid(AmountPaid);
            SetPassword(Password);
            SetRoleType(RoleType);
        }
        public UserProfile(string FirstName, string LastName, string Email, bool IsAdmin, double AmountOwe, double AmountPaid)
        {
            SetFirstName(FirstName);
            SetLastName(LastName);
            SetEmail(Email);
            SetIsAdmin(IsAdmin);
            SetAmountOwe(AmountOwe);
            SetAmountPaid(AmountPaid);
        }
        public UserProfile(string FirstName, string LastName, string Email, bool IsAdmin)
        {
            SetFirstName(FirstName);
            SetLastName(LastName);
            SetEmail(Email);
            SetIsAdmin(IsAdmin);
        }
        public UserProfile(string Token, string Email)
        {
            SetEmail(Email);
            SetToken(Token);
        }
        public UserProfile(string Token)
        {
            SetToken(Token);
        }
        public UserProfile()
        {
        }
        public void SetSalt(string Salt)
        {
            this.Salt = Salt;
        }
        public string GetSalt()
        {
            return Salt;
        }
        public void SetRoleType(string RoleType)
        {
            this.RoleType = RoleType;
        }

        public string GetRoleType()
        {
            CheckNulls(RoleType, "Role Type");
            return RoleType;
        }
        public void SetToken(string Token)
        {
            this.Token = Token;
        }

        public string GetToken()
        {
            CheckNulls(Token, "Token");
            return Token;
        }
        public void SetHashedPassword(string HashedPassword)
        {
            this.HashedPassword = HashedPassword;
        }
        public string GetHashedPassword()
        {
            return HashedPassword;
        }
        public void SetPassword(string Password)
        {
            this.Password = Password;
        }
        public string GetPassword()
        {
            CheckNulls(Password, "Password");
            return Password;
        }
        public string GetFirstName()
        {
            CheckNulls(FirstName, "First Name");
            return FirstName;
        }
        public void SetFirstName(string value)
        {
            FirstName = value;
        }
        public string GetLastName()
        {
            CheckNulls(LastName, "Last Name");
            return LastName;
        }
        public void SetLastName(string value)
        {
            LastName = value;
        }
        public string GetEmail()
        {
            CheckNulls(Email, "Email");
            return Email;
        }
        public void SetEmail(string value)
        {
            Email = value;
        }
        public bool GetIsAdmin()
        {
            return IsAdmin;
        }
        public void SetIsAdmin(bool value)
        {
            IsAdmin = value;
        }
        public double GetAmountOwe()
        {
            return AmountOwe;
        }
        public void SetAmountOwe(double value)
        {
            AmountOwe = value;
        }
        public double GetAmountPaid()
        {
            return AmountPaid;
        }
        public void SetAmountPaid(double value)
        {
            AmountPaid = value;
        }
        public void CheckNulls(string Input, object InputType)
        {
            if(Input == null || Input.Length == 0)
            {
                throw new ArgumentException("Invalid Argument : "+ InputType.ToString() + " = null");
            }
        }
    }

}
