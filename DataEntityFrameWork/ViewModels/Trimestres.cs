using System.ComponentModel.DataAnnotations;

namespace DataEntityFrameWork.ViewModels
{
    public class TrimestresViewModels
    {
        public int TrimestreID { get; set; }
        public string TrimestreNome { get; set; }
        public string Descricao { get; set; }
        public int Inicio{ get; set; }
        public int Termino { get; set; }
    }
}
