using RealEstate.Dtos.ProductDtos;
using RealEstate_API.Dtos.ProductDtos;

namespace RealEstate.Repositories.ProductRepository
{
    public interface IProductRepository
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync();
        //void CreateProduct(CreateProductDto productDto);
        //void DeleteProduct(int id);
        //void UpdateProduct(UpdateProductDto productDto);
        //Task<GetByIdProductDto> GetProduct(int id);
    }
}
