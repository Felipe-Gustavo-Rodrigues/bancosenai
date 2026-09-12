using BancoSENAIAPI.DB;
using BancoSENAIAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BancoSENAIAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class DocumentController : Controller
    {
        private readonly string _caminhoRaiz = Path.Combine(Directory.GetCurrentDirectory(), "ClienteArquivo");

        private static int _nextId = 1;

        [HttpPost("upload/{codigoCliente}")]
        public async Task<IActionResult> PostArquivo(int codigoCliente, IFormFile arquivo)
        {
            if(arquivo == null || arquivo.Length == 0) return BadRequest("Nenhum arquivo encontrado");

            string pastaCliente = Path.Combine(_caminhoRaiz, codigoCliente.ToString());

            if (!Directory.Exists(pastaCliente))
            {
                Directory.CreateDirectory(pastaCliente);
            }

            if(!Banco._document.Any(e=> e.CodigoCliente == codigoCliente))
            {
                return BadRequest("Nenhum cliente encontrado");
            }
            string extensao = Path.GetExtension(arquivo.FileName);
            string nomeOriginal = Path.GetFileNameWithoutExtension(arquivo.FileName);
            string novoNome = $"{codigoCliente}_{nomeOriginal}_{Guid.NewGuid()}{extensao}";
            string caminhoFinal = Path.Combine(pastaCliente, novoNome);

            using (var stream = new FileStream(caminhoFinal, FileMode.Create))
            {
                await arquivo.CopyToAsync(stream);
            }

            var documentoNovo = new DocumentoMetadaDados(_nextId++, nomeOriginal, extensao, caminhoFinal, codigoCliente);

            Banco._document.Add(documentoNovo);

            return Ok(new {mensagem = "Documento criado com suscesso"});;
        }

        [HttpGet("listagem/{codigoCliente}")]
        public async Task<IActionResult> ListarDocumentos([FromRoute]int codigoCliente)
        {
            var documentos = Banco._document.Where(d => d.CodigoCliente == codigoCliente).ToList();
            return Ok(documentos);
        }
    }
}
