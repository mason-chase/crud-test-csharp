using System;

namespace Mc2.CrudTest.Data.Contracts
{
    public interface IUnitOfWork : IReadDbContext
    {
        int SaveChanges();
        [Obsolete]
        void SetModified(object entity, string propertyName, string referencePropertyName = null);
    }
}
