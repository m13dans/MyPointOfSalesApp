using ErrorOr;
using Microsoft.AspNetCore.Http.HttpResults;
using static Microsoft.AspNetCore.Http.TypedResults;

namespace MyPointOfSales.API.Features.Shared;

public static class HttpResultHelper
{
    public static ProblemHttpResult ProblemBasedOnError(Error error)
    {
        var substringIndex = error.Code.IndexOf('.') + 1;
        var code = error.Code[substringIndex..];

        return code switch
        {
            "NotFound" => Problem(error.Description, statusCode: 404),
            "Validation" => Problem(error.Description, statusCode: 400),
            "BadRequest" => Problem(error.Description, statusCode: 400),
            _ => Problem(statusCode: 500)
        };
    }
}