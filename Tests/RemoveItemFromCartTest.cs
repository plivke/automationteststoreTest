using NUnit.Framework;

namespace AutomationFramework.Tests
{
    public class RemoveItemFromCartTest : BaseTest
    {
        [SetUp]
        public void SetUp()
        {
            Pages.IndexPage.ClickOnLoginOrRegister();

            Pages.AccountPage.LoginCustomer(
                TestData.TestData.Login.username,
                TestData.TestData.Login.password);
            Pages.IndexPage.ClickOnHomePageLink();
            Pages.IndexPage.AddProductFromIndex();
        }

        [Test]
        public void RemoveItemFromCart()
        {
            // Klikcemo na link za dodavanje u korpu
            Pages.IndexPage.ClickOnCartPageLink();
            bool isCartEmptyBefore = !Pages.CartPage.IsCartNotEmpty();

            // Klikcemo na link za sklanjanje iz korpe
            Pages.CartPage.RemoveItemsFromCart();
            bool isCartEmptyAfter = !Pages.CartPage.IsCartNotEmpty();

            //Asertacija - Uporedjivanje stanja korpe pre i posle sklanjanja
            Assert.AreNotEqual(isCartEmptyBefore, isCartEmptyAfter);
        }
    }
}
