using ErrorOr;

using FluentValidation.Results;

namespace GigaChat.Core.Common.Extensions;

public static class ValidationResultExtensions
{
    public static List<Error> ToCoreErrors(this ValidationResult validationResult)
    {
        return validationResult.Errors
            .Select(e => Error.Validation(e.PropertyName, e.ErrorMessage))
            .ToList();
    }
}