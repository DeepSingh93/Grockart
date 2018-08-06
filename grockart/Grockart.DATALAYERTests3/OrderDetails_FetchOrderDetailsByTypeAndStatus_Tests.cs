using Grockart.BUSINESSLAYER;
using Grockart.CUSTOM_RESPONSE_CLASSES;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;

namespace Grockart.DATALAYER
{
    [TestClass()]
    public class OrderDetails_FetchOrderDetailsByTypeAndStatus_Tests
    {
        [TestMethod()]
        public void OrderDetailsByTypeAndStatus_1()
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
            OrderObj.SetOrderType("Individual");
            OrderObj.SetStatusName("Cancelled");
            IOrderDetailsDataLayer OrderDetailsDataLayerObj = new OrderDetailsDataLayer(UserProfileObj, OrderObj);
            DataSet Output = OrderDetailsDataLayerObj.FetchOrderDetailsByTypeAndStatus();
            Assert.AreEqual(Output.Tables[0].Rows.Count > 0, true);
        }
        [TestMethod()]
        public void OrderDetailsByTypeAndStatus_2()
        {
            int ExpectedOutput = -2;
            int GotOutput = 0;
            IUserProfile UserProfileObj = new UserProfile();
            IOrder OrderObj = new Order();
            UserProfileObj.SetToken(null);
            OrderObj.SetOrderType("Individual");
            OrderObj.SetStatusName("Cancelled");
            IOrderDetailsDataLayer OrderDetailsDataLayerObj = new OrderDetailsDataLayer(UserProfileObj, OrderObj);
            try
            {
                DataSet Output = OrderDetailsDataLayerObj.FetchOrderDetailsByTypeAndStatus();
            }
            catch (Exception)
            {
                GotOutput = -2;
            }
            Assert.AreEqual(GotOutput, ExpectedOutput);
        }
        [TestMethod()]
        public void OrderDetailsByTypeAndStatus_3()
        {
            int ExpectedOutput = -2;
            int GotOutput = 0;
            IUserProfile UserProfileObj = new UserProfile();
            IOrder OrderObj = new Order();
            UserProfileObj.SetToken("");
            OrderObj.SetOrderType("Individual");
            OrderObj.SetStatusName("Cancelled");
            IOrderDetailsDataLayer OrderDetailsDataLayerObj = new OrderDetailsDataLayer(UserProfileObj, OrderObj);
            try
            {
                DataSet Output = OrderDetailsDataLayerObj.FetchOrderDetailsByTypeAndStatus();
            }
            catch (Exception)
            {
                GotOutput = -2;
            }
            Assert.AreEqual(GotOutput, ExpectedOutput);
        }
        [TestMethod()]
        public void OrderDetailsByTypeAndStatus_4()
        {
            IUserProfile UserProfileObj = new UserProfile();
            IOrder OrderObj = new Order();
            UserProfileObj.SetToken("ABCD");
            OrderObj.SetOrderType("Individual");
            OrderObj.SetStatusName("Cancelled");
            IOrderDetailsDataLayer OrderDetailsDataLayerObj = new OrderDetailsDataLayer(UserProfileObj, OrderObj);
            DataSet Output = OrderDetailsDataLayerObj.FetchOrderDetailsByTypeAndStatus();
            Assert.AreEqual(Output.Tables[0].Rows.Count == 0, true);
        }
        [TestMethod()]
        public void OrderDetailsByTypeAndStatus_5()
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
            IOrderDetailsDataLayer OrderDetailsDataLayerObj = new OrderDetailsDataLayer(UserProfileObj, OrderObj);
            try
            {
                DataSet Output = OrderDetailsDataLayerObj.FetchOrderDetailsByTypeAndStatus();
            }
            catch (Exception)
            {
                GotOutput = -2;
            }
            Assert.AreEqual(GotOutput, ExpectedOutput);
        }
        [TestMethod()]
        public void OrderDetailsByTypeAndStatus_6()
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
            IOrderDetailsDataLayer OrderDetailsDataLayerObj = new OrderDetailsDataLayer(UserProfileObj, OrderObj);
            try
            {
                DataSet Output = OrderDetailsDataLayerObj.FetchOrderDetailsByTypeAndStatus();
            }
            catch (Exception)
            {
                GotOutput = -2;
            }
            Assert.AreEqual(GotOutput, ExpectedOutput);
        }
        [TestMethod()]
        public void OrderDetailsByTypeAndStatus_7()
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
            IOrderDetailsDataLayer OrderDetailsDataLayerObj = new OrderDetailsDataLayer(UserProfileObj, OrderObj);
            DataSet Output = OrderDetailsDataLayerObj.FetchOrderDetailsByTypeAndStatus();
            Assert.AreEqual(Output.Tables[0].Rows.Count == 0, true);
        }
        [TestMethod()]
        public void OrderDetailsByTypeAndStatus_8()
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
            OrderObj.SetOrderType("Individual");
            OrderObj.SetStatusName(null);
            IOrderDetailsDataLayer OrderDetailsDataLayerObj = new OrderDetailsDataLayer(UserProfileObj, OrderObj);
            try
            {
                DataSet Output = OrderDetailsDataLayerObj.FetchOrderDetailsByTypeAndStatus();
            }
            catch (Exception)
            {
                GotOutput = -2;
            }
            Assert.AreEqual(GotOutput, ExpectedOutput);
        }
        [TestMethod()]
        public void OrderDetailsByTypeAndStatus_9()
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
            OrderObj.SetOrderType("Individual");
            OrderObj.SetStatusName("");
            IOrderDetailsDataLayer OrderDetailsDataLayerObj = new OrderDetailsDataLayer(UserProfileObj, OrderObj);
            try
            {
                DataSet Output = OrderDetailsDataLayerObj.FetchOrderDetailsByTypeAndStatus();
            }
            catch (Exception)
            {
                GotOutput = -2;
            }
            Assert.AreEqual(GotOutput, ExpectedOutput);
        }
        [TestMethod()]
        public void OrderDetailsByTypeAndStatus_10()
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
            OrderObj.SetOrderType("Individual");
            OrderObj.SetStatusName("ABCD");
            IOrderDetailsDataLayer OrderDetailsDataLayerObj = new OrderDetailsDataLayer(UserProfileObj, OrderObj);
            DataSet Output = OrderDetailsDataLayerObj.FetchOrderDetailsByTypeAndStatus();
            Assert.AreEqual(Output.Tables[0].Rows.Count == 0, true);
        }
    }            
}