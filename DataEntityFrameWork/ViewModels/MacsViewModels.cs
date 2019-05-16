using DataEntityFrameWork.Models;

namespace DataEntityFrameWork.ViewModels
{
    public class MacsViewModels
    {
        public int MacsID { get; set; }
        public decimal nota1 { get; set; }
        public decimal nota2 { get; set; }
        public decimal nota3 { get; set; }
        public decimal nota4 { get; set; }
        public decimal nota5 { get; set; }
        public decimal nota6 { get; set; }
        public decimal nota7 { get; set; }
        public decimal nota8 { get; set; }
        public int Contador
        {
            get
            {
                var result = 0;
                result += nota1 != 0 ? 1 : 0;
                result += nota2 != 0 ? 1 : 0;
                result += nota3 != 0 ? 1 : 0;
                result += nota4 != 0 ? 1 : 0;
                result += nota5 != 0 ? 1 : 0;
                result += nota6 != 0 ? 1 : 0;
                result += nota7 != 0 ? 1 : 0;
                result += nota8 != 0 ? 1 : 0;
                return result;
            }
        }
        public decimal valuesMacs
        {
            get
            {
                var result = 0M;
                result += nota1;
                result += nota2;
                result += nota3;
                result += nota4;
                result += nota5;
                result += nota6;
                result += nota7;
                result += nota8;
                return result == 0 ? 0 : (result / Contador);
            }
        }

        // Relacionamentos com alunos
        public int AlunosID { get; set; }
        public Alunos Alunos { get; set; }


        // Relacionamentos com Triméstres
        public int TrimestreID { get; set; }
        public Trimestres Trimestres { get; set; }
    }
}
