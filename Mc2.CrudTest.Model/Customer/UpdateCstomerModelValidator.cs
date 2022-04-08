namespace Mc2.CrudTest.Model;

public sealed class UpdateCstomerModelValidator : CustomerModelValidator
{
    public UpdateCstomerModelValidator()
    {
        Id(); 
        FirstName(); 
        LastName(); 
        Email();
        PhoneNumber(); 
        BankAccountNumber();
        DateOfBirth();
    }
}
