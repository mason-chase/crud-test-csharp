using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Xunit;

namespace Mc2.CrudTest.AcceptanceTests
{
    public class BddTddTests
    {
        [Fact]
        public void CreateCustomerValid_ReturnsSuccess()
        {
            //Arrange
            var identity = new Guid().ToString();
            var name = "fakeCustomer";

            //Act
            var fakeCustomerItem = new Customer(identity, name);

            //Assert
            Assert.IsNotNull(fakeCustomerItem);
        }

        [Fact]
        public void Create_buyer_item_success()
        {

        }

        // Please create more tests based on project requirements as per in readme.md
    }
}
