using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataEntityFrameWork.Models
{
    public class Cursos
    {
        [Key]
        public int CursosID { get; set; }
        public string CursosNome { get; set; }
        public string Sigra { get; set; }
        public string Descricao { get; set; }

        // Relações
        public virtual ICollection<Turmas> Turmas { get; set; }
    }
}
