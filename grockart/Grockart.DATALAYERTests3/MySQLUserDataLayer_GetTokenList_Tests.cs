using Grockart.BUSINESSLAYER;
using Grockart.CUSTOM_RESPONSE_CLASSES;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Grockart.DATALAYER
{

    [TestClass()]
    public class MySQLUserDataLayer_GetTokenList_Tests
    {

        /*
         * Input : string email
         * Output : List<string> token list
         * Function Definition : This function returnes the list of tokens for a particular email
         * 
         * Cases covered 
         * 1 : Email is null
         * 2 : Email is empty
         * 3 : Invalid email
         * 4 : Valid email
         */
        private string ExpectedOutput = "";
        private string GotOutput = "";
        [TestMethod()]
        public void GetTokenList_1()
        {
            UserProfile UserProfileObj = new UserProfile();
            UserProfileObj.SetEmail(null);
            ExpectedOutput = "FAIL";
            try
            {
                List<string> TokenList = new SecurityDataLayer(UserProfileObj).GetTokenList();
                GotOutput = "SUCCESS";
            }
            catch (Exception ex)
            {
                GotOutput = "FAIL";
            }
            Assert.AreEqual(ExpectedOutput, GotOutput);
        }
        [TestMethod()]
        public void GetTokenList_2()
        {
            UserProfile UserProfileObj = new UserProfile();
            UserProfileObj.SetEmail("");
            ExpectedOutput = "FAIL";
            try
            {
                List<string> TokenList = new SecurityDataLayer(UserProfileObj).GetTokenList();
                GotOutput = "Success";
            }
            catch (Exception ex)
            {
                GotOutput = "FAIL";
            }
            Assert.AreEqual(ExpectedOutput, GotOutput);
        }
        [TestMethod()]
        public void GetTokenList_3()
        {
            UserProfile UserProfileObj = new UserProfile();
            UserProfileObj.SetEmail("xyz@abc.com");
            List<string> TokenList = null;
            try
            {
                TokenList = new SecurityDataLayer(UserProfileObj).GetTokenList();
            }
            catch (Exception ex)
            {
                GotOutput = ex.Message.ToString();
            }
            Assert.AreEqual(TokenList.Count == 0, true);
        }
        [TestMethod()]
        public void GetTokenList_4()
        {
            UserProfile UserProfileObj = new UserProfile();
            UserProfileObj.SetEmail("demoadmin@demoadmin.com");
            UserProfileObj.SetPassword("aA!12345");
            List<string> TokenList = null;
            try
            {
                TokenList = new SecurityDataLayer(UserProfileObj).GetTokenList();
                if (TokenList.Count == 0)
                {
                    // token count = 0 means that the account is not logged in or all sessions destroyed
                    // generate the token
                    LoginUserReponse response = new UserActions().LoginUserAction(UserProfileObj);
                    TokenList = new SecurityDataLayer(UserProfileObj).GetTokenList();
                }
            }
            catch (Exception)
            {
                TokenList = null;
            }
            Assert.AreEqual(TokenList.Count > 0, true);
        }
    }
}
