using Dapper;
using RealEstate.Models.Context;
using RealEstate_API.Dtos.PopularLocationDto;
using RealEstate_API.Dtos.ServiceDtos;

namespace RealEstate_API.Repositories.PopularLocationRepositories
{
    public class PopularLocationRepository : IPopularLocationRepository
    {
        private readonly Context _context;

        public PopularLocationRepository(Context context)
        {
            _context = context;
        }

        public async void CreatePopularLocation(CreatePopularLocationDto popularLocationDto)
        {
            string query = "Insert into PopularLocations (LocationName, LocationImage) values(@locationName, @locationImage)";
            var parameters = new DynamicParameters();
            parameters.Add("@locationName", popularLocationDto.LocationName);
            parameters.Add("@locationImage", popularLocationDto.LocationImage);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeletePopularLocation(int id)
        {
            string query = "Delete From PopularLocations Where LocationsID=@locationsID";
            var parameters = new DynamicParameters();
            parameters.Add("@locationsID", id);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultPopularLocationDto>> GetAllPopularLocationAsync()
        {
            string query = "Select * From PopularLocations";
            using (var connections = _context.CreateConnection())
            {
                var values = await connections.QueryAsync<ResultPopularLocationDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdPopularLocationDto> GetPopularLocation(int id)
        {
            string query = "Select * From PopularLocations Where LocationsID = @locationsID";
            var parameters = new DynamicParameters();
            parameters.Add("@locationsID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIdPopularLocationDto>(query, parameters);
                return values!;
            }
        }

        public async void UpdatePopularLocation(UpdatePopularLocationDto popularLocationDto)
        {
            string query = "Update PopularLocations Set LocationName = @locationName, LocationImage=@locationImage Where LocationsID = @locationsID";
            var parameters = new DynamicParameters();
            parameters.Add("@locationsID", popularLocationDto.LocationsID);
            parameters.Add("@locationName", popularLocationDto.LocationName);
            parameters.Add("@locationImage", popularLocationDto.LocationImage);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
