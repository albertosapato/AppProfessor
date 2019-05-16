namespace DataEntityFrameWork.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Faltas
    {
        [Key]
        public int FaltasID { get; set; }
        public string Justificacao { get; set; }
        public DateTime DataHoje { get; set; }
        public bool faltou { get; set; }
        public int FaltasNumeros { get; set; }


        // Relações Existente entre Aluno - Faltas
        public int AlunosID { get; set; }
        public virtual Alunos Alunos { get; set; }
    }
}
