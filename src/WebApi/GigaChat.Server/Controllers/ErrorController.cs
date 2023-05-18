using GigaChat.Contracts.Common.Routes;
using GigaChat.Server.Controllers.Common;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GigaChat.Server.Controllers;

[Route(ServerRoutes.Controllers.ErrorController)]
public class ErrorController : ApiController
{
    [HttpGet]
    [AllowAnonymous]
    public ActionResult Error()
    {
        return Problem();
    }
}