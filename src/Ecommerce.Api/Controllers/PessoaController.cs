using Ecommerce.Api.Base;
using Ecommerce.Application.DTOs.Pessoa.Requests;
using Ecommerce.Application.DTOs.Pessoa.Responses;
using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Utility;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Ecommerce.Api.Controllers
{
    public class PessoaController : ControllerV1
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
        /// <returns>Return the Pessoa created</returns>
        [HttpPost]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(AddPessoaResponseDto))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<AddPessoaResponseDto>> AddPessoa(AddPessoaRequestDto requestDto)
        {
            //requestDto.Celular = "99999999";
            //requestDto.Email = "email@email.com";
            //requestDto.Senha = "abcde";
            //requestDto.Tipo = EPessoa.Fisica;            

            AddPessoaResponseDto responseDto = await _pessoaService.AddAsync(requestDto);

            if (responseDto.GuidIsNull)
                return StatusCode(StatusCodes.Status500InternalServerError);

            return Ok(responseDto);
        }

        /// <summary>
        /// Return a Pessoa by Guid
        /// </summary>
        /// <param name="guid"></param>
        /// <returns>Return the Pessoa selected</returns>
        [HttpGet("{guid}")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(GetPessoaResponseDto))]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetPessoaResponseDto>> GetPessoa(Guid guid)
        {
            if (GuidUtility.IsNull(guid)) return NotFound();

            GetPessoaResponseDto responseDto = await _pessoaService.GetByIdAsync(guid);

            if (responseDto.GuidIsNull) return NotFound();

            return Ok(responseDto);
        }

        /// <summary>
        /// Updates a Pessoa fields
        /// </summary>
        /// <param name="requestDto"></param>
        /// <returns>Return the Pessoa modified</returns>
        [HttpPut]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(UpdatePessoaResponseDto))]
        [SwaggerResponse(StatusCodes.Status304NotModified)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UpdatePessoaResponseDto>> PutPessoa(UpdatePessoaRequestDto requestDto)
        {
            if (requestDto.GuidIsNull) return NotFound();

            UpdatePessoaResponseDto responseDto = await _pessoaService.UpdateAsync(requestDto);

            if (responseDto.GuidIsNull)
                return StatusCode(StatusCodes.Status304NotModified);

            return Ok(responseDto);
        }
    }
}
