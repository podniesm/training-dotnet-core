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
                //var sourceInfoTemp = dbContext.SourceInfos.Include(x => x.DataEventRecords).First();
                //Assert.NotEmpty(sourceInfoTemp.DataEventRecords);
                var sourceInfos = dbContext.SourceInfos
                    .Include(s => s.DataEventRecords)
                    .ToList();
                var dataEventRecords = dbContext.DataEventRecords.ToList();
                var dataEventRecord = new DataEventRecord
                {
                    Name = "GWDER",
                };
                var sourceInfo = new SourceInfo
                {
                    Name = "Gazeta Wyborcza",
                };
                sourceInfo.AddDataEventRecord(dataEventRecord);
                dbContext.SourceInfos.Add(sourceInfo);
                //dbContext.DataEventRecords.Add(dataEventRecord);
                dbContext.SaveChanges();
            }
        }
    }
}
