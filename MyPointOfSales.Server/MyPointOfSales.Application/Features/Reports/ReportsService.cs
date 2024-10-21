using MyPointOfSales.Domain.Reports;

namespace MyPointOfSales.Application.Features.Reports;

public class ReportsService(IReportRepository repo)
{
    public async Task<List<Report>> GetReport()
    {
        return await repo.GetReport();
    }
}
