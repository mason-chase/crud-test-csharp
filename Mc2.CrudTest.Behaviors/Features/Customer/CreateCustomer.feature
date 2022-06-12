Feature: Create Customer

Scenario: Create new customer
	Given Customer Has Valid PhoneNumber
	And Customer has valid Email
	And Customer has valid BankAccountNumber
	And Customer Firstname Lastname DateOfBirth Must be Unique
	And Customer Email Must be Unique
	When user create a customer
	Then Customer must be created
