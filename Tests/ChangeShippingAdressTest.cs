using NUnit.Framework;

namespace AutomationFramework.Tests
{
    public class ChangeShippingAdressTest : BaseTest
    {
        [SetUp]
        public void Setup()
        {
            //Dodavanje proizvoda u korpu preko indeksa
            Pages.IndexPage.AddProductFromIndex("65");
            Pages.IndexPage.AddProductFromIndex("52");

            //Klik na link korpe
            Pages.IndexPage.ClickOnCartPageLink();

            // Klik na dugme za kupovinu
            Pages.CartPage.ClickOnCheckout();

            // Login korisnika
            Pages.AccountPage.LoginUser(
                TestData.User.Login.username,
                TestData.User.Login.password);


        }

        [Test]
        public void ChangeShippingAddress()
        {
            Pages.CheckoutPage.ClickOnEditShippingButton();

            Pages.ShippingAddressesPage.ClickOnChangeAdress();

            Pages.ShippingAddressesPage.ChangeShippingAdress(TestData.User.Registration.firstName,
                TestData.User.Registration.lastName,
                TestData.User.Registration.address,
                TestData.User.Registration.city,
                TestData.User.Registration.zipCode);

            Pages.ShippingAddressesPage.ClickOnContinue();

            //Assert testa

            Assert.IsTrue(Pages.CheckoutPage.IsItemPresent());
        }
    }
}
