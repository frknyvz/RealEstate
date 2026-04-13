using Dapper;
using RealEstate.Models.Context;
using RealEstate_API.Dtos.ProductDtos;

namespace RealEstate_API.Repositories.EstateAgentRepositories.DashboardRepositories.LastProductRepositories
{
    public class Last5ProductsRepository : ILast5ProductsRepository
    {
        private readonly Context _context;

        public Last5ProductsRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultLast5ProductWithCategoryDto>> GetResultLast5ProductWithIdAsync(int id)
        {
            string query = "Select Top(5) p.ProductID, p.Title, p.Price, p.City, p.District, c.CategoryName, p.AdvertisementDate, p.ProductCategory From Product p Inner Join Category c on c.CategoryID = p.ProductCategory Where EmployeeID=@employeeId Order By AdvertisementDate Desc";
            var parameters = new DynamicParameters();
            parameters.Add("@employeeId", id);

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultLast5ProductWithCategoryDto>(query, parameters);
                return values.ToList();
            }
        }
    }
}
