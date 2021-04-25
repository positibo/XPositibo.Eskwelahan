namespace XPositibo.Eskwelahan.Api.Source.Infrastructure.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        public UnitOfWork(IUserRepository userRepository, 
            IRoleRepository roleRepository,
            IMemberRepository memberRepository,
            ICompanyRepository companyRepository,
            IUserInRoleRepository userInRoleRepository)
        { 
            Users = userRepository;
            Roles = roleRepository;
            Members = memberRepository;
            Companies = companyRepository;
            UserInRoles = userInRoleRepository;
        }

        public IUserRepository Users { get; }
        public IRoleRepository Roles { get; }
        public IMemberRepository Members { get; }
        public ICompanyRepository Companies { get; }
        public IUserInRoleRepository UserInRoles { get; }
    }
}
