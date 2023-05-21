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
            Pages.IndexPage.ClickOnCartPageLink();
            bool isCartEmptyBefore = !Pages.CartPage.IsCartNotEmpty();

            Pages.CartPage.RemoveItemsFromCart();
            bool isCartEmptyAfter = !Pages.CartPage.IsCartNotEmpty();

            //Asertacija
            Assert.AreNotEqual(isCartEmptyBefore, isCartEmptyAfter);
        }
    }
}
