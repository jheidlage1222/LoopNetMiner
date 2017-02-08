using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using interactions = OpenQA.Selenium.Interactions;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;

namespace LoopNetMiner
{
    class MinerDriver
    {
        private static string UID = "jennifer.leblanc@colliers.com";
        private static string PWD = "leblanc2016";
        ChromeDriver driver = null;
        private TimeSpan awaitDisplay = new TimeSpan(0, 0, 30);
        private static List<SearchArea> searchAreas = new List<SearchArea>();
        public void SearchMine()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddExtensions(//"libraries\\AdBIock-Plus_v2.1.crx",
                                  //"libraries\\Block-image_v1.1.crx", 
                                  "dependencies\\AdBlock.crx",
                                  "dependencies\\ImgBlock.crx");

            //"libraries\\Adguard-AdBlocker_v2.5.11.crx");
            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().SetScriptTimeout(awaitDisplay);
            driver.Manage().Timeouts().ImplicitlyWait(awaitDisplay);
            driver.Manage().Timeouts().SetPageLoadTimeout(awaitDisplay);
            //driver.Manage().Window.Position = new System.Drawing.Point(0, 0);
            try
            {
                //Incase i didnt logout or someone is using the account #thuglife
                driver.Navigate().GoToUrl(Utils.LogoutUrl);
                //I was kind of hoping to avoid these but screw it, we're on the clock.
                //Just give it an extra second to do it's work.
                Thread.Sleep(1000);
            }
            catch
            {

            }
            driver.Url = @"http://www.loopnet.com";
            //
            driver.FindElementByXPath(Utils.LoginButtonXPath).Click();
            //Go to login page
            //driver.Navigate().GoToUrl(loginUrl);
            //uid
            var loginUidTextBox = driver.FindElement(By.Id("ctlLogin_LogonEmail"));
            loginUidTextBox.SendKeys(UID);
            //login
            var loginPwdTextBox = driver.FindElement(By.Id("ctlLogin_LogonPassword"));
            loginPwdTextBox.SendKeys(PWD);
            //
            //Click the login button
            //
            var loginBtn = driver.FindElementById("ctlLogin_btnLogon");
            loginBtn.Click();
            //
            //Fast track to the lease polygons (Collier's submarket)
            //
            //string namesXPath = "/html/body/form/div[5]/div/div/table/tbody/tr[1]";
            string savedSearchesUrl = "http://www.loopnet.com/xNet/MainSite/Listing/SavedSearches/MySavedSearches_FSFL.aspx?LinkCode=29400&ShowBasicLoggedInMsg=N";
            driver.Url = savedSearchesUrl;
            //
            List<String> collierSearchAreaNames = driver.FindElementsByXPath(Utils.SearchNameTDsXPath).Select(name => name.Text).ToList<string>();
            //
            //Get the lease and search area urls and then combine them.
            //
            List<String> collierSearchAreaUrls = driver.FindElementsByXPath(Utils.SearchLinksXPath).Select(href => href.GetAttribute("href")).ToList<string>();
            //
            if (collierSearchAreaNames.Count != collierSearchAreaUrls.Count || collierSearchAreaNames.Count == 0)
                throw new Exception($"Search area count {collierSearchAreaNames.Count} not inline with link count {collierSearchAreaUrls}");
            for (int i = 0; i < collierSearchAreaNames.Count; i++)
            {
                if(collierSearchAreaNames[i].ToLower().Contains("sale"))
                    searchAreas.Add(new SearchArea(collierSearchAreaNames[i], collierSearchAreaUrls[i]));
            }
            //
            //Iterate through types then pages for the type
            //

            List<string> propertyTypes = new List<string>();
            for (int i = 0; i < searchAreas.Count; i++)
            {
                driver.Url = searchAreas[i].BaseUrl;
                //
                //Make the property types visible

                //
                if (i == 0)
                {
                    //Need my overlay killer.
                    //
                    driver.FindElementByXPath(Utils.AllPropertyTypesBtnXPath).Click();
                    //
                    //Uncheck all Types
                    IWebElement selectAllElement = driver.FindElementByXPath(Utils.SelectAllPropertyTypesChkBoxXPath);
                    if (selectAllElement.GetAttribute("checked") == "checked")
                        selectAllElement.Click();
                    //
                    propertyTypes.AddRange(driver.FindElementsByXPath(Utils.PropertyTypeNamesXPath).ToList().Select(x => x.Text));
                }
                else
                {
                    //List<IWebElement> propertyTypeLIs = driver.FindElementsByXPath(Utils.PropertyTypesLIElementsXPath).ToList();
                    //IWebElement prevPropertyBox = propertyTypeLIs.s
                }
                
                //Need to process properties on each page.

                //Move to next.



            }
        }
    }
}
