using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow.Assist;
using Tfl.JourneyPlanner.UI.Tests.Drivers;
using Tfl.JourneyPlanner.UI.Tests.Pages;
using Tfl.JourneyPlanner.UI.Tests.Utilities;

namespace Tfl.JourneyPlanner.UI.Tests.StepDefinitions.When
{
    [Binding]
    public class WhenBindings
    {
        private readonly Driver _driver;
        private readonly TflPlanJourneyPage _tflJourneyPage;
        private readonly JourneyResultsPage _journeyResultsPage;
        private readonly HelperClass _helperClass;

        public WhenBindings(Driver driver)
        {
            _driver = driver;
            _tflJourneyPage = new TflPlanJourneyPage(_driver.Page);
            _journeyResultsPage = new JourneyResultsPage(_driver.Page);
            _helperClass = new HelperClass(_driver.Page);
        }
        [When(@"Passenger enters ""([^""]*)"" as the origin station")]
        public async Task WhenPassengerEntersAsTheStartingLocation(string Origin)
        {
            DataHelper.ToLocation = Origin;
            await _tflJourneyPage.EnterFromJourney(Origin);
            await _tflJourneyPage.SelectDropdownValueAsync(Origin);
        }

        [When(@"Passenger enters ""([^""]*)"" as the destination")]
        public async Task WhenIEnteredToAddress(string destination)
        {
            DataHelper.FromLocation = destination;
            await _tflJourneyPage.EnterToJourney(destination);
            await _tflJourneyPage.SelectDropdownValueAsync(destination);
        }

        [When(@"Passenger enters following travel data")]
        public async Task WhenPassengerEntersFollowingTravelData(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            await _tflJourneyPage.EnterFromJourney((string)data.Origin);
            await _tflJourneyPage.SelectDropdownValueAsync((string)data.Origin);

            await _tflJourneyPage.EnterToJourney((string)data.Destination);
            await _tflJourneyPage.SelectDropdownValueAsync((string)data.Destination);

        }

        [When(@"Passenger clicks the ""([^""]*)"" button")]
        public async Task WhenPassengerClicksTheButton(string Btn)
        {
            await _tflJourneyPage.ClickPlanJourneyBtn();
        }

        [When(@"Passenger updates Preferences to ""([^""]*)"" option on journey results page")]
        public async Task WhenPassengerUpdatesPreferencesToOptionOnJourneyResultsPage(string option)
        {
            await _journeyResultsPage.ClickEditPreferencesBtn();
            await _helperClass.ClickRadioButtonByLabelAsync(option);
            await _journeyResultsPage.ClickUpdateJourney();
        }
   
        [When(@"Passenger clicks the View Details button")]
        public async Task WhenPassengerClicksTheViewDetailsButton()
        {
            await _journeyResultsPage.ClickViewDetailsBtn();
        }

        [When(@"Passenger enters following invalid travel data")]
        public async Task WhenPassengerEntersFollowingInvalidTravelData(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            await _tflJourneyPage.EnterFromJourney((string)data.Origin);
            await _tflJourneyPage.EnterToJourney((string)data.Destination);
        }
    }
}
