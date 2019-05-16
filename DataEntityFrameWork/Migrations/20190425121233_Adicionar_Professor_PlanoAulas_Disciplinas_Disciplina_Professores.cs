using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataEntityFrameWork.Migrations
{
    public partial class Adicionar_Professor_PlanoAulas_Disciplinas_Disciplina_Professores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ClassesNome",
                table: "Classes",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Disciplina",
                columns: table => new
                {
                    DisciplinaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Designacao = table.Column<string>(nullable: false),
                    Sigla = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplina", x => x.DisciplinaID);
                });

            migrationBuilder.CreateTable(
                name: "Professor",
                columns: table => new
                {
                    ProfessorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: false),
                    Bi = table.Column<string>(nullable: false),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    Escolaridade = table.Column<int>(nullable: false),
                    Sexo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professor", x => x.ProfessorID);
                });

            migrationBuilder.CreateTable(
                name: "PlanoAulas",
                columns: table => new
                {
                    PlanoAulasID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Data = table.Column<DateTime>(nullable: false),
                    Licao = table.Column<int>(nullable: false),
                    Duracao = table.Column<int>(nullable: false),
                    UnidadeTematica = table.Column<string>(nullable: true),
                    Sumario = table.Column<string>(nullable: true),
                    ObjectivoGeral = table.Column<string>(nullable: true),
                    Instrutivo = table.Column<string>(nullable: true),
                    Especifico = table.Column<string>(nullable: true),
                    Metodo = table.Column<string>(nullable: true),
                    Procedimento = table.Column<string>(nullable: true),
                    Introducao = table.Column<string>(nullable: true),
                    Desenvolvimento = table.Column<string>(nullable: true),
                    Conclusao = table.Column<string>(nullable: true),
                    ProfessorID = table.Column<int>(nullable: false),
                    ClassesID = table.Column<int>(nullable: false),
                    DisciplinaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanoAulas", x => x.PlanoAulasID);
                    table.ForeignKey(
                        name: "FK_PlanoAulas_Classes_ClassesID",
                        column: x => x.ClassesID,
                        principalTable: "Classes",
                        principalColumn: "ClassesID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanoAulas_Disciplina_DisciplinaID",
                        column: x => x.DisciplinaID,
                        principalTable: "Disciplina",
                        principalColumn: "DisciplinaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanoAulas_Professor_ProfessorID",
                        column: x => x.ProfessorID,
                        principalTable: "Professor",
                        principalColumn: "ProfessorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlanoAulas_ClassesID",
                table: "PlanoAulas",
                column: "ClassesID");

            migrationBuilder.CreateIndex(
                name: "IX_PlanoAulas_DisciplinaID",
                table: "PlanoAulas",
                column: "DisciplinaID");

            migrationBuilder.CreateIndex(
                name: "IX_PlanoAulas_ProfessorID",
                table: "PlanoAulas",
                column: "ProfessorID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlanoAulas");

            migrationBuilder.DropTable(
                name: "Disciplina");

            migrationBuilder.DropTable(
                name: "Professor");

            migrationBuilder.AlterColumn<string>(
                name: "ClassesNome",
                table: "Classes",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
