Feature: PUT
	PUT method testing on .Net

@mytag
Scenario: Update a user First Name
	Given I have a user First Name
	And I Prepare the resource
	When I send the data to the API 
	Then The status code should be 200
	And I verify the data on the MongoDB 