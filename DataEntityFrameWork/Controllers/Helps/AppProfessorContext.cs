namespace DataEntityFrameWork.Controllers.Helps
{
    using DataEntityFrameWork.Models;
    using Microsoft.EntityFrameworkCore;

    public class AppProfessorContext: DbContext
    {
        public AppProfessorContext()
        {
            
        }
        public AppProfessorContext(DbContextOptions<AppProfessorContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=AppProfessor;Trusted_Connection=True;");
            }
        }
        public virtual DbSet<Alunos> Alunos { get; set; }
        public virtual DbSet<Classes> Classes { get; set; }
        public virtual DbSet<Cursos> Cursos { get; set; }
        public virtual DbSet<Escola> Escola { get; set; }
        public virtual DbSet<Faltas> Faltas { get; set; }
        public virtual DbSet<FaltasLogs> FaltasLogs { get; set; }
        public virtual DbSet<Periodo> Periodo { get; set; }
        public virtual DbSet<Trimestres> Trimestres { get; set; }
        public virtual DbSet<Turmas> Turmas { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<Logs> Logs { get; set; }
        public virtual DbSet<Permissoes> Permissoes { get; set; }

        // Macs
        public virtual DbSet<Macs> Macs1 { get; set; }
        public virtual DbSet<Grupos> Grupos { get; set; }


        public virtual DbSet<PlanoAulas> PlanoAulas { get; set; }
        public virtual DbSet<Professor> Professor { get; set; }
        public virtual DbSet<Disciplina> Disciplina { get; set; }
        public virtual DbSet<Professor_Disciplina> professor_Disciplina { get; set; }


    }
}
