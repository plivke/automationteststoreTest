using NUnit.Framework;

namespace AutomationFramework.Tests
{
    public class LoginTest : BaseTest
    {
        static readonly string _firstName = TestData.User.Login.firstName;

        [Test]
        public void Login()
        {
            // Navigiranje na stranicu za login
            Pages.IndexPage.ClickOnLoginOrRegister();
            // Loginovanje sa staticnim kredencijalima
            Pages.AccountPage.LoginUser(
                TestData.User.Login.username,
                TestData.User.Login.password);

            // Asertacija = provera postojanja poruke za uspesno logovanje
            string expectedMsg = (Constants.Messages.Success.welcomeBack + _firstName).Trim().ToLower();
            string actualMsg = Pages.IndexPage.GetWelcomeMessage();
            Assert.AreEqual(expectedMsg, actualMsg);
        }


        [Test]
        public void LoginWithWrongData()
        {
            // Navigiranje na stranicu za login
            Pages.IndexPage.ClickOnLoginOrRegister();
            // Loginovanje sa staticnim kredencijalima
            Pages.AccountPage.LoginUser(
                TestData.User.Login.wrongusername,
                TestData.User.Login.wrongpassword);

            // Asertacija = provera postojanja poruke za uspesno logovanje
            string expectedMsg = Constants.Messages.Error.incorrectlogin;
            string actualMsg = Pages.AccountPage.GetErrorLoginMessage(); 
            Assert.AreEqual(expectedMsg, actualMsg);
        }
        //[TearDown]
        //public void TearDown()
        //{
        //    // Logout korisnika
        //    Pages.AccountLogoutPage.LogoutCustomer();
        //}
    }
}
