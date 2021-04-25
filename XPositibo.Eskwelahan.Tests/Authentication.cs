using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using System.Threading.Tasks;
using XPositibo.Eskwelahan.Api.Source.Domain.BusinessRules;
using XPositibo.Eskwelahan.Api.Source.Domain.UseCases.Command.Authentication.Login;
using XPositibo.Eskwelahan.Api.Source.Domain.UseCases.Command.Authentication.RegisterUser;

namespace XPositibo.Eskwelahan.Tests
{

    [TestClass]
    public class Authentication
    {
        //private DataContext context = null;
        //private IMapper mapper = null;

        [TestInitialize]
        public void Initialize()
        {
            //var options = new DbContextOptionsBuilder<DataContext>()
            //    .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            //    .Options;

            //context = new DataContext(options);

            //var member = new Member
            //{
            //    FirstName = "Unknown",
            //    LastName = "Unknown",
            //    Email = "test@gmail.com",
            //    PhotoUrl = "photo"
            //};

            //var role = new Role { RoleName = "admin" };
            //context.Roles.Add(role);

            //var company = new Company { CompanyName = "companyName" };
            //context.Companies.Add(company);

            //var password = "correct password";
            //byte[] passwordHash, passwordSalt;
            //AuthHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);

            //context.Users.Add(new User
            //{
            //    Username = "user1",
            //    Member = member,
            //    PasswordHash = passwordHash,
            //    PasswordSalt = passwordSalt
            //});

            //context.SaveChanges();

            //var applicationAssembly = Assembly.Load("MyDeliveryApp.Server");
            //var config = new MapperConfiguration(configuration =>
            //{
            //    configuration.AddMaps(applicationAssembly);
            //});
            //mapper = config.CreateMapper();
        }

        [TestCleanup]
        public void Cleanup()
        {
            //context.Dispose();
            //context = null;
        }

        [TestMethod]
        [ExpectedException(typeof(UsernameIsAlreadyRegisteredException))]
        public async Task RegisterUser_UsernameIsAlreadyRegistered()
        {
            var dto = new RegisterUserDto();
            dto.UserInfo = new RegisterUserDto.UserInfoDto
            {
                FirstName = "Unknown",
                LastName = "Unknown",
                Email = "test@gmail.com",
                Username = "user1",
                Password = "password"
            };

            //var useCase = new RegisterUserCommand(dto);
            //var request = new RegisterUserCommand.RequestHandler(context, mapper);

            //await request.Handle(useCase, new CancellationToken());
        }

        [TestMethod]
        [ExpectedException(typeof(EmailIsAlreadyRegisteredException))]
        public async Task RegisterUser_EmailIsAlreadyRegistered()
        {
            var dto = new RegisterUserDto();
            dto.UserInfo = new RegisterUserDto.UserInfoDto
            {
                FirstName = "Unknown",
                LastName = "Unknown",
                Email = "test@gmail.com",
                Username = "user2",
                Password = "password",
                Role = "admin"
            };

            //var useCase = new RegisterUserCommand(dto);
            //var request = new RegisterUserCommand.RequestHandler(context, mapper);

            //await request.Handle(useCase, new CancellationToken());
        }

        [TestMethod]
        [ExpectedException(typeof(CompanyIsAlreadyRegisteredException))]
        public async Task RegisterUser_CompanyNameIsAlreadyRegistered()
        {
            var dto = new RegisterUserDto();
            dto.UserInfo = new RegisterUserDto.UserInfoDto
            {
                FirstName = "Unknown",
                LastName = "Unknown",
                Email = "test3@gmail.com",
                Username = "user3",
                Password = "password",
                Role = "admin"
            };

            dto.CompanyInfo = new RegisterUserDto.CompanyInfoDto { CompanyName = "companyName" };

            //var useCase = new RegisterUserCommand(dto);
            //var request = new RegisterUserCommand.RequestHandler(context, mapper);

            //await request.Handle(useCase, new CancellationToken());
        }

        [TestMethod]
        [ExpectedException(typeof(UsernamePasswordIncorrectException))]
        public async Task Login_UsernameIsIncorrect()
        {
            var dto = new LoginDto
            {
                Username = "wrong username",
                Password = "correct password"
            };

            //var useCase = new LoginCommand(dto);
            //var request = new LoginCommand.RequestHandler(context, mapper);

            //await request.Handle(useCase, new CancellationToken());
        }

        [TestMethod]
        [ExpectedException(typeof(UsernamePasswordIncorrectException))]
        public async Task Login_PasswordIsIncorrect()
        {

            var dto = new LoginDto
            {
                Username = "user1",
                Password = "wrong password"
            };

            //var useCase = new LoginCommand(dto);
            //var request = new LoginCommand.RequestHandler(context, mapper);

            //await request.Handle(useCase, new CancellationToken());
        }

    }
}
