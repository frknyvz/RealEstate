using Dapper;
using RealEstate.Models.Context;
using RealEstate_API.Dtos.ServiceDtos;

namespace RealEstate_API.Repositories.ServiceRepository
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly Context _context;

        public ServiceRepository(Context context)
        {
            _context = context;
        }

        public async void CreateService(CreateServiceDto serviceDto)
        {
            //string query = "Insert into Service (ServiceName,ServiceStatus) Values(@serviceName,@serviceStatus)";
            //var parameters = new DynamicParameters();
            //parameters.Add("@serviceName", serviceDto.ServiceName);
            //parameters.Add("@serviceStatus", serviceDto.ServiceStatus);

            //using (var connection = _context.CreateConnection())
            //{
            //    await connection.ExecuteAsync(query, parameters);
            //}
            throw new NotImplementedException();
        }

        public async void DeleteService(int id)
        {
            //string query = "Delete From Service Where ServiceID=@serviceID";
            //var parameters = new DynamicParameters();
            //parameters.Add("@serviceID", id);
            //using (var connection = _context.CreateConnection())
            //{
            //    await connection.ExecuteAsync(query, parameters);
            //}
            throw new NotImplementedException();
        }

        public async Task<List<ResultServiceDto>> GetAllServiceAsync()
        {
            string query = "Select * From Service";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultServiceDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdServiceDto> GetService(int id)
        {
            //string query = "Select * From Service Where ServiceID = @serviceID";
            //var parameters = new DynamicParameters();
            //parameters.Add("@serviceID", id);
            //using (var connection = _context.CreateConnection())
            //{
            //    var values = await connection.QueryFirstOrDefaultAsync<GetByIdServiceDto>(query, parameters);
            //    return values;
            //}
            throw new NotImplementedException();
        }

        public async void UpdateService(UpdateServiceDto serviceDto)
        {
            //string query = "Update Service Set ServiceName = @serviceName, ServiceStatus=@serviceStatus, Where ServiceID = @serviceID";
            //var parameters = new DynamicParameters();
            //parameters.Add("@serviceID", serviceDto.ServiceID);
            //parameters.Add("@serviceName", serviceDto.ServiceName);
            //parameters.Add("@serviceStatus", serviceDto.ServiceStatus);


            //using (var connection = _context.CreateConnection())
            //{
            //    await connection.ExecuteAsync(query, parameters);
            //}
            throw new NotImplementedException();
        }
    }
}
