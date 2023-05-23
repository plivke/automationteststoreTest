using NUnit.Framework;

namespace AutomationFramework.Tests
{
    public class LoginTest : BaseTest
    {
        private static string _firstName = TestData.TestData.RegisterUser.firstName;

        [Test]
        public void Login()
        {
            // Navigiranje na stranicu za login
            Pages.IndexPage.ClickOnLoginOrRegister();
            // Loginovanje sa staticnim kredencijalima
            Pages.AccountPage.LoginUser(
                TestData.TestData.Login.username,
                TestData.TestData.Login.password);

            // Asertacija = provera postojanja poruke za uspesno logovanje
            string expectedMsg = (Constants.Messages.Success.welcomeBack + _firstName).Trim().ToLower();
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
