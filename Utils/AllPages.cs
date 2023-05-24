using AutomationFramework.Pages;
using SeleniumExtras.PageObjects;
using System;

namespace AutomationFramework.Utils
{
    /// <summary>
    /// Klasa koja inicijalicuje potrebnu stranicu
    /// </summary>
    public class AllPages
    {
        public AllPages(Browsers browser)
        {
            Browser = browser;
        }
        Browsers Browser { get; }
        private T GetPages<T>() where T : new()
        {
            var page = (T)Activator.CreateInstance(typeof(T), Browser.GetDriver);
            PageFactory.InitElements(Browser.GetDriver, page);
            return page;
        }
        public IndexPage IndexPage => GetPages<IndexPage>();
        public AccountPage AccountPage => GetPages<AccountPage>();
        public AccountCreatePage AccountCreatePage => GetPages<AccountCreatePage>();
        public AccountLogoutPage AccountLogoutPage => GetPages<AccountLogoutPage>();
        public AccountForgottenPage AccountForgottenPage => GetPages<AccountForgottenPage>();
        public CartPage CartPage => GetPages<CartPage>();
        public ProductPage ProductPage => GetPages<ProductPage>();
        public ContactUsPage ContactUsPage => GetPages<ContactUsPage>();
        public CheckoutPage CheckoutPage => GetPages<CheckoutPage>();
        public GuestCheckoutPage GuestCheckoutPage => GetPages<GuestCheckoutPage>();
        public WishlistPage WishlistPage => GetPages<WishlistPage>();
        public ChangePasswordPage ChangePasswordPage => GetPages<ChangePasswordPage>();
        public AccountEditPage AccountEditPage => GetPages<AccountEditPage>();
    }
}
