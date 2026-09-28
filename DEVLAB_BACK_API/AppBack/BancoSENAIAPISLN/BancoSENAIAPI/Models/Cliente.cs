
using BancoSENAIAPI.DB;
using System.ComponentModel.DataAnnotations;

namespace BancoSENAIAPI.Models
{
    public class Cliente
    {
        [Key]
        public int CodigoCLiente { get; set; }

        [Required]
        public string NomeCliente { get; set; }

        [Required]
        public string CPF { get; set; }

        [Required]
        public string Sexo { get; set; }

        [Required]
        public string Endereco { get; set; }

        [Required]
        public string Cidade { get; set; }

        [Required]
        public string Estado { get; set; }

        [Required]
        public int Saldo { get; set; }

        [Required]
        public int NumeroAgencia { get; set; }


        public Cliente(int codigoCLiente, string NomeCliente, string CPF, string Sexo, string Endereco, string Cidade, string Estado, int Saldo, int NumeroAgencia)
        {
            this.CodigoCLiente = codigoCLiente;
            this.NomeCliente = NomeCliente;
            this.CPF = CPF;
            this.Sexo = Sexo;
            this.Endereco = Endereco;
            this.Cidade = Cidade;
            this.Estado = Estado;
            this.Saldo = Saldo;
            this.NumeroAgencia = NumeroAgencia;
        }
        public Cliente(string NomeCliente, string CPF, string Sexo, string Endereco, string Cidade, string Estado, int Saldo, int NumeroAgencia)
        {
            this.NomeCliente = NomeCliente;
            this.CPF = CPF;
            this.Sexo = Sexo;
            this.Endereco = Endereco;
            this.Cidade = Cidade;
            this.Estado = Estado;
            this.Saldo = Saldo;
            this.NumeroAgencia = NumeroAgencia;
        }

    }

    public class ClienteDTO
    {
        [Required]
        public string NomeCliente { get; set; }

        [Required]
        public string CPF { get; set; }

        [Required]
        public string Sexo { get; set; }

        [Required]
        public string Endereco { get; set; }

        [Required]
        public string Cidade { get; set; }

        [Required]
        public string Estado { get; set; }

        [Required]
        public int Saldo { get; set; }

        [Required]
        public int NumeroAgencia { get; set; }


    }
}