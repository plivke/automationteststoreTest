using NUnit.Framework;

namespace AutomationFramework.Tests
{
    public class CheckoutTest : BaseTest
    {
        [SetUp]
        public void SetUp()
        {
            Pages.IndexPage.AddProductFromIndex("50");
            Pages.IndexPage.AddProductFromIndex("66");
            Pages.IndexPage.AddProductFromIndex("50");
            Pages.IndexPage.ClickOnCartPageLink();
        }
        [Test]
        public void PurchaseLogedIn()
        {
            Pages.CartPage.ClickOnCheckout();
            Pages.AccountPage.LoginCustomer(
                TestData.TestData.Login.username,
                TestData.TestData.Login.password);
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
                TestData.TestData.GuestUser.firstName,
                TestData.TestData.GuestUser.lastName,
                TestData.TestData.GuestUser.email,
                TestData.TestData.GuestUser.address,
                TestData.TestData.GuestUser.city,
                TestData.TestData.GuestUser.country,
                TestData.TestData.GuestUser.regionState,
                TestData.TestData.GuestUser.zipCode);
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
