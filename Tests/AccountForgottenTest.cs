using AutomationFramework.Utils;
using NUnit.Framework;
using System.Linq;

namespace AutomationFramework.Tests
{
    public class AccountForgottenTest : BaseTest
    {
        // Generisanje slucajnih podataka za registraciju
        static string _firstName = TestData.User.AccountForgotten.firstName;
        static string _loginName = CommonMethods.GenerateRandomUsername(_firstName);
        string _lastName = TestData.User.AccountForgotten.lastName;
        string _password = TestData.User.AccountForgotten.password;
        string _email = _loginName +
            CommonMethods.GetRandomItemFromList((TestData.User.Registration.emailSufix).ToList());


        [SetUp]
        public void SetUp()
        {

            // Registracija korisnika
            Pages.IndexPage.ClickOnLoginOrRegister();
            Pages.AccountPage.ClickOnContinue();
            Pages.AccountCreatePage.RegisterWithRequiredOnly(
                _firstName,
                _lastName,
                _email,
                TestData.User.AccountForgotten.address,
                TestData.User.AccountForgotten.city,
                TestData.User.AccountForgotten.zipCode,
                _loginName,
                _password,
                TestData.User.Registration.notSubscribed);
            // Logout korisnika iz naloga
            Pages.AccountLogoutPage.LogoutCustomer();
            Pages.IndexPage.ClickOnLoginOrRegister();
        }

        [Test]
        public void ForgottenPassword()
        {
            // Navigiranje i popunjavanje polja za Forgotten password
            Pages.AccountPage.ClickOnForgottenPassword();
            Pages.AccountForgottenPage.ForgottenPasswordFillout(_loginName, _email);

            // Asertacija - provera da li poruka za uspesno resetovanu poruku postoji
            string expectedMsg = Constants.Messages.Success.passwordReset.Trim().ToLower();
            string actualMsg = Pages.AccountForgottenPage.GetSuccessMessage();
            Assert.AreEqual(expectedMsg, actualMsg);
        }

        [Test]
        public void ForgottenLogin()
        {
            // Navigiranje i popunjavanje polja za Forgotten login
            Pages.AccountPage.ClickOnForgottenLogin();
            Pages.AccountForgottenPage.ForgottenLoginFillout(_lastName, _email);

            // Asertacija - provera prisustva poruke za uspesno resetovan nalog
            string expectedMsg = Constants.Messages.Success.loginRemider.Trim().ToLower();
            string actualMsg = Pages.AccountForgottenPage.GetSuccessMessage();
            Assert.AreEqual(expectedMsg, actualMsg);
        }

        [TearDown]
        public void TeraDown()
        {
            // U teardown-u se dodeljuje nova vrednost email-u i username-u kako be bi doslo
            // do greske prilikom registracije sa istim kredencijalima
            _email = CommonMethods.GenerateRandomUsername(_firstName) +
                CommonMethods.GetRandomItemFromList((TestData.User.Registration.emailSufix).ToList());
            _loginName = CommonMethods.GenerateRandomUsername(_lastName);
        }
    }
}
