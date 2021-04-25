using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using XPositibo.Eskwelahan.Api.Source.Domain.Entities;

namespace XPositibo.Eskwelahan.Api.Source.Infrastructure.Data.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly IConfiguration configuration;

        public RoleRepository(IConfiguration configuration) => this.configuration = configuration;

        public async Task<int> AddAsync(Role entity)
        {
            var sql = "Insert into Role (RoleName) VALUES (@RoleName)";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            var sql = "DELETE FROM Role WHERE RoleId = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Id = id });
                return result;
            }
        }

        public async Task<IReadOnlyList<Role>> GetAllAsync()
        {
            var sql = "SELECT * FROM Role";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Role>(sql);
                return result.ToList();
            }
        }

        public async Task<Role> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM Role WHERE RoleId = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Role>(sql, new { Id = id });
                return result;
            }
        }

        public async Task<Role> GetByRolenameAsync(string rolename)
        {
            var sql = "SELECT * FROM Role WHERE RoleName = @RoleName";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Role>(sql, new { RoleName = rolename });
                return result;
            }
        }

        public async Task<int> UpdateAsync(Role entity)
        {
            var sql = "UPDATE Role SET RoleName = @RoleName WHERE RoleId = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }
    }
}
