using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_API.Repositories.EstateAgentRepositories.DashboardRepositories.ChartRepositories;

namespace RealEstate_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstateAgentChartController : ControllerBase
    {
        private readonly IChartRepository _chartRepository;

        public EstateAgentChartController(IChartRepository chartRepository)
        {
            _chartRepository = chartRepository;
        }

        [HttpGet("Get5CityForChart")]
        public async Task<IActionResult> Get5CityForChart()
        {
            return Ok(await _chartRepository.Get5CityForChart());
        }

        [HttpGet("GetAvgPriceForSaleChart")]
        public async Task<IActionResult> GetAvgPriceForSaleChart()
        {
            return Ok(await _chartRepository.GetAvgPriceForSaleChart());
        }
    }
}
