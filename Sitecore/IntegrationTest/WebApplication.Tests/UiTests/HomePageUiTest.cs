using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Net.Http;
using System.Threading;
using Xunit;

namespace WebApplication.Tests.UiTests
{
    public class HomePageUiTest : IClassFixture<SeleniumServerFactory<Startup>>, IDisposable
    {
        public SeleniumServerFactory<Startup> Server { get; }
        public IWebDriver Browser { get; }
        public HttpClient Client { get; }
        public ILogs Logs { get; }

        public HomePageUiTest(SeleniumServerFactory<Startup> server)
        {
            Server = server;
            Client = server.CreateClient(); //weird side effecty thing here. This call shouldn't be required for setup, but it is.

            Thread.Sleep(2000);
            var opts = new ChromeOptions();
            opts.AddArgument("--headless"); //Optional, comment this out if you want to SEE the browser window
            opts.SetLoggingPreference(OpenQA.Selenium.LogType.Browser, LogLevel.All);

            var driver = new RemoteWebDriver(opts);
            Browser = driver;
            Logs = new RemoteLogs(driver); //TODO: Still not bringing the logs over yet
        }

        [Fact]
        public void HomePageBrowserTitle()
        {
            Browser.Navigate().GoToUrl(Server.RootUri);
            Assert.StartsWith("Home Page", Browser.Title);
        }

        public void Dispose()
        {
            Browser.Dispose();
        }
    }
}
