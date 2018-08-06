using System;
using System.Collections.Generic;
using System.Data;
using Grockart.CUSTOM_RESPONSE_CLASSES;

namespace Grockart.DATALAYER
{
    public interface ISecurityDataLayer
    {
        List<string> GetTokenList();
        DataSet GetUserToken();
        void AddTokenToDatabase();
        void RemoveToken();
    }
}
