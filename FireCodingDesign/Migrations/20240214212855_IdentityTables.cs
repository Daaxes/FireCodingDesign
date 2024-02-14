using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FireCodingDesign.Migrations
{
    /// <inheritdoc />
    public partial class IdentityTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "1fe1c6d2-cd81-4b00-a030-152e03728087", null, null, "PowerUser", "POWERUSER" },
                    { "25221c80-4b03-4310-9f0f-15b7c75ea7bd", null, null, "Customer", "CUSTOMER" },
                    { "56b11bc8-97c2-4267-b335-974caa093771", null, null, "User", "USER" },
                    { "c4cc5a46-1faa-46f5-aafe-5b65fa7ab79d", null, null, "Admin", "ADMIN" },
                    { "d3175c9e-212b-457c-93d2-7f28fb3bdc6b", null, null, "Owner", "OWNER" },
                    { "dadbb72b-f0fd-4450-b138-26acad92499b", null, null, "SuperAdmin", "SUPERADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1fe1c6d2-cd81-4b00-a030-152e03728087");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "25221c80-4b03-4310-9f0f-15b7c75ea7bd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "56b11bc8-97c2-4267-b335-974caa093771");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c4cc5a46-1faa-46f5-aafe-5b65fa7ab79d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d3175c9e-212b-457c-93d2-7f28fb3bdc6b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dadbb72b-f0fd-4450-b138-26acad92499b");

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
    }
}
