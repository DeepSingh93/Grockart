using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grockart.CUSTOM_RESPONSE_CLASSES
{
    public class CardDetails : ICardDetails
    {
        public int CardID;
        public string Name;
        public string CardNumber;
        public string ExpiryYear;
        public string ExpiryMonth;
        public string Cvv;
        public string IV;
        public string Key;
        public CardDetails(int CardID)
        {
            this.CardID = CardID;
        }
        public CardDetails(string Name, string CardNumber, string ExpiryYear, string ExpiryMonth, string Cvv)
        {
            this.Name = Name;
            this.CardNumber = CardNumber;
            this.ExpiryYear = ExpiryYear;
            this.ExpiryMonth = ExpiryMonth;
            this.Cvv = Cvv;
        }
        public CardDetails()
        {
        }
        public void SetCardID(int CardID)
        {
            this.CardID = CardID;
        }
        public int GetCardID()
        {
            return CardID;
        }
        public void SetName(string Name)
        {
            this.Name = Name;
        }
        public string GetName()
        {
            CheckNulls(Name, "Card Name");
            return Name;
        }
        public void SetCardNumber(string CardNumber)
        {
            this.CardNumber = CardNumber;
        }
        public string GetCardNumber()
        {
            CheckNulls(CardNumber, "Card Number");
            return CardNumber;
        }
        public void SetExpiryYear(string ExpiryYear)
        {
            this.ExpiryYear = ExpiryYear;
        }
        public string GetExpiryYear()
        {
            CheckNulls(ExpiryYear, "Expiry Year");
            return ExpiryYear;
        }
        public void SetExpiryMonth(string ExpiryMonth)
        {
            this.ExpiryMonth = ExpiryMonth;
        }
        public string GetExpiryMonth()
        {
            CheckNulls(ExpiryMonth, "Expiry Month");
            return ExpiryMonth;
        }
        public void SetCvv(string Cvv)
        {
            this.Cvv = Cvv;
        }
        public string GetCvv()
        {
            CheckNulls(Cvv, "Cvv Number");
            return Cvv;
        }
       

        public string GetIV()
        {
            return IV;
        }

        public void SetIV(string IV)
        {
            this.IV = IV;
        }

        public string GetDecryptionKey()
        {
            return Key;
        }

        public void SetDecryptionKey(string DecryptionKey)
        {
            this.Key = DecryptionKey;
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
