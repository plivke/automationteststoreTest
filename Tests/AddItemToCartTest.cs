using AutomationFramework.Utils;
using NUnit.Framework;
using System.Linq;

namespace AutomationFramework.Tests
{
    public class AddItemToCartTest : BaseTest
    {
        [SetUp]
        public void SetUp()
        {
            ///Klik na Login link
            Pages.IndexPage.ClickOnLoginOrRegister();

            //Unos podataka u fomru za login
            Pages.AccountPage.LoginUser(
                TestData.User.Login.username,
                TestData.User.Login.password);

            //Klik na link korpe
            Pages.IndexPage.ClickOnCartPageLink();

            //Brisanje proizvoda iz korpe
            Pages.CartPage.RemoveItemsFromCart();
        }

        [Test]
        public void AddFromIndexPage()
        {
            //Dodavanje proizvoda u korpu sa indeks strane(Home strane)
            Pages.IndexPage.AddProductFromIndex();

            //Klik na link korpe
            Pages.IndexPage.ClickOnCartPageLink();

            // Asertacija(Provera da li je korpa prazna)
            Assert.IsTrue(Pages.CartPage.IsCartNotEmpty());
        }

        [Test]
        public void AddFromProductPage()
        {
            string itemName = CommonMethods.GetRandomItemFromList(
                TestData.Cart.CartItem.itemName.ToList());
            //Klik na proizvod
            Pages.IndexPage.ClickOnProduct(itemName);

            //Dodavanje proizvoda u korpu
            Pages.ProductPage.ClickOnAddToCart();

            //Asertacija (Provera da li je korpa prazna)
            Assert.IsTrue(Pages.CartPage.IsCartNotEmpty());
        }
    }
}
