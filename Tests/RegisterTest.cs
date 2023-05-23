using AutomationFramework.Utils;
using NUnit.Framework;

namespace AutomationFramework.Tests
{
    public class RegisterTest : BaseTest
    {
        // generacija jedinstvenih polja
        private static string firstName = TestData.TestData.RegisterUser.firstName;
        private static string loginName = CommonMethods.GenerateRandomUsername(firstName);
        private static string email = loginName + CommonMethods.GetRandomItemFromList(
            TestData.TestData.RegisterUser.emailSufix);

        [Test]
        public void Register()
        {
            // Registracija korisnika NEOPHODNIH podacima za registraciju
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
                TestData.TestData.RegisterUser.password,
                TestData.TestData.RegisterUser.notSubscribed);

            // Asertacija - provera da li je poruka za uspesnu registraciju prisutna
            Assert.AreEqual(
                Constants.Messages.Success.registration,
                Pages.AccountCreatePage.GetSuccessMessage());
        }
    }
}
