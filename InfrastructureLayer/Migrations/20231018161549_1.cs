using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BilleteraVirtualSofttekBack.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    account_money = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    client_id = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UUID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CBU = table.Column<int>(type: "int", nullable: true),
                    AccountNumber = table.Column<int>(type: "int", nullable: true),
                    Alias = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_Clients_client_id",
                        column: x => x.client_id,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Email", "ModifiedDate", "Name", "Password" },
                values: new object[] { 1, new DateTime(2023, 10, 18, 13, 15, 49, 142, DateTimeKind.Local).AddTicks(4587), null, "1@1.com", null, "random", "389aec82d3ce947fd1ba75e52b2b49d5e7ffcebe7d8e059db3bb8c49594d0bbf" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Email", "ModifiedDate", "Name", "Password" },
                values: new object[] { 2, new DateTime(2023, 10, 18, 13, 15, 49, 142, DateTimeKind.Local).AddTicks(4714), null, "2@2.com", null, "random", "389aec82d3ce947fd1ba75e52b2b49d5e7ffcebe7d8e059db3bb8c49594d0bbf" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "account_money", "client_id", "CreatedDate", "DeletedDate", "Discriminator", "ModifiedDate", "Type", "UUID" },
                values: new object[] { 3, 1000m, 1, new DateTime(2023, 10, 18, 13, 15, 49, 145, DateTimeKind.Local).AddTicks(9984), null, "CryptoAccount", null, 3, new Guid("c2822a8e-e702-40b6-be2e-b2eb9a176b91") });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "AccountNumber", "Alias", "account_money", "CBU", "client_id", "CreatedDate", "DeletedDate", "Discriminator", "ModifiedDate", "Type" },
                values: new object[] { 2, 2, "roca", 2000m, 234567891, 1, new DateTime(2023, 10, 18, 13, 15, 49, 145, DateTimeKind.Local).AddTicks(210), null, "DollarAccount", null, 2 });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "AccountNumber", "Alias", "account_money", "CBU", "client_id", "CreatedDate", "DeletedDate", "Discriminator", "ModifiedDate", "Type" },
                values: new object[] { 1, 1, "espada", 1000m, 123456789, 1, new DateTime(2023, 10, 18, 13, 15, 49, 143, DateTimeKind.Local).AddTicks(7874), null, "PesoAccount", null, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_client_id",
                table: "Accounts",
                column: "client_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
