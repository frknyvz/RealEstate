using RealEstate.Dtos.CategoryDtos;
using RealEstate_API.Dtos.CategoryDtos;

namespace RealEstate.Repositories.CategoryRepository
{
    public interface ICategoryRepository
    {
        Task<List<ResultCategoryDto>> GetAllCategoryAsync();
        void CreateCategory(CreateCategoryDto categoryDto);
        void DeleteCategory(int id);
        void UpdateCategory(UpdateCategoryDto categoryDto);
        Task<GetByIdCategoryDto> GetCategory(int id);
    }
}
