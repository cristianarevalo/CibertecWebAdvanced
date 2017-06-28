using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Cibertec.Automation
{
    public class Driver
    {
        public static IWebDriver Instance { get; set; }
        public static void GetInstance()
        {
            Instance = Instance ?? ChromeDriver();
        }

        public static IWebDriver ChromeDriver()
        {
            var options = new ChromeOptions();
            options.AddArguments("chrome.switches", "--disable-extensions --disable-extensions-file-access-check --disable-extensions-http-throttling --disable-infobars --enable-automation --start-maximized");
            options.AddUserProfilePreference("credentials_enable_service", false);
            options.AddUserProfilePreference("profile.password_manager_enabled", false);
            return new ChromeDriver(options);
        }

        public static void CloseInstance()
        {
            Instance.Close();
            Instance.Quit();
            Instance = null;
        }
    }
}
