using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Domain.Inetgration.Test
{

    public class DomainContextFactory : IDbContextFactory<DomainPgsqlContext>
    {
        public DomainPgsqlContext Create(DbContextFactoryOptions options)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DomainPgsqlContext>();
            optionsBuilder.UseNpgsql("User ID=postgres;Password=pass1;Host=localhost;Port=5432;Database=test;Pooling=true;");
            return new DomainPgsqlContext(optionsBuilder.Options);
        }
    }

    public class DomainPgsqlContext : DbContext
    {
        public DomainPgsqlContext(DbContextOptions<DomainPgsqlContext> options) : base(options)
        {
        }

        public DbSet<DataEventRecord> DataEventRecords { get; set; }

        public DbSet<SourceInfo> SourceInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<DataEventRecord>().HasKey(m => m.DataEventRecordId);
            builder.Entity<SourceInfo>().HasKey(m => m.SourceInfoId);

            // shadow properties
            builder.Entity<DataEventRecord>().Property<DateTime>("UpdatedTimestamp");
            builder.Entity<SourceInfo>().Property<DateTime>("UpdatedTimestamp");

            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();

            UpdateUpdatedProperty<SourceInfo>();
            UpdateUpdatedProperty<DataEventRecord>();

            return base.SaveChanges();
        }

        private void UpdateUpdatedProperty<T>() where T : class
        {
            var modifiedSourceInfo =
                ChangeTracker.Entries<T>()
                    .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (var entry in modifiedSourceInfo)
            {
                entry.Property("UpdatedTimestamp").CurrentValue = DateTime.UtcNow;
            }
        }
    }
}
