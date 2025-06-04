using OpenQA.Selenium;
using System;
using System.IO;

namespace AutomationFramework.Core.Utilities
{
    public static class ScreenshotHelper
    {
        public static void TakeScreenshot(IWebDriver driver, string scenarioTitle)
        {
            try
            {
                ITakesScreenshot screenshotDriver = driver as ITakesScreenshot;
                Screenshot screenshot = screenshotDriver.GetScreenshot();
                string screenshotFileName = $"{scenarioTitle}_{DateTime.Now:yyyyMMdd_HHmmss}.png";
                string screenshotFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Screenshots", screenshotFileName);
                screenshot.SaveAsFile(screenshotFilePath, ScreenshotImageFormat.Png);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error taking screenshot: {ex.Message}");
            }
        }
    }
}
