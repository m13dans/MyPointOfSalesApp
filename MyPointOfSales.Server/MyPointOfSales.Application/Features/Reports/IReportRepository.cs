using MyPointOfSales.Domain.Reports;

namespace MyPointOfSales.Application.Features.Reports;

public interface IReportRepository
{
    public Task<List<Report>> GetReport();
}