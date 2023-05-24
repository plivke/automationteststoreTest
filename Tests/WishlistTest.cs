using AutomationFramework.Utils;
using NUnit.Framework;
using System.Linq;

namespace AutomationFramework.Tests
{
    public class WishlistTest : BaseTest
    {
        readonly static string _itemName =
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
            // Dodavanje proizvoda u wishlist-u na Product stranici
            Pages.ProductPage.ClickOnAddToWishlist();
            Pages.IndexPage.ClickOnAccountLink();
            Pages.AccountPage.ClickOnWishlistLink();
            // Asertacija
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

            //Asertacija - provera poruke da je Wishlista prazna
            //string expectedMsg = Constants.Messages.ListEmpty.wishlist.Trim().ToLower();
            //string actualMsg = Pages.WishlistPage.GetWishlistEmptyMessage();
            //Assert.AreEqual(expectedMsg, actualMsg);


        }
        [TearDown]
        public void TearDown()
        {
            Pages.WishlistPage.RemoveAllItemsFromWishlist();
        }
    }
}
