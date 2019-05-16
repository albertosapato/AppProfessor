using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataEntityFrameWork.Models
{
    public class Periodo
    {
        [Key]
        public int PeriodoID { get; set; }
        public string PeriodoNome { get; set; }
        public string Descricao { get; set; }

        // Relações
        public virtual ICollection<Turmas> Turmas { get; set; }
    }
}
