using AutomationFramework.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFramework.Tests
{
    public class RemoveFromWishList : BaseTest
    {
        [SetUp]
        public void SetUp()
        {
            Pages.IndexPage.ClickOnLoginOrRegister();

            Pages.AccountPage.LoginCustomer(
                TestData.TestData.Login.username,
                TestData.TestData.Login.password);
            Pages.IndexPage.ClickOnHomePageLink();
            Pages.IndexPage.ClickOnProduct(TestData.TestData.Wishlist.itemName);
            Pages.ProductPage.AddToWishlist();
        }
        [Test]
        public void RemoveFromWishlist()
        {
            Pages.ProductPage.RemoveFromWishlist();
            Pages.IndexPage.ClickOnAccountLink();
            Pages.AccountPage.ClickOnWishlistLink();
            // Asertacija
            Assert.IsTrue(!Pages.WishlistPage.IsItemPresent());

        }
    }
}
