
using System.Collections.Generic;

namespace Grockart.CUSTOM_RESPONSE_CLASSES
{
    public class TokenListResponse : ApiAuthResponse
    {
        private static TokenListResponse TokenListResponseObj;
        List<string> TokenList;
        public static TokenListResponse Instance()
        {
            if (TokenListResponseObj == null)
            {
                TokenListResponseObj = new TokenListResponse();
            }

            return TokenListResponseObj;
        }

        public void SetTokenList(List<string> _TokenList)
        {
            TokenList = _TokenList;
        }
        
        public List<string> GetTokenList()
        {
            return TokenList;
        }
    }
}
