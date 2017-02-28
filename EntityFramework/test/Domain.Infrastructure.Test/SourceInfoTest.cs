using System.Diagnostics;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Domain.Infrastructure.Test
{
    public class SourceInfoTest
    {
        [Fact]
        public void Save_SourceInfo_Test()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DomainContext>();
            optionsBuilder.UseNpgsql("User ID=postgres;Password=pass1;Host=localhost;Port=5432;Database=test;Pooling=true;");
            using (var dbContext = new DomainContext(optionsBuilder.Options))
            {
                var sourceInfos = dbContext.SourceInfos.ToList();
                Debug.WriteLine($@"Source Infos: {sourceInfos.Count}");
                var sourceInfo = new SourceInfo
                {
                    Name = "Gazeta Wyborcza",
                };
                dbContext.Add(sourceInfo);
                dbContext.SaveChanges();

                Assert.False(false);
            }
        }
    }
}
