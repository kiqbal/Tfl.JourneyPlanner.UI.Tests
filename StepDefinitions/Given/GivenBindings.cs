using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tfl.JourneyPlanner.UI.Tests.Drivers;
using Tfl.JourneyPlanner.UI.Tests.Pages;
using Tfl.JourneyPlanner.UI.Tests.Utilities;

namespace Tfl.JourneyPlanner.UI.Tests.StepDefinitions.Given
{
    [Binding]
    public class GivenBindings
    {
        private readonly Driver _driver;
        private readonly TflPlanJourneyPage _tflJourneyPage;
        private readonly JourneyResultsPage _journeyResultsPage;
        private readonly HelperClass _helperClass;

        public GivenBindings(Driver driver)
        {
            _driver = driver;
            _tflJourneyPage = new TflPlanJourneyPage(_driver.Page);
            _journeyResultsPage = new JourneyResultsPage(_driver.Page);
            _helperClass = new HelperClass(_driver.Page);
        }

        [Given(@"Passanger is on Tfl Journey planner page")]
        public void GivenIAmOnTheTFLPlanAJourneyPage()
        {
            //_driver.Page.GotoAsync("https://tfl.gov.uk/plan-a-journey");
            _driver.Page.GotoAsync(Reuseables.baseURL);

        }

        [Given(@"Passanger accepts the Cookie Manager on pop up")]
        public async Task GivenIAcceptTheCookieManagerPopUp()
        {

            // Use the helper method to handle and validate the overlay
            await _tflJourneyPage.HandleAndValidateCookieOverlayAsync();

        }
    }
}
