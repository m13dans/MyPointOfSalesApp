using ErrorOr;
using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MyPointOfSales.Application.Features.Items;
using MyPointOfSales.Domain.Items;
using static Microsoft.AspNetCore.Http.TypedResults;

namespace MyPointOfSales.API.Features.Items;

public static class ItemEndpoint
{
    public static void MapItemEndpoint(this IEndpointRouteBuilder app)
    {
        var endpoints = app.MapGroup("api/items").WithOpenApi().WithTags("Items").RequireAuthorization();

        endpoints.MapGet("", GetItems)
            .Produces<List<Item>>();

        endpoints.MapGet("{id:int}", GetItemById)
            .ProducesProblem(404)
            .Produces<Item>();

        endpoints.MapPost("", PostItems)
            .DisableAntiforgery()
            .ProducesProblem(400)
            .Produces<Item>(statusCode: StatusCodes.Status201Created);

        endpoints.MapPut("/{id:int}", UpdateItem)
            .DisableAntiforgery()
            .ProducesProblem(400)
            .Produces<Item>();

        endpoints.MapDelete("/{id:int}", DeleteItem)
            .ProducesProblem(400)
            .Produces<Item>();
    }

    private static async Task<IResult> GetItems(ItemServices services)
    {
        var result = await services.GetItems();
        return Ok(result);
    }
    private static async Task<IResult> GetItemById(ItemServices services, int id)
    {
        var result = await services.GetItemById(id);

        if (result.IsError)
            return ProblemBasedOnError(result.FirstError);

        return Ok(result.Value);
    }

    private static async Task<IResult> PostItems(
        ItemServices services,
        IImageService imageService,
        [FromForm] CreateItemRequest request,
        IValidator<CreateItemRequest> validator)
    {
        var validationResult = await validator.ValidateAsync(request);
        if (!validationResult.IsValid)
            return ValidationProblem(validationResult.ToDictionary());

        var result = await services.CreateItem(imageService, request);

        return result.MatchFirst<IResult>(
            onValue: value => Created($"/api/items/{value.Id}", value: value),
            onFirstError: ProblemBasedOnError);
    }

    private static async Task<IResult> UpdateItem(
        ItemServices services,
        IImageService imageService,
        [FromForm] UpdateItemRequest request,
        [FromRoute] int id,
        IValidator<UpdateItemRequest> validator)
    {
        var validationResult = await validator.ValidateAsync(request);
        if (!validationResult.IsValid)
            return ValidationProblem(validationResult.ToDictionary());

        var result = await services.UpdateItem(request, imageService);

        return result.MatchFirst<IResult>(
            onValue: Ok,
            onFirstError: ProblemBasedOnError);
    }



    private static async Task<IResult> DeleteItem(ItemServices services, int id)
    {
        var result = await services.DeleteItem(id);

        return result.MatchFirst<IResult>(
            onValue: Ok,
            onFirstError: ProblemBasedOnError);
    }

    private static ProblemHttpResult ProblemBasedOnError(Error error) => error.Code switch
    {
        "Item.NotFound" => Problem(error.Description, statusCode: 404),
        "Item.Validation" => Problem(error.Description, statusCode: 400),
        "Item.BadRequest" => Problem(error.Description, statusCode: 400),
        _ => Problem(statusCode: 500)
    };
}
