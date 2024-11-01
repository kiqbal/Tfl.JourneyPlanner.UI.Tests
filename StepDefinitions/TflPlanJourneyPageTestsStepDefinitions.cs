//using System;
//using Tfl.JourneyPlanner.UI.Tests.Drivers;
//using Tfl.JourneyPlanner.UI.Tests.Pages;
//using Tfl.JourneyPlanner.UI.Tests.Utilities;
//using Microsoft.Playwright;
//using TechTalk.SpecFlow;
//using TechTalk.SpecFlow.Assist;
//using NUnit.Framework;

//namespace Tfl.JourneyPlanner.UI.Tests.StepDefinitions
//{
//    [Binding]
//    public class TflPlanJourneyPageTestsStepDefinitions
//    {
//        private readonly Driver _driver;
//        private readonly TflPlanJourneyPage _tflJourneyPage;
//        private readonly JourneyResultsPage _journeyResultsPage;
//        private readonly HelperClass _helperClass;

//        public TflPlanJourneyPageTestsStepDefinitions(Driver driver)
//        {
//            _driver = driver;
//            _tflJourneyPage = new TflPlanJourneyPage(_driver.Page);
//            _journeyResultsPage = new JourneyResultsPage(_driver.Page);
//            _helperClass = new HelperClass(_driver.Page);
//        }


        //[Given(@"I am on the TFL Plan a Journey page")]
        //public void GivenIAmOnTheTFLPlanAJourneyPage()
        //{
        //    _driver.Page.GotoAsync("https://tfl.gov.uk/plan-a-journey");
        //    // Thread.Sleep(30000);

        //}

        //[When(@"I searched ""([^""]*)""")]
        //public async Task WhenISearched(string leicester)
        //{
        //    DataHelper.ToLocation = leicester;
        //    await _tflJourneyPage.EnterFromJourney(leicester);
        //    await _tflJourneyPage.SelectDropdownValueAsync(leicester);
        //}

        //[When(@"I enter invalid to and from locations such and ""([^""]*)"" and ""([^""]*)""")]
        //public async Task WhenIEnterInvalidToAndFromLocationsSuchAndAnd(string invalidToLocation, string invalidFromLocation)
        //{
        //    await _tflJourneyPage.EnterFromJourney(invalidToLocation);
        //    await _tflJourneyPage.EnterToJourney(invalidFromLocation);

        //}

        //[Given(@"I accept the Cookie Manager pop up")]
        //public async Task GivenIAcceptTheCookieManagerPopUp()
        //{

        //    // Use the helper method to handle and validate the overlay
        //    await _tflJourneyPage.HandleAndValidateCookieOverlayAsync();
        //    // Assert.IsTrue(isHidden, "Cookie overlay is still visible after attempting to close it.");

        //}

        //[When(@"I entered ""([^""]*)""")]
        //public async Task WhenIEnteredToAddress(string toAddress)
        //{
        //    DataHelper.FromLocation = toAddress;
        //    await _tflJourneyPage.EnterToJourney(toAddress);
        //    await _tflJourneyPage.SelectDropdownValueAsync(toAddress);
        //}

        //[When(@"I click on Plan my Journey button")]
        //public async Task WhenIClickOnPlanMyJourneyButton()
        //{
        //    await _tflJourneyPage.ClickPlanJourneyBtn();
        //}

        //[Then(@"the widget is unable to plan a journey and showing error messages as ""([^""]*)"" and ""([^""]*)""")]
        //public async Task ThenTheWidgetIsUnableToPlanAJourneyAndShowingErrorMessagesAsAnd(string toJourneyError, string fromJourneyError)
        //{
        //    await _tflJourneyPage.unableToPlanJourney(toJourneyError, fromJourneyError);

        //}

        //[Then(@"validate that widget is showing ""([^""]*)""")]
        //public async Task ThenValidateThatWidgetIsShowing(string errMessage)
        //{
        //    await _journeyResultsPage.validatedInvalidJourneyMessage(errMessage);
        //}

        /* [Then(@"Validate the result for both walking and cycling time")]
         *//*public async Task ThenValidateTheResultForBothWalkingAndCyclingTime()
         {
             await _journeyResultsPage.validateToandFromLocationsOnJourneyResultsPage();
         }*//*



     }*/

        //[Then(@"Validate the result for both walking and cycling time")]
        //public async Task ThenValidateTheResultForBothWalkingAndCyclingTime(Table table)
        //{
        //    dynamic data = table.CreateDynamicInstance();
        //    await _journeyResultsPage.validateToandFromLocationsOnJourneyResultsPage((string)data.ToJourney, (string)data.FromJourney);
        //    await _journeyResultsPage.getWalkingJourneyBoxContent((string)data.ExpectedWalkingTime, (string)data.WalkingDistance, (string)data.WalkingSpeed);
        //    await _journeyResultsPage.getCyclingJourneyBoxContent((string)data.ExpectedCyclingTime, (string)data.CyclingDistance, (string)data.CyclingRoute);

        //}

        //[When(@"I click on Edit Preferences button and update the journey with ""([^""]*)"" option")]
        //public async Task WhenIClickOnEditPreferencesButtonAndUpdateTheJourneyWithOption(string option)
        //{
        //    await _journeyResultsPage.ClickEditPreferencesBtn();
        //    await _helperClass.ClickRadioButtonByLabelAsync(option);
        //    await _journeyResultsPage.ClickUpdateJourney();
        //}

        //[Then(@"I verify that the updated journey cost is positive and has two decimal places\. Additionally, I confirm that the journey time is updated by selecting the route with least walking time")]
        //public async Task ThenIVerifyThatTheUpdatedJourneyCostIsPositiveAndHasTwoDecimalPlaces_AdditionallyIConfirmThatTheJourneyTimeIsUpdatedBySelectingTheRouteWithLeastWalkingTime()
        //{
        //    await _journeyResultsPage.ValidateUpdateJourneyDetailsForCost();
        //    await _journeyResultsPage.ValidateUpdateJourneyDetailsForTime();
        //}

        //[When(@"I click the View Details button and verify that all relevant access information about Covent Garden Underground Station is displayed\.")]
        //public async Task WhenIClickTheViewDetailsButtonAndVerifyThatAllRelevantAccessInformationAboutCoventGardenUndergroundStationIsDisplayed_()
        //{
        //    await _journeyResultsPage.ClickViewDetailsBtn();
        //    await _journeyResultsPage.ValidateAccessInfo();
        //}

/*
    }
}*/