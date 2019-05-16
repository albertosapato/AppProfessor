using System;

namespace DataEntityFrameWork.ViewModels
{
    public class PlanoAulasViewModels
    {
        public int PlanoAulasID { get; set; }
        public DateTime Data { get; set; }
        public int Licao { get; set; }
        public int Duracao { get; set; }
        public string UnidadeTematica { get; set; }
        public string Sumario { get; set; }

        // 
        public string ObjectivoGeral { get; set; }
        public string Instrutivo { get; set; }
        public string Especifico { get; set; }
        public string Metodo { get; set; }
        public string Procedimento { get; set; }

        // Materia
        public string Introducao { get; set; }
        public string Desenvolvimento { get; set; }
        public string Conclusao { get; set; }

        // Relacional
        public int ProfessorID { get; set; }
        public ProfessorViewModels Professor { get; set; }

        public int ClassesID { get; set; }
        public ClassesViewModels Classes { get; set; }

        public int DisciplinaID { get; set; }
        public DisciplinaViewModels Disciplina { get; set; }
    }
}
