namespace Mc2.CrudTest.Model;

public sealed class AddCustomerModelValidator : CustomerModelValidator
{
    public AddCustomerModelValidator()
    {
        FirstName();
        LastName();
        Email();
        PhoneNumber();
        BankAccountNumber();
        DateOfBirth();
    }
}
