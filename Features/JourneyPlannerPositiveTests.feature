Feature: TfL Journey Planner
  As a passenger
  I want to be able to plan a journey on the TfL Journey Planner page
  So that I can easily navigate through London using public transport


@UiTest
Scenario: 1-01 Plan a journey with valid origin and destination with default optins
	Given Passanger is on Tfl Journey planner page
	And Passanger accepts the Cookie Manager on pop up
	When Passenger enters "Leicester" as the origin station
	And Passenger enters "Covent Garden" as the destination
	And Passenger clicks the "Plan my journey" button
	Then Following journey options should be displayed with available routes and times
		| Origin    | Destination   | ExpectedWalkingTimeInMin | ExpectedCyclingTimeInMin | CyclingRoute | WalkingSpeed | CyclingDistanceInKms | WalkingDistanceInKms |
		| Leicester | Covent Garden | 6                        | 1                        | Moderate     | Moderate     | 0.4                  | 0.4             |


Scenario: 1-02 Plan a journey with least walking optins in preferences and validate results
	Given Passanger is on Tfl Journey planner page
	And Passanger accepts the Cookie Manager on pop up
	When Passenger enters following travel data
		| Origin    | Destination   |
		| Leicester | Covent Garden |
	And Passenger clicks the "Plan my journey" button
	And Passenger updates Preferences to "Routes with least walking" option on journey results page
	Then Passenger verify that the updated journey cost is positive and has two decimal places
	And Passenger confirm that the journey time is updated by selecting the route with least walking time
	# last two steps need attentions since we need to know exact data what to verify

Scenario: 1-03 View details and Verify complete access information at Covent Garden Underground Station
		
	Given Passanger is on Tfl Journey planner page
	And Passanger accepts the Cookie Manager on pop up
	When Passenger enters following travel data
		| Origin    | Destination   |
		| Leicester | Covent Garden |
	And Passenger clicks the "Plan my journey" button
	And Passenger updates Preferences to "Routes with least walking" option on journey results page
	And Passenger clicks the View Details button
	Then Passenger verify Covent Garden Underground Station's information is displayed
	# what information we need to verify? 