using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataEntityFrameWork.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    ClassesID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClassesNome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.ClassesID);
                });

            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    CursosID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CursosNome = table.Column<string>(nullable: true),
                    Sigra = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.CursosID);
                });

            migrationBuilder.CreateTable(
                name: "Escola",
                columns: table => new
                {
                    EscolaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    republica = table.Column<string>(nullable: true),
                    Ministerio = table.Column<string>(nullable: true),
                    Outros = table.Column<string>(nullable: true),
                    Imagem = table.Column<byte[]>(nullable: true),
                    Rodape = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Escola", x => x.EscolaID);
                });

            migrationBuilder.CreateTable(
                name: "FaltasLogs",
                columns: table => new
                {
                    FaltasLogsID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Data = table.Column<DateTime>(nullable: false),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaltasLogs", x => x.FaltasLogsID);
                });

            migrationBuilder.CreateTable(
                name: "Periodo",
                columns: table => new
                {
                    PeriodoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PeriodoNome = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Periodo", x => x.PeriodoID);
                });

            migrationBuilder.CreateTable(
                name: "Trimestres",
                columns: table => new
                {
                    TrimestreID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TrimestreNome = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    Inicio = table.Column<int>(nullable: false),
                    Termino = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trimestres", x => x.TrimestreID);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuariosID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Login = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Senha = table.Column<string>(nullable: true),
                    Pin = table.Column<string>(nullable: true),
                    Data = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuariosID);
                });

            migrationBuilder.CreateTable(
                name: "Turmas",
                columns: table => new
                {
                    TurmasID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TurmasNome = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    Sala = table.Column<string>(nullable: true),
                    Quantidade = table.Column<int>(nullable: false),
                    IdadeInicio = table.Column<int>(nullable: false),
                    IdadeFim = table.Column<int>(nullable: false),
                    ClassesID = table.Column<int>(nullable: false),
                    CursosID = table.Column<int>(nullable: false),
                    PeriodoID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turmas", x => x.TurmasID);
                    table.ForeignKey(
                        name: "FK_Turmas_Classes_ClassesID",
                        column: x => x.ClassesID,
                        principalTable: "Classes",
                        principalColumn: "ClassesID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Turmas_Cursos_CursosID",
                        column: x => x.CursosID,
                        principalTable: "Cursos",
                        principalColumn: "CursosID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Turmas_Periodo_PeriodoID",
                        column: x => x.PeriodoID,
                        principalTable: "Periodo",
                        principalColumn: "PeriodoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    AlunosID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    Repetente = table.Column<int>(nullable: false),
                    TurmasID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.AlunosID);
                    table.ForeignKey(
                        name: "FK_Alunos_Turmas_TurmasID",
                        column: x => x.TurmasID,
                        principalTable: "Turmas",
                        principalColumn: "TurmasID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Faltas",
                columns: table => new
                {
                    FaltasID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Justificacao = table.Column<string>(nullable: true),
                    DataHoje = table.Column<DateTime>(nullable: false),
                    faltou = table.Column<bool>(nullable: false),
                    FaltasNumeros = table.Column<int>(nullable: false),
                    AlunosID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faltas", x => x.FaltasID);
                    table.ForeignKey(
                        name: "FK_Faltas_Alunos_AlunosID",
                        column: x => x.AlunosID,
                        principalTable: "Alunos",
                        principalColumn: "AlunosID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_TurmasID",
                table: "Alunos",
                column: "TurmasID");

            migrationBuilder.CreateIndex(
                name: "IX_Faltas_AlunosID",
                table: "Faltas",
                column: "AlunosID");

            migrationBuilder.CreateIndex(
                name: "IX_Turmas_ClassesID",
                table: "Turmas",
                column: "ClassesID");

            migrationBuilder.CreateIndex(
                name: "IX_Turmas_CursosID",
                table: "Turmas",
                column: "CursosID");

            migrationBuilder.CreateIndex(
                name: "IX_Turmas_PeriodoID",
                table: "Turmas",
                column: "PeriodoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Escola");

            migrationBuilder.DropTable(
                name: "Faltas");

            migrationBuilder.DropTable(
                name: "FaltasLogs");

            migrationBuilder.DropTable(
                name: "Trimestres");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Turmas");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "Periodo");
        }
    }
}
