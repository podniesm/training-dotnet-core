using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Domain.Test.Migrations
{
    public partial class SourceInfo_Remove_TestField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TestColumn",
                table: "SourceInfos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TestColumn",
                table: "SourceInfos",
                nullable: false,
                defaultValue: 0);
        }
    }
}
