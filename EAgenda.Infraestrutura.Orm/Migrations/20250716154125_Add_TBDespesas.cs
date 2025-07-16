using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EAgenda.Infraestrutura.Orm.Migrations
{
    /// <inheritdoc />
    public partial class Add_TBDespesas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoriaDespesa_Despesa_DespesasId",
                table: "CategoriaDespesa");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Despesa",
                table: "Despesa");

            migrationBuilder.RenameTable(
                name: "Despesa",
                newName: "Despesas");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataOcorrencia",
                table: "Despesas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Despesas",
                table: "Despesas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriaDespesa_Despesas_DespesasId",
                table: "CategoriaDespesa",
                column: "DespesasId",
                principalTable: "Despesas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoriaDespesa_Despesas_DespesasId",
                table: "CategoriaDespesa");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Despesas",
                table: "Despesas");

            migrationBuilder.RenameTable(
                name: "Despesas",
                newName: "Despesa");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataOcorrencia",
                table: "Despesa",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Despesa",
                table: "Despesa",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriaDespesa_Despesa_DespesasId",
                table: "CategoriaDespesa",
                column: "DespesasId",
                principalTable: "Despesa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
