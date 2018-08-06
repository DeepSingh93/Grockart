using Grockart.CUSTOM_RESPONSE_CLASSES;
using Grockart.DATALAYER;
using System.Collections.Generic;

namespace Grockart.BUSINESSLAYER
{
    public class AdminUserTemplate : UserTemplate<IUserProfile>
    {
        private readonly IUserProfile UserProfileObj;
        private readonly DATALAYER.UserTemplate<IUserProfile> UserDataLayerTemplate;
        private readonly Security SecurityObj;

        public AdminUserTemplate()
        {
        }

        public AdminUserTemplate(IUserProfile UserProfileObj)
        {
            this.UserProfileObj = UserProfileObj;
            UserDataLayerTemplate = new DATALAYER.AdminUserTemplate(UserProfileObj);
            SecurityObj = new Security(UserProfileObj);
        }
        public override APIResponse Add()
        {

            if (SecurityObj.AuthenticateAdmin())
            {
                return UserDataLayerTemplate.Add();
            }
            else
            {
                return APIResponse.NOT_AUTHENTICATED;
            }
        }

        public override List<IUserProfile> FetchList()
        {
            if (SecurityObj.AuthenticateAdmin())
            {
                return UserDataLayerTemplate.FetchList();
            }
            else
            {
                return null;
            }
        }

        public override APIResponse Remove()
        {
            if (SecurityObj.AuthenticateAdmin())
            {
                return UserDataLayerTemplate.Remove();
            }
            else
            {
                return APIResponse.NOT_AUTHENTICATED;
            }
        }
    }
}
