using System.Threading.Tasks;
using XPositibo.Eskwelahan.Api.Source.Domain.Entities;

namespace XPositibo.Eskwelahan.Api.Source.Infrastructure.Data.Repositories
{
    public interface IRoleRepository : IGenericRepository<Role>
    {
        Task<Role> GetByRolenameAsync(string rolename);
    }
}
