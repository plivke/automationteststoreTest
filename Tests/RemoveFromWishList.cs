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
            Pages.AccountPage.LoginCustomer(
                TestData.TestData.Login.username,
                TestData.TestData.Login.password);
            // Navigiranje na home page i odlazak na stranicu proizvoda
            Pages.IndexPage.ClickOnHomePageLink();
            Pages.IndexPage.ClickOnProduct(TestData.TestData.Wishlist.itemName);
            // Dodavanje proizvoda u wishlist-u
            Pages.ProductPage.AddToWishlist();
        }
        [Test]
        public void RemoveFromWishlist()
        {
            //Sklanjanje proizvoda iz wishlist-e na product strani
            Pages.ProductPage.RemoveFromWishlist();
            // Navigiranje na wishlist stranicu
            Pages.IndexPage.ClickOnAccountLink();
            Pages.AccountPage.ClickOnWishlistLink();
            // Asertacija - provera da li je wishlist-a prazna
            Assert.IsTrue(!Pages.WishlistPage.IsItemPresent());

        }
    }
}
