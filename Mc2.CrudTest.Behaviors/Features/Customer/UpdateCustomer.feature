Feature: Update Customer

Scenario: Update Specific Customer By Customer ID
	Given Customer ID
	When user edit the Customer
	Then Get Customer must return new edited values