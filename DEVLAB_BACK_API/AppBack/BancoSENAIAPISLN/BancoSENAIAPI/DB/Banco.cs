using BancoSENAIAPI.Models;

namespace BancoSENAIAPI.DB
{
    public class Banco
    {
        public static List<Carteira> _carteira = new List<Carteira>
        {
            new Carteira ( 101, "Agro", 10000 ),
            new Carteira ( 102, "Tech", 10000 ),
            new Carteira ( 103, "Pop", 10000 ),
        };

        public static List<Agencia> _agencias = new List<Agencia>
        {
            new Agencia { NumeroAgencia = 1001, Cidade = "Aracaju", SiglaEstado = "SE" },
            new Agencia { NumeroAgencia = 2002, Cidade = "São Paulo", SiglaEstado = "SP" },
            new Agencia { NumeroAgencia = 3003, Cidade = "Salvador", SiglaEstado = "BA" }
        };


        public static List<Cliente> _cliente = new List<Cliente>
        {
            new Cliente(1,"Felipe", "00900900900", "M", "Rua A", "Aracaju", "SE", 1000, 1001),
            new Cliente(2, "Caio", "00800800800", "M", "Rua B", "Aracaju", "SE", 1000, 2002),
            new Cliente(3, "Paulo", "00700700700", "M", "Rua C", "Aracaju", "SE", 1000, 3003)
        };

        public static List<DocumentoMetadaDados> _document = new List<DocumentoMetadaDados>
        {
            new DocumentoMetadaDados(1,"Imagem de Carros", ".png", "/Arquivos/dados.png", 101),
            new DocumentoMetadaDados(2, "Imagem de Barcos", ".png", "/Arquivos/dados.png", 101),
            new DocumentoMetadaDados(3, "Imagem de Nada", ".png", "/Arquivos/dados.png", 102)
        };
    }
}
