using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataEntityFrameWork.Models
{
    public class Disciplina
    {
        [Key]
        public int DisciplinaID { get; set; }

        [Display(Name = "Designação"), Required()]
        public string Designacao { get; set; }
        public string Sigla { get; set; }

        public virtual ICollection<PlanoAulas> planoAulas { get; set; }
        public virtual ICollection<Professor_Disciplina> Professor_Disciplinas { get; set; }
    }
}