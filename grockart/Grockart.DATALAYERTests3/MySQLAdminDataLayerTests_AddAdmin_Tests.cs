using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Grockart.CUSTOM_RESPONSE_CLASSES;
using Grockart.DATALAYER;

namespace Grockart.DATALAYER
{
    [TestClass()]
    public class MySQLAdminDataLayerTests_AddAdmin_Tests
    {
        /*
       * Input : string Email
       * Output : API_RESPONSE (OK, NOT_OK)
       * Function Definition : This function will elevate the particular user to admin 
       * 
       * Cases covered 
       * 1. Email = null
       * 2. Email = empty
       * 3. Email is valid
       */
        // email is null
        [TestMethod()]
        public void AddAdmin_1()
        {
            IUserProfile UserProfileObj = new UserProfile();
            UserProfileObj.SetEmail(null);
            APIResponse ExpectedOutput = APIResponse.NOT_OK;
            APIResponse GotOutput = APIResponse.NOT_OK;
            try
            {
                UserTemplate<IUserProfile> AdminTemplate = new AdminUserTemplate(UserProfileObj);
                GotOutput = AdminTemplate.Add();
            }
            catch (Exception)
            {
                GotOutput = APIResponse.NOT_OK;
            }
            Assert.AreEqual(ExpectedOutput, GotOutput);
        }
        // email is empty
        [TestMethod()]
        public void AddAdmin_2()
        {
            IUserProfile UserProfileObj = new UserProfile();
            UserProfileObj.SetEmail("");
            APIResponse ExpectedOutput = APIResponse.NOT_OK;
            APIResponse GotOutput = APIResponse.NOT_OK;
            try
            {
                UserTemplate<IUserProfile> AdminTemplate = new AdminUserTemplate(UserProfileObj);
                GotOutput = AdminTemplate.Add();
            }
            catch (Exception)
            {
                GotOutput = APIResponse.NOT_OK;
            }
            Assert.AreEqual(ExpectedOutput, GotOutput);
        }
        // email is valid
        [TestMethod()]
        public void AddAdmin_3()
        {
            IUserProfile UserProfileObj = new UserProfile();
            UserProfileObj.SetEmail("demouser@demouser.com");
            APIResponse ExpectedOutput = APIResponse.OK;
            APIResponse GotOutput = APIResponse.NOT_OK;
            UserTemplate<IUserProfile> AdminTemplate = new AdminUserTemplate(UserProfileObj);
            try
            {
                GotOutput = AdminTemplate.Add();
            }
            catch (Exception)
            {
                GotOutput = APIResponse.NOT_OK;
            }
            Assert.AreEqual(ExpectedOutput, GotOutput);
            // remove the admin rights
            AdminTemplate.Remove();
        }
    }
}
