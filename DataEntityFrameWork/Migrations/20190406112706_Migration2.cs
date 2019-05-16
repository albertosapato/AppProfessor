using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataEntityFrameWork.Migrations
{
    public partial class Migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UsuariosID",
                table: "Usuarios",
                newName: "UsuariosId");

            migrationBuilder.RenameColumn(
                name: "Data",
                table: "Usuarios",
                newName: "DataNascimento");

            migrationBuilder.AddColumn<string>(
                name: "Apelido",
                table: "Usuarios",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Estado",
                table: "Usuarios",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "GrupoId",
                table: "Usuarios",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<byte[]>(
                name: "Perfil",
                table: "Usuarios",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioNomeCompleto",
                table: "Usuarios",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Grupos",
                columns: table => new
                {
                    GrupoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GrupoNome = table.Column<string>(nullable: true),
                    GrupoComentarios = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupos", x => x.GrupoId);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    LogsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Data = table.Column<DateTime>(nullable: false),
                    Operacao = table.Column<string>(nullable: true),
                    Hora = table.Column<TimeSpan>(nullable: false),
                    UsuariosId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.LogsId);
                    table.ForeignKey(
                        name: "FK_Logs_Usuarios_UsuariosId",
                        column: x => x.UsuariosId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuariosId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Permissoes",
                columns: table => new
                {
                    PermissoesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Adicionar = table.Column<bool>(nullable: false),
                    Guardar = table.Column<bool>(nullable: false),
                    Atualizar = table.Column<bool>(nullable: false),
                    Apagar = table.Column<bool>(nullable: false),
                    Descontos = table.Column<bool>(nullable: false),
                    Dividas = table.Column<bool>(nullable: false),
                    Relatorios = table.Column<bool>(nullable: false),
                    Consultas = table.Column<bool>(nullable: false),
                    Promocoes = table.Column<bool>(nullable: false),
                    Definicoes = table.Column<bool>(nullable: false),
                    Backup = table.Column<bool>(nullable: false),
                    BackupManual = table.Column<bool>(nullable: false),
                    BackupAutomatico = table.Column<bool>(nullable: false),
                    BackupActivarDesativar = table.Column<bool>(nullable: false),
                    Graficos = table.Column<bool>(nullable: false),
                    Grupos = table.Column<bool>(nullable: false),
                    GruposAdicionar = table.Column<bool>(nullable: false),
                    GruposConsultar = table.Column<bool>(nullable: false),
                    Usuarios = table.Column<bool>(nullable: false),
                    UsuariosAdicionar = table.Column<bool>(nullable: false),
                    UsuariosConsultar = table.Column<bool>(nullable: false),
                    UsuariosOnline = table.Column<bool>(nullable: false),
                    UsuariosListagem = table.Column<bool>(nullable: false),
                    UsuariosHistorico = table.Column<bool>(nullable: false),
                    UsuariosCartao = table.Column<bool>(nullable: false),
                    UsuariosVendasReport = table.Column<bool>(nullable: false),
                    Auditoria = table.Column<bool>(nullable: false),
                    ErrosLogs = table.Column<bool>(nullable: false),
                    AuditoriaReport = table.Column<bool>(nullable: false),
                    ErrosLogsReport = table.Column<bool>(nullable: false),
                    ModuloGeral = table.Column<bool>(nullable: false),
                    GrupoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissoes", x => x.PermissoesId);
                    table.ForeignKey(
                        name: "FK_Permissoes_Grupos_GrupoId",
                        column: x => x.GrupoId,
                        principalTable: "Grupos",
                        principalColumn: "GrupoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_GrupoId",
                table: "Usuarios",
                column: "GrupoId");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_UsuariosId",
                table: "Logs",
                column: "UsuariosId");

            migrationBuilder.CreateIndex(
                name: "IX_Permissoes_GrupoId",
                table: "Permissoes",
                column: "GrupoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Grupos_GrupoId",
                table: "Usuarios",
                column: "GrupoId",
                principalTable: "Grupos",
                principalColumn: "GrupoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Grupos_GrupoId",
                table: "Usuarios");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "Permissoes");

            migrationBuilder.DropTable(
                name: "Grupos");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_GrupoId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Apelido",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "GrupoId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Perfil",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "UsuarioNomeCompleto",
                table: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "UsuariosId",
                table: "Usuarios",
                newName: "UsuariosID");

            migrationBuilder.RenameColumn(
                name: "DataNascimento",
                table: "Usuarios",
                newName: "Data");
        }
    }
}
