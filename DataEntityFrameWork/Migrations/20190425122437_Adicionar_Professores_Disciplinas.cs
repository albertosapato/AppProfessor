using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataEntityFrameWork.Migrations
{
    public partial class Adicionar_Professores_Disciplinas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Professor_DisciplinaProfessorDisciplinaID",
                table: "Disciplina",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Professor_Disciplina",
                columns: table => new
                {
                    ProfessorDisciplinaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(nullable: true),
                    ProfessorID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professor_Disciplina", x => x.ProfessorDisciplinaID);
                    table.ForeignKey(
                        name: "FK_Professor_Disciplina_Professor_ProfessorID",
                        column: x => x.ProfessorID,
                        principalTable: "Professor",
                        principalColumn: "ProfessorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Disciplina_Professor_DisciplinaProfessorDisciplinaID",
                table: "Disciplina",
                column: "Professor_DisciplinaProfessorDisciplinaID");

            migrationBuilder.CreateIndex(
                name: "IX_Professor_Disciplina_ProfessorID",
                table: "Professor_Disciplina",
                column: "ProfessorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplina_Professor_Disciplina_Professor_DisciplinaProfessorDisciplinaID",
                table: "Disciplina",
                column: "Professor_DisciplinaProfessorDisciplinaID",
                principalTable: "Professor_Disciplina",
                principalColumn: "ProfessorDisciplinaID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disciplina_Professor_Disciplina_Professor_DisciplinaProfessorDisciplinaID",
                table: "Disciplina");

            migrationBuilder.DropTable(
                name: "Professor_Disciplina");

            migrationBuilder.DropIndex(
                name: "IX_Disciplina_Professor_DisciplinaProfessorDisciplinaID",
                table: "Disciplina");

            migrationBuilder.DropColumn(
                name: "Professor_DisciplinaProfessorDisciplinaID",
                table: "Disciplina");
        }
    }
}
