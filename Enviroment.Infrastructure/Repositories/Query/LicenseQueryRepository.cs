using Dapper;
using Enviroment.Core.Entities;
using Enviroment.Core.Repositories.Query;
using Enviroment.Core.Repositories.Query.Base;
using Enviroment.Infrastructure.Data;
using System.Data;
using System.Data.SqlTypes;

namespace Enviroment.Infrastructure.Repositories.Query
{
    public class LicenseQueryRepository : IQueryRepository<Licenses>, ILicenseQueryRepository
    {
        private readonly IDbConector _db;

        public LicenseQueryRepository(IDbConector db)
        {
            _db = db;
        }

        public async Task<IReadOnlyCollection<Licenses>> GetAllAsync()
        {
            var sql = @"SELECT Id, LicenseName FROM licenses"; 
            using (var connection = _db.CreateConnection())
            {
                return (await connection.QueryAsync<Licenses>(sql)).ToList(); 
            }
        }

        public async Task<Licenses> GetByIdAsync(int id)
        {
            var sql = @"SELECT Id, LicenseName FROM licenses WHERE Id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id);

            using (var connection = _db.CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<Licenses>(sql, parameters);
            }
        }

        public async Task<Licenses> GetByNameAsync(string name)
        {
            var sql = @"SELECT Id, LicenseName FROM licenses WHERE LicenseName = @Name";
            var parameters = new DynamicParameters();
            parameters.Add("Name", name);

            using (var connection = _db.CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<Licenses>(sql);
            }
        }
    }
}
