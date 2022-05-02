using FluentAssertions;
using Mc2.CrudTest.Domain.Model.Exceptions;
using Mc2.CrudTest.Domain.Model.ValueObject;
using Mc2.CrudTest.TestTools;
using Xunit;

namespace Mc2.CrudTest.Domain.Model.Tests
{
    [Trait("(Domain) Customer", "")]
    public class CustomerNameTests
    {
        [Theory]
        [AutoMoqData]
        void Create_NameCreated(string firstName, string lastName)
        {
            var name = Name.Create(firstName, lastName);

            name.First.Should().Be(firstName);
            name.Last.Should().Be(lastName);
        }

        [Fact]
        void Create_CustomerNameIsNullOrEmptyException()
        {

            var thrownException = Try.CatchOrNull(() => Name.Create("", ""));

            thrownException.Should().NotBeNull();
            thrownException.Should()
                .BeOfType<CustomerNameIsNullOrEmptyException>();

        }

    }
}
