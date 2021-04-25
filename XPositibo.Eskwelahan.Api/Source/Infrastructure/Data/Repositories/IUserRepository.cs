using System.Threading.Tasks;
using XPositibo.Eskwelahan.Api.Source.Domain.Entities;
using XPositibo.Eskwelahan.Api.Source.Infrastructure.Data.Repositories;

namespace XPositibo.Eskwelahan.Api.Source.Infrastructure.Data
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetByUsernameAsync(string username);
    }
}
