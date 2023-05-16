using ErrorOr;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GigaChat.Server.Controllers.Common;

[ApiController]
[Authorize]
public abstract class ApiController : ControllerBase
{
    protected ActionResult Problem(IList<Error> errors)
    {
        if (errors.Count is 0) return Problem();
        return errors.All(e => e.Type == ErrorType.Validation) 
            ? ValidationProblem(errors)
            : Problem(errors[0]);
    }
    
    private ActionResult ValidationProblem(IList<Error> errors)
    {
        foreach (var error in errors)
        {
            ModelState.AddModelError(error.Code, error.Description);
        }
        return ValidationProblem(ModelState);
    }
    
    protected ActionResult Problem(Error error)
    {
        if (ErrorType.Validation == error.Type) return ValidationProblem(new[] { error });

        var statusCode = error.Type switch
        {
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            _ => 500
        };

        return Problem(title: error.Description, statusCode: statusCode);
    }
}