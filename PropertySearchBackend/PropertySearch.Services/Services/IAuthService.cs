using PropertySearch.Application.Dto;

namespace PropertySearch.Application.Services
{
    public interface IAuthService
    {
        Task<ServiceResponse<AuthResponseDto>> Login(LoginDto loginDto);
    }
}
