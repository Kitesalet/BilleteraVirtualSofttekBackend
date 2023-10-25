using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BilleteraVirtualSofttekBack.Migrations
{
    public partial class _487892 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SourceAccountId",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DestinationAccountId",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "client_role",
                table: "Clients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "created_date", "accound_uuid" },
                values: new object[] { new DateTime(2023, 10, 25, 10, 31, 3, 262, DateTimeKind.Local).AddTicks(4014), new Guid("955760dc-626e-46a2-9ebd-adb805a4a317") });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "created_date", "accound_uuid" },
                values: new object[] { new DateTime(2023, 10, 25, 10, 31, 3, 262, DateTimeKind.Local).AddTicks(4037), new Guid("d7c77b5e-8c6a-4d09-bf43-9cba3dc74d7a") });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 2,
                column: "created_date",
                value: new DateTime(2023, 10, 25, 10, 31, 3, 261, DateTimeKind.Local).AddTicks(3320));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 5,
                column: "created_date",
                value: new DateTime(2023, 10, 25, 10, 31, 3, 261, DateTimeKind.Local).AddTicks(3325));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 1,
                column: "created_date",
                value: new DateTime(2023, 10, 25, 10, 31, 3, 259, DateTimeKind.Local).AddTicks(9498));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 4,
                column: "created_date",
                value: new DateTime(2023, 10, 25, 10, 31, 3, 259, DateTimeKind.Local).AddTicks(9502));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_date", "client_role" },
                values: new object[] { new DateTime(2023, 10, 25, 10, 31, 3, 258, DateTimeKind.Local).AddTicks(3994), 1 });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "created_date", "client_role" },
                values: new object[] { new DateTime(2023, 10, 25, 10, 31, 3, 258, DateTimeKind.Local).AddTicks(4070), 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "client_role",
                table: "Clients");

            migrationBuilder.AlterColumn<int>(
                name: "SourceAccountId",
                table: "Transactions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DestinationAccountId",
                table: "Transactions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
    }
}
