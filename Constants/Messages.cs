namespace AutomationFramework.Constants
{
    public class Messages
    {
        public static class Success
        {
            public const string
                registration = "Your account has been created!",
                welcomeBack = "Welcome back ",
                passwordReset = "×\r\nSuccess: Password reset link has been sent to your e-mail address.",
                loginRemider = "×\r\nSuccess: Your login name reminder has been sent to your e-mail address.",
                enquirySent = "Your enquiry has been successfully sent to the store owner!",
                orderProcessed = " Your Order Has Been Processed!";
        }

        public static class ListEmpty
        {
            public const string
                cart = "\r\n\r\n\tYour shopping cart is empty!\t\r\n\t",
                wishlist = "\r\n\r\n\tWish list is empty\t\r\n\t";

        }

        public static class Error
        {
            public const string incorrectlogin = "×\r\nError: Incorrect login or password provided.",
                                emailAdressError = "×\r\nError: E-Mail Address is already registered!";
        }
    }
}