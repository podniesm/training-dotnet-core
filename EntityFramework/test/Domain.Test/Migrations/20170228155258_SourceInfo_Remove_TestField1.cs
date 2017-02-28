using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Domain.Test.Migrations
{
    public partial class SourceInfo_Remove_TestField1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TestColumn1",
                table: "SourceInfos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TestColumn1",
                table: "SourceInfos",
                nullable: false,
                defaultValue: 0);
        }
    }
}
