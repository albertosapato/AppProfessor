using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataEntityFrameWork.Models
{
    public class Macs
    {
        [Key]
        public int MacsID { get; set; }

        [Range(0, 20,
            ErrorMessage = "Desculpe mais este valor não é permitido")]
        public decimal nota1 { get; set; }

        [Range(0, 20,
            ErrorMessage = "Desculpe mais este valor não é permitido")]
        public decimal nota2 { get; set; }

        [Range(0, 20,
            ErrorMessage = "Desculpe mais este valor não é permitido")]
        public decimal nota3 { get; set; }

        [Range(0, 20,
            ErrorMessage = "Desculpe mais este valor não é permitido")]
        public decimal nota4 { get; set; }

        [Range(0, 20,
            ErrorMessage = "Desculpe mais este valor não é permitido")]
        public decimal nota5 { get; set; }

        [Range(0, 20,
            ErrorMessage = "Desculpe mais este valor não é permitido")]
        public decimal nota6 { get; set; }

        [Range(0, 20,
            ErrorMessage = "Desculpe mais este valor não é permitido")]
        public decimal nota7 { get; set; }

        [Range(0, 20,
            ErrorMessage = "Desculpe mais este valor não é permitido")]
        public decimal nota8 { get; set; }

        // Váriaveis de Leitura
        [NotMapped]
        public int Contador { get
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
        [NotMapped]
        public decimal valuesMacs { get
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
                return result / Contador;
            }
        }

        // Relacionamentos com alunos
        public int AlunosID { get; set; }
        public virtual Alunos Alunos { get; set; }


        // Relacionamentos com Triméstres
        public int TrimestreID { get; set; }
        public virtual Trimestres Trimestres { get; set; }
    }
}
