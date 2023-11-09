using Dapper;
using RealEstate.Dtos.CategoryDtos;
using RealEstate.Dtos.ProductDtos;
using RealEstate.Models.Context;
using RealEstate_API.Dtos.CategoryDtos;
using RealEstate_API.Dtos.ProductDtos;

namespace RealEstate.Repositories.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly Context _context;

        public ProductRepository(Context context)
        {
            _context = context;
        }

        public void CreateProduct(CreateProductDto productDto)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            string query = "Select * From Product";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync()
        {
            string query = "Select ProductID, Title, Price, City, District, CategoryName From Product Inner Join Category On Product.ProductCategory=Category.CategoryID";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithCategoryDto>(query);
                return values.ToList();
            }
        }

        public Task<GetByIdProductDto> GetProduct(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(UpdateProductDto productDto)
        {
            throw new NotImplementedException();
        }

        //public async void CreateCategory(CreateProductDto categoryDto)
        //{
        //    string query = "Insert into Category (CategoryName,CategoryStatus) Values(@categoryName,@categoryStatus)";
        //    var parameters = new DynamicParameters();
        //    parameters.Add("@categoryName", categoryDto.CategoryName);
        //    parameters.Add("@categoryStatus", true);

        //    using (var connection = _context.CreateConnection())
        //    {
        //        await connection.ExecuteAsync(query, parameters);
        //    }
        //}

        //public async void DeleteCategory(int id)
        //{
        //    string query = "Delete From Category Where CategoryID=@categoryID";
        //    var parameters = new DynamicParameters();
        //    parameters.Add("@categoryID", id);
        //    using (var connection = _context.CreateConnection())
        //    {
        //        await connection.ExecuteAsync(query, parameters);
        //    }
        //}

        //public async Task<List<ResultProductDto>> GetAllCategoryAsync()
        //{
        //    string query = "Select * From Category";
        //    using (var connection = _context.CreateConnection())
        //    {
        //        var values = await connection.QueryAsync<ResultProductDto>(query);
        //        return values.ToList();
        //    }
        //}

        //public async Task<GetByIdProductDto> GetCategory(int id)
        //{
        //    string query = "Select * From Category Where CategoryID = @categoryID";
        //    var parameters = new DynamicParameters();
        //    parameters.Add("@categoryID", id);
        //    using (var connection = _context.CreateConnection())
        //    {
        //        var values = await connection.QueryFirstOrDefaultAsync<GetByIdProductDto>(query, parameters);
        //        return values;
        //    }

        //}

        //public async void UpdateCategory(UpdateProductDto categoryDto)
        //{
        //    string query = "Update Category Set CategoryName = @categoryName, CategoryStatus=@categoryStatus Where CategoryID = @categoryID";
        //    var parameters = new DynamicParameters();
        //    parameters.Add("@categoryID", categoryDto.CategoryID);
        //    parameters.Add("@categoryName", categoryDto.CategoryName);
        //    parameters.Add("@categoryStatus", categoryDto.CategoryStatus);
        //    using (var connection = _context.CreateConnection())
        //    {
        //        await connection.ExecuteAsync(query, parameters);
        //    }

        //}
    }
}
