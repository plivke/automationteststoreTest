using NUnit.Framework;

namespace AutomationFramework.Tests
{
    public class CartTest : BaseTest
    {
        [Test]
        public void CartCountValidation()
        {
            // Promenjliva u kojoj se cuva podatak koliko je proizvoda bilo u korpi
            byte beforeAddToCart = Pages.IndexPage.CartBadgeCount();

            // Dodavanje proizvoda u korpu preko njegovog indeksa
            Pages.IndexPage.AddProductFromIndex("50");
            Pages.IndexPage.AddProductFromIndex("50");
            Pages.IndexPage.AddProductFromIndex("66");

            // Promenljiva u kojoj se cuva podatak koliko je proizvoda u korpi nakon dodavanja
            byte afterAddToCart = Pages.IndexPage.CartBadgeCount();


            // Asertacija(Proveravamo da li su jednake vrednosti pre dodavanja + proizvodi koje smo dodali, i vrednost nakon dodavanja proizvoda)
            Assert.AreEqual(beforeAddToCart + 3, afterAddToCart);
        }

        [Test]
        public void CartTotalValidation()
        {
            // Decimal promenljiva koja cuva podatak o zbiru cena proizvoda pre dodavanja novih
            decimal expectedTotal = Pages.IndexPage.GetCartTotal();

            // Dodavanje novih proizvoda i povecanje vrednosti promenjlive expectedTotal
            expectedTotal += Pages.IndexPage.AddToTotal("50");
            expectedTotal += Pages.IndexPage.AddToTotal("50");
            expectedTotal += Pages.IndexPage.AddToTotal("66");

            // Decimal promenljiva koja cuva podatak o zbiru cena proizvoda nakon dodavanja novih
            decimal actualTotal = Pages.IndexPage.GetCartTotal();


            // Asertacija(Provera da li su vrednosti promenljivih iste)
            Assert.AreEqual(expectedTotal, actualTotal);

        }
    }
}