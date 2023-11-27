using RealEstate_API.Dtos.WhoWeAreDetailDtos;
using RealEstate_API.Dtos.WhoWeAreDtos;

namespace RealEstate_API.Repositories.WhoWeAreRepository
{
    public interface IWhoWeAreDetailRepository
    {
        Task<List<ResultWhoWeAreDetailDto>> GetAllWhoWeAreDetailAsync();
        void CreateWhoWeAreDetail(CreateWhoWeAreDetailDto whoWeAreDetailDto);
        void DeleteWhoWeAreDetail(int id);
        void UpdateWhoWeAreDetail(UpdateWhoWeAreDetailDto whoWeAreDetailDto);
        Task<GetByIdWhoWeAreDetailDto> GetWhoWeAreDetail(int id);
    }
}
