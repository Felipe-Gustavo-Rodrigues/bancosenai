using System.ComponentModel.DataAnnotations;

namespace BancoSENAIAPI.Models
{
    public class Carteira
    {
        [Key]
        public int NumeroCarteira { get; set; }

        [Required]
        public string NomeCarteira { get; set; }

        [Required]
        public decimal ApetiteCarteira { get; set; }

        public Carteira(int NumeroCarteira, string NomeCarteira, decimal ApetiteCarteira)
        {
            this.NumeroCarteira = NumeroCarteira;
            this.NomeCarteira = NomeCarteira;
            this.ApetiteCarteira = ApetiteCarteira;
        }
    }

    public class CarteiraDTO
    {
        public string NomeCarteira { get; set; }
        public decimal ApetiteCarteira { get; set; }
    }
}
