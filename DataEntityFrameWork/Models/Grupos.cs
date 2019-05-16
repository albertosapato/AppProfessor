using DataEntityFrameWork.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntityFrameWork.Models
{
    public class Grupos
    {
        [Key]
        public int GrupoId { get; set; }
        public string GrupoNome { get; set; }
        public string GrupoComentarios { get; set; }
        public virtual ICollection<Permissoes> Permissoes { get; set; }
        public virtual ICollection<Usuarios> Usuarios { get; set; }
    }
}
