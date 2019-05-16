using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataEntityFrameWork.Migrations
{
    public partial class AdicionarMacs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Macs1",
                columns: table => new
                {
                    MacsID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", 
                        SqlServerValueGenerationStrategy.IdentityColumn),
                    nota1 = table.Column<decimal>(nullable: false),
                    nota2 = table.Column<decimal>(nullable: false),
                    nota3 = table.Column<decimal>(nullable: false),
                    nota4 = table.Column<decimal>(nullable: false),
                    nota5 = table.Column<decimal>(nullable: false),
                    nota6 = table.Column<decimal>(nullable: false),
                    nota7 = table.Column<decimal>(nullable: false),
                    nota8 = table.Column<decimal>(nullable: false),
                    AlunosID = table.Column<int>(nullable: false),
                    TrimestreID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Macs1", x => x.MacsID);
                    table.ForeignKey(
                        name: "FK_Macs1_Alunos_AlunosID",
                        column: x => x.AlunosID,
                        principalTable: "Alunos",
                        principalColumn: "AlunosID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Macs1_Trimestres_TrimestreID",
                        column: x => x.TrimestreID,
                        principalTable: "Trimestres",
                        principalColumn: "TrimestreID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Macs1_AlunosID",
                table: "Macs1",
                column: "AlunosID");

            migrationBuilder.CreateIndex(
                name: "IX_Macs1_TrimestreID",
                table: "Macs1",
                column: "TrimestreID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Macs1");
        }
    }
}
