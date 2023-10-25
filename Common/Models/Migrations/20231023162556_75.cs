using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BilleteraVirtualSofttekBack.Migrations
{
    public partial class _75 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "created_date", "accound_uuid" },
                values: new object[] { new DateTime(2023, 10, 23, 13, 25, 55, 901, DateTimeKind.Local).AddTicks(5474), new Guid("9166b17b-2620-4556-8b12-b7a2c9fb9c52") });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "created_date", "accound_uuid" },
                values: new object[] { new DateTime(2023, 10, 23, 13, 25, 55, 901, DateTimeKind.Local).AddTicks(5483), new Guid("f6379cbd-e1d6-41c2-8127-a75c207a17c9") });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "account_alias", "created_date" },
                values: new object[] { "Trial.Hamen.Ryu", new DateTime(2023, 10, 23, 13, 25, 55, 900, DateTimeKind.Local).AddTicks(5614) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "account_number", "account_alias", "created_date" },
                values: new object[] { 56564345, "Accordion.Lupin.Extract", new DateTime(2023, 10, 23, 13, 25, 55, 900, DateTimeKind.Local).AddTicks(5616) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "account_number", "account_alias", "created_date" },
                values: new object[] { 134567544, "Rock.Spy.Pink", new DateTime(2023, 10, 23, 13, 25, 55, 899, DateTimeKind.Local).AddTicks(1928) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "account_number", "account_alias", "created_date" },
                values: new object[] { 434567346, "Sword.Javelin.Coconut", new DateTime(2023, 10, 23, 13, 25, 55, 899, DateTimeKind.Local).AddTicks(1931) });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "id",
                keyValue: 1,
                column: "created_date",
                value: new DateTime(2023, 10, 23, 13, 25, 55, 897, DateTimeKind.Local).AddTicks(5669));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "id",
                keyValue: 2,
                column: "created_date",
                value: new DateTime(2023, 10, 23, 13, 25, 55, 897, DateTimeKind.Local).AddTicks(5789));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "created_date", "accound_uuid" },
                values: new object[] { new DateTime(2023, 10, 23, 13, 19, 20, 47, DateTimeKind.Local).AddTicks(482), new Guid("0e58f61c-cd60-49f1-b212-457d00756849") });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "created_date", "accound_uuid" },
                values: new object[] { new DateTime(2023, 10, 23, 13, 19, 20, 47, DateTimeKind.Local).AddTicks(486), new Guid("1d5cb823-f51b-4cd3-8220-c91e53771665") });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "account_alias", "created_date" },
                values: new object[] { "roca", new DateTime(2023, 10, 23, 13, 19, 20, 46, DateTimeKind.Local).AddTicks(1318) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "account_number", "account_alias", "created_date" },
                values: new object[] { 5, "acor", new DateTime(2023, 10, 23, 13, 19, 20, 46, DateTimeKind.Local).AddTicks(1322) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "account_number", "account_alias", "created_date" },
                values: new object[] { 1, "espada", new DateTime(2023, 10, 23, 13, 19, 20, 44, DateTimeKind.Local).AddTicks(9984) });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "account_number", "account_alias", "created_date" },
                values: new object[] { 4, "riccad", new DateTime(2023, 10, 23, 13, 19, 20, 44, DateTimeKind.Local).AddTicks(9988) });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "id",
                keyValue: 1,
                column: "created_date",
                value: new DateTime(2023, 10, 23, 13, 19, 20, 43, DateTimeKind.Local).AddTicks(7418));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "id",
                keyValue: 2,
                column: "created_date",
                value: new DateTime(2023, 10, 23, 13, 19, 20, 43, DateTimeKind.Local).AddTicks(7480));
        }
    }
}
