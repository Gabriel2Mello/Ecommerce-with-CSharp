using Ecommerce.Infra.Context;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers
{
    public class ClienteController : ControllerBase
    {
        readonly EcommerceContext _context;

        public ClienteController()
        {
            var alala = _context.Clientes.FirstOrDefault();
        }

        [HttpGet("Get")]
        public ActionResult Get()
        {
            var tasldjas = _context.Clientes.FirstOrDefault();
            return Ok();
        }
    }
}
