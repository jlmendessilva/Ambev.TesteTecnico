using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ambev.Data.Migrations
{
    /// <inheritdoc />
    public partial class ajuste_nos_pripriedades_dos_dominios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Data",
                table: "Venda",
                newName: "DataUpdated");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCreated",
                table: "Venda",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Finalizada",
                table: "Venda",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<decimal>(
                name: "Quantidade",
                table: "ItensVenda",
                type: "numeric(10,2)",
                precision: 10,
                scale: 2,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataCreated",
                table: "Venda");

            migrationBuilder.DropColumn(
                name: "Finalizada",
                table: "Venda");

            migrationBuilder.RenameColumn(
                name: "DataUpdated",
                table: "Venda",
                newName: "Data");

            migrationBuilder.AlterColumn<int>(
                name: "Quantidade",
                table: "ItensVenda",
                type: "integer",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(10,2)",
                oldPrecision: 10,
                oldScale: 2);
        }
    }
}
