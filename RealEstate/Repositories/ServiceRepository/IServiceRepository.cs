using RealEstate_API.Dtos.ServiceDtos;

namespace RealEstate_API.Repositories.ServiceRepository
{
    public interface IServiceRepository
    {
        Task<List<ResultServiceDto>> GetAllServiceAsync();
        void CreateService(CreateServiceDto serviceDto);
        void DeleteService(int id);
        void UpdateService(UpdateServiceDto serviceDto);
        Task<GetByIdServiceDto> GetService(int id);
    }
}
