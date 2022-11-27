using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
	public static class Drivers
	{
		private static IWebDriver _driver;

		class Command
		{
			public int beklemeSuresi { get; set; }
			public string command { get; set; }
		}
		public static object JsRun(this IWebDriver driver, string command)
		{


			IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
			int count = 0;
			string exMg;
			while (count < 10)
			{
				Thread.Sleep(500);
				count++;
				try
				{
					dynamic result = jse.ExecuteScript(command);
					var tp = typeof(ReadOnlyCollection<object>);
					if (result?.GetType() == tp && result.Count == 0) continue;
					if (result != null || !command.Contains("return"))
						return result;
				}
				catch (Exception ex)
				{
					exMg = ex.Message;
					continue;

				}
			}
			return null;

		}
		private static IWebDriver OptionDriver()
		{
			ChromeOptions chromeOptions = new();
			ChromeDriverService service = ChromeDriverService.CreateDefaultService();
			chromeOptions.PageLoadStrategy = PageLoadStrategy.Eager;
			chromeOptions.AddArgument("test-type");
			chromeOptions.AddArgument("--ignore-certificate-errors");
			chromeOptions.AddArgument("no-sandbox");
			chromeOptions.AddArgument("disable-infobars");
			chromeOptions.AddArgument("--window-size=400,820");
			chromeOptions.EnableMobileEmulation("Pixel 2 XL");
			service.HideCommandPromptWindow = true;
			IWebDriver driver = new ChromeDriver(service, chromeOptions);
			driver.Manage().Window.Size = new Size(400, 820);
			return driver;
		}
		public static void KillChromeProcces()
		{
			foreach (Process item in Process.GetProcesses())
			{
				if (item.ProcessName is "chrome" or "chromedriver" or "conhost")
				{
					try
					{
						double s = (DateTime.Now - item.StartTime).TotalSeconds;
						if (s >= 30) { item.Kill(); }
					}
					catch {; }
				}
			}
		}
		public static IWebDriver CreateDrivers()
		{
			//   KillChromeProcces();
			return OptionDriver();
		}
	}
}
