using System;
using System.ComponentModel.DataAnnotations;

namespace DataEntityFrameWork.Models
{
    public class PlanoAulas
    {
        [Key]
        public int PlanoAulasID { get; set; }
        public DateTime Data { get; set; }
        public int Licao { get; set; }
        public int Duracao { get; set; }
        public string UnidadeTematica { get; set; }
        public string Sumario { get; set; }

        // 
        public string ObjectivoGeral { get; set; }
        public string Instrutivo { get; set; }
        public string Especifico { get; set; }
        public string Metodo { get; set; }
        public string Procedimento { get; set; }

        // Materia
        public string Introducao { get; set; }
        public string Desenvolvimento { get; set; }
        public string Conclusao { get; set; }

        // Relacional
        public virtual int ProfessorID { get; set; }
        public virtual Professor Professor { get; set; }

        public virtual int ClassesID { get; set; }
        public virtual Classes Classes { get; set; }

        public virtual int DisciplinaID { get; set; }
        public virtual Disciplina Disciplina { get; set; }
    }
}
