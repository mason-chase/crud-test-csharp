Feature: Delete Customer

Scenario: Delete the Customer by ID
	Given Customer ID
	When user Delete the Customer
	Then Get Customer must return zero