using Dapper;
using RealEstate.Models.Context;
using RealEstate_API.Dtos.EmployeeDtos;

namespace RealEstate_API.Repositories.StatisticRepositories
{
    public class StatisticRepository : IStatisticRepository
    {
        private readonly Context _context;

        public StatisticRepository(Context context)
        {
            _context = context;
        }

        public int ActiveCategoryCount()
        {
            string query = "Select Count(*) From Category Where CategoryStatus = 1";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public int ActiveEmployeeCount()
        {
            string query = "Select Count(*) From Employee Where Status = 1";
            using (var connections = _context.CreateConnection())
            {
                var values = connections.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public int ApartmentCount()
        {
            string query = "Select Count(*) From Product Where ProductCategory=1";
            using (var connections = _context.CreateConnection())
            {
                var values = connections.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public decimal AverageProductPriceByRent()
        {
            string query = "Select Avg(Price) From Product Where Type='Kiralık'";
            using (var connections = _context.CreateConnection())
            {
                var values = connections.QueryFirstOrDefault<decimal>(query);
                return values;
            }
        }

        public double AverageProductPriceBySale()
        {
            string query = "Select Avg(Price) From Product Where Type='Satılık'";
            using (var connections = _context.CreateConnection())
            {
                var values = connections.QueryFirstOrDefault<double>(query);
                return values;
            }
        }

        public int AverageRoomCount()
        {
            string query = "Select Avg(RoomCount) From ProductDetails";
            using (var connections = _context.CreateConnection())
            {
                var values = connections.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public int CategoryCount()
        {
            string query = "Select Count(*) From Category";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public string CategoryNameByMaxProductCount()
        {
            string query = "Select TOP(1) CategoryName, Count(*) From Product Inner Join Category On Product.ProductCategory=Category.CategoryID Group By CategoryName Order By COUNT(*) Desc";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<string>(query);
                return values!.ToString();
            }
        }

        public string CityNameByMaxProductCount()
        {
            string query = "Select TOP(1) City, Count(*) as 'product_count' From Product Group By City Order By 'product_count' Desc";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<string>(query);
                return values!.ToString();
            }
        }

        public int DifferentCityCount()
        {
            string query = "Select Count(Distinct(City)) From Product";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public string EmployeeNameByMaxProductCount()
        {
            string query = "Select Top(1) Name, Count(*) as 'emp_count' From Employee Inner Join Product On Product.EmployeeID = Employee.EmployeeID Group By Name Order By 'emp_count' Desc";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<string>(query);
                return values!.ToString();
            }
        }

        public decimal LastProductPrice()
        {
            string query = "Select top(1) Price From Product Order By ProductID Desc";
            using (var connections = _context.CreateConnection())
            {
                var values = connections.QueryFirstOrDefault<decimal>(query);
                return values;
            }
        }

        public string NewestBuildingYear()
        {
            string query = "Select top(1) BuildYear From ProductDetails Order By BuildYear Desc";
            using (var connections = _context.CreateConnection())
            {
                var values = connections.QueryFirstOrDefault<string>(query);
                return values!.ToString();
            }
        }

        public string OldestBuildingYear()
        {
            string query = "Select top(1) BuildYear From ProductDetails Order By BuildYear Asc";
            using (var connections = _context.CreateConnection())
            {
                var values = connections.QueryFirstOrDefault<string>(query);
                return values!.ToString();
            }
        }

        public int PassiveCategoryCount()
        {
            string query = "Select Count(*) From Category Where CategoryStatus=0";
            using (var connections = _context.CreateConnection())
            {
                var values = connections.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public int ProductCount()
        {
            string query = "Select Count(*) From Product";
            using (var connections = _context.CreateConnection())
            {
                var values = connections.QueryFirstOrDefault<int>(query);
                return values;
            }
        }
    }
}
