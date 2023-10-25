using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BilleteraVirtualSofttekBack.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "created_date", "accound_uuid" },
                values: new object[] { new DateTime(2023, 10, 19, 13, 10, 5, 183, DateTimeKind.Local).AddTicks(5584), new Guid("0c3f0865-1964-41bf-91b3-18a2b3124b9a") });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "created_date", "accound_uuid" },
                values: new object[] { new DateTime(2023, 10, 19, 13, 10, 5, 183, DateTimeKind.Local).AddTicks(5592), new Guid("3611fe12-7f9a-48e1-a72d-0bb14868c2ff") });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 2,
                column: "created_date",
                value: new DateTime(2023, 10, 19, 13, 10, 5, 182, DateTimeKind.Local).AddTicks(1293));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 5,
                column: "created_date",
                value: new DateTime(2023, 10, 19, 13, 10, 5, 182, DateTimeKind.Local).AddTicks(1297));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 1,
                column: "created_date",
                value: new DateTime(2023, 10, 19, 13, 10, 5, 179, DateTimeKind.Local).AddTicks(5214));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 4,
                column: "created_date",
                value: new DateTime(2023, 10, 19, 13, 10, 5, 179, DateTimeKind.Local).AddTicks(5218));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "id",
                keyValue: 1,
                column: "created_date",
                value: new DateTime(2023, 10, 19, 13, 10, 5, 176, DateTimeKind.Local).AddTicks(6072));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "id",
                keyValue: 2,
                column: "created_date",
                value: new DateTime(2023, 10, 19, 13, 10, 5, 176, DateTimeKind.Local).AddTicks(6218));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "created_date", "accound_uuid" },
                values: new object[] { new DateTime(2023, 10, 18, 19, 41, 25, 85, DateTimeKind.Local).AddTicks(1244), new Guid("f21b0863-7631-4ff0-ab01-8ad06b761b3c") });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "created_date", "accound_uuid" },
                values: new object[] { new DateTime(2023, 10, 18, 19, 41, 25, 85, DateTimeKind.Local).AddTicks(1248), new Guid("111d283e-0ca4-46aa-b160-708326ab2894") });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 2,
                column: "created_date",
                value: new DateTime(2023, 10, 18, 19, 41, 25, 83, DateTimeKind.Local).AddTicks(8847));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 5,
                column: "created_date",
                value: new DateTime(2023, 10, 18, 19, 41, 25, 83, DateTimeKind.Local).AddTicks(8854));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 1,
                column: "created_date",
                value: new DateTime(2023, 10, 18, 19, 41, 25, 81, DateTimeKind.Local).AddTicks(7885));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 4,
                column: "created_date",
                value: new DateTime(2023, 10, 18, 19, 41, 25, 81, DateTimeKind.Local).AddTicks(7889));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "id",
                keyValue: 1,
                column: "created_date",
                value: new DateTime(2023, 10, 18, 19, 41, 25, 80, DateTimeKind.Local).AddTicks(5628));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "id",
                keyValue: 2,
                column: "created_date",
                value: new DateTime(2023, 10, 18, 19, 41, 25, 80, DateTimeKind.Local).AddTicks(5743));
        }
    }
}
