using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Grockart.CUSTOM_RESPONSE_CLASSES;
using Grockart.BUSINESSLAYER;
using Grockart.DATALAYER;

namespace Grockart.DATALAYER
{
    public class MySQLAdminDataLayerTests_FetchAdminList_Tests
    {
        /*
        * Input : UserProfile Token
        * Output : The list of users with admin rights
        * Function Definition : This function returns back the list of users who have admin rights
        * 
        * Cases covered 
        * 1. When the input token is null
        * 2. When the input token has an invalid token (token deleted or token not active)
        * 3. When the input token is valid 
        */
        private string ExpectedOutput = "";
        private string GotOutput = "";
        [TestMethod()]
        public void FetchAdminListTest_1()
        {
            ExpectedOutput = "Invalid Arguments : Token is null";
            GotOutput = "";
            try
            {
                IUserProfile UserProfileObj = new UserProfile();
                UserProfileObj.SetToken(null);
                UserTemplate<IUserProfile> AdminUserTemplate = new AdminUserTemplate(UserProfileObj);
                List<IUserProfile> Output = AdminUserTemplate.FetchList();
                GotOutput = "SUCCESS";
            }
            catch (Exception ex)
            {
                GotOutput = ex.Message.ToString();
            }

            Assert.AreEqual(ExpectedOutput, GotOutput);
        }
        // case when the input token is invalid
        // here the rowcount of the list should be 0
        [TestMethod()]
        public void FetchAdminListTest_2()
        {
            int ExpectedRowCount = 0;
            int GotRowCount = -1;
            try
            {
                UserProfile UserProfileObj = new UserProfile();
                UserProfileObj.SetToken("abcdef12345");
                UserTemplate<IUserProfile> AdminUserTemplate = new AdminUserTemplate(UserProfileObj);
                List<IUserProfile> Output = AdminUserTemplate.FetchList();
                GotRowCount = Output.Count;
            }
            catch (Exception)
            {
                GotRowCount = -1;
            }
            Assert.AreEqual(ExpectedRowCount, GotRowCount);
        }
        // fetching the valid token with admin rights
        // it should return back the users list
        [TestMethod()]
        public void FetchAdminListTest_3()
        {
            UserProfile UserProfileObj = new UserProfile();
            UserProfileObj.SetEmail("demoadmin@demoadmin.com");
            List<string> token = new SecurityDataLayer(UserProfileObj).GetTokenList();
            if (token.Count == 0)
            {
                // token count = 0 means that the account is not logged in or all sessions destroyed
                // generate the token
                UserProfileObj.SetPassword("aA!12345");
                // login the user
                new UserActions().LoginUserAction(UserProfileObj);
                token = new SecurityDataLayer(UserProfileObj).GetTokenList();
            }
            UserProfileObj.SetToken(token[token.Count - 1].ToString());
            UserTemplate<IUserProfile> AdminUserTemplate = new AdminUserTemplate(UserProfileObj);
            List<IUserProfile> Output = AdminUserTemplate.FetchList();
            Assert.AreEqual(Output.Count > 0, true);
        }
    }
}
