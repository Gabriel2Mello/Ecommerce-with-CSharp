using Ecommerce.Api.Base;
using Ecommerce.Application.DTOs.Cliente.Requests;
using Ecommerce.Application.DTOs.Cliente.Responses;
using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Utility;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Ecommerce.Api.Controllers
{
    public class ClienteController : ControllerV1
    {
        private readonly IClienteService _clienteService;

        /// <summary>
        /// Controller for "Cliente" behavior
        /// </summary>
        /// <param name="clienteService"></param>
        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        /// <summary>
        /// Create a new Cliente
        /// </summary>
        /// <param name="requestDto"></param>
        /// <returns>Return the Cliente created</returns>
        [HttpPost]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(AddClienteResponseDto))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<AddClienteResponseDto>> AddCliente(AddClienteRequestDto requestDto)
        {
            AddClienteResponseDto responseDto = await _clienteService.AddAsync(requestDto);

            if (responseDto.GuidIsNull)
                return StatusCode(StatusCodes.Status500InternalServerError);

            return Ok(responseDto);
        }

        /// <summary>
        /// Return a Cliente by Guid
        /// </summary>
        /// <param name="guid"></param>
        /// <returns>Return a Cliente selected</returns>
        [HttpGet("{guid}")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(GetClienteResponseDto))]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetClienteResponseDto>> GetCliente(Guid guid)
        {
            if (GuidUtility.IsNull(guid)) return NotFound();

            GetClienteResponseDto responseDto = await _clienteService.GetByIdAsync(guid);

            if (responseDto.GuidIsNull) return NotFound();

            return Ok(responseDto);
        }

        /// <summary>
        /// Updates a Cliente fields
        /// </summary>
        /// <param name="requestDto"></param>
        /// <returns>Return the Cliente modified</returns>
        [HttpPut]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(UpdateClienteResponseDto))]
        [SwaggerResponse(StatusCodes.Status304NotModified)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UpdateClienteResponseDto>> UpdateCliente(UpdateClienteRequestDto requestDto)
        {
            if (requestDto.GuidIsNull) return NotFound();

            UpdateClienteResponseDto responseDto = await _clienteService.UpdateAsync(requestDto);

            if (responseDto.GuidIsNull)
                return StatusCode(StatusCodes.Status304NotModified);

            return Ok(responseDto);
        }

        /// <summary>
        /// Delete a Cliente by Guid
        /// </summary>
        /// <param name="guid"></param>
        /// <returns>Return 204 status code if success</returns>
        [HttpDelete("{guid}")]
        [SwaggerResponse(StatusCodes.Status204NoContent)]
        [SwaggerResponse(StatusCodes.Status304NotModified)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCliente(Guid guid)
        {
            if (GuidUtility.IsNull(guid)) return NotFound();

            int changes = await _clienteService.DeleteAsync(guid);

            if (changes == 0)
                return StatusCode(StatusCodes.Status304NotModified);
            
            return NoContent();
        }
    }
}
