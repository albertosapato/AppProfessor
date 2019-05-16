using Microsoft.EntityFrameworkCore.Migrations;

namespace DataEntityFrameWork.Migrations
{
    public partial class Ajustes_Permissoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UsuariosVendasReport",
                table: "Permissoes",
                newName: "Turma");

            migrationBuilder.RenameColumn(
                name: "UsuariosOnline",
                table: "Permissoes",
                newName: "Periodos");

            migrationBuilder.RenameColumn(
                name: "UsuariosListagem",
                table: "Permissoes",
                newName: "Disciplinas");

            migrationBuilder.RenameColumn(
                name: "UsuariosCartao",
                table: "Permissoes",
                newName: "Cursos");

            migrationBuilder.RenameColumn(
                name: "AuditoriaReport",
                table: "Permissoes",
                newName: "Classe");

            migrationBuilder.RenameColumn(
                name: "Auditoria",
                table: "Permissoes",
                newName: "Alunos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Turma",
                table: "Permissoes",
                newName: "UsuariosVendasReport");

            migrationBuilder.RenameColumn(
                name: "Periodos",
                table: "Permissoes",
                newName: "UsuariosOnline");

            migrationBuilder.RenameColumn(
                name: "Disciplinas",
                table: "Permissoes",
                newName: "UsuariosListagem");

            migrationBuilder.RenameColumn(
                name: "Cursos",
                table: "Permissoes",
                newName: "UsuariosCartao");

            migrationBuilder.RenameColumn(
                name: "Classe",
                table: "Permissoes",
                newName: "AuditoriaReport");

            migrationBuilder.RenameColumn(
                name: "Alunos",
                table: "Permissoes",
                newName: "Auditoria");
        }
    }
}
