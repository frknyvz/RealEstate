using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_API.Repositories.EstateAgentRepositories.DashboardRepositories.LastProductRepositories;

namespace RealEstate_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstateAgentLast5ProductsController : ControllerBase
    {
        private readonly ILast5ProductsRepository _last5ProductsRepository;

        public EstateAgentLast5ProductsController(ILast5ProductsRepository last5ProductsRepository)
        {
            _last5ProductsRepository = last5ProductsRepository;
        }

        [HttpGet("EstateAgentLast5ProductList")]
        public async Task<IActionResult> EstateAgentLast5ProductList(int id)
        {
            var values = await _last5ProductsRepository.GetResultLast5ProductWithIdAsync(id);
            return Ok(values);
        }
    }
}
