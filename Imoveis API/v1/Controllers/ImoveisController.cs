using GerenciamentoComercio_Domain.Utils.APIMessage;
using Imoveis_Dominio.v1.Dto_s;
using Imoveis_Dominio.v1.Dto_s.Imoveis;
using Imoveis_Dominio.v1.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Imoveis_API.v1.Controllers
{
    [ApiVersion("1.0", Deprecated = false)]
    [Route("v{version:apiVersion}/imoveis/")]
    [ApiController]
    public class ImoveisController : ControllerBase
    {
        private readonly IImoveisServico _imoveisServico;

        public ImoveisController(IImoveisServico imoveisServico)
        {
            _imoveisServico = imoveisServico;
        }
        [SwaggerOperation("Buscar informações do referente ao cep")]
        [SwaggerResponse(StatusCodes.Status200OK, "", typeof(ChamadaAPIRequest))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Cep não encontrado.", typeof(string))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "O valor deve conter apenas digitos e 8 caracteres.", typeof(string))]
        [HttpGet("chamada-api")]
        public async Task<IActionResult> BuscarImoveisAPI(string cep)
        {
            if (!cep.All(char.IsDigit) || cep.Length != 8) return BadRequest("O valor deve conter apenas digitos e 8 caracteres.");

            APIMessage imoveis = await _imoveisServico.BuscarImoveisAPI(cep);

            return StatusCode((int)imoveis.StatusCode, imoveis.ContentObj);
        }

        [SwaggerOperation("Lista todos os imoveis no banco")]
        [SwaggerResponse(StatusCodes.Status200OK, "", typeof(IList<ImoveisResponse>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Nenhum imóvel foi encontrado.", typeof(string))]
        [HttpGet]
        public async Task<IActionResult> BuscarImoveis()
        {
            APIMessage imoveis = await _imoveisServico.BuscarImoveis();

            return StatusCode((int)imoveis.StatusCode, imoveis.ContentObj);
        }

        [SwaggerOperation("Lista imoveis no banco por id")]
        [SwaggerResponse(StatusCodes.Status200OK, "", typeof(ImovelPorIdResponse))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Imovel não encontrado.", typeof(string))]
        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarImovelPorId(int id)
        {
            APIMessage imovel = await _imoveisServico.BuscarImovelPorId(id);

            return StatusCode((int)imovel.StatusCode, imovel.ContentObj);
        }

        [SwaggerOperation("Adcionar imoveis no banco")]
        [SwaggerResponse(StatusCodes.Status200OK, "Imovel cadastrado com sucesso.", typeof(string))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "O valor deve ser maior que 0.", typeof(string))]
        [HttpPost]
        public async Task<IActionResult> AdicionarImovel(ImoveisRequest request)
        {
            APIMessage novoImovel = await _imoveisServico.AdicionarImovel(request);

            return StatusCode((int)novoImovel.StatusCode, novoImovel.ContentObj);
        }

        [SwaggerOperation("Atualizar imoveis cadastrados no banco por id")]
        [SwaggerResponse(StatusCodes.Status200OK, "Imovel atualizado com sucesso.", typeof(string))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Imovel não encontrado.", typeof(string))]
        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarImovel(int id, ImoveisRequest request)
        {
            APIMessage atualizar = await _imoveisServico.AtualizarImovel(request, id);

            return StatusCode((int)atualizar.StatusCode, atualizar.ContentObj);
        }

        [SwaggerOperation("Deletar imoveis no banco por id")]
        [SwaggerResponse(StatusCodes.Status200OK, "Imovel removido com sucesso.", typeof(string))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Imovel não encontrado.", typeof(string))]
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoverImovel(int id)
        {
            APIMessage remover = await _imoveisServico.RemoverImovel(id);

            return StatusCode((int)remover.StatusCode, remover.ContentObj);
        }
    }
}
