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
            double tamanhoMax = 2 * 1024 * 1024;
            if(arquivo == null || arquivo.Length == 0) return BadRequest("Nenhum arquivo encontrado");

            if(arquivo.Length > tamanhoMax)
            {
                return BadRequest($"Tamanho do arquivo passou de 2MB, então não pode ser enviado");
            }
            string pastaCliente = Path.Combine(_caminhoRaiz, codigoCliente.ToString());

            if (!Directory.Exists(pastaCliente)) 
            {
                Directory.CreateDirectory(pastaCliente);
            }

            if(!Banco._cliente.Any(e=> e.CodigoCLiente == codigoCliente))
            {
                return BadRequest("Nenhum cliente encontrado");
            }
            string extensao = Path.GetExtension(arquivo.FileName);
            if(extensao!= ".png" && extensao != ".jpg" && extensao != ".pdf")
            {
                return BadRequest("Somente pode ser enviados arquivos do tipo");
            }
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
            if(!Banco._document.Any(e => e.CodigoCliente == codigoCliente))
            {
                return NotFound("Nenhum cliente encontrado");
            }
            var documentos = Banco._document.Where(d => d.CodigoCliente == codigoCliente).ToList();
            return Ok(documentos);
        }

        [HttpGet("cliente/{codigoCliente}/dowload/{id}")]
        public async Task<IActionResult> DowloadArquivo([FromRoute] int id, [FromRoute] int codigoCliente)
        {
            if (!Banco._document.Any(e => e.ID == id))
            {
                return NotFound("Nenhum arquivo encontrado");
            }

            var documento = Banco._document.FirstOrDefault(e=> e.ID == id);
            if(documento.CodigoCliente != codigoCliente)
            {
                return BadRequest("Você não pode ver esse arquivo");
            }
           
            var fileByts = await System.IO.File.ReadAllBytesAsync(documento.Caminho);//Lista de bytes que forma  imagem

            return File(fileByts, "aplication/octet-stream", documento.Nome);
        }

        [HttpDelete("cliente/{codigoCliente}/excluir/{id}")]
        public async Task<IActionResult> DeleteDocument([FromRoute] int id, [FromRoute] int codigoCliente)
        {
            if (!Banco._document.Any(e => e.ID == id))
            {
                return NotFound("Nenhum arquivo encontrado");
            }

            var documento = Banco._document.FirstOrDefault(e => e.ID == id);
            if (documento.CodigoCliente != codigoCliente)
            {
                return BadRequest("Você não pode ver esse arquivo");
            }

            Banco._document.Remove(documento);
            System.IO.File.Delete(documento.Caminho);

            return NoContent();
        }
    }
}
