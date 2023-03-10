using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatingAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddedAgeField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Values",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 12, 21, 17, 54, 50, 648, DateTimeKind.Local).AddTicks(1170));

            migrationBuilder.UpdateData(
                table: "Values",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2022, 12, 21, 17, 54, 50, 648, DateTimeKind.Local).AddTicks(1186));

            migrationBuilder.UpdateData(
                table: "Values",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2022, 12, 21, 17, 54, 50, 648, DateTimeKind.Local).AddTicks(1187));

            migrationBuilder.UpdateData(
                table: "Values",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2022, 12, 21, 17, 54, 50, 648, DateTimeKind.Local).AddTicks(1188));

            migrationBuilder.UpdateData(
                table: "Values",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2022, 12, 21, 17, 54, 50, 648, DateTimeKind.Local).AddTicks(1190));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Values",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 12, 21, 17, 46, 15, 954, DateTimeKind.Local).AddTicks(6232));

            migrationBuilder.UpdateData(
                table: "Values",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2022, 12, 21, 17, 46, 15, 954, DateTimeKind.Local).AddTicks(6253));

            migrationBuilder.UpdateData(
                table: "Values",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2022, 12, 21, 17, 46, 15, 954, DateTimeKind.Local).AddTicks(6256));

            migrationBuilder.UpdateData(
                table: "Values",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2022, 12, 21, 17, 46, 15, 954, DateTimeKind.Local).AddTicks(6257));

            migrationBuilder.UpdateData(
                table: "Values",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2022, 12, 21, 17, 46, 15, 954, DateTimeKind.Local).AddTicks(6259));
        }
    }
}
