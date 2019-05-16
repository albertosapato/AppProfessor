using System.Collections.Generic;

namespace DataEntityFrameWork.ViewModels
{
    public class GruposViewModels
    {
        public int GrupoId { get; set; }
        public string GrupoNome { get; set; }
        public string GrupoComentarios { get; set; }
        public virtual List<PermissoesViewModels> Permissoes { get; set; }
        public virtual List<UsuariosViewModels> Usuarios { get; set; }
    }
}
