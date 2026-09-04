using BancoSENAIAPI.DB;
using BancoSENAIAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BancoSENAIAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CarteiraController:ControllerBase
    {
        [HttpGet]
        public IActionResult ListarTodas()
        {
            return Ok(Banco._carteira);
        }

        [HttpPost]
        public IActionResult Cadastrar([FromBody] Carteira novaCarteira)
        {

            if (Banco._carteira.Any(a => a.NumeroCarteira == novaCarteira.NumeroCarteira))
                return BadRequest(new { message = "Este número de agência já existe." });

            if(string.IsNullOrWhiteSpace(novaCarteira.NomeCarteira))
            {
                return BadRequest(new { message = "O nome da carteira não pode ser vazio." });
            }

            if (novaCarteira.ApetiteCarteira == 0)
            {
                novaCarteira.ApetiteCarteira = 10000; // Define o valor padrão de ApetiteCarteira como 10000
            }

            Banco._carteira.Add(novaCarteira);
            // Retorna Status 201 Created conforme boas práticas REST [6, 8]
            return Created("", novaCarteira);
        }

        [HttpGet("{codigo}")]
        public IActionResult ConsultarPorCodigo(int codigo)
        {
            var carteira = Banco._carteira.FirstOrDefault(a => a.NumeroCarteira == codigo);

            if (carteira == null)
                return NotFound(new { message = "Agência não encontrada." }); // Status 404 [6, 7]

            return Ok(carteira); // Status 200 OK [6, 7]
        }

        [HttpPut("{codigo}")]
        public IActionResult Alterar(int codigo, [FromBody] CarteiraDTO carteiraAtualizada)
        {
            var carteiraExistente = Banco._carteira.FirstOrDefault(a => a.NumeroCarteira == codigo);

            if (carteiraExistente == null) return NotFound();

            carteiraExistente.ApetiteCarteira = carteiraAtualizada.ApetiteCarteira;
            carteiraExistente.NomeCarteira = carteiraAtualizada.NomeCarteira;

            // Retorna Status 204 No Content para atualizações bem-sucedidas [6, 9]
            return NoContent();
        }

        [HttpDelete("{codigo}")]
        public IActionResult Excluir(int codigo)
        {
            var carteira = Banco._carteira.FirstOrDefault(a => a.NumeroCarteira == codigo);

            if (carteira == null) return NotFound();

            Banco._carteira.Remove(carteira);
            return Ok(new { message = "Agência excluída com sucesso." }); // Status 200 [6]
        }
    }
}
