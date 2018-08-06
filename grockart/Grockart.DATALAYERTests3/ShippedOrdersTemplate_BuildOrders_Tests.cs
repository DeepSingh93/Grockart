using Grockart.BUSINESSLAYER;
using Grockart.CUSTOM_RESPONSE_CLASSES;
using Grockart.DATALAYER;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grockart.BUSINESSLAYER
{
    [TestClass()]
    public class ShippedOrdersTemplate_BuildOrders_Tests
    {
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
            OrderObj.SetStatusName("Shipped");
            OrderDetailsTemplate ShippedOrdersObj = new ShippedOrdersTemplate(UserProfileObj, OrderObj);
            List<IOrderBuilderResponse> Output = ShippedOrdersObj.BuildOrder();
            Assert.AreEqual(Output.Count > 0, true);
        }
        [TestMethod()]
        public void BuildOrder_2()
        {
            int ExpectedOutput = -2;
            int GotOutput = 0;
            IUserProfile UserProfileObj = new UserProfile();
            IOrder OrderObj = new Order();
            UserProfileObj.SetToken(null);
            OrderObj.SetOrderType("Group");
            OrderObj.SetStatusName("Shipped");
            try
            {
                OrderDetailsTemplate ShippedOrdersObj = new ShippedOrdersTemplate(UserProfileObj, OrderObj);
                List<IOrderBuilderResponse> Output = ShippedOrdersObj.BuildOrder();
            }
            catch (Exception)
            {
                GotOutput = -2;
            }
            Assert.AreEqual(GotOutput, ExpectedOutput);
        }
        [TestMethod()]
        public void BuildOrder_3()
        {
            int ExpectedOutput = -2;
            int GotOutput = 0;
            IUserProfile UserProfileObj = new UserProfile();
            IOrder OrderObj = new Order();
            UserProfileObj.SetToken("");
            OrderObj.SetOrderType("Group");
            OrderObj.SetStatusName("Shipped");
            try
            {
                OrderDetailsTemplate ShippedOrdersObj = new ShippedOrdersTemplate(UserProfileObj, OrderObj);
                List<IOrderBuilderResponse> Output = ShippedOrdersObj.BuildOrder();
            }
            catch (Exception)
            {
                GotOutput = -2;
            }
            Assert.AreEqual(GotOutput, ExpectedOutput);
        }
        [TestMethod()]
        public void BuildOrder_4()
        {
            IUserProfile UserProfileObj = new UserProfile();
            IOrder OrderObj = new Order();
            UserProfileObj.SetToken("ABCD");
            OrderObj.SetOrderType("Group");
            OrderObj.SetStatusName("Shipped");
            OrderDetailsTemplate ShippedOrdersObj = new ShippedOrdersTemplate(UserProfileObj, OrderObj);
            List<IOrderBuilderResponse> Output = ShippedOrdersObj.BuildOrder();
            Assert.AreEqual(Output.Count == 0, true);
            }
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
            OrderObj.SetStatusName("Shipped");
            try
            {
                OrderDetailsTemplate ShippedOrdersObj = new ShippedOrdersTemplate(UserProfileObj, OrderObj);
                List<IOrderBuilderResponse> Output = ShippedOrdersObj.BuildOrder();
            }
            catch (Exception)
            {
                GotOutput = -2;
            }
            Assert.AreEqual(GotOutput, ExpectedOutput);
        }
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
            OrderObj.SetStatusName("Shipped");
            try
            {
                OrderDetailsTemplate ShippedOrdersObj = new ShippedOrdersTemplate(UserProfileObj, OrderObj);
                List<IOrderBuilderResponse> Output = ShippedOrdersObj.BuildOrder();
            }
            catch (Exception)
            {
                GotOutput = -2;
            }
            Assert.AreEqual(GotOutput, ExpectedOutput);
        }
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
            OrderObj.SetStatusName("Shipped");
            OrderDetailsTemplate ShippedOrdersObj = new ShippedOrdersTemplate(UserProfileObj, OrderObj);
            List<IOrderBuilderResponse> Output = ShippedOrdersObj.BuildOrder();
            Assert.AreEqual(Output.Count == 0, true);
        }
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
                OrderDetailsTemplate ShippedOrdersObj = new ShippedOrdersTemplate(UserProfileObj, OrderObj);
                List<IOrderBuilderResponse> Output = ShippedOrdersObj.BuildOrder();
            }
            catch (Exception)
            {
                GotOutput = -2;
            }
            Assert.AreEqual(GotOutput, ExpectedOutput);
        }
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
                OrderDetailsTemplate ShippedOrdersObj = new ShippedOrdersTemplate(UserProfileObj, OrderObj);
                List<IOrderBuilderResponse> Output = ShippedOrdersObj.BuildOrder();
            }
            catch (Exception)
            {
                GotOutput = -2;
            }
            Assert.AreEqual(GotOutput, ExpectedOutput);
        }
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
            OrderDetailsTemplate ShippedOrdersObj = new ShippedOrdersTemplate(UserProfileObj, OrderObj);
            List<IOrderBuilderResponse> Output = ShippedOrdersObj.BuildOrder();
            Assert.AreEqual(Output.Count == 0, true);
        }
    }
}

