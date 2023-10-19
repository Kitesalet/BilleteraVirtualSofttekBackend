using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BilleteraVirtualSofttekBack.Migrations
{
    public partial class _54 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Concept = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    SourceAccountId = table.Column<int>(type: "int", nullable: false),
                    DestinationAccountId = table.Column<int>(type: "int", nullable: false),
                    ClientId1 = table.Column<int>(type: "int", nullable: true),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    deleted_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.id);
                    table.ForeignKey(
                        name: "FK_Transactions_Accounts_DestinationAccountId",
                        column: x => x.DestinationAccountId,
                        principalTable: "Accounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transactions_Accounts_SourceAccountId",
                        column: x => x.SourceAccountId,
                        principalTable: "Accounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transactions_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transactions_Clients_ClientId1",
                        column: x => x.ClientId1,
                        principalTable: "Clients",
                        principalColumn: "id");
                });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "created_date", "accound_uuid" },
                values: new object[] { new DateTime(2023, 10, 18, 19, 35, 27, 570, DateTimeKind.Local).AddTicks(9303), new Guid("687da781-0104-4822-8e80-60020e663331") });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "created_date", "accound_uuid" },
                values: new object[] { new DateTime(2023, 10, 18, 19, 35, 27, 570, DateTimeKind.Local).AddTicks(9308), new Guid("1a7820a4-0a50-4d20-8b50-bfe2bb30d448") });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 2,
                column: "created_date",
                value: new DateTime(2023, 10, 18, 19, 35, 27, 570, DateTimeKind.Local).AddTicks(766));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 5,
                column: "created_date",
                value: new DateTime(2023, 10, 18, 19, 35, 27, 570, DateTimeKind.Local).AddTicks(773));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 1,
                column: "created_date",
                value: new DateTime(2023, 10, 18, 19, 35, 27, 568, DateTimeKind.Local).AddTicks(9593));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 4,
                column: "created_date",
                value: new DateTime(2023, 10, 18, 19, 35, 27, 568, DateTimeKind.Local).AddTicks(9598));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "id",
                keyValue: 1,
                column: "created_date",
                value: new DateTime(2023, 10, 18, 19, 35, 27, 567, DateTimeKind.Local).AddTicks(6613));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "id",
                keyValue: 2,
                column: "created_date",
                value: new DateTime(2023, 10, 18, 19, 35, 27, 567, DateTimeKind.Local).AddTicks(6678));

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ClientId",
                table: "Transactions",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ClientId1",
                table: "Transactions",
                column: "ClientId1");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_DestinationAccountId",
                table: "Transactions",
                column: "DestinationAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_SourceAccountId",
                table: "Transactions",
                column: "SourceAccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "created_date", "accound_uuid" },
                values: new object[] { new DateTime(2023, 10, 18, 18, 30, 3, 76, DateTimeKind.Local).AddTicks(4793), new Guid("cbda4077-6543-4322-8e17-e8d12a7b1aac") });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "created_date", "accound_uuid" },
                values: new object[] { new DateTime(2023, 10, 18, 18, 30, 3, 76, DateTimeKind.Local).AddTicks(4797), new Guid("0d92c084-ca1a-4559-bde8-474e4c5d4fa7") });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 2,
                column: "created_date",
                value: new DateTime(2023, 10, 18, 18, 30, 3, 75, DateTimeKind.Local).AddTicks(5790));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 5,
                column: "created_date",
                value: new DateTime(2023, 10, 18, 18, 30, 3, 75, DateTimeKind.Local).AddTicks(5795));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 1,
                column: "created_date",
                value: new DateTime(2023, 10, 18, 18, 30, 3, 74, DateTimeKind.Local).AddTicks(4071));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 4,
                column: "created_date",
                value: new DateTime(2023, 10, 18, 18, 30, 3, 74, DateTimeKind.Local).AddTicks(4075));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "id",
                keyValue: 1,
                column: "created_date",
                value: new DateTime(2023, 10, 18, 18, 30, 3, 72, DateTimeKind.Local).AddTicks(4242));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "id",
                keyValue: 2,
                column: "created_date",
                value: new DateTime(2023, 10, 18, 18, 30, 3, 72, DateTimeKind.Local).AddTicks(4395));
        }
    }
}
