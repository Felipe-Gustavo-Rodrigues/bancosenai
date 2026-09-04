namespace BancoSENAIAPI.Models
{
    public class Carteira
    {
        public int NumeroCarteira { get; set; }
        public string NomeCarteira { get; set; }
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
