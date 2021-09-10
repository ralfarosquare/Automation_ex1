using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;

namespace Automation_ex1
{
    class Program
    {
        IWebDriver driver;
        public IWebDriver SetUpDriver()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            return driver;
        }
        public void Click(IWebElement element)
        {
            element.Click();
        }

        public void EnterText(IWebElement element, string value)
        {
            element.SendKeys(value);
        }

        //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        #region Facebook Locators 
        By CreateNewAccount = By.XPath("/html/body/div[1]/div[2]/div[1]/div/div/div/div[2]/div/div[1]/form/div[5]/a");
        By FirstNameField = By.Name("firstname");
        By LastNameField = By.Name("lastname");
        By MobileNumberField = By.Name("reg_email__");
        By NewPwdField = By.Id("password_step_input");
        By NonSpecificThing = By.XPath("/html/body/div[1]/section/main/article/div[2]/div[2]/div/p/a/span");
        By TermsLink = By.Id("terms-link");
        
        #endregion

        static void Main(string[] args)
        {   
            IWebElement element;
            IWebDriver driver = new ChromeDriver();
            Program program = new Program();
            driver = program.SetUpDriver();
            driver.Url = "https://www.facebook.com/";

            

            var element1 = driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[1]/div/div/div/div[1]/h2"));
            Assert.IsTrue(element1.Displayed);
            Console.WriteLine("The Text :", element1, "is the same as the log in screen");

            element = driver.FindElement(program.CreateNewAccount);

            program.Click(element);

            element = driver.FindElement(program.FirstNameField);
            program.EnterText(element, "Rodrigo Alonso");

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            element = driver.FindElement(program.LastNameField);
            program.EnterText(element, "Alfaro");


            element = driver.FindElement(program.MobileNumberField);
            program.EnterText(element, "1234567890");

            element = driver.FindElement(program.NewPwdField);
            program.EnterText(element, "Unosquare090921");

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            element = driver.FindElement(program.TermsLink);
            program.Click(element);

            /*  List<IWebElement> elementList = new List<IWebElement>();
              elementList.AddRange(driver.FindElements(By.ClassName("_1-qq")));

              if (elementList.Count > 0 )
              {

                  elementList[0].Click();
              }
              else
              {

                  Console.WriteLine("Menu from 1 to 5 does not exist");
              }*/
            IList<IWebElement> attachmentList = driver.FindElements(By.XPath("/html/body/div[1]/div[3]/div[1]/div/div/div[2]/div[1]/div[1]"));

            foreach (IWebElement elements in attachmentList)
            {
                Console.WriteLine(elements.Text);
            }


            try
            {
                IWebElement IgIcon = driver.FindElement(By.XPath("/html/body/div[1]/section/main/div/div/div[1]/h1"));
            }
            catch (NoSuchElementException IgIconNotDisplayed)
            {
               
                Console.WriteLine("It is not displayed the icon. The icon link belongs to instagram");
            }


            //Second Test


            /*  String expectedtitle = "Condiciones del servicio";

              String actualtitle = driver.FindElement(By.LinkText("Condiciones del servicio")).Text.ToString();

              Assert.AreEqual(expectedtitle, actualtitle);

              Console.WriteLine(expectedtitle, "is the same as :", actualtitle);*/


          


          

        }
    }
}
