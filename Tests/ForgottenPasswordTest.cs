using AutomationFramework.Utils;
using NUnit.Framework;

namespace AutomationFramework.Tests
{
    public class ForgottenPasswordTest : BaseTest
    {
        // generisanje jedinstvenih podataka za registraciju
        private static string firstName = TestData.TestData.RegisterUser.firstName;
        private static string loginName = CommonMethods.GenerateRandomUsername(firstName);
        private static string email = loginName + CommonMethods.GetRandomItemFromList(
            TestData.TestData.RegisterUser.emailSufix);
        private static string password = TestData.TestData.RegisterUser.password;


        [SetUp]
        public void SetUp()
        {
            // registracija korisnika
            Pages.IndexPage.ClickOnLoginOrRegister();
            Pages.AccountPage.ClickOnContinue();
            Pages.AccountCreatePage.RegisterWithRequiredOnly(
                firstName,
                TestData.TestData.RegisterUser.lastName,
                email,
                TestData.TestData.RegisterUser.address,
                TestData.TestData.RegisterUser.city,
                TestData.TestData.RegisterUser.zipCode,
                loginName,
                password,
                TestData.TestData.RegisterUser.notSubscribed);
            // Logout korisnika iz naloga
            Pages.AccountLogoutPage.LogoutCustomer();
            Pages.IndexPage.ClickOnLoginOrRegister();

        }

        [Test]
        public void ForgottenPassword()
        {
            // Navigiranje i popunjavanje polja za Forgotten Password
            Pages.AccountPage.ClickOnForgottenPassword();
            Pages.AccountForgottenPage.ForgottenPasswordFillout(loginName, email);

            // Asertacija - provera da li poruka za uspesno resetovanu poruku postoji
            string expectedMsg = Constants.Messages.Success.passwordReset.Trim().ToLower();
            string actualMsg = Pages.AccountForgottenPage.GetSuccessMessage();
            Assert.AreEqual(expectedMsg, actualMsg);
        }
    }
}