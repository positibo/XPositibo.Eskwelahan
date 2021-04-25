using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using XPositibo.Eskwelahan.Api.Source.Domain.BusinessRules;
using XPositibo.Eskwelahan.Api.Source.Domain.Entities;
using XPositibo.Eskwelahan.Api.Source.Infrastructure.Data.Repositories;
using XPositibo.Eskwelahan.Api.Source.Infrastructure.Helpers;

namespace XPositibo.Eskwelahan.Api.Source.Domain.UseCases.Command.Authentication.RegisterUser
{
    public class RegisterUserCommand : IRequest
    {
        public RegisterUserDto Dto { get; }

        public RegisterUserCommand(RegisterUserDto dto) => this.Dto = dto;

        public class RequestHandler : IRequestHandler<RegisterUserCommand>
        {
            private readonly IUnitOfWork unitOfWork;
            private IMapper mapper;

            public RequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                this.unitOfWork = unitOfWork;
                this.mapper = mapper;
            }

            public async Task<Unit> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
            {
                await UsernameIsAlreadyRegisteredValidation(request.Dto);
                await EmailIsAlreadyRegisteredValidation(request.Dto);
                await CompanyIsAlreadyRegisteredValidation(request.Dto);
                await RoleDoesNotExistValidation(request.Dto);

                byte[] passwordHash, passwordSalt;
                AuthHelper.CreatePasswordHash(request.Dto.UserInfo.Password, out passwordHash, out passwordSalt);

                // add user
                var user = new User
                {
                    Username = request.Dto.UserInfo.Username,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    Member = new Member
                    {
                        FirstName = request.Dto.UserInfo.FirstName,
                        LastName = request.Dto.UserInfo.LastName,
                        Email = request.Dto.UserInfo.Email,
                        PhotoUrl = request.Dto.UserInfo.PhotoUrl,
                    }
                };

                var company = await unitOfWork.Companies.GetByCompanyNameAsync(request.Dto.CompanyInfo.CompanyName);
                if (company != null)
                {
                    user.Member.Company = company;
                }
                else
                {
                    user.Member.Company = new Company
                    {
                        CompanyName = request.Dto.CompanyInfo.CompanyName,
                        Description = request.Dto.CompanyInfo.Description,
                        LogoUrl = request.Dto.CompanyInfo.LogoUrl,
                        IsActive = true
                    };
                }

                await unitOfWork.Users.AddAsync(user);

                // add role
                var role = await unitOfWork.Roles.GetByRolenameAsync(request.Dto.UserInfo.Role);
                if (role != null)
                {
                    var userRole = new UserInRole
                    {
                        UserId = user.UserId,
                        RoleId = role.RoleId
                    };

                    await unitOfWork.UserInRoles.AddAsync(userRole);
                }

                return Unit.Value;
            }

            private async Task UsernameIsAlreadyRegisteredValidation(RegisterUserDto dto)
            {
                var user = await unitOfWork.Users.GetByUsernameAsync(dto.UserInfo.Username);
                if (user != null)
                {
                    throw new UsernameIsAlreadyRegisteredException();
                }
            }

            private async Task RoleDoesNotExistValidation(RegisterUserDto dto)
            {
                var role = await unitOfWork.Roles.GetByRolenameAsync(dto.UserInfo.Role);
                if (role == null)
                {
                    throw new RoleDoesNotExistException();
                }
            }

            private async Task EmailIsAlreadyRegisteredValidation(RegisterUserDto dto)
            {
                var email = await unitOfWork.Members.GetByEmailAsync(dto.UserInfo.Email);
                if (email != null)
                {
                    throw new EmailIsAlreadyRegisteredException();
                }
            }

            private async Task CompanyIsAlreadyRegisteredValidation(RegisterUserDto dto)
            {
                var company = await unitOfWork.Companies.GetByCompanyNameAsync(dto.CompanyInfo.CompanyName);
                if (company != null)
                {
                    throw new CompanyIsAlreadyRegisteredException();
                }
            }

        }
    }
}
