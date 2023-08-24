using Dapper;
using Enviroment.Core.Entities;
using Enviroment.Core.Repositories.Command;
using Enviroment.Infrastructure.Data;
using Enviroment.Infrastructure.SQLQueries;
using System.Data;

namespace Enviroment.Infrastructure.Repositories.Command
{
    public class LicensesCommandRepository : ILinceseCommandRepository
    {
        private readonly IDbConector _db;

        public LicensesCommandRepository(IDbConector db)
        {
            _db = db;
        }

        public Task<Licenses> AddAsync(Licenses entity)
        {
            using (IDbConnection connection = _db.CreateConnection())
            {
                connection.Open();

                var id = connection.QueryAsync<int>(LicenseQueries.CreateLicense, entity);

                var parameters = new DynamicParameters();
                parameters.Add("@id", id);

                return connection.QueryFirstAsync<Licenses>(LicenseQueries.GetLicenseById, parameters);
            }

        }

        public async Task DeleteAsync(Licenses entity)
        {
            using (IDbConnection connection = _db.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@id", entity.Id);
                connection.Open();

                await connection.ExecuteAsync(LicenseQueries.DeleteLicense, parameters);
            }
        }

        public Task<Licenses> UpdateAsync(Licenses entity)
        {
            using IDbConnection connection = _db.CreateConnection();

            var parameters = new DynamicParameters();
            parameters.Add("@LicenseName", entity.LicenseName);
            parameters.Add("@id", entity.Id);

            connection.Open();

            var id = connection.QueryAsync<int>(LicenseQueries.UpdateLicense, parameters);

            return connection.QueryFirstAsync<Licenses>(LicenseQueries.GetLicenseById, parameters);
        }
    }
}
