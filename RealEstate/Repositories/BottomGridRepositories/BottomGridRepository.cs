using Dapper;
using RealEstate.Models.Context;
using RealEstate_API.Dtos.BottomGridDtos;

namespace RealEstate_API.Repositories.BottomGridRepositories
{
    public class BottomGridRepository : IBottomGridRepository
    {
        private readonly Context _context;
        public BottomGridRepository(Context context)
        {
            _context = context;
        }

        public async void CreateBottomGrid(CreateBottomGridDto bottomGridDto)
        {
            string query = "Insert Into BottomGrid(Icon,Title,Description) Values(@icon,@title,@description)";
            var parameters = new DynamicParameters();
            parameters.Add("@icon", bottomGridDto.Icon);
            parameters.Add("@title", bottomGridDto.Title);
            parameters.Add("@description", bottomGridDto.Description);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteBottomGrid(int id)
        {
            string query = "Delete From BottomGrid Where BottomGridID = @bottomGridID";
            var parameters = new DynamicParameters();
            parameters.Add("@bottomGridID", id);

            using(var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultBottomGridDto>> GetAllBottomGridAsync()
        {
            string query = "Select * From BottomGrid";
            using (var connection = _context.CreateConnection())
            {
               var values = await connection.QueryAsync<ResultBottomGridDto>(query);
                return values.ToList();
            };
        }

        public async Task<GetByIdBottomGridDto> GetBottomGrid(int id)
        {
            string query = "Select * From BottomGrid Where BottomGridID = @bottomGridId";
            var parameters = new DynamicParameters();
            parameters.Add("@bottomGridId", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIdBottomGridDto>(query);
                return values!;
;            }
        }

        public async void UpdateBottomGrid(UpdateBottomGridDto bottomGridDto)
        {
            string query = "Update BottomGrid Set Icon = @icon, Title = @title, Description = @description Where BottomGridID = @bottomGridId";
            var parameters = new DynamicParameters();
            parameters.Add("@bottomGridId", bottomGridDto.BottomGridID);
            parameters.Add("@icon", bottomGridDto.Icon);
            parameters.Add("@title", bottomGridDto.Title);
            parameters.Add("@description", bottomGridDto.Description);

            using(var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
