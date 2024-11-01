using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Tfl.JourneyPlanner.UI.Tests.Drivers;
using System.Text.RegularExpressions;
using Tfl.JourneyPlanner.UI.Tests.Utilities;
namespace Tfl.JourneyPlanner.UI.Tests.Pages
{
    internal class JourneyResultsPage
    {
        private IPage _page;
        private readonly ILocator invalidJourneyErrorMsg;
        private readonly ILocator toAndFromLocations;
        private readonly ILocator walkingJourneyBox;
        private readonly ILocator cyclingJourneyBox;
        private readonly ILocator btn_editPreferences;
        private readonly ILocator radioBtn_leastWalking;
        private readonly ILocator btn_updateJourney;
        private readonly ILocator updatedJourneys;
        private readonly ILocator journeyAdviceText;
        private readonly ILocator updatedJourneyCost;
        private readonly ILocator updatedJourneyTime;
        private readonly ILocator btn_viewJourneyDetails;
        private readonly ILocator accessInfo_upStairs;
        private readonly ILocator accessInfo_upLift;
        private readonly ILocator accessInfo_levelWalkWay;

        private readonly HelperClass _helperClass;

        public JourneyResultsPage(IPage page)
        {
            _page = page;
            _helperClass = new HelperClass(_page);
            invalidJourneyErrorMsg = _page.Locator("li[class='field-validation-error']");
            toAndFromLocations = _page.Locator("[class='journey-result-summary'] [class='from-to-wrapper']");
            walkingJourneyBox = _page.Locator("a[class='journey-box walking']");
            cyclingJourneyBox = _page.Locator("a[class='journey-box cycling']");
            btn_editPreferences = _page.Locator("button[class='toggle-options more-options']");
            radioBtn_leastWalking = _page.Locator("div[class='form-control'] label[for= 'JourneyPreference_2']");
            btn_updateJourney = _page.Locator("#more-journey-options .primary-button");
            updatedJourneys = _page.Locator("div[class='clearfix time-boxes time-boxes-override']");
            journeyAdviceText = _page.Locator("#journey-busy-stations-advice");
            updatedJourneyCost = _page.Locator("span[class='journey-cost']");
            updatedJourneyTime = _page.Locator("div[class='journey-time no-map']");
            btn_viewJourneyDetails = _page.Locator("[aria-labelledby='option-1-heading'] .view-hide-details");
            accessInfo_upStairs = _page.Locator("div[class='access-information'] a[data-title='Up stairs']");
            accessInfo_upLift = _page.Locator("div[class='access-information'] a[data-title='Up lift']");
            accessInfo_levelWalkWay = _page.Locator("div[class='access-information'] a[data-title='Level walkway']");

        }

        // Verify invalid journey error message
        public async Task validatedInvalidJourneyMessage(string errorMessage)
        {
            await invalidJourneyErrorMsg.WaitForAsync();
            await _helperClass.ValidateTextContentAsync(invalidJourneyErrorMsg, errorMessage);

        }

        // Get To and From Journey details and compare it with expected values
        public async Task validateToandFromLocationsOnJourneyResultsPage(string ToLocation, string FromLocation)
        {
            await toAndFromLocations.WaitForAsync();
            string toAndFromLocationsText = await _helperClass.GetTextContentAsync(toAndFromLocations);
            toAndFromLocationsText.Should().Contain(ToLocation, $"Expected '{toAndFromLocationsText}' to contain '{ToLocation}'.");
            toAndFromLocationsText.Should().Contain(FromLocation, $"Expected '{toAndFromLocationsText}' to contain '{FromLocation}'.");

        }

        // Get Walking Journey Box content and compare it with expected values
        public async Task getWalkingJourneyBoxContent(double ExpectedWalkingTime, double WalkingDistance, string WalkingSpeed)
        {
            await walkingJourneyBox.WaitForAsync();
            string walkingJourneyBoxText = await _helperClass.GetTextContentAsync(walkingJourneyBox);

            // Split the string by new lines and create an array
            string[] parts = walkingJourneyBoxText.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length >= 4)
            {
                // Extract the required values
                string walkingSpeed = parts[1].Split(':')[1].Trim(); // Moderate
                string distance = parts[2].Split(':')[1].Replace("km", "").Trim(); // 0.4
                string time = parts[3].Replace("mins", "").Trim(); // 6

                // Store the values in an array
                string[] result = { walkingSpeed, distance, time };

                // Loop through each item and assert with conditional checks
                for (int i = 0; i < result.Length; i++)
                    if (i == 0) // Check the walking speed
                    {
                        result[i].Should().Be(WalkingSpeed, $"Expected {WalkingSpeed} but got '{result[i]}' at index {i}");
                    }
                    else if (i == 1)// Check that distance and time are non-empty and non-zero
                    {
                        result[i].Should().NotBeNullOrEmpty($"Expected a non-empty value but got '{result[i]}' at index {i}");
                        double parsedValue;
                        bool isNumber = double.TryParse(result[i], out parsedValue);
                        isNumber.Should().BeTrue($"Expected '{result[i]}' to be a valid number at index {i}");
                        Console.WriteLine(result[i], "result at index");
                        parsedValue.Should().BeApproximately(WalkingDistance, precision: 0.001,
                        $"Expected '{parsedValue}' to approximately match '{WalkingDistance}' at index {i}");

                    }
                    else if (i == 2)
                    {
                        double parsedValue;
                        bool isNumber = double.TryParse(result[i], out parsedValue);
                        isNumber.Should().BeTrue($"Expected '{result[i]}' to be a valid number at index {i}");
                        Console.WriteLine(result[i], "result at index");
                        parsedValue.Should().BeApproximately(ExpectedWalkingTime, precision: 0.001,
                        $"Expected '{parsedValue}' to approximately match '{ExpectedWalkingTime}' at index {i}");
                    }
            }
            else
            {
                Console.WriteLine("The input string does not contain the expected number of lines.");
            }
        }

        // Get Cycling Journey Box content and compare it with expected values
        public async Task getCyclingJourneyBoxContent(double ExpectedCyclingTime, double CyclingDistance, string CyclingRoute)
        {
            await cyclingJourneyBox.WaitForAsync();
            string CyclingJourneyBoxText = await _helperClass.GetTextContentAsync(cyclingJourneyBox);

            // Split the string by new lines and create an array
            string[] parts = CyclingJourneyBoxText.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length >= 4)
            {
                // Extract the required values
                string cyclingRoute = parts[1].Split(':')[1].Trim(); // Moderate
                string cyclingdistance = parts[2].Split(':')[1].Replace("km", "").Trim(); // 0.4
                string time = parts[3].Replace("mins", "").Trim(); // 6

                // Store the values in an array
                string[] result = { cyclingRoute, cyclingdistance, time };

                // Loop through each item and assert with conditional checks
                for (int i = 0; i < result.Length; i++)
                {
                    if (i == 0) // Check the walking speed
                    {
                        result[i].Should().Be(CyclingRoute, $"Expected {CyclingRoute} but got '{result[i]}' at index {i}");
                    }
                    else if (i == 1)// Check that distance and time are non-empty and non-zero
                    {
                        result[i].Should().NotBeNullOrEmpty($"Expected a non-empty value but got '{result[i]}' at index {i}");
                        double parsedValue;
                        bool isNumber = double.TryParse(result[i], out parsedValue);
                        isNumber.Should().BeTrue($"Expected '{result[i]}' to be a valid number at index {i}");
                        Console.WriteLine(result[i], "result at index");
                        parsedValue.Should().BeApproximately(CyclingDistance, precision: 0.001,
                        $"Expected '{parsedValue}' to approximately match '{CyclingDistance}' at index {i}");

                    }
                    else if (i == 2)
                    {
                        double parsedValue;
                        bool isNumber = double.TryParse(result[i], out parsedValue);
                        isNumber.Should().BeTrue($"Expected '{result[i]}' to be a valid number at index {i}");
                        Console.WriteLine(result[i], "result at index");
                        parsedValue.Should().BeApproximately(ExpectedCyclingTime, precision: 0.001,
                        $"Expected '{parsedValue}' to approximately match '{ExpectedCyclingTime}' at index {i}");
                    }
                    else
                    {
                        Console.WriteLine($"Validation passed for index xyz {i}: {result[i]}");
                    }


                }
            }
            else
            {
                Console.WriteLine("The input string does not contain the expected number of lines.");
            }
        }
        // Click Edit Preferences Button
        public async Task ClickEditPreferencesBtn()
        {
            await btn_editPreferences.ClickAsync();
        }

        // Click Update Journey Button
        public async Task ClickUpdateJourney()
        {
            await btn_updateJourney.ClickAsync();
            await journeyAdviceText.WaitForAsync();
        }

        public async Task ValidateUpdateJourneyDetailsForCost()
        {
            string[] updatedCost = await _helperClass.GetTextFromElements(updatedJourneyCost);
            foreach (string text in updatedCost)
            {
                // Remove the pound symbol
                string priceString = text.Replace("£", "");

                // Parse the price string to a decimal
                decimal price;
                decimal.TryParse(priceString, out price);

                // Assertions
                price.Should().BeGreaterThan(0); // Ensure positive price
                price.Should().BeApproximately(price, 0.01m); // Ensure two decimal places
            }
        }

        public async Task ValidateUpdateJourneyDetailsForTime()
        {
            string[] updatedTime = await _helperClass.GetTextFromElements(updatedJourneyTime);
            List<int> numbers = new List<int>();
            foreach (string text in updatedTime)
            {
                var match = Regex.Match(text, @"\d+");
                if (match.Success)
                {
                    int number = int.Parse(match.Value);
                    Console.WriteLine(number);
                    numbers.Add(number);

                }
                else
                {
                    Console.WriteLine("Number not found in: " + text);
                }
            }
            // Assert the order of the first two numbers
            numbers[0].Should().BeLessThanOrEqualTo(numbers[1]);

        }
        // Click View Details Button
        public async Task ClickViewDetailsBtn()
        {
            await btn_viewJourneyDetails.ClickAsync();
        }

        // Validate access information
        public async Task ValidateAccessInfo()
        {
            await _helperClass.AssertElementVisibilityAsync(accessInfo_upStairs, true);
            await _helperClass.AssertElementVisibilityAsync(accessInfo_upLift, true);
            await _helperClass.AssertElementVisibilityAsync(accessInfo_levelWalkWay, true);

        }
    }
}