using NUnit.Framework;

namespace AutomationFramework.Tests
{
    public class EditAccountTest : BaseTest
    {
        [SetUp]
        public void SetUp()
        {
            // Navigiranje na stranicu za login
            Pages.IndexPage.ClickOnLoginOrRegister();
            // Loginovanje sa staticnim kredencijalima
            Pages.AccountPage.LoginUser(
                TestData.User.Login.username,
                TestData.User.Login.password);
        }
    }
}
