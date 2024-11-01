using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tfl.JourneyPlanner.UI.Tests.Drivers;
using Tfl.JourneyPlanner.UI.Tests.Utilities;
namespace Tfl.JourneyPlanner.UI.Tests.Pages
{
    internal class TflPlanJourneyPage
    {
        private IPage _page;
        private readonly ILocator textField_journeyFrom;
        private readonly ILocator textField_journeyTo;
        private readonly ILocator btn_planAJourney;
        private readonly ILocator _cookieOverlay;
        private readonly ILocator _inputFromError;
        private readonly ILocator _inputToError;
        private readonly HelperClass _helperClass;

        public TflPlanJourneyPage(IPage page)
        {
            _page = page;
            _helperClass = new HelperClass(_page);
            textField_journeyFrom = _page.Locator("input[name='InputFrom']");
            textField_journeyTo = _page.Locator("input[name='InputTo']");
            btn_planAJourney = _page.Locator("id=plan-journey-button");
            _cookieOverlay = _page.Locator("#CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll");
            _inputFromError = _page.Locator("#InputFrom-error");
            _inputToError = _page.Locator("#InputTo-error");

            /* _btnLogin = _page.Locator("id=next");
             _InvalidLoginMsg = _page.Locator("text='Your password is incorrect'");
             _accessDeniedMsg = _page.Locator("//h1[contains(text(), 'Access Denied')]");
             _horizonWorkMsg = _page.Locator(" //h1[contains(text(), 'horizon works')]");*/

        }

        public async Task ClickPlanJourneyBtn()
            {
            await btn_planAJourney.ClickAsync();
            }


        public async Task EnterFromJourney(string JourneyFromText)
        {
            await _page.WaitForLoadStateAsync();
            // Text to type slowly


            // Type each character with a delay to trigger suggestions
            foreach (char c in JourneyFromText)
            {
                await textField_journeyFrom.PressAsync(c.ToString());
                await _page.WaitForTimeoutAsync(200);
            }
           /* //Thread.Sleep(60000);
            await textField_journeyFrom.FillAsync(JourneyFromText);*/
           
        }

        public async Task EnterToJourney(string JourneyToText)
        {
            await _page.WaitForLoadStateAsync();
            // Text to type slowly


            // Type each character with a delay to trigger suggestions
            foreach (char c in JourneyToText)
            {
                await textField_journeyTo.PressAsync(c.ToString());
                await _page.WaitForTimeoutAsync(200);
            }
            /* //Thread.Sleep(60000);
             await textField_journeyFrom.FillAsync(JourneyFromText);*/

        }

        public async Task SelectDropdownValueAsync(string inputText)
        {
            // Wait for the dropdown elements to appear
            await _page.WaitForSelectorAsync("span[class='tt-suggestions']");

            // Get all elements with the selector
            var dropdownElements = await _page.QuerySelectorAllAsync("div[class='tt-suggestion']");

            // Loop through each element to find the one matching the input text
            foreach (var element in dropdownElements)
            {
                var textContent = await element.InnerTextAsync();
                if (textContent.Contains(inputText, StringComparison.OrdinalIgnoreCase))
                {
                    await element.ClickAsync();
                    return;
                }
            }

            // Throw an exception if the desired text was not found
            throw new Exception($"Dropdown value '{inputText}' not found.");
        }
        public async Task HandleAndValidateCookieOverlayAsync()
        {
            /*try
            {
                // Attempt to locate and interact with the cookie banner if it appears

                var cookieBanner = _page.Locator("#cb-cookiebanner");
                

                if (await cookieBanner.IsVisibleAsync())
                {
                    Console.WriteLine("Cookie banner is visible.");

                    // Locate the "Accept only essential cookies" button
                    var acceptButton = cookieBanner.Locator("#CybotCookiebotDialogBodyButtonDecline");

                    if (await acceptButton.IsVisibleAsync())
                    {
                        await acceptButton.ClickAsync();
                        Console.WriteLine("Cookie banner accepted.");
                    }
                }
                else
                {
                    Console.WriteLine("Cookie banner not visible.");
                }
            }
            catch (PlaywrightException e)
            {
                Console.WriteLine("Cookie banner was not found or could not be interacted with: " + e.Message);
            }*/

            // Check if the cookie overlay is visible
            await _cookieOverlay.WaitForAsync();
            bool isVisible = await _cookieOverlay.IsVisibleAsync();
            if (isVisible)
            {
                await _cookieOverlay.DblClickAsync();
                Thread.Sleep(1000);
                Console.WriteLine("Cookie banner closed.");
                await _page.ReloadAsync();
            }
        }

        public async Task unableToPlanJourney(string inputFromText, string inputToText)
        {
            Console.WriteLine("I am inside Unbale");
            await _inputToError.WaitForAsync();
            await _helperClass.ValidateTextContentAsync(_inputFromError, inputFromText);
            await _helperClass.ValidateTextContentAsync(_inputToError, inputToText);
            
        }
    }
    }

/*
    public async Task<bool> IsInvalidMesssage()
        {
            return await _InvalidLoginMsg.IsVisibleAsync();
        }
        public async Task<bool> IsinvalidLoginMsgExisit()
        {
            return await _InvalidLoginMsg.IsVisibleAsync();
        }
        //Access Denied Message when user tries to goto /horizon after having pulse entitlement
        public async Task getAccessDeniedMsg()
        {
            await _accessDeniedMsg.InnerTextAsync();
            Thread.Sleep(50000);
        }

        public async Task getHorizonWorksMsg()
        {
            await _horizonWorkMsg.InnerTextAsync();
            Thread.Sleep(50000);
        }
    }*/