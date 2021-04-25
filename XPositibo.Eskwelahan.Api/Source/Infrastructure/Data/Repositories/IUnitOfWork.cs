namespace XPositibo.Eskwelahan.Api.Source.Infrastructure.Data.Repositories
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }

        IRoleRepository Roles { get; }

        IMemberRepository Members { get; }

        ICompanyRepository Companies { get; }

        IUserInRoleRepository UserInRoles { get; }
    }
}
