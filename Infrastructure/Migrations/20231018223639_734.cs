using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BilleteraVirtualSofttekBack.Migrations
{
    public partial class _734 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "created_date", "accound_uuid" },
                values: new object[] { new DateTime(2023, 10, 18, 19, 35, 27, 570, DateTimeKind.Local).AddTicks(9303), new Guid("687da781-0104-4822-8e80-60020e663331") });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "created_date", "accound_uuid" },
                values: new object[] { new DateTime(2023, 10, 18, 19, 35, 27, 570, DateTimeKind.Local).AddTicks(9308), new Guid("1a7820a4-0a50-4d20-8b50-bfe2bb30d448") });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 2,
                column: "created_date",
                value: new DateTime(2023, 10, 18, 19, 35, 27, 570, DateTimeKind.Local).AddTicks(766));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 5,
                column: "created_date",
                value: new DateTime(2023, 10, 18, 19, 35, 27, 570, DateTimeKind.Local).AddTicks(773));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 1,
                column: "created_date",
                value: new DateTime(2023, 10, 18, 19, 35, 27, 568, DateTimeKind.Local).AddTicks(9593));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 4,
                column: "created_date",
                value: new DateTime(2023, 10, 18, 19, 35, 27, 568, DateTimeKind.Local).AddTicks(9598));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "id",
                keyValue: 1,
                column: "created_date",
                value: new DateTime(2023, 10, 18, 19, 35, 27, 567, DateTimeKind.Local).AddTicks(6613));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "id",
                keyValue: 2,
                column: "created_date",
                value: new DateTime(2023, 10, 18, 19, 35, 27, 567, DateTimeKind.Local).AddTicks(6678));
        }
    }
}
