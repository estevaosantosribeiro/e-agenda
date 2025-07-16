using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EAgenda.Infraestrutura.Orm.Migrations
{
    /// <inheritdoc />
    public partial class Add_TBCompromisso : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compromisso_Contatos_ContatoId",
                table: "Compromisso");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Compromisso",
                table: "Compromisso");

            migrationBuilder.RenameTable(
                name: "Compromisso",
                newName: "Compromissos");

            migrationBuilder.RenameIndex(
                name: "IX_Compromisso_ContatoId",
                table: "Compromissos",
                newName: "IX_Compromissos_ContatoId");

            migrationBuilder.AlterColumn<string>(
                name: "Local",
                table: "Compromissos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Link",
                table: "Compromissos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Compromissos",
                table: "Compromissos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Compromissos_Contatos_ContatoId",
                table: "Compromissos",
                column: "ContatoId",
                principalTable: "Contatos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compromissos_Contatos_ContatoId",
                table: "Compromissos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Compromissos",
                table: "Compromissos");

            migrationBuilder.RenameTable(
                name: "Compromissos",
                newName: "Compromisso");

            migrationBuilder.RenameIndex(
                name: "IX_Compromissos_ContatoId",
                table: "Compromisso",
                newName: "IX_Compromisso_ContatoId");

            migrationBuilder.AlterColumn<string>(
                name: "Local",
                table: "Compromisso",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Link",
                table: "Compromisso",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Compromisso",
                table: "Compromisso",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Compromisso_Contatos_ContatoId",
                table: "Compromisso",
                column: "ContatoId",
                principalTable: "Contatos",
                principalColumn: "Id");
        }
    }
}
