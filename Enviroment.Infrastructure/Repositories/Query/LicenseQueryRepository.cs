using Dapper;
using Enviroment.Core.Entities;
using Enviroment.Core.Repositories.Query;
using Enviroment.Core.Repositories.Query.Base;
using Enviroment.Infrastructure.Data;
using Enviroment.Infrastructure.SQLQueries;

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
            using var connection = _db.CreateConnection();
            return (await connection.QueryAsync<Licenses>(LicenseQueries.GetAllLicenses)).ToList();
        }

        public async Task<Licenses> GetByIdAsync(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Id", id);

            using var connection = _db.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<Licenses>(LicenseQueries.GetLicenseById, parameters);
        }

        public async Task<Licenses> GetByNameAsync(string name)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Name", name);

            using var connection = _db.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<Licenses>(LicenseQueries.GetLicenseByName, parameters);
        }
    }
}
