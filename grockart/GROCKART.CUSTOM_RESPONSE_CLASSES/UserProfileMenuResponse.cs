namespace Grockart.CUSTOM_RESPONSE_CLASSES
{
    public class UserProfileMenuResponse
    {
        public bool IsProfileAvailable = false;
        public bool ShouldReupdate = false;
        public bool DeleteThisMenu = false;
        public object UserProfile;
        public void SetUserProfile(object UserProfile)
        {
            this.UserProfile = UserProfile;
        }
    }
}
