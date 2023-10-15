using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NZWalksCleanArch.DataService.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("0be7662a-6cf8-45ca-aa0e-9088d9b41ece"),
                columns: new[] { "AddedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 10, 14, 20, 20, 35, 79, DateTimeKind.Utc).AddTicks(7055), new DateTime(2023, 10, 14, 20, 20, 35, 79, DateTimeKind.Utc).AddTicks(7055) });

            migrationBuilder.UpdateData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("82ff4bef-e4d8-4784-a45d-e09038b6b95d"),
                columns: new[] { "AddedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 10, 14, 20, 20, 35, 79, DateTimeKind.Utc).AddTicks(7045), new DateTime(2023, 10, 14, 20, 20, 35, 79, DateTimeKind.Utc).AddTicks(7046) });

            migrationBuilder.UpdateData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("cc765ba3-3470-471f-915d-100fe14fdef0"),
                columns: new[] { "AddedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 10, 14, 20, 20, 35, 79, DateTimeKind.Utc).AddTicks(7058), new DateTime(2023, 10, 14, 20, 20, 35, 79, DateTimeKind.Utc).AddTicks(7058) });

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("390b81b6-0879-481a-8720-42f5b8637c41"),
                columns: new[] { "AddedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 10, 14, 20, 20, 35, 79, DateTimeKind.Utc).AddTicks(7160), new DateTime(2023, 10, 14, 20, 20, 35, 79, DateTimeKind.Utc).AddTicks(7161) });

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("51440791-8a91-4e61-8f6d-602860252f93"),
                columns: new[] { "AddedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 10, 14, 20, 20, 35, 79, DateTimeKind.Utc).AddTicks(7156), new DateTime(2023, 10, 14, 20, 20, 35, 79, DateTimeKind.Utc).AddTicks(7157) });

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("84a43188-0df0-4337-a9fa-e7851cddff14"),
                columns: new[] { "AddedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 10, 14, 20, 20, 35, 79, DateTimeKind.Utc).AddTicks(7153), new DateTime(2023, 10, 14, 20, 20, 35, 79, DateTimeKind.Utc).AddTicks(7154) });

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("a4f8ab81-6c1a-4935-b996-d77d822ac369"),
                columns: new[] { "AddedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 10, 14, 20, 20, 35, 79, DateTimeKind.Utc).AddTicks(7149), new DateTime(2023, 10, 14, 20, 20, 35, 79, DateTimeKind.Utc).AddTicks(7150) });

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("b082d575-2826-4277-91f5-d300ddcf3438"),
                columns: new[] { "AddedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 10, 14, 20, 20, 35, 79, DateTimeKind.Utc).AddTicks(7144), new DateTime(2023, 10, 14, 20, 20, 35, 79, DateTimeKind.Utc).AddTicks(7145) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("0be7662a-6cf8-45ca-aa0e-9088d9b41ece"),
                columns: new[] { "AddedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 30, 14, 52, 49, 738, DateTimeKind.Utc).AddTicks(9380), new DateTime(2023, 9, 30, 14, 52, 49, 738, DateTimeKind.Utc).AddTicks(9381) });

            migrationBuilder.UpdateData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("82ff4bef-e4d8-4784-a45d-e09038b6b95d"),
                columns: new[] { "AddedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 30, 14, 52, 49, 738, DateTimeKind.Utc).AddTicks(9367), new DateTime(2023, 9, 30, 14, 52, 49, 738, DateTimeKind.Utc).AddTicks(9368) });

            migrationBuilder.UpdateData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("cc765ba3-3470-471f-915d-100fe14fdef0"),
                columns: new[] { "AddedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 30, 14, 52, 49, 738, DateTimeKind.Utc).AddTicks(9384), new DateTime(2023, 9, 30, 14, 52, 49, 738, DateTimeKind.Utc).AddTicks(9384) });

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("390b81b6-0879-481a-8720-42f5b8637c41"),
                columns: new[] { "AddedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 30, 14, 52, 49, 738, DateTimeKind.Utc).AddTicks(9483), new DateTime(2023, 9, 30, 14, 52, 49, 738, DateTimeKind.Utc).AddTicks(9484) });

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("51440791-8a91-4e61-8f6d-602860252f93"),
                columns: new[] { "AddedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 30, 14, 52, 49, 738, DateTimeKind.Utc).AddTicks(9480), new DateTime(2023, 9, 30, 14, 52, 49, 738, DateTimeKind.Utc).AddTicks(9481) });

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("84a43188-0df0-4337-a9fa-e7851cddff14"),
                columns: new[] { "AddedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 30, 14, 52, 49, 738, DateTimeKind.Utc).AddTicks(9477), new DateTime(2023, 9, 30, 14, 52, 49, 738, DateTimeKind.Utc).AddTicks(9477) });

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("a4f8ab81-6c1a-4935-b996-d77d822ac369"),
                columns: new[] { "AddedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 30, 14, 52, 49, 738, DateTimeKind.Utc).AddTicks(9472), new DateTime(2023, 9, 30, 14, 52, 49, 738, DateTimeKind.Utc).AddTicks(9473) });

            migrationBuilder.UpdateData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("b082d575-2826-4277-91f5-d300ddcf3438"),
                columns: new[] { "AddedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 9, 30, 14, 52, 49, 738, DateTimeKind.Utc).AddTicks(9465), new DateTime(2023, 9, 30, 14, 52, 49, 738, DateTimeKind.Utc).AddTicks(9466) });
        }
    }
}
