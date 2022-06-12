using EntityFrameworkCore.Testing.Moq;
using Mc2.CrudTest.Domain.Models.Entities;
using Mc2.CrudTest.Persistence;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Mc2.CrudTest.DataAccessTest
{
    public class CustomerDbContextTest
    {
        [Fact]
        public void DbContext_WithDbContextOptions_IsAvailable()
        {
            var mockedDbContext = Create.MockedDbContextFor<CustomerDbContext>();
            Assert.NotNull(mockedDbContext);
        }

        [Fact]
        public void DbContext_DbSets_MustHaveDbSetWithTypeCustomerModelEntity()
        {
            var mockedDbContext = Create.MockedDbContextFor<CustomerDbContext>();
            Assert.True(mockedDbContext.Customers is DbSet<CustomerEntity>);
        }
    }
}
