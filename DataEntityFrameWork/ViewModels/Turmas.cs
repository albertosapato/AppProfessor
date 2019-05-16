using System.Collections.Generic;

namespace DataEntityFrameWork.ViewModels
{
    public  class TurmasViewModels
    {
        public int TurmasID { get; set; }
        public string TurmasNome { get; set; }
        public string Descricao { get; set; }
        public string Sala { get; set; }
        public int Quantidade { get; set; }
        public int IdadeInicio { get; set; }
        public int IdadeFim { get; set; }

        // Relações
        //Classe
        public int ClassesID { get; set; }
        public virtual ClassesViewModels Classes { get; set; }

        // Curso
        public int CursosID { get; set; }
        public virtual CursosViewModels Cursos { get; set; }

        // Periodo
        public int PeriodoID { get; set; }
        public PeriodoViewModels Periodo { get; set; }

        // Relação
        // Turma - Alunos
        public List<AlunosViewModels> Alunos { get; set; }
    }
}
