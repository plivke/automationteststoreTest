﻿using OpenQA.Selenium;
using System.Threading;

namespace AutomationFramework.Pages
{
    public class AccountEditPage : BasePage
    {
        /// <summary>
        /// Konstruktor bez parametara
        /// </summary>
        public AccountEditPage()
        {
            _driver = null;
        }

        /// <summary>
        /// Parametarizovani konstruktor
        /// </summary>
        /// <param name="webDriver">Driver</param>
        public AccountEditPage(IWebDriver webDriver)
        {
            _driver = webDriver;
        }

        // Locators
        //readonly By firstNameBy = By.Id("AccountFrm_firstname");
        //readonly By lastNameBy = By.Id("AccountFrm_lastname");
        //readonly By emailBy = By.Id("AccountFrm_email");
        readonly By telephoneBy = By.Id("AccountFrm_telephone");
        readonly By faxBy = By.Id("AccountFrm_fax");
        readonly By continueButtonBy = By.XPath("//button[@title='Continue']");

        ///// <summary>
        ///// Metoda koja menja ime korisnika
        ///// </summary>
        ///// <param name="firstName">Ime</param>
        //private void EnterFirstName(string firstName)
        //{
        //    WriteText(firstNameBy, firstName);
        //}

        ///// <summary>
        ///// Metoda koja menja prezime korisnika
        ///// </summary>
        ///// <param name="lastName">Prezime</param>
        //public void EnterLastName(string lastName)
        //{
        //    WriteText(lastNameBy, lastName);
        //}

        ///// <summary>
        ///// Metoda koja menja email korisnika
        ///// </summary>
        ///// <param name="email">Korisnicki email</param>
        //public void EnterEmail(string email)
        //{
        //    WriteText(emailBy, email);
        //}

        /// <summary>
        /// Metoda koja vraca string iz telephone polja
        /// </summary>
        /// <returns></returns>
        public string GetTelephone()
        {
            return ReadValue(telephoneBy);
        }

        /// <summary>
        /// Metoda koja menja broj telefona korisnika
        /// </summary>
        /// <param name = "newTelephone" > Broj telefona</param>
        public string EnterTelephone(string newTelephone)
        {
            string oldTelephone = GetTelephone();
            Thread.Sleep(1000);
            WriteText(telephoneBy, newTelephone);
            return oldTelephone;
        }

        /// <summary>
        /// Metoda koja menja broj faksa korisnika
        /// </summary>
        /// <param name = "newFax" > Broj faksa</param>
        public string EnterFax(string newFax)
        {
            string oldFax = ReadText(faxBy);
            WriteText(telephoneBy, newFax);
            return oldFax;
        }

        /// <summary>
        /// Metoda koja klikne na Continue dugme
        /// </summary>
        public void ClickOnCountinue()
        {
            ClickElement(continueButtonBy);
        }
    }
}