using AutomationFramework.Utils;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace AutomationFramework.Tests
{
    public class CheckoutTest : BaseTest
    {
        // Broj proizvoda koji se stavljaju u korpu
        static readonly int _itemCount = 3;
        static readonly List<string> itemIds = new(TestData.Cart.CartItem.itemId.ToList());

        [SetUp]
        public void SetUp()
        {
            // Dodavanje slucajno odabranih proizvoda sa Index stranice
            for (int i = 0; i < _itemCount; i++)
            {
                string itemId = CommonMethods.GetRandomItemFromList(itemIds);
                Pages.IndexPage.AddProductFromIndex(itemId);
            }

            // Klik na link korpe
            Pages.IndexPage.ClickOnCartPageLink();
        }

        [Test]
        public void PurchaseLoggedIn()
        {
            // Klik na dugme za kupovinu
            Pages.CartPage.ClickOnCheckout();

            // Login korisnika
            Pages.AccountPage.LoginUser(
                TestData.User.Login.username,
                TestData.User.Login.password);

            // Kupovina proizvoda u EUR valuti
            Pages.CheckoutPage.PurchaseInCurency("EUR");

            // Asertacija(Provera da li je kupovina uspesna)
            string expectedMsg = Constants.Messages.Success.orderProcessed.Trim().ToLower();
            string actualMsg = Pages.CheckoutPage.GetSuccessMessage();
            Assert.AreEqual(expectedMsg, actualMsg);
        }

        [Test]
        public void PurchaseAsGuest()
        {

            // Klik na dugme za kupovinu
            Pages.CartPage.ClickOnCheckout();

            // Guest kupovina
            Pages.AccountPage.GuestCheckout();

            // Upis podataka na formu
            Pages.GuestCheckoutPage.GuestCheckoutForm(
                TestData.User.Guest.firstName,
                TestData.User.Guest.lastName,
                TestData.User.Guest.email,
                TestData.User.Guest.address,
                TestData.User.Guest.city,
                TestData.User.Guest.country,
                TestData.User.Guest.regionState,
                TestData.User.Guest.zipCode);

            // Kupovina proizvoda u GBP valuti
            Pages.CheckoutPage.PurchaseInCurency("GBP");


            // Asertacija(Provera da li je kupovina uspesna)
            string expectedMsg = Constants.Messages.Success.orderProcessed.Trim().ToLower();
            string actualMsg = Pages.CheckoutPage.GetSuccessMessage();
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
