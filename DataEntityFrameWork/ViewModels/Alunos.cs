namespace DataEntityFrameWork.ViewModels
{
    using System;
    using System.Collections.Generic;
    using DataEntityFrameWork.ViewModels;

    public class AlunosViewModels
    {
        public int AlunosID { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public int Idade { get { return DateTime.Now.Year - DataNascimento.Year; } }
        public int Repetente { get; set; }
        public bool Repetir { get { return Repetente == 1 ? true : false; } }

       
        // Relação Aluno - Turma
        public int TurmasID { get; set; }
        public TurmasViewModels Turmas { get; set; }

        // Faltas - Alunos
        public List<TurmasViewModels> Faltas { get; set; }
    }
}
