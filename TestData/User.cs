using System.Collections.Generic;
using System.Web;

namespace AutomationFramework.TestData
{
    public class User
    {
        public static class Registration
        {
            public const string
                firstName = "GlupoImeDobraEmailAdresa",
                lastName = "Antonino",
                email = "mrAntonino22@yahoo.com",
                address = "Ulica Bezbrojna 31",
                city = "Grad greha",
                country = "",
                regionState = "",
                zipCode = "49000",
                telephone = "00381631072590",
                loginName = "Marco72",
                password = "password123";

            public const bool
                subscribed = true,
                notSubscribed = false;

            public static readonly IEnumerable<string>
                emailSufix = new List<string>()
            {
                "@yahoo.com",
                "@gmail.com",
                "@its.edu.rs",
                "@comtrade.com"
            };
        }
        public static class Login
        {
            public static string
                username = "GlupoImeDobraEmailAdresa30902",
                password = "password123",
                firstName = "Simon",
                wrongusername = "Simon9001",
                wrongpassword = "wrongpass";
        }

        public static class Guest
        {
            public const string
                firstName = "Paul",
                lastName = "Scholes",
                email = "ginger16@hotmail.com",
                address = "Sheep Lovers Street 98",
                city = "Nothingham",
                country = "United Kingdom",
                regionState = "North Lanarkshire",
                zipCode = "69000",
                telephone = "00381631072590",
                loginName = "ginger16",
                password = "password123";
        }

        public static class AccountForgotten
        {
            public static string
                forgottenEmail = "",
                forgottenLastName = "";
        }
    }
}
