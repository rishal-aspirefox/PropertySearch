namespace PropertySearch.Application.Dto
{
    public class AuthResponseDto
    {
        public string Token { get; set; } = null!;

        public string Email { get; set; } = null!;

        public DateTime Expiration { get; set; }
    }
}
