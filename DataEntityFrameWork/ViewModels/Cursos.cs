using System.Collections.Generic;

namespace DataEntityFrameWork.ViewModels
{
    public class CursosViewModels
    {
        public int CursosID { get; set; }
        public string CursosNome { get; set; }
        public string Sigra { get; set; }
        public string Descricao { get; set; }

        // Relações
        public List<TurmasViewModels> Turmas { get; set; }
    }
}
