using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataEntityFrameWork.Models
{
    public class Professor
    {
        [Key]
        public int ProfessorID { get; set; }

        [Display(Name = "Professor"), Required()]
        public string Nome { get; set; }

        [Display(Name = "BI"), Required()]
        public string Bi { get; set; }

        [DataType(DataType.DateTime), Required()]
        public DateTime DataNascimento { get; set; }
        public int Idade { get { return DateTime.Now.Year - DataNascimento.Year; } }
        public Escolaridade Escolaridade { get; set; }
        public Sexo Sexo { get; set; }

        // Relacionamento
        public virtual ICollection<PlanoAulas> planoAulas { get; set; }
        public virtual ICollection<Professor_Disciplina> Professor_Disciplina { get; set; }
    }
}