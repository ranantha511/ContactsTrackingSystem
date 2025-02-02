using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactTrackingSystem.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserLogins",
                columns: new[] { "Id", "Password", "Username" },
                values: new object[] { new Guid("e977e05c-17c1-4144-91a9-50a4143d4ee9"), "Test!234", "AdminUser@gmail.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserLogins",
                keyColumn: "Id",
                keyValue: new Guid("e977e05c-17c1-4144-91a9-50a4143d4ee9"));
        }
    }
}
