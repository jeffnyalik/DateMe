using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatingAPI.Migrations
{
    /// <inheritdoc />
    public partial class Seeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Values",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 12, 21, 14, 38, 56, 142, DateTimeKind.Local).AddTicks(3130));

            migrationBuilder.UpdateData(
                table: "Values",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2022, 12, 21, 14, 38, 56, 142, DateTimeKind.Local).AddTicks(3148));

            migrationBuilder.UpdateData(
                table: "Values",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2022, 12, 21, 14, 38, 56, 142, DateTimeKind.Local).AddTicks(3264));

            migrationBuilder.UpdateData(
                table: "Values",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2022, 12, 21, 14, 38, 56, 142, DateTimeKind.Local).AddTicks(3270));

            migrationBuilder.UpdateData(
                table: "Values",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2022, 12, 21, 14, 38, 56, 142, DateTimeKind.Local).AddTicks(3271));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Values",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 12, 21, 12, 43, 20, 326, DateTimeKind.Local).AddTicks(4348));

            migrationBuilder.UpdateData(
                table: "Values",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2022, 12, 21, 12, 43, 20, 326, DateTimeKind.Local).AddTicks(4366));

            migrationBuilder.UpdateData(
                table: "Values",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2022, 12, 21, 12, 43, 20, 326, DateTimeKind.Local).AddTicks(4368));

            migrationBuilder.UpdateData(
                table: "Values",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2022, 12, 21, 12, 43, 20, 326, DateTimeKind.Local).AddTicks(4369));

            migrationBuilder.UpdateData(
                table: "Values",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2022, 12, 21, 12, 43, 20, 326, DateTimeKind.Local).AddTicks(4370));
        }
    }
}
