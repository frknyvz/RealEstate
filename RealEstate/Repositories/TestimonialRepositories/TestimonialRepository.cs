using Dapper;
using RealEstate.Models.Context;
using RealEstate_API.Dtos.TestimonialDtos;

namespace RealEstate_API.Repositories.TestimonialRepositories
{
    public class TestimonialRepository : ITestimonialRepository
    {
        private readonly Context _context;

        public TestimonialRepository(Context context)
        {
            _context = context;
        }
        public async Task<List<ResultTestimonialDto>> GetAllTestimonialAsync()
        {
            string query = "Select * From Testimonial";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultTestimonialDto>(query);
                return values.ToList();
            }
        }
        public void DeleteTestimonial(int id)
        {
            throw new NotImplementedException();
        }
        public Task<GetByIdTestimonialDto> GetTestimonialGrid(int id)
        {
            throw new NotImplementedException();
        }
    }
}
