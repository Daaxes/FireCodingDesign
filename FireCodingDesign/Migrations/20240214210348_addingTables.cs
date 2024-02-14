using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FireCodingDesign.Migrations
{
    /// <inheritdoc />
    public partial class addingTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "259ddb9f-18ad-4d3d-b8f1-d20208b2c512");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4a250674-8975-4761-b73d-9711beb7328e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "888866bb-78e0-4a87-9ab4-d384089870ce");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8a723bb5-be15-42d6-bdfe-c4a3b4421ae3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e29b191-bdbd-457a-9d54-48188e195022");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f3138f48-5292-4fdc-880b-ae7aaf09d0b5");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "AdministrationModelId", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1ae8431a-639a-43f4-aba4-70c4e7d69ca2", null, null, "SuperAdmin", "SUPERADMIN" },
                    { "29f85c24-1e9d-4d9d-9a7c-f6c20e2a782a", null, null, "Owner", "OWNER" },
                    { "787d4ed2-aedb-4e4b-8412-6542faeca1ab", null, null, "Admin", "ADMIN" },
                    { "a9c44a95-9453-4b43-bdd2-a4eb595e3811", null, null, "PowerUser", "POWERUSER" },
                    { "c0a6ed19-4c2a-4b81-aeba-4647aa3a20dd", null, null, "Customer", "CUSTOMER" },
                    { "e29b9d9d-a0dc-4ea8-9c20-c1f5b4973ffb", null, null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ae8431a-639a-43f4-aba4-70c4e7d69ca2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29f85c24-1e9d-4d9d-9a7c-f6c20e2a782a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "787d4ed2-aedb-4e4b-8412-6542faeca1ab");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a9c44a95-9453-4b43-bdd2-a4eb595e3811");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c0a6ed19-4c2a-4b81-aeba-4647aa3a20dd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e29b9d9d-a0dc-4ea8-9c20-c1f5b4973ffb");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "AdministrationModelId", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "259ddb9f-18ad-4d3d-b8f1-d20208b2c512", null, null, "Owner", "OWNER" },
                    { "4a250674-8975-4761-b73d-9711beb7328e", null, null, "PowerUser", "POWERUSER" },
                    { "888866bb-78e0-4a87-9ab4-d384089870ce", null, null, "Customer", "CUSTOMER" },
                    { "8a723bb5-be15-42d6-bdfe-c4a3b4421ae3", null, null, "Admin", "ADMIN" },
                    { "9e29b191-bdbd-457a-9d54-48188e195022", null, null, "SuperAdmin", "SUPERADMIN" },
                    { "f3138f48-5292-4fdc-880b-ae7aaf09d0b5", null, null, "User", "USER" }
                });
        }
    }
}
