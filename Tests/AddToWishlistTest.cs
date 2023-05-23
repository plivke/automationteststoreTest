using NUnit.Framework;

namespace AutomationFramework.Tests
{
    public class AddToWishlistTest : BaseTest
    {
        [SetUp]
        public void SetUp()
        {
            Pages.IndexPage.ClickOnLoginOrRegister();

            Pages.AccountPage.LoginCustomer(
                TestData.TestData.Login.username,
                TestData.TestData.Login.password);
            Pages.IndexPage.ClickOnHomePageLink();
        }
        [Test]
        public void AddToWishlist()
        {
            Pages.IndexPage.ClickOnProduct(TestData.TestData.Wishlist.itemName);
            Pages.ProductPage.AddToWishlist();
            Pages.IndexPage.ClickOnAccountLink();
            Pages.AccountPage.ClickOnWishlistLink();
            // Asertacija
            string itemName = Pages.WishlistPage.GetItemName();
            Assert.AreEqual(TestData.TestData.Wishlist.itemName, itemName);

        }

        [TearDown]
        public void TearDown()
        {
            Pages.WishlistPage.RemoveItem();
        }
    }
}
