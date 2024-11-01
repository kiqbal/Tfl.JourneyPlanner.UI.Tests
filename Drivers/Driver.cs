using Microsoft.Playwright;

namespace Tfl.JourneyPlanner.UI.Tests.Drivers
{
    public class Driver : IDisposable
    {
        private readonly Task<IPage> _page;
        private IBrowser? _browser;

        public Driver()
        {
            _page = InitializePlaywright();
        }
        public IPage Page => _page.Result;

        public async Task<IPage> InitializePlaywright()
        {
            //PlayWright
            var playwright = await Playwright.CreateAsync();

            _browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false, // Set to true if you want headless mode
                Channel = "chrome" // Specify Chrome as the browser channel
            });

           /* //Browser
            _browser = await playwright.Firefox.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
            });*/

            //Page
            return await _browser.NewPageAsync();

        }
        public void Dispose()
        {

            _browser?.CloseAsync();
        }
    }
}

