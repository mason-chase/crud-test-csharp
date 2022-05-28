using Mc2.CrudTest.Data.Shared.Constants;
using Mc2.CrudTest.Domain.Common;
using Mc2.CrudTest.Domain.Entities;

namespace Mc2.CrudTest.Data.Shared.Extensions;

public static class TableMappingName
{
    public static TableName[] GetNames()
    {
        var names = new TableName[]
        {
            new TableName(nameof(Customer),TableMappingNameConst.PluralName.Customers,TableMappingNameConst.SchemaName.Mc2),
        };

        return names;
    }
}