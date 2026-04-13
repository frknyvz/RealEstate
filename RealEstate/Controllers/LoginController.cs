using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Models.Context;
using RealEstate_API.Dtos.LoginDtos;
using RealEstate_API.Dtos.ProductDtos;
using RealEstate_API.Tools;

namespace RealEstate_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly Context _context;

        public LoginController(Context context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(CreateLoginDto createLoginDto)
        {
            string query = "Select * From AppUser Where UserName=@userName And Password=@password";
            string query2 = "Select UserID From AppUser Where UserName=@userName And Password=@password";
            var parameters = new DynamicParameters();
            parameters.Add("@userName", createLoginDto.Username);
            parameters.Add("@password", createLoginDto.Password);

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<CreateLoginDto>(query, parameters);
                var values2 = await connection.QueryFirstOrDefaultAsync<GetAppUserIdDto>(query2, parameters);
                if (values != null)
                {
                    GetCheckAppUserViewModel getCheckAppUserViewModel = new GetCheckAppUserViewModel();
                    getCheckAppUserViewModel.UserName = values.Username;
                    getCheckAppUserViewModel.Id = values2.UserID;
                    var token = JwtTokenGenerator.GenerateToken(getCheckAppUserViewModel);

                    return Ok(token);
                }
                else
                {
                    return Ok("Başarısız");
                }
            }
        }
    }
}
