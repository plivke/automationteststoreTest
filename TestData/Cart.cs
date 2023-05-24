using System.Collections.Generic;

namespace AutomationFramework.TestData
{
    public class Cart
    {
        public static class CartItem
        {
            public static readonly IEnumerable<string> itemId =
                new List<string>()
                {
                     "50", "52", "65", "66", "72", "88", "114"
                };
            public static readonly IEnumerable<string> itemName =
                new List<string>()
                {
                    // Commented items are *curently* OUT OF STOCK
                    "Skinsheen Bronzer Stick", /*"BeneFit Girl Meets Pearl",*/
                    "Benefit Bella Bamba", "Tropiques Minerale Loose Bronzer",
                    "Absolute Anti-Age Spot Replenishing Unifying TreatmentSPF 15",
                    /*"Flash Bronzer Body Gel",*/ "Total Moisture Facial Cream",
                    "New French With Ease (1 book + 1 mp3 CD)", "Total Moisture Facial Cream"
                };
        }
    }
}
