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

        }
    }
}
