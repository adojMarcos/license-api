using Enviroment.Core.Entities;
using Enviroment.Core.Repositories.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enviroment.Infrastructure.Data;
using System.Data;
using Dapper;

namespace Enviroment.Infrastructure.Repositories.Command
{
    public class LicensesCommandRepository : ILinceseCommandRepository
    {
        private readonly IDbConector _db;

        public LicensesCommandRepository(IDbConector db)
        {
            _db = db;
        }

        public async Task<Licenses> AddAsync(Licenses entity)
        {
            using (IDbConnection connection = _db.CreateConnection())
            {
                string sql = @"INSERT INTO licenses(LicenseName) values(@LicenseName);
                                SELECT CAST(SCOPE_IDENTITY() as int)";

                connection.Open();

                var id = await connection.QueryAsync<int>(sql, entity);

                var parameters = new DynamicParameters();
                parameters.Add("@id", id);

                return await connection.QueryFirstAsync<Licenses>("SELECT Id, LicenseName FROM licenses WHERE Id = @id", parameters);
            }

        }

        public async Task DeleteAsync(Licenses entity)
        {
            using (IDbConnection connection = _db.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@id", entity.Id);
                connection.Open();

                var result = await connection.ExecuteAsync("DELETE FROM licenses WHERE Id = @id", parameters);
            }
        }

        public async Task<Licenses> UpdateAsync(Licenses entity)
        {
            using (IDbConnection connection = _db.CreateConnection())
            {
                string sql = @"UPDATE licenses SET LicenseName = @LicenseName WHERE Id = @id;";

                var parameters = new DynamicParameters();
                parameters.Add("@LicenseName", entity.LicenseName);
                parameters.Add("@id", entity.Id);

                connection.Open();

                var id = await connection.QueryAsync<int>(sql, parameters);

                return await connection.QueryFirstAsync<Licenses>("SELECT Id, LicenseName FROM licenses WHERE Id = @id", parameters);

            }
        }
    }
}
