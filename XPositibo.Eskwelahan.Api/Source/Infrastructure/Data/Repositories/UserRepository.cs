using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using XPositibo.Eskwelahan.Api.Source.Domain.Entities;

namespace XPositibo.Eskwelahan.Api.Source.Infrastructure.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration configuration;

        public UserRepository(IConfiguration configuration) => this.configuration = configuration;

        public async Task<int> AddAsync(User entity)
        {
            var sql = "Insert into [User] (Username,PasswordHash,PasswordSalt,Token) VALUES (@Username,@PasswordHash,@PasswordSalt,@Token)";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            var sql = "DELETE FROM [User] WHERE UserId = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Id = id });
                return result;
            }
        }

        public async Task<IReadOnlyList<User>> GetAllAsync()
        {
            var sql = "SELECT * FROM [User]";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<User>(sql);
                return result.ToList();
            }
        }

        public async Task<User> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM [User] WHERE UserId = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<User>(sql, new { Id = id });
                return result;
            }
        }

        public async Task<User> GetByUsernameAsync(string username)
        {
            var sql = "SELECT * FROM [User] WHERE Username = @Username";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<User>(sql, new { Username = username });
                return result;
            }
        }

        public async Task<int> UpdateAsync(User entity)
        {
            var sql = "UPDATE [User] SET Username = @Username, PasswordHash = @PasswordHash, PasswordSalt = @PasswordSalt, Token = @Token WHERE UserId = @UserId";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }
    }
}
