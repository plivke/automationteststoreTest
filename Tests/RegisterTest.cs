﻿using AutomationFramework.Utils;
using NUnit.Framework;
using System.Linq;

namespace AutomationFramework.Tests
{
    public class RegisterTest : BaseTest
    {
        // Generacija slucajnih korisnickih polja
        static readonly string _firstName = TestData.User.Registration.firstName;
        static readonly string _loginName = CommonMethods.GenerateRandomUsername(_firstName);
        static readonly string _email = _loginName + CommonMethods.GetRandomItemFromList(
        TestData.User.Registration.emailSufix.ToList<string>());

        [Test]
        public void Register()
        {
            // Registracija korisnika NEOPHODNIM podacima za registraciju
            Pages.IndexPage.ClickOnLoginOrRegister();
            Pages.AccountPage.ClickOnContinue();
            Pages.AccountCreatePage.RegisterWithRequiredOnly(
                _firstName,
                TestData.User.Registration.lastName,
                _email,
                TestData.User.Registration.address,
                TestData.User.Registration.city,
                TestData.User.Registration.zipCode,
                _loginName,
                TestData.User.Registration.password,
                TestData.User.Registration.notSubscribed);

            // Asertacija - provera postojanja poruke za uspesnu registraciju
            string expectedMsg = Constants.Messages.Success.registration.Trim().ToLower();
            string actualMsg = Pages.AccountCreatePage.GetSuccessMessage();
            Assert.AreEqual(expectedMsg, actualMsg);
        }
    }
}
