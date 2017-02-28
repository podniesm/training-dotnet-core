using System.Diagnostics;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Domain.Inetgration.Test
{
    public class SourceInfoTest
    {
        [Fact]
        public void Save_SourceInfo_Test()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DomainPgsqlContext>();
            optionsBuilder.UseNpgsql("User ID=postgres;Password=pass1;Host=localhost;Port=5432;Database=test;Pooling=true;");
            using (var dbContext = new DomainPgsqlContext(optionsBuilder.Options))
            {
                var soucreInfos = dbContext.SourceInfos.ToList();
                Debug.WriteLine($@"Source Infos: {soucreInfos.Count}");
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
