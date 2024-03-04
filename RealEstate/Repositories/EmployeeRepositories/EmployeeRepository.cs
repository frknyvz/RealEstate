using Dapper;
using RealEstate.Models.Context;
using RealEstate_API.Dtos.EmployeeDtos;

namespace RealEstate_API.Repositories.EmployeeRepositories
{
    public class EmployeeRepository:IEmployeeRepository
    {
        private readonly Context _context;

        public EmployeeRepository(Context context)
        {
            _context = context;
        }

        public async void CreateEmployee(CreateEmployeeDto createEmployeeDto)
        {
            string query = "Insert into Employee (Name,Title,Mail,PhoneNumber,ImageUrl,Status) Values(@name,@title,@mail,@phonenumber,@imageurl,@status)";
            var parameters = new DynamicParameters();
            parameters.Add("@name", createEmployeeDto.Name);
            parameters.Add("@title", createEmployeeDto.Title);
            parameters.Add("@email", createEmployeeDto.Mail);
            parameters.Add("@phonenumber", createEmployeeDto.PhoneNumber);
            parameters.Add("@imageurl", createEmployeeDto.ImageURL);
            parameters.Add("@status", true);


            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteEmployee(int id)
        {
            string query = "Delete From Employee Where EmployeeID=@employeeID";
            var parameters = new DynamicParameters();
            parameters.Add("@employeeID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultEmployeeDto>> GetAllEmployeeAsync()
        {
            string query = "Select * From Employee";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultEmployeeDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdEmployeeDto> GetEmployee(int id)
        {
            string query = "Select * From Employee Where EmployeeID = @employeeID";
            var parameters = new DynamicParameters();
            parameters.Add("@employeeID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIdEmployeeDto>(query, parameters);
                return values!;
            }
        }

        public async void UpdateEmployee(UpdateEmployeeDto updateEmployeeDto)
        {
            string query = "Update Employee Set Name=@name, Title=@title, Mail=@mail, PhoneNumber=@phonenumber, ImageUrl=@imageurl, Status=@status Where EmployeeID = @employeeID";
            var parameters = new DynamicParameters();
            parameters.Add("@employeeID", updateEmployeeDto.EmployeeID);
            parameters.Add("@name", updateEmployeeDto.Name);
            parameters.Add("@title", updateEmployeeDto.Title);
            parameters.Add("@email", updateEmployeeDto.Mail);
            parameters.Add("@phonenumber", updateEmployeeDto.PhoneNumber);
            parameters.Add("@imageurl", updateEmployeeDto.ImageURL);
            parameters.Add("@status", true);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
