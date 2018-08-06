using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Grockart.CUSTOM_RESPONSE_CLASSES;

namespace Grockart.DATALAYER
{
    public class MySQLAdminDataLayerTests_RemoveAdmin_Tests
    {
        /*
        * Input : string Email
        * Output : API_RESPONSE (OK, NOT_OK)
        * Function Definition : This function will remove a particular user
        * 
        * Cases covered 
        * 1. Email = null
        * 2. Email = empty
        * 3. Email is valid
        */
        // email is null
        [TestMethod()]
        public void RemoveAdmin_1()
        {
            IUserProfile UserProfileObj = new UserProfile();
            UserProfileObj.SetEmail(null);
            APIResponse ExpectedOutput = APIResponse.NOT_OK;
            APIResponse GotOutput = APIResponse.NOT_OK;
            try
            {
                UserTemplate<IUserProfile> AdminTemplate = new AdminUserTemplate(UserProfileObj);
                GotOutput = AdminTemplate.Remove();
            }
            catch (Exception)
            {
                GotOutput = APIResponse.NOT_OK;
            }
            Assert.AreEqual(ExpectedOutput, GotOutput);
        }
        // email is empty
        [TestMethod()]
        public void RemoveAdmin_2()
        {
            IUserProfile UserProfileObj = new UserProfile();
            UserProfileObj.SetEmail("");
            APIResponse ExpectedOutput = APIResponse.NOT_OK;
            APIResponse GotOutput = APIResponse.NOT_OK;
            try
            {
                UserTemplate<IUserProfile> AdminTemplate = new AdminUserTemplate(UserProfileObj);
                GotOutput = AdminTemplate.Remove();
            }
            catch (Exception)
            {
                GotOutput = APIResponse.NOT_OK;
            }
            Assert.AreEqual(ExpectedOutput, GotOutput);
        }
        // email is valid
        [TestMethod()]
        public void RemoveAdmin_3()
        {
            IUserProfile UserProfileObj = new UserProfile();
            UserProfileObj.SetEmail("demoadmin@demoadmin.com");
            APIResponse ExpectedOutput = APIResponse.OK;
            APIResponse GotOutput = APIResponse.NOT_OK;
            UserTemplate<IUserProfile> AdminTemplate = new AdminUserTemplate(UserProfileObj);
            try
            {
                GotOutput = AdminTemplate.Remove();
            }
            catch (Exception)
            {
                GotOutput = APIResponse.NOT_OK;
            }
            // re-add the removed admin to admin
            AdminTemplate.Add();
            Assert.AreEqual(ExpectedOutput, GotOutput);
        }
    }
}
