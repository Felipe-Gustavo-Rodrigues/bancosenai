
using System.ComponentModel.DataAnnotations;

namespace BancoSENAIAPI.Models
{
    public class DocumentoMetadaDados
    {
        [Key]
        public int ID { get; private set; }

        [Required]
        public string Nome { get; private set; }

        [Required]
        public string Extensao { get; private set; }

        [Required]
        public string Caminho { get; private set; }

        [Required]
        public int CodigoCliente { get; private set; }

        public DocumentoMetadaDados(int iD, string nome, string extensao, string caminho, int codigoCliente)
        {
            ID = iD;
            Nome = nome;
            Extensao = extensao;
            Caminho = caminho;
            CodigoCliente = codigoCliente;
        }

        public DocumentoMetadaDados(string nome, string extensao, string caminho, int codigoCliente)
        {
            Nome = nome;
            Extensao = extensao;
            Caminho = caminho;
            CodigoCliente = codigoCliente;
        }


    }
}
