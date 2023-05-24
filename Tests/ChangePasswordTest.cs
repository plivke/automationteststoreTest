using AutomationFramework.Utils;
using NUnit.Framework;
using System.Linq;

namespace AutomationFramework.Tests
{
    public class ChangePasswordTest : BaseTest
    {
        // Generacija slucajnih korisnickih polja
        static readonly string _firstName = TestData.User.Registration.firstName;
        static readonly string _loginName = CommonMethods.GenerateRandomUsername(_firstName);
        static readonly string _email = _loginName + CommonMethods.GetRandomItemFromList(
        TestData.User.Registration.emailSufix.ToList());
        static string _password = CommonMethods.GenerateRandomUsername(_firstName);
        static string _newPassword = CommonMethods.GenerateRandomUsername(_firstName);
        [SetUp]
        public void SetUp()
        {
            // Registracija korisnika NEOPHODNIM podacima za registraciju
            Pages.IndexPage.ClickOnLoginOrRegister();
            Pages.AccountPage.ClickOnContinue();
            Pages.AccountCreatePage.RegisterWithRequiredOnly(
                _firstName,
                TestData.User.Registration.lastName,
                _email,
                TestData.User.Registration.address,
                TestData.User.Registration.city,
                TestData.User.Registration.zipCode,
                _loginName,
                _password,
                TestData.User.Registration.notSubscribed);

            Pages.IndexPage.ClickOnAccountLink();
            Pages.AccountPage.ClickOnChangePassword();
        }

        [Test]
        public void ChangePassword()
        {
            Pages.ChangePasswordPage.ChangePassword(_password, _newPassword);

            // Asertacija
            string actualMsg = Constants.Messages.Success.passwordChanged.Trim().ToLower();
            string expectedMsg = Pages.ChangePasswordPage.GetSuccessMessage();
            Assert.AreEqual(expectedMsg, actualMsg);

        }
    }
}
