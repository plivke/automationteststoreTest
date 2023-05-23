using System.Collections.Generic;

namespace AutomationFramework.TestData
{
    public class TestData
    {
        public static class RegisterUser
        {
            public const string
                firstName = "Simon",
                lastName = "Simonovic",
                email = "simonovic22@yahoo.com",
                address = "Grcica Milenka 11",
                city = "Novi Sad",
                country = "",
                regionState = "",
                zipCode = "49000",
                telephone = "00381631072590",
                loginName = "simo22",
                password = "password123";

            public const bool
                subscribed = true,
                notSubscribed = false;

            public static readonly List<string>
                emailSufix = new List<string>()
            {
                "@yahoo.com", "@gmail.com", "@its.edu.rs", "@comtrade.com"
            };
        }

        public static class Login
        {
            public const string
                username = "Simon9000",
                password = "password123";
        }

        public static class CartItem
        {
            public const string
                itemId = "68";
        }

        public static class Wishlist
        {
            public const string itemName = "Skinsheen Bronzer Stick";
        }

        public static class ContactUs
        {
            public const string
                firstName = "Ivan",
                email = "jedvaNasaoContactUs@link.com",
                enquiry = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. " +
                "Morbi condimentum varius leo non efficitur. Sed ultricies, dui auctor " +
                "auctor aliquam, lectus diam mattis risus, in tincidunt dolor erat sed " +
                "nisl. Integer id semper enim. Nulla eget purus mattis, lacinia mauris ut, " +
                "ultrices felis. Nulla venenatis ornare arcu eu pulvinar. Vivamus ut leo et " +
                "ligula rutrum faucibus. Pellentesque elementum libero quis convallis euismod." +
                " Donec eu lacus cursus, dictum orci vitae, tempor erat. Proin ultrices " +
                "consectetur mattis. Ut eget nisl a nibh malesuada pellentesque.";
        }
        public static class Search
        {
            public const string
                searchItem = "Benefit Bella Bamba";
        }
        public static class GuestUser
        {
            public const string
                firstName = "Roy",
                lastName = "Keane",
                email = "RoyTheBoy16@hotmail.com",
                address = "Sheep Lovers Street 98",
                city = "Nothingham",
                country = "United Kingdom",
                regionState = "North Lanarkshire",
                zipCode = "69000",
                telephone = "00381631072590",
                loginName = "RoyTheBoy16",
                password = "password123";
        }
    }
}

