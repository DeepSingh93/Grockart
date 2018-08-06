using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grockart.CUSTOM_RESPONSE_CLASSES
{
    public class AuthAdminResponse
    {
        public AuthResponse Response;
        public string ResponseString;
        private static AuthAdminResponse AuthAdminResponseObj;
        public static AuthAdminResponse Instance()
        {
            if(AuthAdminResponseObj == null)
            {
                AuthAdminResponseObj = new AuthAdminResponse();
            }

            return AuthAdminResponseObj;
        }
    }
}
