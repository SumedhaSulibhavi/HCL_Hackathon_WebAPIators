using System.ComponentModel.DataAnnotations;

namespace HCL_Hackathon_WebAPIators.DTOs
{
    // Contract used for creating fresh customer accounts
    public record RegisterDto(
        [Required][EmailAddress] string Email,
        [Required][StringLength(50, MinimumLength = 3)] string Username,
        [Required][MinLength(6)] string Password
    );

    // Contract used for validating incoming sign-in credentials
    public record LoginDto(
        [Required][EmailAddress] string Email,
        [Required] string Password
    );

    // Contract returned upon successful validation to feed the Angular navbar state
    public record AuthResponseDto(
        string Token,
        string Username,
        string Role
    );
}