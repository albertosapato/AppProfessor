namespace DataEntityFrameWork.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class FaltasViewModels
    {
        public int FaltasID { get; set; }
        public string Justificacao { get; set; }
        public DateTime DataHoje { get; set; }
        public bool faltou { get; set; }
        public int FaltasNumeros { get; set; }


        // Relações Existente entre Aluno - Faltas
        public int AlunosID { get; set; }
        public AlunosViewModels Alunos { get; set; }
    }
}
