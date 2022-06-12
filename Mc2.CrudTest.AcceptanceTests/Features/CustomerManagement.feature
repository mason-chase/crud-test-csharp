Feature: CustomerManagement

Feature: Manage Customers in the system

@tag1
Scenario: Customer gets created successfully
	Given Customer has valid Email
	And Has valid phone number
	And Has valid bank account number
	And Customer is not duplicate
		| Firstname | Lastname | DateOfBirth      | PhoneNumber  | Email         | BankAccountNumber |
		| Hadi      | Ardebili | 1982/07/07 00:00 | 989121486706 | hadi@mail.com | 123456789         |
	When User create Customer with following detailes
		| Firstname | Lastname | DateOfBirth      | PhoneNumber  | Email         | BankAccountNumber |
		| Hadi      | Ardebili | 1982/07/07 00:00 | 989121486706 | hadi@mail.com | 123456789         |
	Then Customer is created successfully

Scenario: Customer gets deleted successfully
	Given The following CustomerID in the system
		| ID |
		| 1  |
	When Customer gets deleted
	Then The Customer gets deleted successfully

Scenario: Customer gets updated successfully
	Given The following Customer in the system
		| ID | Firstname | Lastname | DateOfBirth      | PhoneNumber  | Email         | BankAccountNumber |
		| 1  | Hadi      | Ardebili | 1982/07/08 00:00 | 989121112222 | hadi@mail.com | 111111111         |
	When Customer gets updated
	Then Customer is created successfully

Scenario: Customer gets returned successfully
	Given The following CustomerID in the system
		| ID |
		| 1  |
	When Customer is selected
	Then Customer is returned successfully
