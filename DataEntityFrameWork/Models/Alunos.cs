namespace DataEntityFrameWork.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Alunos
    {
        [Key]
        public int AlunosID { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public int Idade { get { return DateTime.Now.Year - DataNascimento.Year; } }
        public int Repetente { get; set; }
        public bool Repetir { get { return Repetente == 0 ? true : false; } }

       
        // Relação Aluno - Turma
        public int TurmasID { get; set; }
        public virtual Turmas Turmas { get; set; }

        // Faltas - Alunos
        public virtual ICollection<Faltas> Faltas { get; set; }


        // Notas
        public virtual ICollection<Macs> Macs1 { get; set; }
    }
}
