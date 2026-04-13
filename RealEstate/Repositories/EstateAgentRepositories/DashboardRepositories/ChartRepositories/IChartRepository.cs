using RealEstate_API.Dtos.ChartDtos;

namespace RealEstate_API.Repositories.EstateAgentRepositories.DashboardRepositories.ChartRepositories
{
    public interface IChartRepository
    {
        Task<List<ResultChartDto>> Get5CityForChart();

        Task<List<ResultChartDto2>> GetAvgPriceForSaleChart();
    }
}
