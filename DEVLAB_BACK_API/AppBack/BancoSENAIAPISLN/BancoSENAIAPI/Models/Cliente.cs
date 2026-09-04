
using BancoSENAIAPI.DB;

namespace BancoSENAIAPI.Models
{
    public class Cliente
    {
        public int CodigoCLiente { get; set; }
        public string NomeCliente { get; set; }
        public string CPF { get; set; }
        public string Sexo { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public int Saldo { get; set; }
        public int NumeroAgencia { get; set; }


        public Cliente(int codigoCLiente, string NomeCliente, string CPF, string Sexo, string Endereço, string Cidade, string Estado, int Saldo, int NumeroAgencia)
        {
            this.CodigoCLiente = codigoCLiente;
            this.NomeCliente = NomeCliente;
            this.CPF = CPF;
            this.Sexo = Sexo;
            this.Endereco = Endereço;
            this.Cidade = Cidade;
            this.Estado = Estado;
            this.Saldo = Saldo;
            this.NumeroAgencia = NumeroAgencia;
        }

    }

    public class ClienteDTO
    {
        public string NomeCliente { get; set; }
        public string CPF { get; set; }
        public string Sexo { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public int Saldo { get; set; }
        public int NumeroAgencia { get; set; }


    }
}