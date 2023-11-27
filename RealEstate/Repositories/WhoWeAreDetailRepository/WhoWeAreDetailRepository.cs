using Dapper;
using RealEstate.Models.Context;
using RealEstate_API.Dtos.WhoWeAreDetailDtos;
using RealEstate_API.Dtos.WhoWeAreDtos;

namespace RealEstate_API.Repositories.WhoWeAreRepository
{
    public class WhoWeAreDetailRepository : IWhoWeAreDetailRepository
    {
        private readonly Context _context;

        public WhoWeAreDetailRepository(Context context)
        {
            _context = context;
        }

        public async void CreateWhoWeAreDetail(CreateWhoWeAreDetailDto whoWeAreDetailDto)
        {
            string query = "Insert into WhoWeAreDetail (Title,SubTitle,Description1,Description2) Values(@title,@subtitle,@description1,@description2)";
            var parameters = new DynamicParameters();
            parameters.Add("@title", whoWeAreDetailDto.Title);
            parameters.Add("@subtitle", whoWeAreDetailDto.SubTitle);
            parameters.Add("@description1", whoWeAreDetailDto.Description1);
            parameters.Add("@description2", whoWeAreDetailDto.Description2);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteWhoWeAreDetail(int id)
        {
            string query = "Delete From WhoWeAreDetail Where WhoWeAreDetailID=@whoWeAreDetailID";
            var parameters = new DynamicParameters();
            parameters.Add("@whoWeAreDetailID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultWhoWeAreDetailDto>> GetAllWhoWeAreDetailAsync()
        {
            string query = "Select * From WhoWeAreDetail";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultWhoWeAreDetailDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdWhoWeAreDetailDto> GetWhoWeAreDetail(int id)
        {
            string query = "Select * From WhoWeAreDetail Where WhoWeAreDetailID = @whoWeAreDetailID";
            var parameters = new DynamicParameters();
            parameters.Add("@whoWeAreDetailID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIdWhoWeAreDetailDto>(query, parameters);
                return values;
            }
        }

        public async void UpdateWhoWeAreDetail(UpdateWhoWeAreDetailDto whoWeAreDetailDto)
        {
            string query = "Update WhoWeAreDetail Set Title = @title, SubTitle=@subtitle, Description1=@description1, Description2=@description2 Where WhoWeAreDetailID = @whoWeAreDetailID";
            var parameters = new DynamicParameters();
            parameters.Add("@whoWeAreDetailID", whoWeAreDetailDto.WhoWeAreDetailID);
            parameters.Add("@title", whoWeAreDetailDto.Title);
            parameters.Add("@subtitle", whoWeAreDetailDto.SubTitle);
            parameters.Add("@description1", whoWeAreDetailDto.Description1);
            parameters.Add("@description2", whoWeAreDetailDto.Description2);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
