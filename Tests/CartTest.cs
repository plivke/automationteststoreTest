using NUnit.Framework;

namespace AutomationFramework.Tests
{
    public class CartTest : BaseTest
    {
        [Test]
        public void CartCountValidation()
        {
            int beforeAddToCart = Pages.IndexPage.CartBadgeCount();

            Pages.IndexPage.AddProductFromIndex("50");
            Pages.IndexPage.AddProductFromIndex("50");
            Pages.IndexPage.AddProductFromIndex("66");

            int afterAddToCart = Pages.IndexPage.CartBadgeCount();
            // Asertacija
            Assert.AreEqual(beforeAddToCart + 3, afterAddToCart);
        }

        [Test]
        public void CartTotalValidation()
        {

            decimal expectedTotal = Pages.IndexPage.GetCartTotal();
            expectedTotal += Pages.IndexPage.AddToTotal("50");
            expectedTotal += Pages.IndexPage.AddToTotal("50");
            expectedTotal += Pages.IndexPage.AddToTotal("66");

            decimal actualTotal = Pages.IndexPage.GetCartTotal();
            // Asertacija
            Assert.AreEqual(expectedTotal, actualTotal);

        }
    }
}