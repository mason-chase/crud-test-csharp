using FluentAssertions;
using Mc2.CrudTest.Domain.Model.Exceptions;
using Mc2.CrudTest.Domain.Model.ValueObject;
using Mc2.CrudTest.TestTools;
using Xunit;

namespace Mc2.CrudTest.Domain.Model.Tests
{
    [Trait("(Domain) Customer", "")]
    public class EmailTests
    {
        [Fact]
        void Create_EmailCreated()
        {
            string value = "parisa.hadadinia@gmail.com";
            var email = Email.Create(value);

            email.Value.Should().Be(value);
        }

        [Fact]
        void Create_InvalidCustomerEmailException()
        {

            var thrownException = Try.CatchOrNull(() => Email.Create("asd"));

            thrownException.Should().NotBeNull();
            thrownException.Should()
                .BeOfType<InvalidCustomerEmailException>();

        }
    }
}
