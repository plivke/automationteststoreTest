using NUnit.Framework;

namespace AutomationFramework.Tests
{
    public class ContactUsTest : BaseTest
    {
        [Test]
        public void ContactUs()
        {
            Pages.IndexPage.ClickOnContactUs();
            Pages.ContactUsPage.FilloutContactUsForm(
                TestData.TestData.ContactUs.firstName,
                TestData.TestData.ContactUs.email,
                TestData.TestData.ContactUs.enquiry);
            // Asertacija
            string expectedMsg = Constants.Messages.Success.enquirySent.Trim().ToLower();
            string actualMsg = Pages.ContactUsPage.GetSuccessMessage();
            Assert.AreEqual(expectedMsg, actualMsg);
        }
    }
}
