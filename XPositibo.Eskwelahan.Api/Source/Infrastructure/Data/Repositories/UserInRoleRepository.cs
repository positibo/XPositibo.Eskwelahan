using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using XPositibo.Eskwelahan.Api.Source.Domain.Entities;

namespace XPositibo.Eskwelahan.Api.Source.Infrastructure.Data.Repositories
{
    public class UserInRoleRepository : IUserInRoleRepository
    {
        private readonly IConfiguration configuration;

        public UserInRoleRepository(IConfiguration configuration) => this.configuration = configuration;

        public async Task<int> AddAsync(UserInRole entity)
        {
            var sql = "Insert into UserInRole (UserId, RoleId) VALUES (@UserId,@RoleId)";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<UserInRole>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserInRole> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(UserInRole entity)
        {
            throw new NotImplementedException();
        }
    }
}
