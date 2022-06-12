using Mc2.CrudTest.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.DataAccess.Cofigurations
{
    internal class IdentityUserRoleConfig : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
       
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasKey(c => c.RoleId);
        }
    }
}
