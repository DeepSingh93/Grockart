using Grockart.CUSTOM_RESPONSE_CLASSES;
using System.Collections.Generic;
using System.Data;

namespace Grockart.DATALAYER
{
    
    public interface IUserDatalayer
    {
        DataSet RegisterUser(UserProfile UserProfileObj);
        DataSet GetUserProfile(UserProfile UserProfileObj);
        DataSet GetHashedPassword(UserProfile UserProfileObj);
        APIResponse RecoverPassword(string FPToken, string Email);
    }
}
