using FluentAssertions;
using Mc2.CrudTest.Domain.Model.Exceptions;
using Mc2.CrudTest.Domain.Model.ValueObject;
using Mc2.CrudTest.TestTools;
using Xunit;

namespace Mc2.CrudTest.Domain.Model.Tests
{
    [Trait("(Domain) Customer", "")]
    public class PhoneNumberTests
    {
        [Fact]
        void Create_PhoneNumberCreated()
        {
            string countryCode = "PK";
            string number = "03336323900";
            var phoneNumber = PhoneNumber.Create(countryCode, number);

            phoneNumber.CountryCode.Should().Be(countryCode);
            phoneNumber.Number.Should().Be(number);
        }

        [Fact]
        void Create_InvalidPhonNumberException()
        {

            var thrownException = Try.CatchOrNull(() => PhoneNumber.Create("ZZ", "foo"));

            thrownException.Should().NotBeNull();

        }
    }
}
