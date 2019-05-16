using System;
using System.ComponentModel.DataAnnotations;

namespace DataEntityFrameWork.ViewModels
{
    public class EscolaViewModels
    {
        public int EscolaID { get; set; }
        public string Nome { get; set; }
        public string republica { get; set; }
        public string Ministerio { get; set; }
        public string Outros { get; set; }
        public Byte [] Imagem { get; set; }
        public string Rodape { get; set; }
    }
}
