namespace DataEntityFrameWork.ViewModels
{
    using System.Collections.Generic;
    public class DisciplinaViewModels
    {
        public int DisciplinaID { get; set; }
        public string Designacao { get; set; }
        public string Sigla { get; set; }
        public List<PlanoAulasViewModels> planoAulas { get; set; }
        public List<Professor_DisciplinaViewModels> Professor_Disciplinas { get; set; }
    }
}
