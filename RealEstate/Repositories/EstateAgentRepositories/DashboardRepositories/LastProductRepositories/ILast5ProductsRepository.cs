using RealEstate_API.Dtos.ProductDtos;

namespace RealEstate_API.Repositories.EstateAgentRepositories.DashboardRepositories.LastProductRepositories
{
    public interface ILast5ProductsRepository
    {
        Task<List<ResultLast5ProductWithCategoryDto>> GetResultLast5ProductWithIdAsync(int id);
    }
}
