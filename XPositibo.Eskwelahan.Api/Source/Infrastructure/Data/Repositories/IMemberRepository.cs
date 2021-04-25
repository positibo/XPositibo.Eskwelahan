using System.Threading.Tasks;
using XPositibo.Eskwelahan.Api.Source.Domain.Entities;

namespace XPositibo.Eskwelahan.Api.Source.Infrastructure.Data.Repositories
{
    public interface IMemberRepository : IGenericRepository<Member>
    {
        Task<Member> GetByEmailAsync(string email);
    }
}
