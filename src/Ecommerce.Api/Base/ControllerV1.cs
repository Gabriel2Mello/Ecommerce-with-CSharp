using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Base
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("api/v{v:apiVersion}/[controller]")]
    [ApiController]
    public abstract class ControllerV1 : ControllerBase
    {
    }
}
