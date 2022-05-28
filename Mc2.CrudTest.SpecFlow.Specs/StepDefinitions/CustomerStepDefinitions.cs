using Mc2.CrudTest.SpecFlow.Specs.API;

namespace Mc2.CrudTest.SpecFlow.Specs.StepDefinitions;

[Binding]
public sealed class CustomerStepDefinitions
{
    private readonly CustomersApi _customersApi;

    private int? _result;

    public CustomerStepDefinitions(CustomersApi calculator!!) => _customersApi = calculator;

    //[Given(@"")]
    //[Then(@"")]
    [When(@"add customer")]
    public async Task WhenTheCustomerAddedAsync() => _result = await _customersApi.AddAsync();
}