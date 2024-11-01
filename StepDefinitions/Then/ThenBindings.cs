using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow.Assist;
using Tfl.JourneyPlanner.UI.Tests.Drivers;
using Tfl.JourneyPlanner.UI.Tests.Pages;
using Tfl.JourneyPlanner.UI.Tests.Utilities;

namespace Tfl.JourneyPlanner.UI.Tests.StepDefinitions.Then
{
    [Binding]
    public class ThenBindings
    {
        private readonly Driver _driver;
        private readonly TflPlanJourneyPage _tflJourneyPage;
        private readonly JourneyResultsPage _journeyResultsPage;
        private readonly HelperClass _helperClass;

        public ThenBindings(Driver driver)
        {
            _driver = driver;
            _tflJourneyPage = new TflPlanJourneyPage(_driver.Page);
            _journeyResultsPage = new JourneyResultsPage(_driver.Page);
            _helperClass = new HelperClass(_driver.Page);
        }

        [Then(@"Following journey options should be displayed with available routes and times")]
        public async Task ThenValidateTheResultForBothWalkingAndCyclingTime(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            await _journeyResultsPage.validateToandFromLocationsOnJourneyResultsPage((string)data.Origin, (string)data.Destination);
            await _journeyResultsPage.getWalkingJourneyBoxContent((double)data.ExpectedWalkingTimeInMin, (double)data.WalkingDistanceInKms, (string)data.WalkingSpeed);
            await _journeyResultsPage.getCyclingJourneyBoxContent((double)data.ExpectedCyclingTimeInMin, (double)data.CyclingDistanceInKms, (string)data.CyclingRoute);

        }

        [Then(@"Passenger verify that the updated journey cost is positive and has two decimal places")]
        public async Task ThenIVerifyThatTheUpdatedJourneyCostIsPositiveAndHasTwoDecimalPlaces()
        {
            await _journeyResultsPage.ValidateUpdateJourneyDetailsForCost();
        }
        [Then(@"Passenger confirm that the journey time is updated by selecting the route with least walking time")]
        public async Task IConfirmThatTheJourneyTimeIsUpdatedBySelectingTheRouteWithLeastWalkingTime()
        {
       
            await _journeyResultsPage.ValidateUpdateJourneyDetailsForTime();
        }

        [Then(@"Passenger verify Covent Garden Underground Station's information is displayed")]
        public async Task ThenPassengerVerifyCoventGardenUndergroundStationsInformationIsDisplayed()
        {
            await _journeyResultsPage.ValidateAccessInfo();
        }

       [Then(@"Journey Planner display following error messages")]
        public async Task ThenJourneyPlannerDisplayFollowingErrorMessages(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            await _tflJourneyPage.unableToPlanJourney((string)data.OriginRequired, (string)data.DestinationRequired);
        }
        [Then(@"Passenger is shown following error message")]
        public async Task ThenPassengerIsShownFollowingErrorMessage(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            await _journeyResultsPage.validatedInvalidJourneyMessage((string)data.ErrorMessage);
        }





    }
}
