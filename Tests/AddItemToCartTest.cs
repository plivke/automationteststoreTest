using NUnit.Framework;

namespace AutomationFramework.Tests
{
    public class AddItemToCartTest : BaseTest
    {
        [SetUp]
        public void SetUp()
        {
            Pages.IndexPage.ClickOnLoginOrRegister();

            Pages.AccountPage.LoginCustomer(
                TestData.TestData.Login.username,
                TestData.TestData.Login.password);
            Pages.IndexPage.ClickOnCartPageLink();
            Pages.CartPage.RemoveItemsFromCart();

        }

        [Test]
        public void AddFromIndexPage()
        {
            Pages.IndexPage.AddProductFromIndex();
            Pages.IndexPage.ClickOnCartPageLink();
            // Asertacija
            Assert.IsTrue(Pages.CartPage.IsCartNotEmpty());
        }

        [Test]
        public void AddFromProductPage()
        {
            Pages.IndexPage.ClickOnProduct();
            Pages.ProductPage.ClickOnAddToCart();
            //Asertacija 
            Assert.IsTrue(Pages.CartPage.IsCartNotEmpty());
        }
    }
}
