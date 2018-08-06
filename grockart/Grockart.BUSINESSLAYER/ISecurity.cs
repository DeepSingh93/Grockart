using System.Collections.Generic;

namespace Grockart.DATALAYER
{
    public interface ISecurity
    {
        bool AuthenticateUser();
        bool AuthenticateAdmin();
        List<string> GetTokenList();
        void RemoveTokenFromDB();
        void AddTokenToDB();
    }
}
