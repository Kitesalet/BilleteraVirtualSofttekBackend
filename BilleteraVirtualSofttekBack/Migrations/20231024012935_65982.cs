using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BilleteraVirtualSofttekBack.Migrations
{
    public partial class _65982 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "created_date", "accound_uuid" },
                values: new object[] { new DateTime(2023, 10, 23, 22, 29, 35, 311, DateTimeKind.Local).AddTicks(1151), new Guid("c890eb9a-7c2b-4b1f-8c4d-9d7d3151597a") });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "created_date", "accound_uuid" },
                values: new object[] { new DateTime(2023, 10, 23, 22, 29, 35, 311, DateTimeKind.Local).AddTicks(1156), new Guid("66eafada-15e6-4f94-b3da-c065b7f1ea35") });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 2,
                column: "created_date",
                value: new DateTime(2023, 10, 23, 22, 29, 35, 310, DateTimeKind.Local).AddTicks(280));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 5,
                column: "created_date",
                value: new DateTime(2023, 10, 23, 22, 29, 35, 310, DateTimeKind.Local).AddTicks(284));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 1,
                column: "created_date",
                value: new DateTime(2023, 10, 23, 22, 29, 35, 308, DateTimeKind.Local).AddTicks(3371));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 4,
                column: "created_date",
                value: new DateTime(2023, 10, 23, 22, 29, 35, 308, DateTimeKind.Local).AddTicks(3376));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "id",
                keyValue: 1,
                column: "created_date",
                value: new DateTime(2023, 10, 23, 22, 29, 35, 306, DateTimeKind.Local).AddTicks(1195));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "id",
                keyValue: 2,
                column: "created_date",
                value: new DateTime(2023, 10, 23, 22, 29, 35, 306, DateTimeKind.Local).AddTicks(1324));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                column: "created_date",
                value: new DateTime(2023, 10, 23, 13, 25, 55, 900, DateTimeKind.Local).AddTicks(5614));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 5,
                column: "created_date",
                value: new DateTime(2023, 10, 23, 13, 25, 55, 900, DateTimeKind.Local).AddTicks(5616));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 1,
                column: "created_date",
                value: new DateTime(2023, 10, 23, 13, 25, 55, 899, DateTimeKind.Local).AddTicks(1928));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 4,
                column: "created_date",
                value: new DateTime(2023, 10, 23, 13, 25, 55, 899, DateTimeKind.Local).AddTicks(1931));

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
    }
}
