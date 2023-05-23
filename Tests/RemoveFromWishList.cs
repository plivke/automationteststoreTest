using NUnit.Framework;

namespace AutomationFramework.Tests
{
    public class RemoveFromWishList : BaseTest
    {
        [SetUp]
        public void SetUp()
        {
            // Logovanje korisnika
            Pages.IndexPage.ClickOnLoginOrRegister();
            Pages.AccountPage.LoginUser(
                TestData.TestData.Login.username,
                TestData.TestData.Login.password);
            // Navigiranje na home page i odlazak na stranicu proizvoda
            Pages.IndexPage.ClickOnHomePageLink();
            Pages.IndexPage.ClickOnProduct(TestData.TestData.Wishlist.itemName);
        }
        [Test]
        public void RemoveFromWishlist()
        {
            // Sklanjanje proizvoda iz wishlist-e na Product stranici
            Pages.ProductPage.ClickOnRemoveFromWishlist();
            // Navigiranje na Wishlist stranicu
            Pages.IndexPage.ClickOnAccountLink();
            Pages.AccountPage.ClickOnWishlistLink();
            // Asertacija - provera da li je Wishlist prazan
            Assert.IsTrue(!Pages.WishlistPage.IsItemPresent());

        }
    }
}
