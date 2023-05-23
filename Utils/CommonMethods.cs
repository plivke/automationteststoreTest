
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace AutomationFramework.Utils
{
    public class CommonMethods
    {
        /// <summary>
        /// Metoda koja klikne na element
        /// </summary>
        /// <param name="driver">driver</param>
        /// <param name="elementBy">element</param>
        public static void ClickOnElement(IWebDriver driver, By elementBy)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(ExpectedConditions.ElementIsVisible(elementBy));

            element.Click();
        }

        public static void HoverOnElement(IWebDriver driver, By elementBy)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(ExpectedConditions.ElementIsVisible(elementBy));

            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();
        }

        /// <summary>
        /// Metoda koja upisuje text u element
        /// </summary>
        /// <param name="driver">driver</param>
        /// <param name="elementBy">element</param>
        /// <param name="text">text koji se upisuje</param>
        public static void WriteTextToElement(IWebDriver driver, By elementBy, string text)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(ExpectedConditions.ElementIsVisible(elementBy));

            element.Clear();
            element.SendKeys(text);
        }

        /// <summary>
        /// Metoda koja cita text iz elementa
        /// </summary>
        public static string ReadTextFromElement(IWebDriver driver, By elementBy)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(ExpectedConditions.ElementIsVisible(elementBy));
            return element.Text;
        }

        /// <summary>
        /// Metoda koja kreira jedinstvenog korisnika, kreirajuci random broj
        /// kao sufix na "Random User" string
        /// </summary>
        /// <param name="randomName">osnova za username</param>
        /// <returns>Vraca slucajan Username</returns>
        public static string GenerateRandomUsername(string randomName)
        {
            int randomNumber = GenerateRandomNumber(1111, 6666);
            string username = randomName + randomNumber;
            return username;
        }

        /// <summary>
        /// Metoda koja generise random broj
        /// </summary>
        /// <returns>Vraca random broj od do</returns>
        public static int GenerateRandomNumber(int from, int to)
        {
            Random random = new Random();
            int randomNumber = random.Next(from, to);
            return randomNumber;
        }

        /// <summary>
        /// Metoda koja proverava da li se element nalazi na stranici
        /// </summary>
        /// <param name="driver">driver</param>
        /// <param name="elementBy">lokator elementa By</param>
        /// <returns>Vraca true/false</returns>
        public static bool IsElementPresented(IWebDriver driver, By elementBy)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                var element = wait.Until(ExpectedConditions.ElementIsVisible(elementBy));

                return element.Displayed;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Metoda koja konvertuje string cene proizvoda u decimalni tip, pri tome
        /// otklanjajuci simbol valute koja se uz cifre nalazi. Npr. $32.66 => 32.66
        /// </summary>
        /// <param name="driver">driver</param>
        /// <param name="elementBy">lokator elementa</param>
        /// <returns>Vraca decimalnu vrednost proizvoda</returns>
        public static decimal PriceTextToDecimal(IWebDriver driver, By elementBy)
        {
            string priceCurrency = ReadTextFromElement(driver, elementBy);
            char[] currency = Constants.Misc.currencies.Cast<char>().ToArray();
            decimal price = 0m;
            decimal.TryParse(priceCurrency.Trim(currency), out price);
            return price;
        }

        /// <summary>
        /// Metoda koja vraca sve opcije iz select elementa
        /// </summary>
        /// <param name="driver">driver</param>
        /// <param name="elementBy">lokator elementa</param>
        /// <returns>Vraca listu opcija iz select elementa, u malim slovima</returns>
        public static List<string> GetAllOptions(IWebDriver driver, By elementBy)
        {
            List<string> optionsList = new List<string>();
            try
            {
                ReadOnlyCollection<IWebElement> options = driver.FindElements(elementBy);

                foreach (IWebElement option in options)
                {
                    optionsList.Add(option.Text.Trim().ToLower());
                }
            }
            catch (Exception)
            {

                throw;
            }
            return optionsList;
        }

        /// <summary>
        /// Metoda koja vraca random vrednost iz liste
        /// </summary>
        /// <param name="list">lista</param>
        /// <returns>Vraca random vrednost iz liste</returns>
        public static string GetRandomItemFromList(List<string> list)
        {
            Random rnd = new Random();
            return list[rnd.Next(0, list.Count - 1)];
        }
    }
}
