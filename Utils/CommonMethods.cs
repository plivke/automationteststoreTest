using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AutomationFramework.Utils
{
    public class CommonMethods
    {
        /// <summary>
        /// Metoda koja ceka vidljivost elementa
        /// </summary>
        /// <param name="elementBy">Lokator elementa</param>
        private static IWebElement WaitElementVisibility(IWebDriver driver, By elementBy, byte timespan = 5)
        {
            WebDriverWait wait = new(driver, TimeSpan.FromSeconds(timespan));
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(elementBy));
            return element;
        }

        /// <summary>
        /// Metoda koja klikne na element
        /// </summary>
        /// <param name="driver">Driver</param>
        /// <param name="elementBy">Lokator elementa</param>
        public static void ClickOnElement(IWebDriver driver, By elementBy)
        {
            WaitElementVisibility(driver, elementBy).Click();
        }

        /// <summary>
        /// Metoda koja simulira kratko drzanje pointera misa na elementu
        /// kako bi se element dinamicno prikazao
        /// </summary>
        /// <param name="driver">Driver</param>
        /// <param name="elementBy">Lokator elementa</param>
        public static void HoverOnElement(IWebDriver driver, By elementBy)
        {
            Actions action = new(driver);
            action.MoveToElement(WaitElementVisibility(driver, elementBy)).Perform();
        }

        /// <summary>
        /// Metoda koja upisuje text u element
        /// </summary>
        /// <param name="driver">Driver</param>
        /// <param name="elementBy">Lokator elementa</param>
        /// <param name="text">text koji se upisuje</param>
        public static void WriteTextToElement(IWebDriver driver, By elementBy, string text)
        {
            IWebElement element = WaitElementVisibility(driver, elementBy);
            element.Clear();
            element.SendKeys(text);
        }

        /// <summary>
        /// Metoda koja cita textualni sadrzaj elementa
        /// </summary>
        public static string ReadTextFromElement(IWebDriver driver, By elementBy)
        {
            return WaitElementVisibility(driver, elementBy).Text;
        }

        /// <summary>
        /// Metoda koja cita sadrzaj atributa value iz elementa
        /// </summary>
        public static string ReadValueFromElement(IWebDriver driver, By elementBy)
        {
            return WaitElementVisibility(driver, elementBy).GetAttribute("value");
        }


        /// <summary>
        /// Metoda koja po indeksu bira jedan slucajan podelement Select-a
        /// </summary>
        /// <param name="driver">Driver</param>
        /// <param name="elementBy">Lokator elementa</param>
        public static void SelectRandomElement(IWebDriver driver, By elementBy)
        {
            SelectElement element = new(WaitElementVisibility(driver, elementBy));
            // provera da li postoji vise od 2 opcije, ako postoji izaberi slucajnu opciju
            // ako ne postoji selectuj opciju na index[1], index[0] je nevalidan
            if (element.Options.Count > 2)
                element.SelectByIndex(GenerateRandomNumber(1, element.Options.Count - 1));
            else
                element.SelectByIndex(1);
        }

        /// <summary>
        /// Metoda koja kreira slucajni korisnicki username, kreirajuci
        /// slucajni broj kao sufix na imenu korisnika
        /// </summary>
        /// <param name="name">osnova za username</param>
        /// <returns>slucajan username</returns>
        public static string GenerateRandomUsername(string name)
        {
            int randomNumber = GenerateRandomNumber(4095, 65535);
            string username = name + randomNumber;
            return username;
        }

        /// <summary>
        /// Metoda koja generise slucajni broj
        /// </summary>
        /// <returns>slucajni broj</returns>
        public static int GenerateRandomNumber(int from, int to)
        {
            Random random = new();
            int randomNumber = random.Next(from, to);
            return randomNumber;
        }

        /// <summary>
        /// Metoda koja proverava da li se element nalazi na stranici
        /// </summary>
        /// <param name="driver">Driver</param>
        /// <param name="elementBy">Lokator elementa</param>
        /// <returns>true ako postoji element, false ako ne postoji element</returns>
        public static bool IsElementPresented(IWebDriver driver, By elementBy)
        {
            try
            {
                return WaitElementVisibility(driver, elementBy, 2).Displayed;
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
        /// <param name="driver">Driver</param>
        /// <param name="elementBy">Lokator elementa</param>
        /// <returns>Vraca decimalnu vrednost proizvoda</returns>
        public static decimal PriceTextToDecimal(IWebDriver driver, By elementBy)
        {
            string priceCurrency = ReadTextFromElement(driver, elementBy);
            // U niz karaktera ubacujemo moguce simbole valuta koje se trimuju iz
            // stringa 
            char[] currency = Constants.Misc.currencies.Cast<char>().ToArray();
            _ = decimal.TryParse(priceCurrency.Trim(currency), out decimal price);

            return price;
        }

        /// <summary>
        /// Metoda koja vraca slucajne vrednost iz liste
        /// </summary>
        /// <param name="list">Lista vrednosti</param>
        /// <returns>slucajna vrednost iz liste</returns>
        public static string GetRandomItemFromList(List<string> list)
        {
            Random rnd = new();
            return list[rnd.Next(0, list.Count - 1)];
        }
    }
}
