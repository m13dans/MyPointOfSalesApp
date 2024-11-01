using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using MyPointOfSales.API.Features.Shared;
using MyPointOfSales.Application.Features.Transactions;
using MyPointOfSales.Domain.Transactions;
using static Microsoft.AspNetCore.Http.TypedResults;
using static MyPointOfSales.API.Features.Shared.HttpResultHelper;

namespace MyPointOfSales.API.Features.Transactions;

public static class TransactionEndpoint
{
    public static void MapTransactionEndpoint(this IEndpointRouteBuilder app)
    {
        var endpoints = app.MapGroup("api/pos/transactions")
            .WithOpenApi()
            .WithTags("Transaction");
        // .RequireAuthorization();

        endpoints.MapGet("", GetTransaction)
            .Produces<List<Transaction>>();

        endpoints.MapPost("", PostTransaction)
            .DisableAntiforgery()
            .ProducesProblem(400)
            .Produces<Transaction>();
    }

    private static async Task<IResult> GetTransaction(TransactionService services)
    {
        var result = await services.GetTransaction();
        return Ok(result);
    }
    private static async Task<IResult> PostTransaction(
        TransactionService services,
        PostTransactionRequest request,
        IValidator<PostTransactionRequest> validator)
    {
        var validationResult = await validator.ValidateAsync(request);
        if (!validationResult.IsValid)
            return ValidationProblem(validationResult.ToDictionary());

        var result = await services.PostTransaction(request);

        return result.MatchFirst<IResult>(
            Ok,
            ProblemBasedOnError);
    }
}
