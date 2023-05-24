using AutomationFramework.Utils;
using NUnit.Framework;

namespace AutomationFramework.Tests
{
    public class ChangePasswordTest : BaseTest
    {
        static string newPass = CommonMethods.GenerateRandomUsername(TestData.User.Login.password);
        [SetUp]
        public void SetUp()
        {
            // Navigiranje na stranicu za login
            Pages.IndexPage.ClickOnLoginOrRegister();
            // Loginovanje sa staticnim kredencijalima
            Pages.AccountPage.LoginUser(
                TestData.User.Login.username,
                TestData.User.Login.password);
            Pages.IndexPage.ClickOnAccountLink();
            Pages.AccountPage.ClickOnChangePasswordLink();
        }

        [Test]
        public void ChangePassword()
        {
            Pages.ChangePasswordPage.ChangePassword(
                TestData.User.Login.password,
                newPass);

            // Asertacija
            string actualMsg = Constants.Messages.Success.passwordChanged.Trim().ToLower();
            string expectedMsg = Pages.ChangePasswordPage.GetSuccessMessage();
            Assert.AreEqual(expectedMsg, actualMsg);

        }
        [TearDown]
        public void ChangePassToNew()
        {
            TestData.User.Login.password = newPass;
        }
    }
}
