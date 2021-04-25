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
    public class CompanyRepository : ICompanyRepository
    {
        private readonly IConfiguration configuration;

        public CompanyRepository(IConfiguration configuration) => this.configuration = configuration;

        public async Task<int> AddAsync(Company entity)
        {
            var sql = "Insert into Company (CompanyName,Description,LogoUrl,IsActive) VALUES (@CompanyName,@Description,@LogoUrl,@IsActive)";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            var sql = "DELETE FROM Company WHERE CompanyId = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Id = id });
                return result;
            }
        }

        public async Task<IReadOnlyList<Company>> GetAllAsync()
        {
            var sql = "SELECT * FROM Company";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Company>(sql);
                return result.ToList();
            }
        }

        public async Task<Company> GetByCompanyNameAsync(string companyName)
        {
            var sql = "SELECT * FROM Company WHERE CompanyName = @CompanyName";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Company>(sql, new { CompanyName = companyName });
                return result;
            }
        }

        public async Task<Company> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM Company WHERE CompanyId = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Company>(sql, new { Id = id });
                return result;
            }
        }

        public async Task<int> UpdateAsync(Company entity)
        {
            var sql = "UPDATE Company SET CompanyName = @CompanyName, Description = @Description, LogoUrl = @LogoUrl, IsActive = @IsActive WHERE CompanyId = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }
    }
}
