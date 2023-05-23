using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFramework.Tests
{
    public class WishlistTest : BaseTest
    {
        [SetUp]
        public void SetUp()
        {
            Pages.IndexPage.ClickOnLoginOrRegister();

            Pages.AccountPage.LoginCustomer(
                TestData.TestData.Login.username,
                TestData.TestData.Login.password);
        }
        [Test]
        public void AddToWishlist()
        {
            Pages.IndexPage.ClickOnProduct();
            Pages.ProductPage.ClickOnWishlistLink();
            Pages.IndexPage.ClickOnAccountLink();
            Pages.AccountPage.ClickOnWishlistLink();

            
        }
        [Test]
        public void RemoveFromWishlist()
        {

        }

    }
}
