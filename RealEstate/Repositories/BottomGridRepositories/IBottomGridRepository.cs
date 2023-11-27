using RealEstate_API.Dtos.BottomGridDtos;

namespace RealEstate_API.Repositories.BottomGridRepositories
{
    public interface IBottomGridRepository
    {
        Task<List<ResultBottomGridDto>> GetAllBottomGridAsync();
        void CreateBottomGrid(CreateBottomGridDto bottomGridDto);
        void UpdateBottomGrid(UpdateBottomGridDto bottomGridDto);
        void DeleteBottomGrid(int id);
        Task<GetByIdBottomGridDto> GetBottomGrid(int id);

    }
}
