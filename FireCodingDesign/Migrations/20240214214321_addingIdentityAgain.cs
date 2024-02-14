using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FireCodingDesign.Migrations
{
    /// <inheritdoc />
    public partial class addingIdentityAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "453ad47c-6c64-47b4-b904-70d435964cb9", null, null, "Admin", "ADMIN" },
                    { "46ef890e-a856-4a80-8a01-ec4c3176222c", null, null, "Customer", "CUSTOMER" },
                    { "4af80b46-1eec-4824-a84b-2c2a5236c7fe", null, null, "Owner", "OWNER" },
                    { "834b532b-91c4-45b0-96ec-5dd307b4c690", null, null, "SuperAdmin", "SUPERADMIN" },
                    { "bc4afa7a-a76b-4ab9-80e3-e89cd09b536f", null, null, "PowerUser", "POWERUSER" },
                    { "eca30d45-1c44-46d9-8020-e7e9e97afd33", null, null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "453ad47c-6c64-47b4-b904-70d435964cb9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "46ef890e-a856-4a80-8a01-ec4c3176222c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4af80b46-1eec-4824-a84b-2c2a5236c7fe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "834b532b-91c4-45b0-96ec-5dd307b4c690");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bc4afa7a-a76b-4ab9-80e3-e89cd09b536f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eca30d45-1c44-46d9-8020-e7e9e97afd33");

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
    }
}
