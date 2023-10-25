using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BilleteraVirtualSofttekBack.Migrations
{
    public partial class _3534 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Clients_ClientId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Clients_ClientId1",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_ClientId1",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "ClientId1",
                table: "Transactions");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Clients_ClientId",
                table: "Transactions",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Clients_ClientId",
                table: "Transactions");

            migrationBuilder.AddColumn<int>(
                name: "ClientId1",
                table: "Transactions",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "created_date", "accound_uuid" },
                values: new object[] { new DateTime(2023, 10, 18, 19, 36, 38, 429, DateTimeKind.Local).AddTicks(7112), new Guid("d5ca0c5b-0f40-4d05-8aa2-74d30dc115a3") });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "created_date", "accound_uuid" },
                values: new object[] { new DateTime(2023, 10, 18, 19, 36, 38, 429, DateTimeKind.Local).AddTicks(7116), new Guid("b144a1ca-e063-4b66-a718-c180cae737eb") });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 2,
                column: "created_date",
                value: new DateTime(2023, 10, 18, 19, 36, 38, 428, DateTimeKind.Local).AddTicks(6806));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 5,
                column: "created_date",
                value: new DateTime(2023, 10, 18, 19, 36, 38, 428, DateTimeKind.Local).AddTicks(6810));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 1,
                column: "created_date",
                value: new DateTime(2023, 10, 18, 19, 36, 38, 427, DateTimeKind.Local).AddTicks(2756));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 4,
                column: "created_date",
                value: new DateTime(2023, 10, 18, 19, 36, 38, 427, DateTimeKind.Local).AddTicks(2760));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "id",
                keyValue: 1,
                column: "created_date",
                value: new DateTime(2023, 10, 18, 19, 36, 38, 425, DateTimeKind.Local).AddTicks(8240));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "id",
                keyValue: 2,
                column: "created_date",
                value: new DateTime(2023, 10, 18, 19, 36, 38, 425, DateTimeKind.Local).AddTicks(8369));

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ClientId1",
                table: "Transactions",
                column: "ClientId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Clients_ClientId",
                table: "Transactions",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Clients_ClientId1",
                table: "Transactions",
                column: "ClientId1",
                principalTable: "Clients",
                principalColumn: "id");
        }
    }
}
