using RealEstate_API.Dtos.PopularLocationDto;

namespace RealEstate_API.Repositories.PopularLocationRepositories
{
    public interface IPopularLocationRepository
    {
        Task<List<ResultPopularLocationDto>> GetAllPopularLocationAsync();
        void CreatePopularLocation(CreatePopularLocationDto popularLocationDto);
        void DeletePopularLocation(int id);
        void UpdatePopularLocation(UpdatePopularLocationDto popularLocationDto);
        Task<GetByIdPopularLocationDto> GetPopularLocation(int id);
    }
}
