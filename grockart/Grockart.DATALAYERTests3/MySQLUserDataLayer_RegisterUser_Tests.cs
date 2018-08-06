using Grockart.CUSTOM_RESPONSE_CLASSES;
using Grockart.DATALAYER;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Grockart.DATALAYER
{
    /*
         * Input : UserProfileObj
         * Output : RegisterResponse Enum (OK, EmailAlreadyExists)
         * Function Definition : This function registeres the user to the system
         * 
         * Cases covered 
         * 1 - 8 : When one or more than one input values are null
         * 9 : Everything is valid
         * 10 : Email already exists
         * 11 : Invalid role type
         */
    [TestClass()]
    public class MySQLUserDataLayer_RegisterUser_Tests
    {
        private string ExpectedOutput = "";
        private string GotOutput = "";
        UserTemplate<IUserProfile> NormalUserTemplate = null;
        [TestMethod()]

        public void RegisterUserTest_1()
        {
            UserProfile UserProfileObj = new UserProfile();
            UserProfileObj.SetFirstName(null);
            ExpectedOutput = "FAIL";
            GotOutput = "";
            try
            {
                NormalUserTemplate = new NormalUserTemplate(UserProfileObj);
                NormalUserTemplate.Add();
                GotOutput = "SUCCESS";
            }
            catch (Exception ex)
            {
                GotOutput = "FAIL";
            }
            Assert.AreEqual(ExpectedOutput, GotOutput);
        }
        // lastname is null
        [TestMethod()]
        public void RegisterUserTest_2()
        {
            UserProfile UserProfileObj = new UserProfile();
            UserProfileObj.SetFirstName("Demo_FirstName");
            UserProfileObj.SetLastName(null);
            ExpectedOutput = "FAIL";
            GotOutput = "";
            try
            {
                NormalUserTemplate = new NormalUserTemplate(UserProfileObj);
                NormalUserTemplate.Add();
                GotOutput = "SUCCESS";
            }
            catch (Exception ex)
            {
                GotOutput = "FAIL";
            }
            Assert.AreEqual(ExpectedOutput, GotOutput);
        }
        // email is null
        [TestMethod()]
        public void RegisterUserTest_3()
        {
            UserProfile UserProfileObj = new UserProfile();
            UserProfileObj.SetFirstName("Demo_FirstName");
            UserProfileObj.SetLastName("Demo_Test_LastName");
            UserProfileObj.SetLastName(null);
            ExpectedOutput = "FAIL";
            GotOutput = "";
            try
            {
                NormalUserTemplate = new NormalUserTemplate(UserProfileObj);
                NormalUserTemplate.Add();
                GotOutput = "SUCCESS";
            }
            catch (Exception ex)
            {
                GotOutput = "FAIL";
            }
            Assert.AreEqual(ExpectedOutput, GotOutput);
        }
        // hashedpassword is null
        [TestMethod()]
        public void RegisterUserTest_4()
        {
            ExpectedOutput = "Invalid Arguments : Input parameters are null";
            GotOutput = "";
            UserProfile UserProfileObj = new UserProfile();
            UserProfileObj.SetFirstName("Demo_FirstName");
            UserProfileObj.SetLastName("Demo_Test_LastName");
            UserProfileObj.SetLastName("Demo_Test@Demo_Test.com");
            UserProfileObj.SetHashedPassword(null);
            ExpectedOutput = "FAIL";
            GotOutput = "";
            try
            {
                NormalUserTemplate = new NormalUserTemplate(UserProfileObj);
                NormalUserTemplate.Add();
                GotOutput = "SUCCESS";
            }
            catch (Exception ex)
            {
                GotOutput = "FAIL";
            }
            Assert.AreEqual(ExpectedOutput, GotOutput);
        }
        // salt is null
        [TestMethod()]
        public void RegisterUserTest_5()
        {
            ExpectedOutput = "Invalid Arguments : Input parameters are null";
            GotOutput = "";
            UserProfile UserProfileObj = new UserProfile();
            UserProfileObj.SetFirstName("Demo_FirstName");
            UserProfileObj.SetLastName("Demo_Test_LastName");
            UserProfileObj.SetLastName("Demo_Test@Demo_Test.com");
            UserProfileObj.SetHashedPassword("hashed_pwd");
            UserProfileObj.SetSalt(null);
            ExpectedOutput = "FAIL";
            GotOutput = "";
            try
            {
                NormalUserTemplate = new NormalUserTemplate(UserProfileObj);
                NormalUserTemplate.Add();
                GotOutput = "SUCCESS";
            }
            catch (Exception ex)
            {
                GotOutput = "FAIL";
            }
            Assert.AreEqual(ExpectedOutput, GotOutput);
        }
        // token is null
        [TestMethod()]
        public void RegisterUserTest_6()
        {
            ExpectedOutput = "Invalid Arguments : Input parameters are null";
            GotOutput = "";
            UserProfile UserProfileObj = new UserProfile();
            UserProfileObj.SetFirstName("Demo_FirstName");
            UserProfileObj.SetLastName("Demo_Test_LastName");
            UserProfileObj.SetLastName("Demo_Test@Demo_Test.com");
            UserProfileObj.SetHashedPassword("hashed_pwd");
            UserProfileObj.SetSalt("salt");
            UserProfileObj.SetToken(null);
            ExpectedOutput = "FAIL";
            GotOutput = "";
            try
            {
                NormalUserTemplate = new NormalUserTemplate(UserProfileObj);
                NormalUserTemplate.Add();
                GotOutput = "SUCCESS";
            }
            catch (Exception ex)
            {
                GotOutput = "FAIL";
            }
            Assert.AreEqual(ExpectedOutput, GotOutput);
        }
        // roletype is null
        [TestMethod()]
        public void RegisterUserTest_7()
        {
            ExpectedOutput = "FAIL";
            GotOutput = "";
            UserProfile UserProfileObj = new UserProfile();
            UserProfileObj.SetFirstName("Demo_FirstName");
            UserProfileObj.SetLastName("Demo_Test_LastName");
            UserProfileObj.SetLastName("Demo_Test@Demo_Test.com");
            UserProfileObj.SetHashedPassword("hashed_pwd");
            UserProfileObj.SetSalt("salt");
            UserProfileObj.SetToken("token");
            UserProfileObj.SetRoleType(null);
            try
            {
                NormalUserTemplate = new NormalUserTemplate(UserProfileObj);
                NormalUserTemplate.Add();
                GotOutput = "SUCCESS";
            }
            catch (Exception ex)
            {
                GotOutput = "FAIL";
            }
            Assert.AreEqual(ExpectedOutput, GotOutput);
        }
        // more than 1 null values
        [TestMethod()]
        public void RegisterUserTest_8()
        {
            UserProfile UserProfileObj = new UserProfile();
            UserProfileObj.SetFirstName(null);
            UserProfileObj.SetLastName("Demo_Test_LastName");
            UserProfileObj.SetLastName("Demo_Test@Demo_Test.com");
            UserProfileObj.SetHashedPassword("hashed_pwd");
            UserProfileObj.SetSalt("salt");
            UserProfileObj.SetToken("token");
            UserProfileObj.SetRoleType(null);
            ExpectedOutput = "FAIL";
            GotOutput = "";
            try
            {
                NormalUserTemplate = new NormalUserTemplate(UserProfileObj);
                NormalUserTemplate.Add();
                GotOutput = "SUCCESS";
            }
            catch (Exception ex)
            {
                GotOutput = "FAIL";
            }
            Assert.AreEqual(ExpectedOutput, GotOutput);
        }
        // everything valid
        [TestMethod()]
        public void RegisterUserTest_9()
        {
            UserProfile UserProfileObj = new UserProfile();
            UserProfileObj.SetFirstName("Deep");
            UserProfileObj.SetLastName("Demo_Test_LastName");
            UserProfileObj.SetHashedPassword("hashed_pwd");
            UserProfileObj.SetSalt("salt");
            UserProfileObj.SetToken("token");
            UserProfileObj.SetRoleType("NORMAL");
            UserProfileObj.SetPassword("aA!12345");
            UserProfileObj.SetEmail("Demo_Test_002@Demo_Test.com");
            ExpectedOutput = "SUCCESS";
            try
            {
                NormalUserTemplate = new NormalUserTemplate(UserProfileObj);
                NormalUserTemplate.Add();
                GotOutput = "SUCCESS";
            }
            catch (Exception)
            {
                GotOutput = "FAIL";
            }
            NormalUserTemplate = new NormalUserTemplate(UserProfileObj);
            NormalUserTemplate.Remove();
            Assert.AreEqual(ExpectedOutput, GotOutput);
        }
        // email already exists
        [TestMethod()]
        public void RegisterUserTest_10()
        {
            UserProfile UserProfileObj = new UserProfile();
            UserProfileObj.SetFirstName("Demo Name");
            UserProfileObj.SetLastName("Demo_Test_LastName");
            UserProfileObj.SetEmail("Demo_Test@Demo_Test.com");
            UserProfileObj.SetHashedPassword("hashed_pwd");
            UserProfileObj.SetSalt("salt");
            UserProfileObj.SetToken("token");
            UserProfileObj.SetRoleType("NORMAL");
            UserProfileObj.SetPassword("aA!12345");
            ExpectedOutput = "EMAIL ALREADY EXISTS";
            try
            {
                NormalUserTemplate = new NormalUserTemplate(UserProfileObj);
                NormalUserTemplate.Add();
                GotOutput = "SUCCESS";
                
            }
            catch (MySqlException mse)
            {
                GotOutput = "EMAIL ALREADY EXISTS";
            }
            catch (Exception ex)
            {
                GotOutput = "FAIL";
            }
            Assert.AreEqual(ExpectedOutput, GotOutput);
        }
        // invalid role type
        [TestMethod()]
        public void RegisterUserTest_11()
        {
            UserProfile UserProfileObj = new UserProfile();
            UserProfileObj.SetFirstName(null);
            UserProfileObj.SetLastName("Demo_Test_LastName");
            UserProfileObj.SetLastName("Demo_Test@Demo_Test.com");
            UserProfileObj.SetHashedPassword("hashed_pwd");
            UserProfileObj.SetSalt("salt");
            UserProfileObj.SetToken("token");
            UserProfileObj.SetRoleType("NORMAL");
            ExpectedOutput = "NOT REGISTERED";
            try
            {
                NormalUserTemplate = new NormalUserTemplate(UserProfileObj);
                NormalUserTemplate.Add();
                GotOutput = "SUCCESS";
            }
            catch (Exception ex)
            {
                GotOutput = "NOT REGISTERED";
            }
            Assert.AreEqual(ExpectedOutput, GotOutput);
        }
    }
}
