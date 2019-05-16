using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntityFrameWork.ViewModels
{
    public class ProfessorViewModelsAdapter
    {
        public int ProfessorDisciplinaID { get; set; }
        public string Descricao { get; set; }

        // Relacionamentos
        public int ProfessorID { get; set; }
        public ProfessorViewModels Professor { get; set; }
        public List<DisciplinaViewModels> Disciplina { get; set; }
    }
}
