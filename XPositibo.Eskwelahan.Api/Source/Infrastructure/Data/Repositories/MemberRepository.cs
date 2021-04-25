using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using XPositibo.Eskwelahan.Api.Source.Domain.Entities;

namespace XPositibo.Eskwelahan.Api.Source.Infrastructure.Data.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly IConfiguration configuration;

        public MemberRepository(IConfiguration configuration) => this.configuration = configuration;

        public async Task<int> AddAsync(Member entity)
        {
            var sql = "Insert into Member (FirstName, LastName, PhotoUrl, Email, Address, ContactNumber, CompanyId) VALUES (@FirstName, @LastName, @PhotoUrl, @Email, @Address, @ContactNumber, @CompanyId)";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            var sql = "DELETE FROM Member WHERE UserId = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Id = id });
                return result;
            }
        }

        public async Task<IReadOnlyList<Member>> GetAllAsync()
        {
            var sql = "SELECT * FROM Member";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Member>(sql);
                return result.ToList();
            }
        }

        public async Task<Member> GetByEmailAsync(string email)
        {
            var sql = "SELECT * FROM Member WHERE Email = @Email";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Member>(sql, new { Email = email });
                return result;
            }
        }

        public async Task<Member> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM Member WHERE UserId = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Member>(sql, new { Id = id });
                return result;
            }
        }

        public async Task<int> UpdateAsync(Member entity)
        {
            var sql = "UPDATE Member SET FirstName = @FirstName, LastName = @LastName, PhotoUrl = @PhotoUrl, Email = @Email, Address = @Address, ContactNumber = @ContactNumber, CompanyId = @CompanyId  WHERE UserId = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }
    }
}
