using Dapper;
using RealEstate.Models.Context;
using RealEstate_API.Dtos.ChartDtos;

namespace RealEstate_API.Repositories.EstateAgentRepositories.DashboardRepositories.ChartRepositories
{
    public class ChartRepository : IChartRepository
    {
        private readonly Context _context;

        public ChartRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultChartDto>> Get5CityForChart()
        {
            string query = "Select Top(5) City, Count(*) as 'CityCount' From Product Group By City Order By CityCount Desc";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultChartDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultChartDto2>> GetAvgPriceForSaleChart()
        {
            string query = "Select AVG(Price) as 'AvgPrice', City From Product Where EmployeeID=1 And Type='Satılık' Group By City Order By 'AvgPrice' Desc";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultChartDto2>(query);
                return values.ToList();
            }
        }
    }
}

