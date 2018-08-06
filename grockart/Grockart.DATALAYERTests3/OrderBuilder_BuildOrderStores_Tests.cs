using Grockart.CUSTOM_RESPONSE_CLASSES;
using Grockart.DATALAYER;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Grockart.BUSINESSLAYER
{
    [TestClass()]
    public class OrderBuilder_BuildOrderStores_Tests
    {
        [TestMethod()]
        public void BuildOrderStores_1()
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
            OrderObj.SetOrderID(32);
            OrderBuilderAbstract OrderBuilderObj = new OrderBuilder(UserProfileObj, OrderObj);
            List<string> StoreList = OrderBuilderObj.BuildOrderStores();
            Assert.AreEqual(StoreList.Count > 0, true);
        }
        [TestMethod()]
        public void BuildOrderStores_2()
        {
            int ExpectedOutput = -2;
            int GotOutput = 0;
            IUserProfile UserProfileObj = new UserProfile();
            IOrder OrderObj = new Order();
            UserProfileObj.SetToken(null);
            OrderObj.SetOrderType("Group");
            OrderObj.SetOrderID(32);
            OrderBuilderAbstract OrderBuilderObj = new OrderBuilder(UserProfileObj, OrderObj);
            try
            {
                List<string> StoreList = OrderBuilderObj.BuildOrderStores();
            }
            catch (Exception)
            {
                GotOutput = -2;
            }
            Assert.AreEqual(GotOutput, ExpectedOutput);
        }
        [TestMethod()]
        public void BuildOrderStores_3()
        {
            int ExpectedOutput = -2;
            int GotOutput = 0;
            IUserProfile UserProfileObj = new UserProfile();
            IOrder OrderObj = new Order();
            UserProfileObj.SetToken("");
            OrderObj.SetOrderType("Group");
            OrderObj.SetOrderID(32);
            OrderBuilderAbstract OrderBuilderObj = new OrderBuilder(UserProfileObj, OrderObj);
            try
            {
                List<string> StoreList = OrderBuilderObj.BuildOrderStores();
            }
            catch (Exception)
            {
                GotOutput = -2;
            }
            Assert.AreEqual(GotOutput, ExpectedOutput);
        }
        [TestMethod()]
        public void BuildOrderStores_4()
        {
            IUserProfile UserProfileObj = new UserProfile();
            IOrder OrderObj = new Order();
            UserProfileObj.SetToken("ABCD");
            OrderObj.SetOrderType("Group");
            OrderObj.SetOrderID(32);
            OrderBuilderAbstract OrderBuilderObj = new OrderBuilder(UserProfileObj, OrderObj);
            List<string> StoreList = OrderBuilderObj.BuildOrderStores();
            Assert.AreEqual(StoreList.Count == 0, true);
        }
        [TestMethod()]
        public void BuildOrderStores_5()
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
            OrderObj.SetOrderID(32);
            OrderBuilderAbstract OrderBuilderObj = new OrderBuilder(UserProfileObj, OrderObj);
            try
            {
                List<string> StoreList = OrderBuilderObj.BuildOrderStores();
            }
            catch (Exception)
            {
                GotOutput = -2;
            }
            Assert.AreEqual(GotOutput, ExpectedOutput);
        }
        [TestMethod()]
        public void BuildOrderStores_6()
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
            OrderObj.SetOrderID(32);
            OrderBuilderAbstract OrderBuilderObj = new OrderBuilder(UserProfileObj, OrderObj);
            try
            {
                List<string> StoreList = OrderBuilderObj.BuildOrderStores();
            }
            catch (Exception)
            {
                GotOutput = -2;
            }
            Assert.AreEqual(GotOutput, ExpectedOutput);
        }
        [TestMethod()]
        public void BuildOrderStores_7()
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
            OrderObj.SetOrderID(32);
            OrderBuilderAbstract OrderBuilderObj = new OrderBuilder(UserProfileObj, OrderObj);
            List<string> StoreList = OrderBuilderObj.BuildOrderStores();
            Assert.AreEqual(StoreList.Count == 0, true);
        }
        [TestMethod()]
        public void BuildOrderStores_8()
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
            OrderObj.SetOrderID(-1);
            OrderBuilderAbstract OrderBuilderObj = new OrderBuilder(UserProfileObj, OrderObj);
            try
            {
                List<string> StoreList = OrderBuilderObj.BuildOrderStores();
            }
            catch (Exception)
            {
                GotOutput = -2;
            }
            Assert.AreEqual(GotOutput, ExpectedOutput);
        }
        [TestMethod()]
        public void BuildOrderStores_9()
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
            OrderObj.SetOrderID(11111);
            OrderBuilderAbstract OrderBuilderObj = new OrderBuilder(UserProfileObj, OrderObj);
            List<string> StoreList = OrderBuilderObj.BuildOrderStores();
            Assert.AreEqual(StoreList.Count == 0, true);
        }
    }
}
