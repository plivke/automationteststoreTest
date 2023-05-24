using AutomationFramework.Utils;
using NUnit.Framework;

namespace AutomationFramework.Tests
{
    public class EditAccountTest : BaseTest
    {
        static string? _newTelephone = TestData.User.AccountEdit.telephone2 +
            CommonMethods.GenerateRandomNumber(1111, 9999).ToString();

        [SetUp]
        public void SetUp()
        {
            // Navigiranje na stranicu za login
            Pages.IndexPage.ClickOnLoginOrRegister();
            // Loginovanje sa staticnim kredencijalima
            Pages.AccountPage.LoginUser(
                TestData.User.AccountEdit.username,
                TestData.User.AccountEdit.password);
            Pages.AccountPage.ClickOnAccoutDetails();

        }

        [Test]
        public void EditAccount()
        {
            string oldTelephone = Pages.AccountEditPage.EnterTelephone(
                _newTelephone);
            Pages.AccountEditPage.ClickOnCountinue();
            Pages.AccountPage.ClickOnAccoutDetails();
            string newTelephone = Pages.AccountEditPage.GetTelephone();
            Assert.AreNotEqual(oldTelephone, newTelephone);
        }
    }
}
