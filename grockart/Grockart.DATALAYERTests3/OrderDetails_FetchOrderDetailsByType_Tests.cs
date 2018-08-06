using Grockart.BUSINESSLAYER;
using Grockart.CUSTOM_RESPONSE_CLASSES;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;

namespace Grockart.DATALAYER
{
    [TestClass()]
    public class OrderDetails_FetchOrderDetailsByType_Tests
    {
        [TestMethod()]
        public void OrderDetailsByType_1()
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
            IOrderDetailsDataLayer OrderDetailsDataLayerObj = new OrderDetailsDataLayer(UserProfileObj, OrderObj); ;
            DataSet Output = OrderDetailsDataLayerObj.FetchOrderDetailsByType();
            Assert.AreEqual(Output.Tables[0].Rows.Count > 0, true);
        }
        [TestMethod()]
        public void OrderDetailsByType_2()
        {
            int ExpectedOutput = -2;
            int GotOutput = 0;
            IUserProfile UserProfileObj = new UserProfile();
            IOrder OrderObj = new Order();
            UserProfileObj.SetToken(null);
            OrderObj.SetOrderType("Group");
            IOrderDetailsDataLayer OrderDetailsDataLayerObj = new OrderDetailsDataLayer(UserProfileObj, OrderObj);
            try
            {
                DataSet Output = OrderDetailsDataLayerObj.FetchOrderDetailsByType();
            }
            catch (Exception)
            {
                GotOutput = -2;
            }
            Assert.AreEqual(GotOutput, ExpectedOutput);
        }
        [TestMethod()]
        public void OrderDetailsByType_3()
        {
            int ExpectedOutput = -2;
            int GotOutput = 0;
            IUserProfile UserProfileObj = new UserProfile();
            IOrder OrderObj = new Order();
            UserProfileObj.SetToken("");
            OrderObj.SetOrderType("Group");
            IOrderDetailsDataLayer OrderDetailsDataLayerObj = new OrderDetailsDataLayer(UserProfileObj, OrderObj);
            try
            {
                DataSet Output = OrderDetailsDataLayerObj.FetchOrderDetailsByType();
            }
            catch (Exception)
            {
                GotOutput = -2;
            }
            Assert.AreEqual(GotOutput, ExpectedOutput);
        }
        [TestMethod()]
        public void OrderDetailsByType_4()
        {
            IUserProfile UserProfileObj = new UserProfile();
            IOrder OrderObj = new Order();
            UserProfileObj.SetToken("ABCD");
            OrderObj.SetOrderType("Group");
            IOrderDetailsDataLayer OrderDetailsDataLayerObj = new OrderDetailsDataLayer(UserProfileObj, OrderObj);
            DataSet Output = OrderDetailsDataLayerObj.FetchOrderDetailsByType();
            Assert.AreEqual(Output.Tables[0].Rows.Count == 0, true);
        }
        [TestMethod()]
        public void OrderDetailsByType_5()
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
            IOrderDetailsDataLayer OrderDetailsDataLayerObj = new OrderDetailsDataLayer(UserProfileObj, OrderObj);
            try
            {
                DataSet Output = OrderDetailsDataLayerObj.FetchOrderDetailsByType();
            }
            catch (Exception)
            {
                GotOutput = -2;
            }
            Assert.AreEqual(GotOutput, ExpectedOutput);
        }
        [TestMethod()]
        public void OrderDetailsByType_6()
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
            IOrderDetailsDataLayer OrderDetailsDataLayerObj = new OrderDetailsDataLayer(UserProfileObj, OrderObj);
            try
            {
                DataSet Output = OrderDetailsDataLayerObj.FetchOrderDetailsByType();
            }
            catch (Exception)
            {
                GotOutput = -2;
            }
            Assert.AreEqual(GotOutput, ExpectedOutput);
        }
        [TestMethod()]
        public void OrderDetailsByType_7()
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
            IOrderDetailsDataLayer OrderDetailsDataLayerObj = new OrderDetailsDataLayer(UserProfileObj, OrderObj);
            DataSet Output = OrderDetailsDataLayerObj.FetchOrderDetailsByType();
            Assert.AreEqual(Output.Tables[0].Rows.Count == 0, true);
        }
    }
}
