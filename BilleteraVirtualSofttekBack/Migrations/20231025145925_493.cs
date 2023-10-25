using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BilleteraVirtualSofttekBack.Migrations
{
    public partial class _493 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Clients_client_id",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Accounts_DestinationAccountId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Accounts_SourceAccountId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Clients_ClientId",
                table: "Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clients",
                table: "Clients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts");

            migrationBuilder.RenameTable(
                name: "Transactions",
                newName: "transaction");

            migrationBuilder.RenameTable(
                name: "Clients",
                newName: "client");

            migrationBuilder.RenameTable(
                name: "Accounts",
                newName: "account");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "transaction",
                newName: "transaction_type");

            migrationBuilder.RenameColumn(
                name: "SourceAccountId",
                table: "transaction",
                newName: "transaction_source_account");

            migrationBuilder.RenameColumn(
                name: "DestinationAccountId",
                table: "transaction",
                newName: "transaction_destination_account");

            migrationBuilder.RenameColumn(
                name: "Concept",
                table: "transaction",
                newName: "transaction_concept");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "transaction",
                newName: "transaction_client");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "transaction",
                newName: "transaction_amount");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_SourceAccountId",
                table: "transaction",
                newName: "IX_transaction_transaction_source_account");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_DestinationAccountId",
                table: "transaction",
                newName: "IX_transaction_transaction_destination_account");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_ClientId",
                table: "transaction",
                newName: "IX_transaction_transaction_client");

            migrationBuilder.RenameIndex(
                name: "IX_Accounts_client_id",
                table: "account",
                newName: "IX_account_client_id");

            migrationBuilder.AlterColumn<int>(
                name: "transaction_concept",
                table: "transaction",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_transaction",
                table: "transaction",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_client",
                table: "client",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_account",
                table: "account",
                column: "id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_account_client_client_id",
                table: "account",
                column: "client_id",
                principalTable: "client",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_transaction_account_transaction_destination_account",
                table: "transaction",
                column: "transaction_destination_account",
                principalTable: "account",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_transaction_account_transaction_source_account",
                table: "transaction",
                column: "transaction_source_account",
                principalTable: "account",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_transaction_client_transaction_client",
                table: "transaction",
                column: "transaction_client",
                principalTable: "client",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_account_client_client_id",
                table: "account");

            migrationBuilder.DropForeignKey(
                name: "FK_transaction_account_transaction_destination_account",
                table: "transaction");

            migrationBuilder.DropForeignKey(
                name: "FK_transaction_account_transaction_source_account",
                table: "transaction");

            migrationBuilder.DropForeignKey(
                name: "FK_transaction_client_transaction_client",
                table: "transaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_transaction",
                table: "transaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_client",
                table: "client");

            migrationBuilder.DropPrimaryKey(
                name: "PK_account",
                table: "account");

            migrationBuilder.RenameTable(
                name: "transaction",
                newName: "Transactions");

            migrationBuilder.RenameTable(
                name: "client",
                newName: "Clients");

            migrationBuilder.RenameTable(
                name: "account",
                newName: "Accounts");

            migrationBuilder.RenameColumn(
                name: "transaction_type",
                table: "Transactions",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "transaction_source_account",
                table: "Transactions",
                newName: "SourceAccountId");

            migrationBuilder.RenameColumn(
                name: "transaction_destination_account",
                table: "Transactions",
                newName: "DestinationAccountId");

            migrationBuilder.RenameColumn(
                name: "transaction_concept",
                table: "Transactions",
                newName: "Concept");

            migrationBuilder.RenameColumn(
                name: "transaction_client",
                table: "Transactions",
                newName: "ClientId");

            migrationBuilder.RenameColumn(
                name: "transaction_amount",
                table: "Transactions",
                newName: "Amount");

            migrationBuilder.RenameIndex(
                name: "IX_transaction_transaction_source_account",
                table: "Transactions",
                newName: "IX_Transactions_SourceAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_transaction_transaction_destination_account",
                table: "Transactions",
                newName: "IX_Transactions_DestinationAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_transaction_transaction_client",
                table: "Transactions",
                newName: "IX_Transactions_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_account_client_id",
                table: "Accounts",
                newName: "IX_Accounts_client_id");

            migrationBuilder.AlterColumn<string>(
                name: "Concept",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transactions",
                table: "Transactions",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clients",
                table: "Clients",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts",
                column: "id");

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
                column: "created_date",
                value: new DateTime(2023, 10, 25, 10, 31, 3, 258, DateTimeKind.Local).AddTicks(3994));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "id",
                keyValue: 2,
                column: "created_date",
                value: new DateTime(2023, 10, 25, 10, 31, 3, 258, DateTimeKind.Local).AddTicks(4070));

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Clients_client_id",
                table: "Accounts",
                column: "client_id",
                principalTable: "Clients",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Accounts_DestinationAccountId",
                table: "Transactions",
                column: "DestinationAccountId",
                principalTable: "Accounts",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Accounts_SourceAccountId",
                table: "Transactions",
                column: "SourceAccountId",
                principalTable: "Accounts",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Clients_ClientId",
                table: "Transactions",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
