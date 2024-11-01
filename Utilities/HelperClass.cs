using System;
using System.Threading.Tasks;
using Microsoft.Playwright;
using FluentAssertions;

namespace Tfl.JourneyPlanner.UI.Tests.Utilities
{
    internal class HelperClass
    {
        private readonly IPage _page;

        public HelperClass(IPage page)
        {
            _page = page;
        }

        public async Task ValidateTextContentAsync(ILocator locator, string expectedText)
        {
            // Check if the locator is visible
            bool isVisible = await locator.IsVisibleAsync();
            if (!isVisible)
            {
                throw new Exception("The specified locator is not visible on the page.");
            }

            // Get the inner text from the locator
            string actualText = await locator.InnerTextAsync();
            Console.WriteLine($"Actual Text: {actualText}");

            // Assert that the actual text matches the expected text
            actualText.Should().Be(expectedText, $"Expected text '{expectedText}' does not match actual text '{actualText}'.");

            // Log a success message
            Console.WriteLine("Text validation completed successfully.");
        }

        public async Task<string> GetTextContentAsync(ILocator locator)
        {
            // Check if the locator is visible
            bool isVisible = await locator.IsVisibleAsync();
            if (!isVisible)
            {
                throw new Exception("The specified locator is not visible on the page.");
            }

            // Get the inner text from the locator
            string actualText = await locator.InnerTextAsync();
            Console.WriteLine($"Actual Text: {actualText}");

            // Log a success message
            Console.WriteLine("Text extraction completed successfully.");
            return actualText;
        }

        public async Task ClickRadioButtonByLabelAsync(string labelText)
        {
            // Get all radio button elements within the specified container
            var radioButtons = await _page.QuerySelectorAllAsync("[class='show-me-list'] [class='form-control'] input[type='radio'] + label[class='boxed-label-for-input']");
            foreach (var radioButton in radioButtons)
            {
                // Check for the label text in the parent or sibling element
                var label = await radioButton.TextContentAsync();

                if (!string.IsNullOrEmpty(label) && label.Contains(labelText))
                {
                    // Click the matching radio button
                    await radioButton.ClickAsync();
                    Console.WriteLine($"Clicked radio button with label: {labelText}");
                    return;
                }
            }

            // If no match is found, log or throw an error
            throw new Exception($"Radio button with label '{labelText}' not found.");
        }

        public async Task<string[]> GetTextFromElements(ILocator locator)
        {
           
            // Get the count of elements matched by the locator
            int elementCount = await locator.CountAsync();

            // Initialize an array to store text content of each element
            var texts = new string[elementCount];

            // Iterate through each element and retrieve its text
            for (int i = 0; i < elementCount; i++)
            {
                texts[i] = await locator.Nth(i).InnerTextAsync();

            }
            return texts;
        }

        public async Task AssertElementVisibilityAsync(ILocator locator, bool shouldBeVisible = true)
        {
            // Check visibility based on the shouldBeVisible parameter
            bool isVisible = await locator.IsVisibleAsync();

            // Use Fluent Assertions to validate visibility status
            if (shouldBeVisible)
            {
                isVisible.Should().BeTrue("Expected the element to be visible on the page, but it was not.");
            }
            else
            {
                isVisible.Should().BeFalse("Expected the element to be invisible on the page, but it was visible.");
            }
        }
    }
}

