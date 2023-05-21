using AutomationFramework.Utils;
using NUnit.Framework;

namespace AutomationFramework.Tests
{
    public class ForgottenLoginTest : BaseTest
    {
        private static string firstName = TestData.TestData.RegisterUser.firstName;
        private static string loginName = CommonMethods.GenerateRandomUsername(firstName);
        private static string email = loginName + CommonMethods.GetRandomItemFromList(
            TestData.TestData.RegisterUser.emailSufix);
        private static string lastName = TestData.TestData.RegisterUser.lastName;

        [SetUp]
        public void SetUp()
        {
            Pages.IndexPage.ClickOnLoginOrRegister();
            Pages.AccountPage.ClickOnContinue();
            Pages.AccountCreatePage.RegisterWithRequiredOnly(
                firstName,
                lastName,
                email,
                TestData.TestData.RegisterUser.address,
                TestData.TestData.RegisterUser.city,
                TestData.TestData.RegisterUser.zipCode,
                loginName,
                 TestData.TestData.RegisterUser.password,
                TestData.TestData.RegisterUser.notSubscribed);
            Pages.AccountLogoutPage.LogoutCustomer();
            Pages.IndexPage.ClickOnLoginOrRegister();
        }
        [Test]
        public void ForgottenLogin()
        {
            Pages.AccountPage.ClickOnForgottenLogin();
            Pages.AccountForgottenPage.ForgottenLoginFillout(lastName, email);

            // Asertacija
            string expectedMsg = Constants.Messages.Success.loginRemider.Trim().ToLower();
            string actualMsg = Pages.AccountForgottenPage.GetSuccessMessage();
            Assert.AreEqual(expectedMsg, actualMsg);

        }
    }
}
