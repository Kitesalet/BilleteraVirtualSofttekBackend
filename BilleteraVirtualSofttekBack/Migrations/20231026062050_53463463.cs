using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BilleteraVirtualSofttekBack.Migrations
{
    public partial class _53463463 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "account",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "created_date", "accound_uuid" },
                values: new object[] { new DateTime(2023, 10, 26, 3, 20, 49, 501, DateTimeKind.Local).AddTicks(9199), new Guid("f88ea603-6b06-4c3d-a7e9-3dd20ca654fd") });

            migrationBuilder.UpdateData(
                table: "account",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "created_date", "accound_uuid" },
                values: new object[] { new DateTime(2023, 10, 26, 3, 20, 49, 501, DateTimeKind.Local).AddTicks(9204), new Guid("e972d390-cd4a-4702-8713-2506959ad138") });

            migrationBuilder.UpdateData(
                table: "account",
                keyColumn: "id",
                keyValue: 2,
                column: "created_date",
                value: new DateTime(2023, 10, 26, 3, 20, 49, 500, DateTimeKind.Local).AddTicks(9349));

            migrationBuilder.UpdateData(
                table: "account",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "account_balance", "created_date" },
                values: new object[] { 0m, new DateTime(2023, 10, 26, 3, 20, 49, 500, DateTimeKind.Local).AddTicks(9353) });

            migrationBuilder.UpdateData(
                table: "account",
                keyColumn: "id",
                keyValue: 1,
                column: "created_date",
                value: new DateTime(2023, 10, 26, 3, 20, 49, 499, DateTimeKind.Local).AddTicks(6937));

            migrationBuilder.UpdateData(
                table: "account",
                keyColumn: "id",
                keyValue: 4,
                column: "created_date",
                value: new DateTime(2023, 10, 26, 3, 20, 49, 499, DateTimeKind.Local).AddTicks(6941));

            migrationBuilder.UpdateData(
                table: "client",
                keyColumn: "id",
                keyValue: 1,
                column: "created_date",
                value: new DateTime(2023, 10, 26, 3, 20, 49, 498, DateTimeKind.Local).AddTicks(1219));

            migrationBuilder.UpdateData(
                table: "client",
                keyColumn: "id",
                keyValue: 2,
                column: "created_date",
                value: new DateTime(2023, 10, 26, 3, 20, 49, 498, DateTimeKind.Local).AddTicks(1283));

            migrationBuilder.InsertData(
                table: "client",
                columns: new[] { "id", "created_date", "deleted_date", "client_email", "modified_date", "client_name", "client_password", "client_role" },
                values: new object[] { 3, new DateTime(2023, 10, 26, 3, 20, 49, 498, DateTimeKind.Local).AddTicks(1438), null, "3@3.com", null, "random", "389aec82d3ce947fd1ba75e52b2b49d5e7ffcebe7d8e059db3bb8c49594d0bbf", 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "client",
                keyColumn: "id",
                keyValue: 3);

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
                columns: new[] { "account_balance", "created_date" },
                values: new object[] { 4000m, new DateTime(2023, 10, 25, 16, 11, 4, 9, DateTimeKind.Local).AddTicks(8733) });

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
    }
}
