using MyPointOfSales.Application.Features.Reports;
using MyPointOfSales.Domain.Reports;
using static Microsoft.AspNetCore.Http.TypedResults;

namespace MyPointOfSales.API.Features.Reports;

public static class ReportsEndpoint
{
    public static void MapReportEndpoint(this IEndpointRouteBuilder app)
    {
        var endpoints = app.MapGroup("api/pos/reports")
            .WithOpenApi()
            .WithTags("Reports")
            .RequireAuthorization();

        endpoints.MapGet("", GetReport)
            .Produces<List<Report>>();
    }

    private static async Task<IResult> GetReport(ReportsService services)
    {
        var result = await services.GetReport();
        return Ok(result);
    }
}
