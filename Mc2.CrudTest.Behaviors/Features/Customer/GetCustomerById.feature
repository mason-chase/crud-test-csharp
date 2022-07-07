Feature: Get Customer By ID

Scenario: Get Specific Customer by Customer ID
	Given Customer ID
	When user Lookup the given Customer by ID
	Then Customer data must be returned