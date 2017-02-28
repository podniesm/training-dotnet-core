using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Domain.Test;

namespace Domain.Test.Migrations
{
    [DbContext(typeof(DomainPgsqlContext))]
    [Migration("20170228153624_Test_Migration")]
    partial class Test_Migration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752");

            modelBuilder.Entity("Domain.DataEventRecord", b =>
                {
                    b.Property<long>("DataEventRecordId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<long>("SourceInfoId");

                    b.Property<DateTime>("Timestamp");

                    b.Property<DateTime>("UpdatedTimestamp");

                    b.HasKey("DataEventRecordId");

                    b.HasIndex("SourceInfoId");

                    b.ToTable("DataEventRecords");
                });

            modelBuilder.Entity("Domain.SourceInfo", b =>
                {
                    b.Property<long>("SourceInfoId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int>("TestColumn");

                    b.Property<DateTime>("Timestamp");

                    b.Property<DateTime>("UpdatedTimestamp");

                    b.HasKey("SourceInfoId");

                    b.ToTable("SourceInfos");
                });

            modelBuilder.Entity("Domain.DataEventRecord", b =>
                {
                    b.HasOne("Domain.SourceInfo", "SourceInfo")
                        .WithMany("DataEventRecords")
                        .HasForeignKey("SourceInfoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
