using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatingAPI.Migrations
{
    /// <inheritdoc />
    public partial class NewExtendedUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Values",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 12, 21, 12, 32, 22, 194, DateTimeKind.Local).AddTicks(9461));

            migrationBuilder.UpdateData(
                table: "Values",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2022, 12, 21, 12, 32, 22, 194, DateTimeKind.Local).AddTicks(9479));

            migrationBuilder.UpdateData(
                table: "Values",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2022, 12, 21, 12, 32, 22, 194, DateTimeKind.Local).AddTicks(9481));

            migrationBuilder.UpdateData(
                table: "Values",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2022, 12, 21, 12, 32, 22, 194, DateTimeKind.Local).AddTicks(9482));

            migrationBuilder.UpdateData(
                table: "Values",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2022, 12, 21, 12, 32, 22, 194, DateTimeKind.Local).AddTicks(9484));
        }
    }
}
