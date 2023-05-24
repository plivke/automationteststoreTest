using NUnit.Framework;

namespace AutomationFramework.Tests
{
    public class RemoveItemFromCartTest : BaseTest
    {
        [SetUp]
        public void SetUp()
        {
            Pages.IndexPage.ClickOnLoginOrRegister();

            Pages.AccountPage.LoginUser(
                TestData.User.Login.username,
                TestData.User.Login.password);
            Pages.IndexPage.ClickOnHomePageLink();
            Pages.IndexPage.AddProductFromIndex();
        }

        [Test]
        public void RemoveItemFromCart()
        {
            // Kliknemo na link za odlazak u korpu
            Pages.IndexPage.ClickOnCartPageLink();
            bool isCartEmptyBefore = !Pages.CartPage.IsCartNotEmpty();

            // Kliknemo na link za sklanjanje iz korpe
            Pages.CartPage.RemoveItemsFromCart();
            bool isCartEmptyAfter = !Pages.CartPage.IsCartNotEmpty();

            // Asertacija - uporedjivanje stanja korpe pre i posle sklanjanja
            Assert.AreNotEqual(isCartEmptyBefore, isCartEmptyAfter);
        }
    }
}
