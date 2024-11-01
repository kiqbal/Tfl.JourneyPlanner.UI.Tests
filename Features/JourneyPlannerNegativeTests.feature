Feature: TfL - Journey Planner
  As a passenger
  I should see errors on journey planner when I enter incorrect data travel data while planning my london journey

Scenario:  2-01 Verify that journey planner is unable to plan a journey if no origin and destination is provided
	Given Passanger is on Tfl Journey planner page
	And Passanger accepts the Cookie Manager on pop up
	When Passenger clicks the "Plan my journey" button
	Then Journey Planner display following error messages
		| OriginRequired              | DestinationRequired       |
		| The From field is required. | The To field is required. |


Scenario: Verify that the widget does not provide results when an invalid journey is planned

	Given Passanger is on Tfl Journey planner page
	And Passanger accepts the Cookie Manager on pop up
	When Passenger enters following invalid travel data 
		| Origin     | Destination |
		| 1234asdasd | 1234asdasd  |
	And Passenger clicks the "Plan my journey" button
	Then Passenger is shown following error message
		| ErrorMessage                                          |
		| Sorry, we can't find a journey matching your criteria |