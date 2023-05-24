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
            Pages.IndexPage.ClickOnCartPageLink();
        }

        [Test]
        public void PurchaseLoggedIn()
        {
            Pages.CartPage.ClickOnCheckout();
            Pages.AccountPage.LoginUser(
                TestData.User.Login.username,
                TestData.User.Login.password);
            Pages.CheckoutPage.PurchaseInCurency("EUR");
            // Asertacija
            string expectedMsg = Constants.Messages.Success.orderProcessed.Trim().ToLower();
            string actualMsg = Pages.CheckoutPage.GetSuccessMessage();
            Assert.AreEqual(expectedMsg, actualMsg);
        }

        [Test]
        public void PurchaseAsGuest()
        {
            Pages.CartPage.ClickOnCheckout();
            Pages.AccountPage.GuestCheckout();
            Pages.GuestCheckoutPage.GuestCheckoutForm(
                TestData.User.Guest.firstName,
                TestData.User.Guest.lastName,
                TestData.User.Guest.email,
                TestData.User.Guest.address,
                TestData.User.Guest.city,
                TestData.User.Guest.country,
                TestData.User.Guest.regionState,
                TestData.User.Guest.zipCode);
            Pages.CheckoutPage.PurchaseInCurency("GBP");
            // Asertacija
            string expectedMsg = Constants.Messages.Success.orderProcessed.Trim().ToLower();
            string actualMsg = Pages.CheckoutPage.GetSuccessMessage();
            Assert.AreEqual(expectedMsg, actualMsg);
        }
        [TearDown]
        public void TearDown()
        {
            Pages.AccountLogoutPage.LogoutCustomer();
        }
    }
}
