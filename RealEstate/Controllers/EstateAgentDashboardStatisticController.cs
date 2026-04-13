using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_API.Repositories.EstateAgentRepositories.DashboardRepositories.StatisticRepositories;

namespace RealEstate_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstateAgentDashboardStatisticController : ControllerBase
    {
        private readonly IStatisticRepository _statisticRepository;

        public EstateAgentDashboardStatisticController(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }

        [HttpGet("AllProductCount")]
        public IActionResult AllProductCount()
        {
            return Ok(_statisticRepository.AllProductCount());
        }

        [HttpGet("ProductCountByEmployeeId")]
        public IActionResult ProductCountByEmployeeId(int id)
        {
            return Ok(_statisticRepository.ProductCountByEmployeeId(id));
        }

        [HttpGet("ProductCountByStatusFalse")]
        public IActionResult ProductCountByStatusFalse(int id)
        {
            return Ok(_statisticRepository.ProductCountByStatusFalse(id));
        }

        [HttpGet("ProductCountByStatusTrue")]
        public IActionResult ProductCountByStatusTrue(int id)
        {
            return Ok(_statisticRepository.ProductCountByStatusTrue(id));
        }
    }
}
