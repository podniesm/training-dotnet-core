using System.Reflection;
using Domain.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Domain.Migrator
{
    public class DomainContextFactory : IDbContextFactory<DomainContext>
    {
        public DomainContext Create(DbContextFactoryOptions options)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DomainContext>();
            optionsBuilder.UseNpgsql("User ID=postgres;Password=pass1;Host=localhost;Port=5432;Database=test;Pooling=true;", a =>
                {
                    var assemblyName = GetType().GetTypeInfo().Assembly.GetName().Name;
                    a.MigrationsAssembly(assemblyName);
                });
            return new DomainContext(optionsBuilder.Options);
        }
    }
}