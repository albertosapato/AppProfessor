using Microsoft.EntityFrameworkCore.Migrations;

namespace DataEntityFrameWork.Migrations
{
    public partial class Adicionar_Professores_Disciplinas_Correcao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disciplina_Professor_Disciplina_Professor_DisciplinaProfessorDisciplinaID",
                table: "Disciplina");

            migrationBuilder.DropForeignKey(
                name: "FK_Professor_Disciplina_Professor_ProfessorID",
                table: "Professor_Disciplina");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Professor_Disciplina",
                table: "Professor_Disciplina");

            migrationBuilder.DropIndex(
                name: "IX_Disciplina_Professor_DisciplinaProfessorDisciplinaID",
                table: "Disciplina");

            migrationBuilder.DropColumn(
                name: "Professor_DisciplinaProfessorDisciplinaID",
                table: "Disciplina");

            migrationBuilder.RenameTable(
                name: "Professor_Disciplina",
                newName: "professor_Disciplina");

            migrationBuilder.RenameIndex(
                name: "IX_Professor_Disciplina_ProfessorID",
                table: "professor_Disciplina",
                newName: "IX_professor_Disciplina_ProfessorID");

            migrationBuilder.AddColumn<int>(
                name: "DisciplinaID",
                table: "professor_Disciplina",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_professor_Disciplina",
                table: "professor_Disciplina",
                column: "ProfessorDisciplinaID");

            migrationBuilder.CreateIndex(
                name: "IX_professor_Disciplina_DisciplinaID",
                table: "professor_Disciplina",
                column: "DisciplinaID");

            migrationBuilder.AddForeignKey(
                name: "FK_professor_Disciplina_Disciplina_DisciplinaID",
                table: "professor_Disciplina",
                column: "DisciplinaID",
                principalTable: "Disciplina",
                principalColumn: "DisciplinaID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_professor_Disciplina_Professor_ProfessorID",
                table: "professor_Disciplina",
                column: "ProfessorID",
                principalTable: "Professor",
                principalColumn: "ProfessorID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_professor_Disciplina_Disciplina_DisciplinaID",
                table: "professor_Disciplina");

            migrationBuilder.DropForeignKey(
                name: "FK_professor_Disciplina_Professor_ProfessorID",
                table: "professor_Disciplina");

            migrationBuilder.DropPrimaryKey(
                name: "PK_professor_Disciplina",
                table: "professor_Disciplina");

            migrationBuilder.DropIndex(
                name: "IX_professor_Disciplina_DisciplinaID",
                table: "professor_Disciplina");

            migrationBuilder.DropColumn(
                name: "DisciplinaID",
                table: "professor_Disciplina");

            migrationBuilder.RenameTable(
                name: "professor_Disciplina",
                newName: "Professor_Disciplina");

            migrationBuilder.RenameIndex(
                name: "IX_professor_Disciplina_ProfessorID",
                table: "Professor_Disciplina",
                newName: "IX_Professor_Disciplina_ProfessorID");

            migrationBuilder.AddColumn<int>(
                name: "Professor_DisciplinaProfessorDisciplinaID",
                table: "Disciplina",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Professor_Disciplina",
                table: "Professor_Disciplina",
                column: "ProfessorDisciplinaID");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplina_Professor_DisciplinaProfessorDisciplinaID",
                table: "Disciplina",
                column: "Professor_DisciplinaProfessorDisciplinaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplina_Professor_Disciplina_Professor_DisciplinaProfessorDisciplinaID",
                table: "Disciplina",
                column: "Professor_DisciplinaProfessorDisciplinaID",
                principalTable: "Professor_Disciplina",
                principalColumn: "ProfessorDisciplinaID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Professor_Disciplina_Professor_ProfessorID",
                table: "Professor_Disciplina",
                column: "ProfessorID",
                principalTable: "Professor",
                principalColumn: "ProfessorID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
