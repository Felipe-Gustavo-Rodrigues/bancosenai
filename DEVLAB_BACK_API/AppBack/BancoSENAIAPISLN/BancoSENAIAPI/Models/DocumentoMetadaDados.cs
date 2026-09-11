using BancoSENAIAPI.DB;

namespace BancoSENAIAPI.Models
{
    public class DocumentoMetadaDados
    {
        public int ID { get; private set; }
        public string Nome { get; private set; }
        public string Extensao { get; private set; }
        public string Caminho { get; private set; }
        public int CodigoCliente { get; private set; }

        public DocumentoMetadaDados(int iD, string nome, string extensao, string caminho, int codigoCliente)
        {
            ID = iD;
            Nome = nome;
            Extensao = extensao;
            Caminho = caminho;
            CodigoCliente = codigoCliente;
        }


    }
}
