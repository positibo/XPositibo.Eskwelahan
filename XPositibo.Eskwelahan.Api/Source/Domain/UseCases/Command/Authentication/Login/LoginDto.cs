using System.ComponentModel.DataAnnotations;

namespace XPositibo.Eskwelahan.Api.Source.Domain.UseCases.Command.Authentication.Login
{
    public class LoginDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
