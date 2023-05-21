using NUnit.Framework;

namespace AutomationFramework.Tests
{
    public class LoginTest : BaseTest
    {
        private static string firstName = TestData.TestData.RegisterUser.firstName;
        //private static string loginName = CommonMethods.GenerateRandomUsername(firstName);
        //private static string email = loginName + CommonMethods.GetRandomItemFromList(
        //    TestData.TestData.RegisterUser.emailSufix);

        //[SetUp]
        //public void SetUp()
        //{
        //    Pages.IndexPage.ClickOnLoginOrRegister();
        //    Pages.AccountPage.ClickOnContinue();
        //    Pages.AccountCreatePage.RegisterWithRequiredOnly(
        //        firstName,
        //        TestData.TestData.RegisterUser.lastName,
        //        email,
        //        TestData.TestData.RegisterUser.address,
        //        TestData.TestData.RegisterUser.city,
        //        TestData.TestData.RegisterUser.zipCode,
        //        loginName,
        //        TestData.TestData.RegisterUser.password,
        //        TestData.TestData.RegisterUser.notSubscribed);


        //}

        [Test]
        public void Login()
        {
            Pages.IndexPage.ClickOnLoginOrRegister();

            Pages.AccountPage.LoginCustomer(
                TestData.TestData.Login.username,
                TestData.TestData.Login.password);

            // Asertacija
            string expectedMsg = Constants.Messages.Success.welcomeUser + firstName.ToLower();
            string actualMsg = Pages.IndexPage.GetWelcomeMessage();
            Assert.AreEqual(expectedMsg, actualMsg);
        }
        [TearDown]
        public void TearDown()
        {
            Pages.AccountLogoutPage.LogoutCustomer();
        }
    }
}
