using Ecommerce.Application.DTOs.Pessoa.Requests;
using Ecommerce.Application.DTOs.Pessoa.Responses;
using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Shared.Enums;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Ecommerce.Api.Controllers
{
    [Consumes("application/json"), Produces("application/json")]    
    [ApiVersion("1.0")]
    [Route("api/v{v:apiVersion}/pessoa")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaService _pessoaService;

        /// <summary>
        /// Controller for "Pessoa" behavior
        /// </summary>
        /// <param name="pessoaService"></param>
        public PessoaController(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        /// <summary>
        /// Create a new Pessoa
        /// </summary>
        /// <param name="requestDto"></param>
        /// <returns></returns>
        [HttpPost]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(AddPessoaResponseDto))]
        public async Task<ActionResult<AddPessoaResponseDto>> AddPessoa(AddPessoaRequestDto requestDto)
        {
            requestDto.Celular = "99999999";
            requestDto.Email = "email@email.com";
            requestDto.Senha = "abcde";
            requestDto.Tipo = EPessoa.Fisica;            

            AddPessoaResponseDto responseDto = await _pessoaService.AddAsync(requestDto);

            return Ok(responseDto);
        }

        /// <summary>
        /// Updates a Pessoa fields
        /// </summary>
        /// <param name="requestDto"></param>
        /// <returns></returns>
        [HttpPut]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(PutPessoaResponseDto))]
        [SwaggerResponse(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<PutPessoaResponseDto>> PutPessoa(PutPessoaRequestDto requestDto)
        {
            if (requestDto.GuidIsNull)
                return NoContent();

            PutPessoaResponseDto responseDto = await _pessoaService.UpdateAsync(requestDto);
            return Ok(responseDto);
        }

        /// <summary>
        /// Return a Pessoa
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        [HttpGet("{guid}")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(GetPessoaResponseDto))]
        [SwaggerResponse(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<GetPessoaResponseDto>> GetPessoa(Guid guid)
        {            
            GetPessoaResponseDto responseDto = await _pessoaService.GetByIdAsync(guid);

            if (responseDto.GuidIsNull)
                return NoContent();
            
            return Ok(responseDto);
        }
    }
}
