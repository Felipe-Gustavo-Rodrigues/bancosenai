using BancoSENAIAPI.DB;
using BancoSENAIAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BancoSENAIAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        public IActionResult ListarTodas()
        {
            return Ok(Banco._cliente);
        }

        [HttpGet("{codigo}")]
        public IActionResult ConsultarPorCodigo(int codigo)
        {
            var carteira = Banco._cliente.FirstOrDefault(a => a.CodigoCLiente == codigo);

            if (carteira == null)
                return NotFound(new { message = "Agência não encontrada." }); // Status 404 [6, 7]

            return Ok(carteira); // Status 200 OK [6, 7]
        }

        [HttpPost]
        public IActionResult Cadastrar([FromBody] ClienteDTO novoCliente)
        {
            int codigoClienteNovo = Banco._cliente[Banco._cliente.Count - 1].CodigoCLiente;
            Cliente createCliente = new Cliente(codigoClienteNovo + 1, novoCliente.NomeCliente, novoCliente.CPF, novoCliente.Sexo,
                novoCliente.Endereco, novoCliente.Cidade, novoCliente.Estado, novoCliente.Saldo, novoCliente.NumeroAgencia);
            Banco._cliente.Add(createCliente);
            // Retorna Status 201 Created conforme boas práticas REST [6, 8]
            return Created("", createCliente);
        }

        [HttpPut("{codigo}")]
        public IActionResult Alterar(int codigo, [FromBody] ClienteDTO clienteAtualizar)
        {
            var clienteExiste = Banco._cliente.FirstOrDefault(a => a.CodigoCLiente == codigo);

            if (clienteExiste == null) return NotFound();

            clienteExiste.NomeCliente = clienteAtualizar.NomeCliente;
            clienteExiste.CPF = clienteAtualizar.CPF;
            clienteExiste.Sexo = clienteAtualizar.Sexo;
            clienteExiste.Endereco = clienteAtualizar.Endereco;
            clienteExiste.Cidade = clienteAtualizar.Cidade;
            clienteExiste.Estado = clienteAtualizar.Estado;
            clienteExiste.Saldo = clienteAtualizar.Saldo;
            clienteExiste.NumeroAgencia = clienteAtualizar.NumeroAgencia;

            // Retorna Status 204 No Content para atualizações bem-sucedidas [6, 9]
            return NoContent();
        }

        [HttpDelete("{codigo}")]
        public IActionResult Excluir(int codigo)
        {
            var cliente = Banco._cliente.FirstOrDefault(a => a.CodigoCLiente == codigo);

            if (cliente == null) return NotFound();

            Banco._cliente.Remove(cliente);
            return Ok(new { message = "Agência excluída com sucesso." }); // Status 200 [6]
        }
    }
}