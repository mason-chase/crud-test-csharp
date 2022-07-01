Feature: Test

A short summary of the feature
@tag1

Scenario: Create new customer
	Given Has valid PhoneNumber | 
	And has valid Email
	And has valid BankAccountNumber
	And Is unique by Firstname Lastname DateOfBirth
	And Email is not duplicate
		<Customer>[TABLE]
	When user creates a <customer>
	Then Customer must be created

