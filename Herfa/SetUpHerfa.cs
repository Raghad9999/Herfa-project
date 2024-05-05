using System.Drawing;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Herfa
{
    [TestClass]
    public class SetUpHerfa
    {
        public static IWebDriver driver = new ChromeDriver();
        public static string url = "https://localhost:44349/";


        public static void NavigateToWebPage()
        {
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Size = new Size(1500, 800);


        }




        public static int imageId = 0;
        public static string TakeScreenshot()
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            string path = @"E:\Herfa\HerfaScreenshot";
            string fullPath = Path.Combine(path + "/Image" + imageId + ".png");
            screenshot.SaveAsFile(fullPath, ScreenshotImageFormat.Png);
            imageId++;
            return fullPath;
        }


    }
}
