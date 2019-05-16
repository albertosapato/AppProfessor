using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntityFrameWork.Models
{
    public  class Turmas
    {
        [Key]
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
        public virtual Classes Classes { get; set; }

        // Curso
        public int CursosID { get; set; }
        public virtual Cursos Cursos { get; set; }

        // Periodo
        public int PeriodoID { get; set; }
        public virtual Periodo Periodo { get; set; }

        // Relação
        // Turma - Alunos
        public virtual ICollection<Alunos> Alunos { get; set; }
    }
}
