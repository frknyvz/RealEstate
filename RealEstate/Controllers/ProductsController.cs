using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Dtos.CategoryDtos;
using RealEstate.Repositories.ProductRepository;

namespace RealEstate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            var values = await _productRepository.GetAllProductAsync();
            return Ok(values);
        }

        [HttpGet("ProductListWithCategory")]
        public async Task<IActionResult> ProductListWithCategory()
        {
            var values = await _productRepository.GetAllProductWithCategoryAsync();
            return Ok(values);
        }
        [HttpGet("ProductDealOfTheDayStatusChangeToTrue/{id}")]
        public async Task<IActionResult> ProductDealOfTheDayStatusChangeToTrue(int id)
        {
            _productRepository.ProductDealOfTheDayStatusChangeToTrue(id);
            return Ok("İlan Durumu Başarıyla Güncellendi");
        }

        [HttpGet("ProductDealOfTheDayStatusChangeToFalse/{id}")]
        public async Task<IActionResult> ProductDealOfTheDayStatusChangeToFalse(int id)
        {
            _productRepository.ProductDealOfTheDayStatusChangeToFalse(id);
            return Ok("İlan Durumu Başarıyla Güncellendi");
        }

        [HttpGet("Last5ProductList")]
        public async Task<IActionResult> Last5ProductList()
        {
            var values = await _productRepository.GetLast5ProductAsync();
            return Ok(values);
        }

        //[HttpPost]
        //public async Task<IActionResult> CreateCategory(CreateProductDto createCategoryDto)
        //{
        //    _categoryRepository.CreateCategory(createCategoryDto);
        //    return Ok("Kategori Eklemesi Yapıldı.");
        //}
        //[HttpDelete]
        //public async Task<IActionResult> DeleteCategory(int id)
        //{
        //    _categoryRepository.DeleteCategory(id);
        //    return Ok("Kategori Başarıyla Silindi");
        //}
        //[HttpPut]
        //public async Task<IActionResult> UpdateCategory(UpdateProductDto updateCategoryDto)
        //{
        //    _categoryRepository.UpdateCategory(updateCategoryDto);
        //    return Ok("Kategori Başarıyla Güncellendi");
        //}
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetCategory(int id)
        //{
        //    var value = await _categoryRepository.GetCategory(id);
        //    return Ok(value);
        //}
    }
}
