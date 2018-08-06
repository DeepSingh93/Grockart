using Grockart.CUSTOM_RESPONSE_CLASSES;
using Grockart.DATALAYER;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Grockart.BUSINESSLAYER
{
    [TestClass()]
    public class CancelledOrdersTemplate_OrderBuilders_Tests
    {
        /*
           Input : Valid Token, OrderType, StatusName
           Output: 1 or more than one row affected
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
            OrderObj.SetStatusName("Cancelled");
            OrderDetailsTemplate CancelledOrdersObj = new CancelledOrdersTemplate(UserProfileObj, OrderObj);
            List<IOrderBuilderResponse> Output = CancelledOrdersObj.BuildOrder();
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
            OrderObj.SetStatusName("Cancelled");
            try
            {
                OrderDetailsTemplate CancelledOrdersObj = new CancelledOrdersTemplate(UserProfileObj, OrderObj);
                List<IOrderBuilderResponse> Output = CancelledOrdersObj.BuildOrder();
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
            OrderObj.SetStatusName("Cancelled");
            try
            {
                OrderDetailsTemplate CancelledOrdersObj = new CancelledOrdersTemplate(UserProfileObj, OrderObj);
                List<IOrderBuilderResponse> Output = CancelledOrdersObj.BuildOrder();
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
            OrderObj.SetStatusName("Cancelled");
            OrderDetailsTemplate CancelledOrdersObj = new CancelledOrdersTemplate(UserProfileObj, OrderObj);
            List<IOrderBuilderResponse> Output = CancelledOrdersObj.BuildOrder();
            Assert.AreEqual(Output.Count == 0, true);
        }
        /*
           Input : Valid Token, Null OrderType and valid 
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
            OrderObj.SetStatusName("Cancelled");
            try
            {
                OrderDetailsTemplate CancelledOrdersObj = new CancelledOrdersTemplate(UserProfileObj, OrderObj);
                List<IOrderBuilderResponse> Output = CancelledOrdersObj.BuildOrder();
            }
            catch (Exception)
            {
                GotOutput = -2;
            }
            Assert.AreEqual(GotOutput, ExpectedOutput);
        }
        /*
           Input : Valid Token, Null OrderType and valid StatusName
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
            OrderObj.SetStatusName("Cancelled");
            try
            {
                OrderDetailsTemplate CancelledOrdersObj = new CancelledOrdersTemplate(UserProfileObj, OrderObj);
                List<IOrderBuilderResponse> Output = CancelledOrdersObj.BuildOrder();
            }
            catch (Exception)
            {
                GotOutput = -2;
            }
            Assert.AreEqual(GotOutput, ExpectedOutput);
        }
        /*
           Input : Valid Token, valid OrderType but doesnot exit in database
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
            OrderObj.SetStatusName("Cancelled");
            OrderDetailsTemplate CancelledOrdersObj = new CancelledOrdersTemplate(UserProfileObj, OrderObj);
            List<IOrderBuilderResponse> Output = CancelledOrdersObj.BuildOrder();
            Assert.AreEqual(Output.Count == 0, true);
        }
        /*
         Input : Valid Token, valid OrderType and Null StatusName
         Output: throws an exception
      */
        [TestMethod()]
        public void BuildOrder_8()
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
            OrderObj.SetOrderType("Group");
            OrderObj.SetStatusName(null);
            try
            {
                OrderDetailsTemplate CancelledOrdersObj = new CancelledOrdersTemplate(UserProfileObj, OrderObj);
                List<IOrderBuilderResponse> Output = CancelledOrdersObj.BuildOrder();
            }
            catch (Exception)
            {
                GotOutput = -2;
            }
            Assert.AreEqual(GotOutput, ExpectedOutput);
        }
        /*
         Input : Valid Token, valid OrderType and Empty StatusName
         Output: throws an exception
      */
        [TestMethod()]
        public void BuildOrder_9()
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
            OrderObj.SetOrderType("Group");
            OrderObj.SetStatusName("");
            try
            {
                OrderDetailsTemplate CancelledOrdersObj = new CancelledOrdersTemplate(UserProfileObj, OrderObj);
                List<IOrderBuilderResponse> Output = CancelledOrdersObj.BuildOrder();
            }
            catch (Exception)
            {
                GotOutput = -2;
            }
            Assert.AreEqual(GotOutput, ExpectedOutput);
        }
        /*
         Input : Valid Token, valid OrderType and valid StatusName but doesnot exits in dbms
         Output: "0" rows affected
      */
        [TestMethod()]
        public void BuildOrder_10()
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
            OrderObj.SetStatusName("ABCD");
            OrderDetailsTemplate CancelledOrdersObj = new CancelledOrdersTemplate(UserProfileObj, OrderObj);
            List<IOrderBuilderResponse> Output = CancelledOrdersObj.BuildOrder();
            Assert.AreEqual(Output.Count == 0, true);
        }
    }
}

