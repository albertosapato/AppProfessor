using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataEntityFrameWork.ViewModels
{
    public class PeriodoViewModels
    {
        public int PeriodoID { get; set; }
        public string PeriodoNome { get; set; }
        public string Descricao { get; set; }

        // Relações
        public virtual List<TurmasViewModels> Turmas { get; set; }
    }
}
