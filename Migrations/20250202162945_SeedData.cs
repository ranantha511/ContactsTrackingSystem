using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ContactTrackingSystem.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactId", "EmailAddress", "FirstName", "LastName", "PhoneNumber", "ZipCode" },
                values: new object[,]
                {
                    { new Guid("1f58098d-7de6-40f4-9d13-d7cb33b02b47"), "akenaway7@webnode.com", "Ashia", "Kenaway", "735-679-5530", "85853" },
                    { new Guid("313e0be6-9ca5-4901-a19a-3a3c593b4b29"), "hmccluin4@barnesandnoble.com", "Helene", "McCluin", "170-986-3084", "32879" },
                    { new Guid("4e867020-1305-4cb1-85c3-041c04ab6758"), "vlimeburn5@unblog.fr", "Vassili", "Limeburn", "140-153-9927", "75005" },
                    { new Guid("56079b0c-6328-4f81-a91b-e664d5ad1c25"), "dratchford1@indiatimes.com", "Duff", "Ratchford", "138-493-8133", "83740" },
                    { new Guid("5c5e2eb4-0319-4781-9b82-634313ec228c"), "emundle6@sun.com", "Enriqueta", "Mundle", "927-644-3552", "78132" },
                    { new Guid("7878280e-7046-4c1a-bdc6-34ae8256d9c5"), "rbarrable8@newyorker.com", "Regan", "Barrable", "679-473-2885", "19188" },
                    { new Guid("83c4c256-ffbd-4bbc-b527-d49389ccfbae"), "cgribbins3@wikipedia.org", "Clea", "Gribbins", "821-170-9142", "66497" },
                    { new Guid("90f55200-ee3c-45e6-ab14-ca8e1951c29a"), "bgiff2@toplist.cz", "Bancroft", "Giff", "370-491-2907", "73970" },
                    { new Guid("9cfdf9cc-d423-4efe-b46c-06e40361af0c"), "jgenge0@moonfruit.com", "Jarvis", "Genge", "160-614-7833", "88358" },
                    { new Guid("9fe9b5d6-9a87-4edb-b083-6d54dbd802a8"), "alongmore9@nps.gov", "Amabelle", "Longmore", "307-257-3220", "12936" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: new Guid("1f58098d-7de6-40f4-9d13-d7cb33b02b47"));

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: new Guid("313e0be6-9ca5-4901-a19a-3a3c593b4b29"));

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: new Guid("4e867020-1305-4cb1-85c3-041c04ab6758"));

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: new Guid("56079b0c-6328-4f81-a91b-e664d5ad1c25"));

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: new Guid("5c5e2eb4-0319-4781-9b82-634313ec228c"));

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: new Guid("7878280e-7046-4c1a-bdc6-34ae8256d9c5"));

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: new Guid("83c4c256-ffbd-4bbc-b527-d49389ccfbae"));

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: new Guid("90f55200-ee3c-45e6-ab14-ca8e1951c29a"));

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: new Guid("9cfdf9cc-d423-4efe-b46c-06e40361af0c"));

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: new Guid("9fe9b5d6-9a87-4edb-b083-6d54dbd802a8"));
        }
    }
}
