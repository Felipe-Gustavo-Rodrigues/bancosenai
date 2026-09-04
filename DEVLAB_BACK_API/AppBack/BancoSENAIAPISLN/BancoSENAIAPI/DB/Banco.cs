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
    }
}
