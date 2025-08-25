using Microsoft.AspNetCore.Mvc;
using PropertySearch.Application.Dto;
using PropertySearch.Application.Services;

namespace PropertySearch.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<ServiceResponse<AuthResponseDto>> Login([FromBody] LoginDto loginDto)
        {
            try
            {
                var authResponse = await _authService.Login(loginDto);
                return authResponse;
            }
            catch (Exception ex)
            {
                return ServiceResponse<AuthResponseDto>.Failure(ex.Message);
            }
        }
    }
}
