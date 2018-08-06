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
    public class GroupOrderTemplate_OrderCreated_Tests
    {
        [TestMethod()]
        public void CreatedOrders_1()
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
            OrderObj.SetStatusName("Order_Created");
            OrderTypeTemplate GroupOrderObj = new GroupOrderTemplate(UserProfileObj, OrderObj);
            List<IOrderBuilderResponse> Output = GroupOrderObj.FetchOrderCreatedID();
            Assert.AreEqual(Output.Count>0, true);
        }
        [TestMethod()]
        public void CreatedOrders_2()
        {
            int ExpectedOutput = -2;
            int GotOutput = 0;
            IUserProfile UserProfileObj = new UserProfile();
            IOrder OrderObj = new Order();
            OrderObj.SetOrderType("Group");
            OrderObj.SetStatusName("Order_Created");
            UserProfileObj.SetToken("");
            try
            {
                OrderTypeTemplate GroupOrderObj = new GroupOrderTemplate(UserProfileObj, OrderObj);
                List<IOrderBuilderResponse> Output = GroupOrderObj.FetchOrderCreatedID();
            }
            catch (Exception)
            {
                GotOutput = -2;
            }
            Assert.AreEqual(GotOutput, ExpectedOutput);
        }
        [TestMethod()]
        public void CreatedOrders_3()
        {
            int ExpectedOutput = -2;
            int GotOutput = 0;
            IUserProfile UserProfileObj = new UserProfile();
            IOrder OrderObj = new Order();
            OrderObj.SetOrderType("Group");
            OrderObj.SetStatusName("Order_Created");
            UserProfileObj.SetToken(null);
            try
            {
                OrderTypeTemplate GroupOrderObj = new GroupOrderTemplate(UserProfileObj, OrderObj);
                List<IOrderBuilderResponse> Output = GroupOrderObj.FetchOrderCreatedID();
            }
            catch (Exception)
            {
                GotOutput = -2;
            }
            Assert.AreEqual(GotOutput, ExpectedOutput);
        }
        [TestMethod()]
        public void CreatedOrders_4()
        {
            IUserProfile UserProfileObj = new UserProfile();
            IOrder OrderObj = new Order();
            OrderObj.SetOrderType("Group");
            UserProfileObj.SetToken("ABCD");
            OrderObj.SetStatusName("Order_Created");
            OrderTypeTemplate GroupOrderObj = new GroupOrderTemplate(UserProfileObj, OrderObj);
            List<IOrderBuilderResponse> Output = GroupOrderObj.FetchOrderCreatedID();
            Assert.AreEqual(Output.Count == 0, true);
        }
    }
}

