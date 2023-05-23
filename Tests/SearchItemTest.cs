using NUnit.Framework;

namespace AutomationFramework.Tests
{
    public class SearchItemTest : BaseTest
    {
        [Test]
        public void SearchItem()
        {
            // Upisuje tekst u search bar i trazi proizvod
            string searchItem = TestData.TestData.Search.searchItem.Trim().ToLower();
            Pages.IndexPage.SearchProduct(searchItem);

            // Asertacija - ime pronadjenog proizvoda uporedjujemo sa imenom trazenog proizvoda
            string foundItem = Pages.ProductPage.GetProductName();
            Assert.AreEqual(searchItem, foundItem);

        }
    }
}
