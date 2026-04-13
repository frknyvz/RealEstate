using Dapper;
using RealEstate.Models.Context;

namespace RealEstate_API.Repositories.EstateAgentRepositories.DashboardRepositories.StatisticRepositories
{
    public class StatisticRepository : IStatisticRepository
    {
        private readonly Context _context;

        public StatisticRepository(Context context)
        {
            _context = context;
        }

        public int AllProductCount()
        {
            string query = "Select Count(*) From Product";
            using (var connections = _context.CreateConnection())
            {
                var values = connections.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public int ProductCountByEmployeeId(int id)
        {
            string query = "Select Count(*) From Product Where EmployeeID=@employeeId";
            var parameters = new DynamicParameters();
            parameters.Add("@employeeId", id);
            using (var connections = _context.CreateConnection())
            {
                var values = connections.QueryFirstOrDefault<int>(query, parameters);
                return values;
            }
        }

        public int ProductCountByStatusFalse(int id)
        {
            string query = "Select Count(*) From Product Where EmployeeID=@employeeId And ProductStatus = 0";
            var parameters = new DynamicParameters();
            parameters.Add("@employeeId", id);
            using (var connections = _context.CreateConnection())
            {
                var values = connections.QueryFirstOrDefault<int>(query, parameters);
                return values;
            }
        }

        public int ProductCountByStatusTrue(int id)
        {
            string query = "Select Count(*) From Product Where EmployeeID=@employeeId And ProductStatus = 1";
            var parameters = new DynamicParameters();
            parameters.Add("@employeeId", id);
            using (var connections = _context.CreateConnection())
            {
                var values = connections.QueryFirstOrDefault<int>(query, parameters);
                return values;
            }
        }
    }
}
