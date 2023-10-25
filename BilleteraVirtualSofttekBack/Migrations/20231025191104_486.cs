using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BilleteraVirtualSofttekBack.Migrations
{
    public partial class _486 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "account",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "created_date", "accound_uuid" },
                values: new object[] { new DateTime(2023, 10, 25, 16, 11, 4, 11, DateTimeKind.Local).AddTicks(7961), new Guid("72d0456f-b299-4efd-9a6e-050652771c13") });

            migrationBuilder.UpdateData(
                table: "account",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "created_date", "accound_uuid" },
                values: new object[] { new DateTime(2023, 10, 25, 16, 11, 4, 11, DateTimeKind.Local).AddTicks(7970), new Guid("ac028e6e-5753-427c-9064-7e17ccbebea8") });

            migrationBuilder.UpdateData(
                table: "account",
                keyColumn: "id",
                keyValue: 2,
                column: "created_date",
                value: new DateTime(2023, 10, 25, 16, 11, 4, 9, DateTimeKind.Local).AddTicks(8729));

            migrationBuilder.UpdateData(
                table: "account",
                keyColumn: "id",
                keyValue: 5,
                column: "created_date",
                value: new DateTime(2023, 10, 25, 16, 11, 4, 9, DateTimeKind.Local).AddTicks(8733));

            migrationBuilder.UpdateData(
                table: "account",
                keyColumn: "id",
                keyValue: 1,
                column: "created_date",
                value: new DateTime(2023, 10, 25, 16, 11, 4, 8, DateTimeKind.Local).AddTicks(4996));

            migrationBuilder.UpdateData(
                table: "account",
                keyColumn: "id",
                keyValue: 4,
                column: "created_date",
                value: new DateTime(2023, 10, 25, 16, 11, 4, 8, DateTimeKind.Local).AddTicks(5000));

            migrationBuilder.UpdateData(
                table: "client",
                keyColumn: "id",
                keyValue: 1,
                column: "created_date",
                value: new DateTime(2023, 10, 25, 16, 11, 4, 6, DateTimeKind.Local).AddTicks(8246));

            migrationBuilder.UpdateData(
                table: "client",
                keyColumn: "id",
                keyValue: 2,
                column: "created_date",
                value: new DateTime(2023, 10, 25, 16, 11, 4, 6, DateTimeKind.Local).AddTicks(8320));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "account",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "created_date", "accound_uuid" },
                values: new object[] { new DateTime(2023, 10, 25, 11, 59, 25, 370, DateTimeKind.Local).AddTicks(4662), new Guid("7410ef44-4523-464f-a415-ed7e36f217fb") });

            migrationBuilder.UpdateData(
                table: "account",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "created_date", "accound_uuid" },
                values: new object[] { new DateTime(2023, 10, 25, 11, 59, 25, 370, DateTimeKind.Local).AddTicks(4668), new Guid("2f087c93-f82b-4d4a-9369-506f67581234") });

            migrationBuilder.UpdateData(
                table: "account",
                keyColumn: "id",
                keyValue: 2,
                column: "created_date",
                value: new DateTime(2023, 10, 25, 11, 59, 25, 369, DateTimeKind.Local).AddTicks(266));

            migrationBuilder.UpdateData(
                table: "account",
                keyColumn: "id",
                keyValue: 5,
                column: "created_date",
                value: new DateTime(2023, 10, 25, 11, 59, 25, 369, DateTimeKind.Local).AddTicks(270));

            migrationBuilder.UpdateData(
                table: "account",
                keyColumn: "id",
                keyValue: 1,
                column: "created_date",
                value: new DateTime(2023, 10, 25, 11, 59, 25, 367, DateTimeKind.Local).AddTicks(6950));

            migrationBuilder.UpdateData(
                table: "account",
                keyColumn: "id",
                keyValue: 4,
                column: "created_date",
                value: new DateTime(2023, 10, 25, 11, 59, 25, 367, DateTimeKind.Local).AddTicks(6954));

            migrationBuilder.UpdateData(
                table: "client",
                keyColumn: "id",
                keyValue: 1,
                column: "created_date",
                value: new DateTime(2023, 10, 25, 11, 59, 25, 366, DateTimeKind.Local).AddTicks(2556));

            migrationBuilder.UpdateData(
                table: "client",
                keyColumn: "id",
                keyValue: 2,
                column: "created_date",
                value: new DateTime(2023, 10, 25, 11, 59, 25, 366, DateTimeKind.Local).AddTicks(2660));
        }
    }
}
