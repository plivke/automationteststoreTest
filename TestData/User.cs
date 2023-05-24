using System.Collections.Generic;

namespace AutomationFramework.TestData
{
    public class User
    {
        public static class Registration
        {
            public const string
                firstName = "Simon",
                lastName = "Says",
                email = "mrAntonino812@yahoo.com",
                address = "Ulica Bezbrojna 31",
                city = "Grad greha",
                country = "",
                regionState = "",
                zipCode = "49000",
                telephone = "00381631072590",
                loginName = "simonito",
                password = "simonito"; //simonito53155
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
                username = "lukac",
                password = "lukac",
                firstName = "Luka",
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
                firstName = "Simon",
                lastName = "Says",
                email = "mrAntonino812@yahoo.com",
                address = "Ulica Bezbrojna 31",
                city = "Grad greha",
                country = "",
                regionState = "",
                zipCode = "49000",
                telephone = "00381631072590",
                loginName = "simonito",
                password = "simonito",
                forgottenEmail = "",
                forgottenLastName = "";
        }

        public static class AccountEdit
        {
            public static string
                username = "webersmark2",
                password = "webersmark2",
                firstName = "Mark",
                lastName = "Webber",
                email = "webbersmark2@yahoo.com",
                telephone1 = "00231353421",
                telephone2 = "1199310",
                address1 = "Middle of Nowhere 22",
                city = "Sin City",
                fax = "";
        }
    }
}
