using Mc2.CrudTest.Data.Contracts;
using Mc2.CrudTest.Data.EntityMaps;
using Mc2.CrudTest.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;

namespace Mc2.CrudTest.Data.Implementations
{
    public class ReadDbContext : DbContext, IReadDbContext
    {
        readonly string _defaultSchema;

        public DbSet<Customer> Customers { get; protected set; }

        protected ReadDbContext(DbContextOptions options, string defaultSchema = null) : base(options)
        {
            _defaultSchema = defaultSchema;
        }
        ReadDbContext(DbContextOptions<ReadDbContext> options, string defaultSchema = null) : base(options)
        {
            _defaultSchema = defaultSchema;
        }

        public override ChangeTracker ChangeTracker
        {
            get
            {
                var tracker = base.ChangeTracker;
                tracker.AutoDetectChangesEnabled = false;
                tracker.LazyLoadingEnabled = false;
                tracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
                return tracker;
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerEntityMap());
        }

        public static ReadDbContext Create(DbContextOptions<ReadDbContext> options) => Create(options, null);
        public static ReadDbContext Create(DbContextOptions<ReadDbContext> options, string defaultSchema) =>
            new ReadDbContext(options, defaultSchema);
        public static ReadDbContext Create(DbContextOptions options, string defaultSchema = null) =>
            new ReadDbContext(options, defaultSchema);
    }

    public class UnitOfWork : ReadDbContext, IUnitOfWork
    {
        UnitOfWork(DbContextOptions<UnitOfWork> options, string defaultSchema = null) : this((DbContextOptions)options, defaultSchema)
        {
        }
        UnitOfWork(DbContextOptions options, string defaultSchema = null) : base(options, defaultSchema)
        {
        }

        public override ChangeTracker ChangeTracker
        {
            get
            {
                var tracker = base.ChangeTracker;
                tracker.AutoDetectChangesEnabled = true;
                tracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll;
                return tracker;
            }
        }

        [Obsolete]
        public void SetModified(object entity, string propertyName, string referencePropertyName = null)
        {
            if (referencePropertyName != null)
                entity = Entry(entity).Reference(referencePropertyName).TargetEntry.Entity;

            Entry(entity).Property(propertyName).IsModified = true;
        }

        public static UnitOfWork Create(DbContextOptions<UnitOfWork> options) => Create(options, null);
        public static UnitOfWork Create(DbContextOptions<UnitOfWork> options, string defaultSchema) =>
            new UnitOfWork(options, defaultSchema);
        public new static UnitOfWork Create(DbContextOptions options, string defaultSchema = null) =>
            new UnitOfWork(options, defaultSchema);
    }
}
