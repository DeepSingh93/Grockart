using System.Collections.Generic;

namespace Grockart.CUSTOM_RESPONSE_CLASSES
{
    public class AdminListResponse
    {
        private static AdminListResponse AdminListResponseObj;
        public static AdminListResponse Instance()
        {
            if(AdminListResponseObj == null)
            {
                AdminListResponseObj = new AdminListResponse();
            }

            return AdminListResponseObj;
        }
        public bool HasList;
        public bool ShouldRedirectToHomePage;
        public string ResponseString;
        public List<UserProfile> AdminList;
    }
}
