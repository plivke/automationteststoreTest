using AutomationFramework.Utils;
using NUnit.Framework;
using System.Linq;

namespace AutomationFramework.Tests
{
    public class WishlistTest : BaseTest
    {
        // Uzimanje slucajno odabranog imena na koji se klikne
        static readonly string _itemName =
            CommonMethods.GetRandomItemFromList((TestData.Wishlist.Items.itemName).ToList());

        [SetUp]
        public void SetUp()
        {
            // Logovanje korisnika
            Pages.IndexPage.ClickOnLoginOrRegister();
            Pages.AccountPage.LoginUser(
                TestData.User.Login.username,
                TestData.User.Login.password);
            // Navigiranje na home page i odlazak na stranicu proizvoda
            Pages.IndexPage.ClickOnHomePageLink();
            Pages.IndexPage.ClickOnProduct(_itemName);
        }
        [Test]
        public void AddToWishlist()
        {
            // Dodavanje proizvoda u Wishlist-u na Product stranici
            Pages.ProductPage.ClickOnAddToWishlist();
            Pages.IndexPage.ClickOnAccountLink();
            Pages.AccountPage.ClickOnWishlistLink();
            //Asertacija - provera da li je isti proizvod dodat u Wishlist-u
            string itemName = Pages.WishlistPage.GetItemName();
            Assert.AreEqual(_itemName, itemName);
        }

        [Test]
        public void RemoveFromWishlist()
        {
            // Sklanjanje proizvoda iz wishlist-e na Product stranici
            Pages.ProductPage.ClickOnRemoveFromWishlist();
            // Navigiranje na Wishlist stranicu
            Pages.IndexPage.ClickOnAccountLink();
            Pages.AccountPage.ClickOnWishlistLink();

            //Asertacija - provera da li je Wishlist prazan
            Assert.IsTrue(!Pages.WishlistPage.IsItemPresent());

        }
        [TearDown]
        public void TearDown()
        {
            Pages.WishlistPage.RemoveAllItemsFromWishlist();
        }
    }
}
