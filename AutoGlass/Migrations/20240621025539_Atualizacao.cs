using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoGlass.Migrations
{
    public partial class Atualizacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Codigo",
                table: "Produtos",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Produtos_CK_Produto_DataValidade_MaiorQue_DataFabricacao",
                table: "Produtos",
                sql: "([DataValidade] >= [DataFabricacao])");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Produtos_CK_Produto_DataValidade_MaiorQue_DataFabricacao",
                table: "Produtos");

            migrationBuilder.AlterColumn<Guid>(
                name: "Codigo",
                table: "Produtos",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);
        }
    }
}
