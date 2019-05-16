namespace DataEntityFrameWork.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Classes
    {
        [Key]
        public int ClassesID { get; set; }

        [Required(), Display(Name = "Classe")]
        public string ClassesNome { get; set; }

        // Relações
        public virtual ICollection<Turmas> Turmas { get; set; }
        public virtual ICollection<PlanoAulas> planoAulas { get; set; }
    }
}
