namespace DataEntityFrameWork.ViewModels
{
    public class Professor_DisciplinaViewModels
    {
        public int ProfessorDisciplinaID { get; set; }
        public string Descricao { get; set; }

        // Relacionamentos
        public int ProfessorID { get; set; }
        public ProfessorViewModels Professor { get; set; }

        public int DisciplinaID { get; set; }
        public DisciplinaViewModels Disciplina { get; set; }
    }
}