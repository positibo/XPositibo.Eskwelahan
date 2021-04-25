using AutoMapper;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using XPositibo.Eskwelahan.Api.Source.Domain.BusinessRules;
using XPositibo.Eskwelahan.Api.Source.Domain.Entities;
using XPositibo.Eskwelahan.Api.Source.Infrastructure.Data.Repositories;
using XPositibo.Eskwelahan.Api.Source.Infrastructure.Helpers;

namespace XPositibo.Eskwelahan.Api.Source.Domain.UseCases.Command.Authentication.Login
{
    public class LoginCommand : IRequest<LoginResultDto>
    {
        public LoginDto Dto { get; set; }

        public LoginCommand(LoginDto dto) => this.Dto = dto;

        public class RequestHandler : IRequestHandler<LoginCommand, LoginResultDto>
        {
            private readonly IUnitOfWork unitOfWork;
            private IMapper mapper;

            public RequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                this.unitOfWork = unitOfWork;
                this.mapper = mapper;
            }

            public async Task<LoginResultDto> Handle(LoginCommand request, CancellationToken cancellationToken)
            {
                var user = await unitOfWork.Users.GetByUsernameAsync(request.Dto.Username);
                if (user == null)
                    throw new UsernamePasswordIncorrectException();

                // check if password is correct
                if (!AuthHelper.VerifyPasswordHash(request.Dto.Password, user.PasswordHash, user.PasswordSalt))
                    throw new UsernamePasswordIncorrectException();

                // authentication is successful
                LoginResultDto result = new LoginResultDto
                {
                    Id = user.UserId,
                    Username = user.Username,
                    Token = GenerateJwtToken(user),
                };

                if (!string.IsNullOrEmpty(result.Token))
                {
                    user.Token = result.Token;
                    await unitOfWork.Users.UpdateAsync(user);
                }

                return result;
            }

            private string GenerateJwtToken(User user)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(AuthHelper.SECRET);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, user.UserId.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);

                return tokenString;
            }
        }
    }
}
