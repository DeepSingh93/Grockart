using Grockart.CUSTOM_RESPONSE_CLASSES;
using Grockart.DATALAYER;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Grockart.BUSINESSLAYER
{
    [TestClass()]
    public class AllOrdersTemplate_BuildOrder_Tests
    {
        /*
           Input : Valid Token and Valid OrderType
           Output: 1 row affected
        */
        [TestMethod()]
        public void BuildOrder_1()
        {
            IUserProfile UserProfileObj = new UserProfile();
            UserProfileObj.SetEmail("tanishka123@gmail.com");
            List<string> token = new SecurityDataLayer(UserProfileObj).GetTokenList();
            if (token.Count == 0)
            {
                // token count = 0 means that the account is not logged in or all sessions destroyed
                // generate the token
                UserProfileObj.SetPassword("Root@123");
                LoginUserReponse response = new UserActions().LoginUserAction(UserProfileObj);
                token = new SecurityDataLayer(UserProfileObj).GetTokenList();
            }
            UserProfileObj.SetToken(token[token.Count - 1].ToString());
            IOrder OrderObj = new Order();
            OrderObj.SetOrderType("Group");
            OrderDetailsTemplate AllOrdersObj = new AllOrdersTemplate(UserProfileObj, OrderObj);
            List<IOrderBuilderResponse> Output = AllOrdersObj.BuildOrder();
            Assert.AreEqual(Output.Count > 0, true);
        }
        /*
           Input : Null Token
           Output: throws an exception
        */
        [TestMethod()]
        public void BuildOrder_2()
        {
            int ExpectedOutput = -2;
            int GotOutput = 0;
            IUserProfile UserProfileObj = new UserProfile();
            IOrder OrderObj = new Order();
            UserProfileObj.SetToken(null);
            OrderObj.SetOrderType("Group");
            try
            {
                OrderDetailsTemplate AllOrdersObj = new AllOrdersTemplate(UserProfileObj, OrderObj);
                List<IOrderBuilderResponse> Output = AllOrdersObj.BuildOrder();
            }
            catch (Exception)
            {
                GotOutput = -2;
            }
            Assert.AreEqual(GotOutput, ExpectedOutput);
        }
        /*
           Input : Empty Token
           Output: throws an exception
        */
        [TestMethod()]
        public void BuildOrder_3()
        {
            int ExpectedOutput = -2;
            int GotOutput = 0;
            IUserProfile UserProfileObj = new UserProfile();
            IOrder OrderObj = new Order();
            UserProfileObj.SetToken("");
            OrderObj.SetOrderType("Group");
            try
            {
                OrderDetailsTemplate AllOrdersObj = new AllOrdersTemplate(UserProfileObj, OrderObj);
                List<IOrderBuilderResponse> Output = AllOrdersObj.BuildOrder();
            }
            catch (Exception)
            {
                GotOutput = -2;
            }
            Assert.AreEqual(GotOutput, ExpectedOutput);
        }
        /*
           Input : Valid Token but doesnot exist in dbms
           Output: "0" rows affected
        */
        [TestMethod()]
        public void BuildOrder_4()
        {
            IUserProfile UserProfileObj = new UserProfile();
            IOrder OrderObj = new Order();
            UserProfileObj.SetToken("ABCD");
            OrderObj.SetOrderType("Group");
            OrderDetailsTemplate AllOrdersObj = new AllOrdersTemplate(UserProfileObj, OrderObj);
            List<IOrderBuilderResponse> Output = AllOrdersObj.BuildOrder();
            Assert.AreEqual(Output.Count == 0, true);
        }
        /*
           Input : Null OrderType
           Output: throws an exception
        */
        [TestMethod()]
        public void BuildOrder_5()
        {
            int ExpectedOutput = -2;
            int GotOutput = 0;
            IUserProfile UserProfileObj = new UserProfile();
            UserProfileObj.SetEmail("tanishka123@gmail.com");
            List<string> token = new SecurityDataLayer(UserProfileObj).GetTokenList();
            if (token.Count == 0)
            {
                // token count = 0 means that the account is not logged in or all sessions destroyed
                // generate the token
                UserProfileObj.SetPassword("Root@123");
                LoginUserReponse response = new UserActions().LoginUserAction(UserProfileObj);
                token = new SecurityDataLayer(UserProfileObj).GetTokenList();
            }
            UserProfileObj.SetToken(token[token.Count - 1].ToString());
            IOrder OrderObj = new Order();
            OrderObj.SetOrderType(null);
            try
            {
                OrderDetailsTemplate AllOrdersObj = new AllOrdersTemplate(UserProfileObj, OrderObj);
                List<IOrderBuilderResponse> Output = AllOrdersObj.BuildOrder();
            }
            catch (Exception)
            {
                GotOutput = -2;
            }
            Assert.AreEqual(GotOutput, ExpectedOutput);
        }
        /*
           Input : Empty OrderType
           Output: throws an exception
        */
        [TestMethod()]
        public void BuildOrder_6()
        {
            int ExpectedOutput = -2;
            int GotOutput = 0;
            IUserProfile UserProfileObj = new UserProfile();
            UserProfileObj.SetEmail("tanishka123@gmail.com");
            List<string> token = new SecurityDataLayer(UserProfileObj).GetTokenList();
            if (token.Count == 0)
            {
                // token count = 0 means that the account is not logged in or all sessions destroyed
                // generate the token
                UserProfileObj.SetPassword("Root@123");
                LoginUserReponse response = new UserActions().LoginUserAction(UserProfileObj);
                token = new SecurityDataLayer(UserProfileObj).GetTokenList();
            }
            UserProfileObj.SetToken(token[token.Count - 1].ToString());
            IOrder OrderObj = new Order();
            OrderObj.SetOrderType("");
            try
            {
                OrderDetailsTemplate AllOrdersObj = new AllOrdersTemplate(UserProfileObj, OrderObj);
                List<IOrderBuilderResponse> Output = AllOrdersObj.BuildOrder();
            }
            catch (Exception)
            {
                GotOutput = -2;
            }
            Assert.AreEqual(GotOutput, ExpectedOutput);
        }
        /*
           Input : Valid OrderType but doesnot exist in dbms
           Output: "0" rows affected
        */
        [TestMethod()]
        public void BuildOrder_7()
        {
            IUserProfile UserProfileObj = new UserProfile();
            UserProfileObj.SetEmail("tanishka123@gmail.com");
            List<string> token = new SecurityDataLayer(UserProfileObj).GetTokenList();
            if (token.Count == 0)
            {
                // token count = 0 means that the account is not logged in or all sessions destroyed
                // generate the token
                UserProfileObj.SetPassword("Root@123");
                LoginUserReponse response = new UserActions().LoginUserAction(UserProfileObj);
                token = new SecurityDataLayer(UserProfileObj).GetTokenList();
            }
            UserProfileObj.SetToken(token[token.Count - 1].ToString());
            IOrder OrderObj = new Order();
            OrderObj.SetOrderType("ABCD");
            OrderDetailsTemplate AllOrdersObj = new AllOrdersTemplate(UserProfileObj, OrderObj);
            List<IOrderBuilderResponse> Output = AllOrdersObj.BuildOrder();
            Assert.AreEqual(Output.Count == 0, true);
        }
    }
}
