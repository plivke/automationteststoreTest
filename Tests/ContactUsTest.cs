using NUnit.Framework;

namespace AutomationFramework.Tests
{
    public class ContactUsTest : BaseTest
    {
        [Test]
        public void ContactUs()
        {
            //Klik na ContactUs link
            Pages.IndexPage.ClickOnContactUs();

            //Popunjavanje forme
            Pages.ContactUsPage.FilloutContactUsForm(
                TestData.ContactUs.Form.firstName,
                TestData.ContactUs.Form.email,
                TestData.ContactUs.Form.enquiry);
            
            // Asertacija (Provera da li je poruka uspesno poslata)
            string expectedMsg = Constants.Messages.Success.enquirySent.Trim().ToLower();
            string actualMsg = Pages.ContactUsPage.GetSuccessMessage();
            Assert.AreEqual(expectedMsg, actualMsg);
        }
    }
}
