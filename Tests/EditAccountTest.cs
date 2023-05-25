using AutomationFramework.Utils;
using NUnit.Framework;

namespace AutomationFramework.Tests
{
    public class EditAccountTest : BaseTest
    {
        /// polje u koje se pamti slucajan broj telefona
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
            // Odlazak na  stranicu za informacije o nalogu
            Pages.AccountPage.ClickOnAccoutDetails();
        }

        [Test]
        public void EditAccount()
        {
            // Cuva se stari broj telefona i upisuje se novi
            string oldTelephone = Pages.AccountEditPage.EnterTelephone(
                _newTelephone);
            // Cuvaju se promene i izlazi sa stranice
            Pages.AccountEditPage.ClickOnCountinue();
            // Asertacija - vracanje na stranicu i uporedjivanje stare i
            // nove vrednosti upisane u polje za broj telefona
            Pages.AccountPage.ClickOnAccoutDetails();
            string newTelephone = Pages.AccountEditPage.GetTelephone();
            Assert.AreNotEqual(oldTelephone, newTelephone);
        }
    }
}
