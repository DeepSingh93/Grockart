using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Grockart.CUSTOM_RESPONSE_CLASSES;
using Grockart.BUSINESSLAYER;
using Grockart.DATALAYER;

namespace Grockart.DATALAYER
{
    [TestClass()]
    public class MySQLAdminDataLayerTests_FetchUserList_Tests
    {
        /*
        * Input : UserProfile Token, String Query
        * Output : The list of users 
        * Function Definition : This function returns back the list of users including the rights of the user (Admin/Normal)
        * 
        * Cases covered 
        * 1. Token = null and Query = null
        * 2. Token = null and Query = valid
        * 3. Token = valid and QUery = null
        * 4. Token = empty and Query = empty
        * 5. Token = valid and Query = empty
        * 6. Token = empty and Query = valid
        * 7. Token = valid and Query = valid
        */
        private string ExpectedOutput = "";
        private string GotOutput = "";
        // both the input parameters  are null
        [TestMethod()]
        public void FetchUserList_1()
        {
            UserProfile UserProfileObj = new UserProfile();
            UserProfileObj.SetToken(null);
            string Query = null;
            ExpectedOutput = "FAIL";
            GotOutput = "";
            try
            {
                UserTemplate<IUserProfile> NormalTemplate = new NormalUserTemplate(UserProfileObj, Query);
                List<IUserProfile> profiles = NormalTemplate.FetchList();
                GotOutput = "Success";
            }
            catch (Exception ex)
            {
                GotOutput = "FAIL";
            }

            Assert.AreEqual(ExpectedOutput, GotOutput);
        }
        // when the token is null
        [TestMethod()]
        public void FetchUserList_2()
        {
            UserProfile UserProfileObj = new UserProfile();
            UserProfileObj.SetToken(null);
            string Query = "demouser";
            ExpectedOutput = "FAIL";
            GotOutput = "";
            try
            {
                UserTemplate<IUserProfile> NormalTemplate = new NormalUserTemplate(UserProfileObj, Query);
                List<IUserProfile> profiles = NormalTemplate.FetchList();
                GotOutput = "Success";
            }
            catch (Exception ex)
            {
                GotOutput = "FAIL";
            }

            Assert.AreEqual(ExpectedOutput, GotOutput);
        }
        // when the query string is null
        [TestMethod()]
        public void FetchUserList_3()
        {
            UserProfile UserProfileObj = new UserProfile();
            UserProfileObj.SetToken("Abc");
            string Query = null;
            ExpectedOutput = "FAIL";
            GotOutput = "";
            try
            {
                UserTemplate<IUserProfile> NormalTemplate = new NormalUserTemplate(UserProfileObj, Query);
                List<IUserProfile> profiles = NormalTemplate.FetchList();
                GotOutput = "Success";
            }
            catch (Exception ex)
            {
                GotOutput = "FAIL";
            }

            Assert.AreEqual(ExpectedOutput, GotOutput);
        }
        // when the token is empty and query is valid
        [TestMethod()]
        public void FetchUserList_4()
        {
            UserProfile UserProfileObj = new UserProfile();
            UserProfileObj.SetToken("");
            string Query = "demouser";
            ExpectedOutput = "FAIL";
            GotOutput = "";
            try
            {
                UserTemplate<IUserProfile> NormalTemplate = new NormalUserTemplate(UserProfileObj, Query);
                List<IUserProfile> profiles = NormalTemplate.FetchList();
                GotOutput = "Success";
            }
            catch (Exception ex)
            {
                GotOutput = "FAIL";
            }

            Assert.AreEqual(ExpectedOutput, GotOutput);
        }
        // when the token is valid and query is empty
        [TestMethod()]
        public void FetchUserList_5()
        {
            // get the token for valid admin email
            UserProfile UserProfileObj = new UserProfile();
            UserProfileObj.SetEmail("demoadmin@demoadmin.com");
            List<string> token = new SecurityDataLayer(UserProfileObj).GetTokenList();
            if (token.Count == 0)
            {
                // token count = 0 means that the account is not logged in or all sessions destroyed
                // generate the token
                UserProfileObj.SetPassword("aA!12345");
                // this will generate the token in db
                new UserActions().LoginUserAction(UserProfileObj);
                token = new SecurityDataLayer(UserProfileObj).GetTokenList();
            }
            UserProfileObj.SetToken(token[token.Count - 1]);
            string Query = "";
            ExpectedOutput = "FAIL";
            GotOutput = "";
            try
            {
                UserTemplate<IUserProfile> NormalTemplate = new NormalUserTemplate(UserProfileObj, Query);
                List<IUserProfile> profiles = NormalTemplate.FetchList();
                GotOutput = "Success";
            }
            catch (Exception ex)
            {
                GotOutput = "FAIL";
            }

            Assert.AreEqual(ExpectedOutput, GotOutput);
        }
        // both are valid
        [TestMethod()]
        public void FetchUserList_6()
        {
            UserProfile UserProfileObj = new UserProfile();
            UserProfileObj.SetEmail("demoadmin@demoadmin.com");
            List<string> token = new SecurityDataLayer(UserProfileObj).GetTokenList();
            if (token.Count == 0)
            {
                // token count = 0 means that the account is not logged in or all sessions destroyed
                // generate the token
                UserProfileObj.SetPassword("aA!12345");
                // this will generate the token in db
                new UserActions().LoginUserAction(UserProfileObj);
                token = new SecurityDataLayer(UserProfileObj).GetTokenList();
            }
            UserProfileObj.SetToken(token[token.Count - 1]);
            string Query = "demouser";
            ExpectedOutput = "Success";
            GotOutput = "";
            try
            {
                UserTemplate<IUserProfile> NormalTemplate = new NormalUserTemplate(UserProfileObj, Query);
                List<IUserProfile> profiles = NormalTemplate.FetchList();
                GotOutput = "Success";
            }
            catch (Exception ex)
            {
                GotOutput = "FAIL";
            }

            Assert.AreEqual(ExpectedOutput, GotOutput);
        }
    }
}
