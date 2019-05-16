﻿// <auto-generated />
using System;
using DataEntityFrameWork.Controllers.Helps;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataEntityFrameWork.Migrations
{
    [DbContext(typeof(AppProfessorContext))]
    [Migration("20190425121233_Adicionar_Professor_PlanoAulas_Disciplinas_Disciplina_Professores")]
    partial class Adicionar_Professor_PlanoAulas_Disciplinas_Disciplina_Professores
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataEntityFrameWork.Models.Alunos", b =>
                {
                    b.Property<int>("AlunosID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataNascimento");

                    b.Property<string>("Nome");

                    b.Property<int>("Repetente");

                    b.Property<int>("TurmasID");

                    b.HasKey("AlunosID");

                    b.HasIndex("TurmasID");

                    b.ToTable("Alunos");
                });

            modelBuilder.Entity("DataEntityFrameWork.Models.Classes", b =>
                {
                    b.Property<int>("ClassesID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClassesNome")
                        .IsRequired();

                    b.HasKey("ClassesID");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("DataEntityFrameWork.Models.Cursos", b =>
                {
                    b.Property<int>("CursosID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CursosNome");

                    b.Property<string>("Descricao");

                    b.Property<string>("Sigra");

                    b.HasKey("CursosID");

                    b.ToTable("Cursos");
                });

            modelBuilder.Entity("DataEntityFrameWork.Models.Disciplina", b =>
                {
                    b.Property<int>("DisciplinaID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Designacao")
                        .IsRequired();

                    b.Property<string>("Sigla");

                    b.HasKey("DisciplinaID");

                    b.ToTable("Disciplina");
                });

            modelBuilder.Entity("DataEntityFrameWork.Models.Escola", b =>
                {
                    b.Property<int>("EscolaID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("Imagem");

                    b.Property<string>("Ministerio");

                    b.Property<string>("Nome");

                    b.Property<string>("Outros");

                    b.Property<string>("Rodape");

                    b.Property<string>("republica");

                    b.HasKey("EscolaID");

                    b.ToTable("Escola");
                });

            modelBuilder.Entity("DataEntityFrameWork.Models.Faltas", b =>
                {
                    b.Property<int>("FaltasID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AlunosID");

                    b.Property<DateTime>("DataHoje");

                    b.Property<int>("FaltasNumeros");

                    b.Property<string>("Justificacao");

                    b.Property<bool>("faltou");

                    b.HasKey("FaltasID");

                    b.HasIndex("AlunosID");

                    b.ToTable("Faltas");
                });

            modelBuilder.Entity("DataEntityFrameWork.Models.FaltasLogs", b =>
                {
                    b.Property<int>("FaltasLogsID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Data");

                    b.Property<string>("Descricao");

                    b.HasKey("FaltasLogsID");

                    b.ToTable("FaltasLogs");
                });

            modelBuilder.Entity("DataEntityFrameWork.Models.Grupos", b =>
                {
                    b.Property<int>("GrupoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GrupoComentarios");

                    b.Property<string>("GrupoNome");

                    b.HasKey("GrupoId");

                    b.ToTable("Grupos");
                });

            modelBuilder.Entity("DataEntityFrameWork.Models.Logs", b =>
                {
                    b.Property<int>("LogsId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Data");

                    b.Property<TimeSpan>("Hora");

                    b.Property<string>("Operacao");

                    b.Property<int>("UsuariosId");

                    b.HasKey("LogsId");

                    b.HasIndex("UsuariosId");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("DataEntityFrameWork.Models.Macs", b =>
                {
                    b.Property<int>("MacsID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AlunosID");

                    b.Property<int>("TrimestreID");

                    b.Property<decimal>("nota1");

                    b.Property<decimal>("nota2");

                    b.Property<decimal>("nota3");

                    b.Property<decimal>("nota4");

                    b.Property<decimal>("nota5");

                    b.Property<decimal>("nota6");

                    b.Property<decimal>("nota7");

                    b.Property<decimal>("nota8");

                    b.HasKey("MacsID");

                    b.HasIndex("AlunosID");

                    b.HasIndex("TrimestreID");

                    b.ToTable("Macs1");
                });

            modelBuilder.Entity("DataEntityFrameWork.Models.Periodo", b =>
                {
                    b.Property<int>("PeriodoID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao");

                    b.Property<string>("PeriodoNome");

                    b.HasKey("PeriodoID");

                    b.ToTable("Periodo");
                });

            modelBuilder.Entity("DataEntityFrameWork.Models.Permissoes", b =>
                {
                    b.Property<int>("PermissoesId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Adicionar");

                    b.Property<bool>("Alunos");

                    b.Property<bool>("Apagar");

                    b.Property<bool>("Atualizar");

                    b.Property<bool>("Backup");

                    b.Property<bool>("BackupActivarDesativar");

                    b.Property<bool>("BackupAutomatico");

                    b.Property<bool>("BackupManual");

                    b.Property<bool>("Classe");

                    b.Property<bool>("Consultas");

                    b.Property<bool>("Cursos");

                    b.Property<bool>("Definicoes");

                    b.Property<bool>("Descontos");

                    b.Property<bool>("Disciplinas");

                    b.Property<bool>("Dividas");

                    b.Property<bool>("ErrosLogs");

                    b.Property<bool>("ErrosLogsReport");

                    b.Property<bool>("Graficos");

                    b.Property<int>("GrupoId");

                    b.Property<bool>("Grupos");

                    b.Property<bool>("GruposAdicionar");

                    b.Property<bool>("GruposConsultar");

                    b.Property<bool>("Guardar");

                    b.Property<bool>("ModuloGeral");

                    b.Property<bool>("Periodos");

                    b.Property<bool>("Promocoes");

                    b.Property<bool>("Relatorios");

                    b.Property<bool>("Turma");

                    b.Property<bool>("Usuarios");

                    b.Property<bool>("UsuariosAdicionar");

                    b.Property<bool>("UsuariosConsultar");

                    b.Property<bool>("UsuariosHistorico");

                    b.HasKey("PermissoesId");

                    b.HasIndex("GrupoId");

                    b.ToTable("Permissoes");
                });

            modelBuilder.Entity("DataEntityFrameWork.Models.PlanoAulas", b =>
                {
                    b.Property<int>("PlanoAulasID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClassesID");

                    b.Property<string>("Conclusao");

                    b.Property<DateTime>("Data");

                    b.Property<string>("Desenvolvimento");

                    b.Property<int>("DisciplinaID");

                    b.Property<int>("Duracao");

                    b.Property<string>("Especifico");

                    b.Property<string>("Instrutivo");

                    b.Property<string>("Introducao");

                    b.Property<int>("Licao");

                    b.Property<string>("Metodo");

                    b.Property<string>("ObjectivoGeral");

                    b.Property<string>("Procedimento");

                    b.Property<int>("ProfessorID");

                    b.Property<string>("Sumario");

                    b.Property<string>("UnidadeTematica");

                    b.HasKey("PlanoAulasID");

                    b.HasIndex("ClassesID");

                    b.HasIndex("DisciplinaID");

                    b.HasIndex("ProfessorID");

                    b.ToTable("PlanoAulas");
                });

            modelBuilder.Entity("DataEntityFrameWork.Models.Professor", b =>
                {
                    b.Property<int>("ProfessorID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bi")
                        .IsRequired();

                    b.Property<DateTime>("DataNascimento");

                    b.Property<int>("Escolaridade");

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<int>("Sexo");

                    b.HasKey("ProfessorID");

                    b.ToTable("Professor");
                });

            modelBuilder.Entity("DataEntityFrameWork.Models.Trimestres", b =>
                {
                    b.Property<int>("TrimestreID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao");

                    b.Property<int>("Inicio");

                    b.Property<int>("Termino");

                    b.Property<string>("TrimestreNome");

                    b.HasKey("TrimestreID");

                    b.ToTable("Trimestres");
                });

            modelBuilder.Entity("DataEntityFrameWork.Models.Turmas", b =>
                {
                    b.Property<int>("TurmasID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClassesID");

                    b.Property<int>("CursosID");

                    b.Property<string>("Descricao");

                    b.Property<int>("IdadeFim");

                    b.Property<int>("IdadeInicio");

                    b.Property<int>("PeriodoID");

                    b.Property<int>("Quantidade");

                    b.Property<string>("Sala");

                    b.Property<string>("TurmasNome");

                    b.HasKey("TurmasID");

                    b.HasIndex("ClassesID");

                    b.HasIndex("CursosID");

                    b.HasIndex("PeriodoID");

                    b.ToTable("Turmas");
                });

            modelBuilder.Entity("DataEntityFrameWork.Models.Usuarios", b =>
                {
                    b.Property<int>("UsuariosId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apelido");

                    b.Property<DateTime>("DataNascimento");

                    b.Property<string>("Email");

                    b.Property<bool>("Estado");

                    b.Property<int>("GrupoId");

                    b.Property<string>("Login");

                    b.Property<byte[]>("Perfil");

                    b.Property<string>("Pin");

                    b.Property<string>("Senha");

                    b.Property<string>("UsuarioNomeCompleto");

                    b.HasKey("UsuariosId");

                    b.HasIndex("GrupoId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("DataEntityFrameWork.Models.Alunos", b =>
                {
                    b.HasOne("DataEntityFrameWork.Models.Turmas", "Turmas")
                        .WithMany("Alunos")
                        .HasForeignKey("TurmasID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataEntityFrameWork.Models.Faltas", b =>
                {
                    b.HasOne("DataEntityFrameWork.Models.Alunos", "Alunos")
                        .WithMany("Faltas")
                        .HasForeignKey("AlunosID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataEntityFrameWork.Models.Logs", b =>
                {
                    b.HasOne("DataEntityFrameWork.Models.Usuarios", "Usuarios")
                        .WithMany("Logs")
                        .HasForeignKey("UsuariosId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataEntityFrameWork.Models.Macs", b =>
                {
                    b.HasOne("DataEntityFrameWork.Models.Alunos", "Alunos")
                        .WithMany("Macs1")
                        .HasForeignKey("AlunosID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DataEntityFrameWork.Models.Trimestres", "Trimestres")
                        .WithMany("Macs")
                        .HasForeignKey("TrimestreID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataEntityFrameWork.Models.Permissoes", b =>
                {
                    b.HasOne("DataEntityFrameWork.Models.Grupos", "Grupo")
                        .WithMany("Permissoes")
                        .HasForeignKey("GrupoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataEntityFrameWork.Models.PlanoAulas", b =>
                {
                    b.HasOne("DataEntityFrameWork.Models.Classes", "Classes")
                        .WithMany("planoAulas")
                        .HasForeignKey("ClassesID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DataEntityFrameWork.Models.Disciplina", "Disciplina")
                        .WithMany("planoAulas")
                        .HasForeignKey("DisciplinaID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DataEntityFrameWork.Models.Professor", "Professor")
                        .WithMany("planoAulas")
                        .HasForeignKey("ProfessorID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataEntityFrameWork.Models.Turmas", b =>
                {
                    b.HasOne("DataEntityFrameWork.Models.Classes", "Classes")
                        .WithMany("Turmas")
                        .HasForeignKey("ClassesID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DataEntityFrameWork.Models.Cursos", "Cursos")
                        .WithMany("Turmas")
                        .HasForeignKey("CursosID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DataEntityFrameWork.Models.Periodo", "Periodo")
                        .WithMany("Turmas")
                        .HasForeignKey("PeriodoID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataEntityFrameWork.Models.Usuarios", b =>
                {
                    b.HasOne("DataEntityFrameWork.Models.Grupos", "Grupos")
                        .WithMany("Usuarios")
                        .HasForeignKey("GrupoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
