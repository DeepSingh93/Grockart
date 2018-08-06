using Grockart.BUSINESSLAYER;
using Grockart.CUSTOM_RESPONSE_CLASSES;
using Grockart.DATALAYER;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grockart.DATALAYER
{
    [TestClass()]
    public class MySQLUserDataLayer_AuthenticateUser_Tests
    {
        /*
      * Input : object token
      * Output : boolean
      * Function Definition : This function authenticates whether the input token is valid or not ?
      * 
      * Cases covered 
      * 1 : Token is null
      * 2 : TOken is empty
      * 3 : Invalid token
      * 4 : Valid token
      */
        [TestMethod()]
        public void AuthenticateUser_1()
        {
            UserProfile UserProfileObj = new UserProfile();
            UserProfileObj.SetToken(null);
            DataSet GotOutput;
            try
            {
                GotOutput = new SecurityDataLayer(UserProfileObj).GetUserToken();
            }
            catch (Exception)
            {
                GotOutput = null;
            }
            Assert.AreEqual(null, GotOutput);
        }
        [TestMethod()]
        public void AuthenticateUser_2()
        {
            UserProfile UserProfileObj = new UserProfile();
            UserProfileObj.SetToken("");
            DataSet GotOutput;
            try
            {
                GotOutput = new SecurityDataLayer(UserProfileObj).GetUserToken();
            }
            catch (Exception)
            {
                GotOutput = null;
            }
            Assert.AreEqual(null, GotOutput);
        }
        [TestMethod()]
        public void AuthenticateUser_3()
        {
            UserProfile UserProfileObj = new UserProfile();
            UserProfileObj.SetToken("absca");
            DataSet GotOutput;
            try
            {
                GotOutput = new SecurityDataLayer(UserProfileObj).GetUserToken();
            }
            catch (Exception)
            {
                GotOutput = null;
            }
            Assert.AreEqual(GotOutput.Tables[0].Rows[0][0].ToString(), "0");
        }
        [TestMethod()]
        public void AuthenticateUser_4()
        {
            UserProfile UserProfileObj = new UserProfile();
            UserProfileObj.SetEmail("demoadmin@demoadmin.com");
            List<string> token = new SecurityDataLayer(UserProfileObj).GetTokenList();
            if (token.Count == 0)
            {
                // token count = 0 means that the account is not logged in or all sessions destroyed
                // generate the token
                UserProfileObj.SetPassword("aA!12345");
                LoginUserReponse response = new UserActions().LoginUserAction(UserProfileObj);
                token = new SecurityDataLayer(UserProfileObj).GetTokenList();
            }
            UserProfileObj.SetToken(token[token.Count - 1].ToString());
            DataSet GotOutput;
            try
            {
                GotOutput = new SecurityDataLayer(UserProfileObj).GetUserToken();
            }
            catch (Exception)
            {
                GotOutput = null;
            }
            Assert.AreEqual(int.Parse(GotOutput.Tables[0].Rows[0][0].ToString()) > 0, true);
        }

    }
}
