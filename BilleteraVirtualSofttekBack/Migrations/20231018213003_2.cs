using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BilleteraVirtualSofttekBack.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Clients",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Clients",
                newName: "client_password");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Clients",
                newName: "client_name");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "Clients",
                newName: "modified_date");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Clients",
                newName: "client_email");

            migrationBuilder.RenameColumn(
                name: "DeletedDate",
                table: "Clients",
                newName: "deleted_date");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Clients",
                newName: "created_date");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Accounts",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "account_money",
                table: "Accounts",
                newName: "account_balance");

            migrationBuilder.RenameColumn(
                name: "UUID",
                table: "Accounts",
                newName: "accound_uuid");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Accounts",
                newName: "account_type");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "Accounts",
                newName: "modified_date");

            migrationBuilder.RenameColumn(
                name: "DeletedDate",
                table: "Accounts",
                newName: "deleted_date");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Accounts",
                newName: "created_date");

            migrationBuilder.RenameColumn(
                name: "CBU",
                table: "Accounts",
                newName: "account_date");

            migrationBuilder.RenameColumn(
                name: "Alias",
                table: "Accounts",
                newName: "account_alias");

            migrationBuilder.RenameColumn(
                name: "AccountNumber",
                table: "Accounts",
                newName: "account_number");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "created_date", "accound_uuid" },
                values: new object[] { new DateTime(2023, 10, 18, 18, 30, 3, 76, DateTimeKind.Local).AddTicks(4793), new Guid("cbda4077-6543-4322-8e17-e8d12a7b1aac") });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 2,
                column: "created_date",
                value: new DateTime(2023, 10, 18, 18, 30, 3, 75, DateTimeKind.Local).AddTicks(5790));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 1,
                column: "created_date",
                value: new DateTime(2023, 10, 18, 18, 30, 3, 74, DateTimeKind.Local).AddTicks(4071));

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "id", "account_balance", "client_id", "created_date", "deleted_date", "Discriminator", "modified_date", "account_type", "accound_uuid" },
                values: new object[] { 6, 2000m, 1, new DateTime(2023, 10, 18, 18, 30, 3, 76, DateTimeKind.Local).AddTicks(4797), null, "CryptoAccount", null, 3, new Guid("0d92c084-ca1a-4559-bde8-474e4c5d4fa7") });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "id", "account_number", "account_alias", "account_balance", "account_date", "client_id", "created_date", "deleted_date", "Discriminator", "modified_date", "account_type" },
                values: new object[,]
                {
                    { 5, 5, "acor", 4000m, 654334523, 1, new DateTime(2023, 10, 18, 18, 30, 3, 75, DateTimeKind.Local).AddTicks(5795), null, "DollarAccount", null, 2 },
                    { 4, 4, "riccad", 2000m, 532456234, 1, new DateTime(2023, 10, 18, 18, 30, 3, 74, DateTimeKind.Local).AddTicks(4075), null, "PesoAccount", null, 1 }
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Clients",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "modified_date",
                table: "Clients",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "deleted_date",
                table: "Clients",
                newName: "DeletedDate");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "Clients",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "client_password",
                table: "Clients",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "client_name",
                table: "Clients",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "client_email",
                table: "Clients",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Accounts",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "modified_date",
                table: "Accounts",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "deleted_date",
                table: "Accounts",
                newName: "DeletedDate");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "Accounts",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "account_type",
                table: "Accounts",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "account_number",
                table: "Accounts",
                newName: "AccountNumber");

            migrationBuilder.RenameColumn(
                name: "account_date",
                table: "Accounts",
                newName: "CBU");

            migrationBuilder.RenameColumn(
                name: "account_balance",
                table: "Accounts",
                newName: "account_money");

            migrationBuilder.RenameColumn(
                name: "account_alias",
                table: "Accounts",
                newName: "Alias");

            migrationBuilder.RenameColumn(
                name: "accound_uuid",
                table: "Accounts",
                newName: "UUID");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UUID" },
                values: new object[] { new DateTime(2023, 10, 18, 13, 15, 49, 145, DateTimeKind.Local).AddTicks(9984), new Guid("c2822a8e-e702-40b6-be2e-b2eb9a176b91") });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 18, 13, 15, 49, 145, DateTimeKind.Local).AddTicks(210));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 18, 13, 15, 49, 143, DateTimeKind.Local).AddTicks(7874));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 18, 13, 15, 49, 142, DateTimeKind.Local).AddTicks(4587));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 18, 13, 15, 49, 142, DateTimeKind.Local).AddTicks(4714));
        }
    }
}
