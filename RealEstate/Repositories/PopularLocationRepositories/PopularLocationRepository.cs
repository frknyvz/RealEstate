using Dapper;
using RealEstate.Models.Context;
using RealEstate_API.Dtos.PopularLocationDto;

namespace RealEstate_API.Repositories.PopularLocationRepositories
{
    public class PopularLocationRepository : IPopularLocationRepository
    {
        private readonly Context _context;

        public PopularLocationRepository(Context context)
        {
            _context = context;
        }

        public void CreatePopularLocation(CreatePopularLocationDto popularLocationDto)
        {
            throw new NotImplementedException();
        }

        public void DeletePopularLocation(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResultPopularLocationDto>> GetAllPopularLocationAsync()
        {
            string query = "Select * From PopularLocations";
            using(var connections = _context.CreateConnection())
            {
                var values = await connections.QueryAsync<ResultPopularLocationDto>(query); 
                return values.ToList();
            }
        }

        public Task<GetByIdPopularLocationDto> GetPopularLocation(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdatePopularLocation(UpdatePopularLocationDto popularLocationDto)
        {
            throw new NotImplementedException();
        }
    }
}
