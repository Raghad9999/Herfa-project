using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using static OpenQA.Selenium.Support.UI.WebDriverWait;

using OpenQA.Selenium;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.Interactions;
using static MongoDB.Bson.Serialization.Serializers.SerializerHelper;
using System.Collections.ObjectModel;
using Docker.DotNet.Models;
using AventStack.ExtentReports.Model;
using System.Security.Cryptography;
using Herfa.Models;
using static System.Net.Mime.MediaTypeNames;

namespace Herfa
{

    [TestClass]
    public class HerfaFunctionTest
    {
        public static string EncodeToHash(string input)
        {
            string passHash = string.Empty;
            MD5 hash = MD5.Create();
            byte[] data = hash.ComputeHash(Encoding.Default.GetBytes(input));
            StringBuilder sb = new StringBuilder();
            foreach (byte b in data) { sb.Append(b.ToString()); }
            passHash = sb.ToString();
            return passHash;
        }



        public static ExtentHtmlReporter reporter;
        public static ExtentReports extent;




        [ClassInitialize()]
        public static void Setup(TestContext context)

        {
            reporter = new ExtentHtmlReporter(@"E:\Herfa\HerfaReport\");
            extent = new ExtentReports();
            extent.AttachReporter(reporter);
        }



        [ClassCleanup()]
        public static void CleanUp()

        {
            extent.Flush();
        }




        [TestMethod]
        public void T0_LoginTest()
        {   

            var test = extent.CreateTest("Login");
            SetUpHerfa.NavigateToWebPage();


            try
            {

                ModelContext model = new ModelContext();
                var users = model.LoginFps.Where(x => x.Roleid == 3).ToList();

                Random random = new Random();
                var randomUser = users[random.Next(0, users.Count)];



                IWebElement Login = SetUpHerfa.driver.FindElement(By.XPath("/html/body/header/div/div/div/div[3]/a[1]"));
                Login.Click();



                IWebElement user_name = SetUpHerfa.driver.FindElement(By.XPath("//*[@id=\"Email\"]"));
                System.Threading.Thread.Sleep(1000);
                user_name.SendKeys(randomUser.Email);



                IWebElement pass_word = SetUpHerfa.driver.FindElement(By.XPath("//*[@id=\"myPass1\"]"));
                randomUser.Password = EncodeToHash("Raghad.12345");
                model.Update(randomUser);
                model.SaveChanges();
                System.Threading.Thread.Sleep(1000);
                pass_word.SendKeys("Raghad.12345");



                IWebElement loginBtn = SetUpHerfa.driver.FindElement(By.XPath("/html/body/section/div/div/div[2]/form/div[6]/button"));
                System.Threading.Thread.Sleep(1000);
                loginBtn.Click();




                test.Pass("Login Sucssufully");
                string path = SetUpHerfa.TakeScreenshot();
                test.AddScreenCaptureFromPath(path);

            }


            catch (Exception e)
            {


                test.Fail("Login Fail");
                test.Log(Status.Error, e.Message);
                string path = SetUpHerfa.TakeScreenshot();
                test.AddScreenCaptureFromPath(path);



            }

        }



        [TestMethod]
        public void T1_Select_Category()
        {
            var test = extent.CreateTest("Select Category");

            try
            {

                IWebElement Categories = SetUpHerfa.driver.FindElement(By.XPath("/html/body/header/div/div/div/div[2]/nav/ul/li[2]/a"));
                System.Threading.Thread.Sleep(2000);
                Categories.Click();


                IWebElement fillter = SetUpHerfa.driver.FindElement(By.XPath("/html/body/div[1]/div[1]/div/form[1]/div/button"));
                System.Threading.Thread.Sleep(1000);
                fillter.Click();

                IWebElement Select_Categories = SetUpHerfa.driver.FindElement(By.XPath("/html/body/div[1]/div[1]/div/form[1]/div/div/a[3]"));
                System.Threading.Thread.Sleep(1000);
                Select_Categories.Click();



                test.Pass("Select Category Pass");
                string path = SetUpHerfa.TakeScreenshot();
                test.AddScreenCaptureFromPath(path);

            }
            catch (Exception e)
            {
                test.Fail("Select Category Faild");
                test.Log(Status.Error, e.Message);
                string path = SetUpHerfa.TakeScreenshot();
                test.AddScreenCaptureFromPath(path);



            }

        }


        [TestMethod]
        public void T2_Select_Products()
        {
            var test = extent.CreateTest("Select Product");
            try
            {

                IWebElement Select_Product1 = SetUpHerfa.driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div/div[2]/div/div[2]/div[1]/form/button/p/i"));
                System.Threading.Thread.Sleep(1000);
                Select_Product1.Click();

                IWebElement Select_Product2 = SetUpHerfa.driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div/div[3]/div/div[2]/div[1]/form/button/p/i"));
                System.Threading.Thread.Sleep(1000);
                Select_Product2.Click();

                IWebElement Select_Product3 = SetUpHerfa.driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div/div[4]/div/div[2]/div[1]/form/button/p/i"));
                System.Threading.Thread.Sleep(1000);
                Select_Product3.Click();


                test.Pass("Select Product Pass");
                string path = SetUpHerfa.TakeScreenshot();
                test.AddScreenCaptureFromPath(path);

            }
            catch (Exception e)
            {
                test.Fail("Select Product Fail");
                test.Log(Status.Error, e.Message);
                string path = SetUpHerfa.TakeScreenshot();
                test.AddScreenCaptureFromPath(path);


            }
        }



        [TestMethod]
        public void T3_Open_Cart()
        {
            var test = extent.CreateTest("Open Cart");
            try
            {

                IWebElement OpenCart = SetUpHerfa.driver.FindElement(By.XPath("/html/body/header/div/div/div/div[3]/ul/li/a/i"));
                System.Threading.Thread.Sleep(1000);
                OpenCart.Click();

                test.Pass("Open Cart Pass");
                string path = SetUpHerfa.TakeScreenshot();
                test.AddScreenCaptureFromPath(path);

            }
            catch (Exception e)
            {
                test.Fail("Open Cart Fail");
                test.Log(Status.Error, e.Message);
                string path = SetUpHerfa.TakeScreenshot();
                test.AddScreenCaptureFromPath(path);


            }

        }



        [TestMethod]
        public void T4_Open_CheckOut()
        {
            var test = extent.CreateTest("Open Checkout");

            try { 

            IWebElement OpenCheckOut = SetUpHerfa.driver.FindElement(By.XPath("//*[@id='ShoppingCarttt']/div/div[2]/div[3]/a[2]"));
            System.Threading.Thread.Sleep(2000);
            OpenCheckOut.SendKeys(Keys.Enter);
            OpenCheckOut.Click();



            test.Pass("Open Checkout Pass");
            string path = SetUpHerfa.TakeScreenshot();
            test.AddScreenCaptureFromPath(path);



        }
            catch (Exception e)
            {
                test.Fail("Open Checkout Fail");
                test.Log(Status.Error, e.Message);
                string path = SetUpHerfa.TakeScreenshot();
        test.AddScreenCaptureFromPath(path);


            }




}



        [TestMethod]
        public void T5_Payment_Process()
        {
            var test = extent.CreateTest("Payment");
            try
            {


                IWebElement Cardholder_Name = SetUpHerfa.driver.FindElement(By.CssSelector("body > div:nth-child(3) > section.p-4.p-md-5.mt-3 > div > div > div > div > form > div.form-outline.mb-4 > input"));
                System.Threading.Thread.Sleep(1000);

                Cardholder_Name.SendKeys(Keys.Enter);
                Cardholder_Name.SendKeys("Raghad Albetar");



                IWebElement Card_Number = SetUpHerfa.driver.FindElement(By.CssSelector("body > div:nth-child(3) > section.p-4.p-md-5.mt-3 > div > div > div > div > form > div.row.mb-4 > div.col-7 > div > input"));
                System.Threading.Thread.Sleep(1000);
                Card_Number.SendKeys("1234123412341234");


                IWebElement CVV = SetUpHerfa.driver.FindElement(By.CssSelector("body > div:nth-child(3) > section.p-4.p-md-5.mt-3 > div > div > div > div > form > div.row.mb-4 > div.col-5 > div > input"));
                System.Threading.Thread.Sleep(1000);
                CVV.SendKeys("789");


                IWebElement Expire = SetUpHerfa.driver.FindElement(By.XPath("/html/body/div[1]/section[2]/div/div/div/div/form/button"));
                System.Threading.Thread.Sleep(1000);


                Expire.SendKeys("April");
                Expire.SendKeys(Keys.Tab);
                Expire.SendKeys("2026");




                IWebElement Pay = SetUpHerfa.driver.FindElement(By.Id("staticBackdropLabel"));
                System.Threading.Thread.Sleep(1000);
                Pay.Click();

                System.Threading.Thread.Sleep(3000);

                IWebElement payspan = SetUpHerfa.driver.FindElement(By.XPath("/html/body/main/section/div/div/div[1]/form/div[4]/span"));
                string spanText = payspan.GetAttribute("innerText");
                Assert.AreEqual(spanText, "Success:");


                test.Pass("Payment Sucssufully");
                string path = SetUpHerfa.TakeScreenshot();
                test.AddScreenCaptureFromPath(path);


            }
            catch (Exception e)
            {


                test.Fail("Payment Fail");
                test.Log(Status.Error, e.Message);
                string path = SetUpHerfa.TakeScreenshot();
                test.AddScreenCaptureFromPath(path);

            }











        }
    }
}
