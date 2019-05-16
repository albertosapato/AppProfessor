using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataEntityFrameWork.Models
{
    public class Trimestres
    {
        [Key]
        public int TrimestreID { get; set; }
        public string TrimestreNome { get; set; }
        public string Descricao { get; set; }
        public int Inicio{ get; set; }
        public int Termino { get; set; }

        public virtual ICollection<Macs> Macs { get; set; }
    }
}
