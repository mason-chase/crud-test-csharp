Feature: Customers

Web API for customers

@AddCustomerTag
Scenario: Add customer
	Given I am a client
	When I make a POST request with '/customers/create' to 'CreateCustomer'
	Then the response status code is '201'
	And the location header is 'https://localhost/5001/customers/create'
	#And the response must be 'int'