using NUnit.Framework;

namespace AutomationFramework.Tests
{
    public class LoginTest : BaseTest
    {
        private static string firstName = TestData.TestData.RegisterUser.firstName;

        [Test]
        public void Login()
        {
            // Navigiranje na stranicu za login
            Pages.IndexPage.ClickOnLoginOrRegister();
            // Logovanje sa staticnik kredencijalima
            Pages.AccountPage.LoginCustomer(
                TestData.TestData.Login.username,
                TestData.TestData.Login.password);

            // Asertacija = provera postojanja poruke za uspesno logovanje
            string expectedMsg = Constants.Messages.Success.welcomeUser + firstName.ToLower();
            string actualMsg = Pages.IndexPage.GetWelcomeMessage();
            Assert.AreEqual(expectedMsg, actualMsg);
        }
        [TearDown]
        public void TearDown()
        {
            // Logout korisnika
            Pages.AccountLogoutPage.LogoutCustomer();
        }
    }
}
