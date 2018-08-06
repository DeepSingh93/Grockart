using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grockart.CUSTOM_RESPONSE_CLASSES
{
    public interface ICardDetails
    {
        void SetCardID(int CardID);
        int GetCardID();
        void SetName(string Name);
        string GetName();
        void SetCardNumber(string CardNumber);
        string GetCardNumber();
        void SetExpiryYear(string ExpiryYear);
        string GetExpiryYear();
        void SetExpiryMonth(string ExpiryMonth);
        string GetExpiryMonth();
        void SetCvv(string Cvv);
        string GetCvv();
        string GetIV();
        void SetIV(string IV);
        string GetDecryptionKey();
        void SetDecryptionKey(string DecryptionKey);

    }
}
