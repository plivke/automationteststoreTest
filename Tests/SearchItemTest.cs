using NUnit.Framework;

namespace AutomationFramework.Tests
{
    public class SearchItemTest : BaseTest
    {
        [Test]
        public void SearchItem()
        {
            string searchItem = TestData.TestData.Search.searchItem.Trim().ToLower();
            Pages.IndexPage.SearchProduct(searchItem);

            string foundItem = Pages.ProductPage.GetProductName();
            // Asertacija
            Assert.AreEqual(searchItem, foundItem);

        }
    }
}
