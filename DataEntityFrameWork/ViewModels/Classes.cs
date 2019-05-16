using System.Collections.Generic;

namespace DataEntityFrameWork.ViewModels
{
    public class ClassesViewModels
    {
        public int ClassesID { get; set; }
        public string ClassesNome { get; set; }

        // Relações
        public List<TurmasViewModels> Turmas { get; set; }
    }
}
