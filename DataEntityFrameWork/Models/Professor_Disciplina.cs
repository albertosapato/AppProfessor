using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntityFrameWork.Models
{
    public class Professor_Disciplina
    {
        [Key]
        public int ProfessorDisciplinaID { get; set; }
        public string Descricao { get; set; }

        // Relacionamentos
        public virtual int ProfessorID { get; set; }
        public virtual Professor Professor { get; set; }

        public virtual int DisciplinaID { get; set; }
        public virtual Disciplina Disciplina { get; set; }
    }
}
