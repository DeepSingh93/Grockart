namespace Grockart.CUSTOM_RESPONSE_CLASSES
{
    public class LoginUserReponse
    {
        private bool isLoggedIn;
        private string token;
        private string encryptedEmail;
        private string errorText;

        public string GetEncryptedEmail()
        {
            return encryptedEmail;
        }

        public void SetEncryptedEmail(string value)
        {
            encryptedEmail = value;
        }
        public string GetErrorText()
        {
            return errorText;
        }
        public void SetErrorText(string value)
        {
            errorText = value;
        }
        public bool GetIsLoggedIn()
        {
            return isLoggedIn;
        }
        public void SetIsLoggedIn(bool value)
        {
            isLoggedIn = value;
        }
        public string GetToken()
        {
            return token;
        }
        public void SetToken(string value)
        {
            token = value;
        }

    }
}
