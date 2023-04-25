using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaRepository _pessoaRepository;

        public PessoaController(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddPessoa()
        {            
            var pessoa = new Pessoa(Guid.NewGuid(), "99999999", "email@email.com", "abcde", "Fisica");
            await _pessoaRepository.AddAsync(pessoa);
            return Ok(pessoa);
        }
    }
}
