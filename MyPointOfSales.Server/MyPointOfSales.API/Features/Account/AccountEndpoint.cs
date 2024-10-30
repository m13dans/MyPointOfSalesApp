using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using static Microsoft.AspNetCore.Http.TypedResults;
using MyPointOfSales.Application.Features.Account;
using MyPointOfSales.Application.Features.Items;

namespace MyPointOfSales.API.Features.Account;

public static class AccountEndpoint
{
    public static void MapAccountEndpoint(this IEndpointRouteBuilder app)
    {
        var endpoints = app.MapGroup("api/accounts").WithOpenApi().WithTags("Accounts");

        endpoints.MapPost("/register", Register)
            .ProducesValidationProblem()
            .Produces(statusCode: StatusCodes.Status201Created);

        endpoints.MapPost("/login", Login)
            .ProducesValidationProblem()
            .Produces<LoginUserResponse>();

        endpoints.MapPost("logout", Logout);
    }

    private static async Task<IResult> Register(
        UserService services,
        RegisterUserRequest command,
        IValidator<RegisterUserRequest> validator)
    {
        var validationResult = await validator.ValidateAsync(command);
        if (!validationResult.IsValid)
            return ValidationProblem(validationResult.ToDictionary());

        var result = await services.RegisterUser(command);

        return result.Match<IResult>(
            value => Ok("Account Created"),
            error => ValidationProblem(error.ToDictionary(x => x.Code,
              y => error.Select(x => x.Description).ToArray())));
    }

    private static async Task<IResult> Login(
        UserService services,
        LoginUserRequest command,
        IValidator<LoginUserRequest> validator)
    {
        var validationResult = await validator.ValidateAsync(command);
        if (!validationResult.IsValid)
            return ValidationProblem(validationResult.ToDictionary());

        var result = await services.LoginUser(command);

        return result.Match<IResult>(
            Ok,
            error => ValidationProblem(error.ToDictionary(x => x.Code,
              _ => error.Select(x => x.Description).ToArray())));

    }
    public static Task<IResult> Logout()
    {
        throw new NotImplementedException();
    }

}
