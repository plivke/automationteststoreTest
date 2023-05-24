using AutomationFramework.Utils;
using NUnit.Framework;
using System.Linq;

namespace AutomationFramework.Tests
{
    public class SearchItemTest : BaseTest
    {
        static readonly string _searchItem =
            CommonMethods.GetRandomItemFromList(TestData.Search.Items.itemName.ToList<string>());

        [Test]
        public void SearchItem()
        {
            // Upisuje tekst u search bar i trazi proizvod
            Pages.IndexPage.SearchProduct(_searchItem);

            // Asertacija - ime pronadjenog proizvoda uporedjujemo sa imenom trazenog proizvoda
            string foundItem = Pages.ProductPage.GetProductName();
            Assert.AreEqual(_searchItem, foundItem);
        }
    }
}
