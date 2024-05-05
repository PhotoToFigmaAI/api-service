using Microsoft.AspNetCore.Mvc;

namespace api_service.Controllers;

[ApiController]
public class BaseController : ControllerBase
{
    protected string AuthHeader => HttpContext.Request.Headers["Authorizations"].ToString();
}
