using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ambev.Data.Migrations
{
    /// <inheritdoc />
    public partial class atualizacao_campos_tabela_venda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataUpdated",
                table: "Venda",
                newName: "DataCadastro");

            migrationBuilder.RenameColumn(
                name: "DataCreated",
                table: "Venda",
                newName: "DataAtualizacao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataCadastro",
                table: "Venda",
                newName: "DataUpdated");

            migrationBuilder.RenameColumn(
                name: "DataAtualizacao",
                table: "Venda",
                newName: "DataCreated");
        }
    }
}
