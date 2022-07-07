using Mc2.CrudTest.Persistence;
using System;

namespace Mc2.CrudTest.AcceptanceTests.Common
{
    public abstract class TestCommandBase : IDisposable
    {
        protected readonly CustomerDbContext _context;

        public TestCommandBase()
        {
            _context = CustomersContextFactory.Create();
        }

        public void Dispose()
        {
            CustomersContextFactory.Destroy(_context);
        }
    }
}
