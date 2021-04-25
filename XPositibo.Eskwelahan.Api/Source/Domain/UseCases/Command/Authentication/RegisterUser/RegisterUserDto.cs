using System.ComponentModel.DataAnnotations;

namespace XPositibo.Eskwelahan.Api.Source.Domain.UseCases.Command.Authentication.RegisterUser
{
    public class RegisterUserDto
    {
        public UserInfoDto UserInfo { get; set; }
        public CompanyInfoDto CompanyInfo { get; set; }

        public class UserInfoDto
        {
            [Required]
            public string FirstName { get; set; }

            [Required]
            public string LastName { get; set; }

            [Required]
            public string Username { get; set; }

            [Required]
            public string Password { get; set; }

            [Required]
            public string Email { get; set; }

            public string PhotoUrl { get; set; }

            [Required]
            public string Role { get; set; }
        }

        public class CompanyInfoDto
        {
            [Required]
            public string CompanyName { get; set; }
            public string Description { get; set; }
            public string LogoUrl { get; set; }
        }
    }
}
