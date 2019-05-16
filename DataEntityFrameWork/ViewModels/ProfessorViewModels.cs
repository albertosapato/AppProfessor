using DataEntityFrameWork.Models;
using System;
using System.Collections.Generic;

namespace DataEntityFrameWork.ViewModels
{
    public class ProfessorViewModels
    {
        public int ProfessorID { get; set; }
        public string Nome { get; set; }
        public string Bi { get; set; }
        public DateTime DataNascimento { get; set; }
        public Escolaridade Escolaridade { get; set; }
        public Sexo Sexo { get; set; }

        // Relacionamento
        public List<PlanoAulasViewModels> planoAulas { get; set; }
        public List<Professor_DisciplinaViewModels> Professor_Disciplina { get; set; }
    }
}