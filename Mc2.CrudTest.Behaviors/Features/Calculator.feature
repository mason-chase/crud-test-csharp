Feature: CreateCustomer

Add a new given customer to the system.
@tag1
Scenario: Create new customer
	Given Has valid PhoneNumber
	And has valid Email
	And has valid BankAccountNumber
	And Is unique by Firstname Lastname DateOfBirth
	And Email is not duplicate
	When user creates a <customer>
	Then Customer must be created
