using RealEstate_API.Dtos.TestimonialDtos;

namespace RealEstate_API.Repositories.TestimonialRepositories
{
    public interface ITestimonialRepository
    {
        Task<List<ResultTestimonialDto>> GetAllTestimonialAsync();
        void DeleteTestimonial(int id);
        Task<GetByIdTestimonialDto> GetTestimonialGrid(int id);
    }
}
