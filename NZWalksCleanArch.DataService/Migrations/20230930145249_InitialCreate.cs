using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalksCleanArch.DataService.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Difficulties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Difficulties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    RegionImageUrl = table.Column<string>(type: "text", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Walks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    LengthInKm = table.Column<double>(type: "double precision", nullable: false),
                    WalkImageUrl = table.Column<string>(type: "text", nullable: true),
                    DifficultyId = table.Column<Guid>(type: "uuid", nullable: false),
                    RegionId = table.Column<Guid>(type: "uuid", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Walks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Walks_Difficulties_DifficultyId",
                        column: x => x.DifficultyId,
                        principalTable: "Difficulties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Walks_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "AddedDate", "Name", "Status", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("0be7662a-6cf8-45ca-aa0e-9088d9b41ece"), new DateTime(2023, 9, 30, 14, 52, 49, 738, DateTimeKind.Utc).AddTicks(9380), "Medium", 2, new DateTime(2023, 9, 30, 14, 52, 49, 738, DateTimeKind.Utc).AddTicks(9381) },
                    { new Guid("82ff4bef-e4d8-4784-a45d-e09038b6b95d"), new DateTime(2023, 9, 30, 14, 52, 49, 738, DateTimeKind.Utc).AddTicks(9367), "Easy", 2, new DateTime(2023, 9, 30, 14, 52, 49, 738, DateTimeKind.Utc).AddTicks(9368) },
                    { new Guid("cc765ba3-3470-471f-915d-100fe14fdef0"), new DateTime(2023, 9, 30, 14, 52, 49, 738, DateTimeKind.Utc).AddTicks(9384), "Hard", 2, new DateTime(2023, 9, 30, 14, 52, 49, 738, DateTimeKind.Utc).AddTicks(9384) }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "AddedDate", "Code", "Name", "RegionImageUrl", "Status", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("390b81b6-0879-481a-8720-42f5b8637c41"), new DateTime(2023, 9, 30, 14, 52, 49, 738, DateTimeKind.Utc).AddTicks(9483), "NSN", "Nelson", "https://test.com/image5.png", 2, new DateTime(2023, 9, 30, 14, 52, 49, 738, DateTimeKind.Utc).AddTicks(9484) },
                    { new Guid("51440791-8a91-4e61-8f6d-602860252f93"), new DateTime(2023, 9, 30, 14, 52, 49, 738, DateTimeKind.Utc).AddTicks(9480), "WGN", "Wellington", "https://test.com/image4.png", 2, new DateTime(2023, 9, 30, 14, 52, 49, 738, DateTimeKind.Utc).AddTicks(9481) },
                    { new Guid("84a43188-0df0-4337-a9fa-e7851cddff14"), new DateTime(2023, 9, 30, 14, 52, 49, 738, DateTimeKind.Utc).AddTicks(9477), "BOP", "Bay of Plenty", "https://test.com/image3.png", 2, new DateTime(2023, 9, 30, 14, 52, 49, 738, DateTimeKind.Utc).AddTicks(9477) },
                    { new Guid("a4f8ab81-6c1a-4935-b996-d77d822ac369"), new DateTime(2023, 9, 30, 14, 52, 49, 738, DateTimeKind.Utc).AddTicks(9472), "NTL", "NorthLand", "https://test.com/image2.png", 2, new DateTime(2023, 9, 30, 14, 52, 49, 738, DateTimeKind.Utc).AddTicks(9473) },
                    { new Guid("b082d575-2826-4277-91f5-d300ddcf3438"), new DateTime(2023, 9, 30, 14, 52, 49, 738, DateTimeKind.Utc).AddTicks(9465), "AKL", "AuckLand", "https://test.com/image1.png", 2, new DateTime(2023, 9, 30, 14, 52, 49, 738, DateTimeKind.Utc).AddTicks(9466) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Walks_DifficultyId",
                table: "Walks",
                column: "DifficultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Walks_RegionId",
                table: "Walks",
                column: "RegionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Walks");

            migrationBuilder.DropTable(
                name: "Difficulties");

            migrationBuilder.DropTable(
                name: "Regions");
        }
    }
}
