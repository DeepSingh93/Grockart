namespace Grockart.CUSTOM_RESPONSE_CLASSES
{
    public enum APIResponse
    {
        OK,
        NOT_OK,
        NOT_AUTHENTICATED
    }

    public class ApiAuthResponse
    {
        private APIResponse APIResponse;
        public void SetAPIResponse(APIResponse APIResponse)
        {
            this.APIResponse = APIResponse;
        }
        public APIResponse GetAPIResponse()
        {
            return APIResponse;
        }
        public string Value
        {
            get
            {
                return APIResponse.ToString();
            }
        }
    }
}
