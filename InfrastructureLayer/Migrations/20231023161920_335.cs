using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BilleteraVirtualSofttekBack.Migrations
{
    public partial class _335 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "account_date",
                table: "Accounts",
                newName: "account_cbu");

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
                column: "created_date",
                value: new DateTime(2023, 10, 23, 13, 19, 20, 46, DateTimeKind.Local).AddTicks(1318));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 5,
                column: "created_date",
                value: new DateTime(2023, 10, 23, 13, 19, 20, 46, DateTimeKind.Local).AddTicks(1322));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 1,
                column: "created_date",
                value: new DateTime(2023, 10, 23, 13, 19, 20, 44, DateTimeKind.Local).AddTicks(9984));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 4,
                column: "created_date",
                value: new DateTime(2023, 10, 23, 13, 19, 20, 44, DateTimeKind.Local).AddTicks(9988));

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "account_cbu",
                table: "Accounts",
                newName: "account_date");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "created_date", "accound_uuid" },
                values: new object[] { new DateTime(2023, 10, 19, 13, 25, 48, 223, DateTimeKind.Local).AddTicks(6943), new Guid("fabd3d3d-fdba-4da5-8ec4-aee33d698bd2") });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "created_date", "accound_uuid" },
                values: new object[] { new DateTime(2023, 10, 19, 13, 25, 48, 223, DateTimeKind.Local).AddTicks(6948), new Guid("66d8ceea-a7bc-49b8-8fbc-86228b35e35d") });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 2,
                column: "created_date",
                value: new DateTime(2023, 10, 19, 13, 25, 48, 222, DateTimeKind.Local).AddTicks(6429));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 5,
                column: "created_date",
                value: new DateTime(2023, 10, 19, 13, 25, 48, 222, DateTimeKind.Local).AddTicks(6434));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 1,
                column: "created_date",
                value: new DateTime(2023, 10, 19, 13, 25, 48, 221, DateTimeKind.Local).AddTicks(1119));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 4,
                column: "created_date",
                value: new DateTime(2023, 10, 19, 13, 25, 48, 221, DateTimeKind.Local).AddTicks(1125));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "id",
                keyValue: 1,
                column: "created_date",
                value: new DateTime(2023, 10, 19, 13, 25, 48, 219, DateTimeKind.Local).AddTicks(3724));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "id",
                keyValue: 2,
                column: "created_date",
                value: new DateTime(2023, 10, 19, 13, 25, 48, 219, DateTimeKind.Local).AddTicks(3950));
        }
    }
}
