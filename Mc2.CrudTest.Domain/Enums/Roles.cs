using System;

namespace Mc2.CrudTest.Domain;

[Flags]
public enum Roles
{
    None = 0,
    User = 1,
    Admin = 2
}
