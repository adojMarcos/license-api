using Dapper;
using Enviroment.Core.Entities;
using Enviroment.Core.Repositories.Command;
using Enviroment.Infrastructure.Data;
using Enviroment.Infrastructure.SQLQueries;
using System.Data;

namespace Enviroment.Infrastructure.Repositories.Command
{
    public class ClientCommandRepository : IClientCommandRepository
    {
        private readonly IDbConector _db;

        public ClientCommandRepository(IDbConector db)
        {
            _db = db;
        }

        public async Task<Clients> AddAsync(Clients entity)
        {
            using IDbConnection conn = _db.CreateConnection();

            conn.Open();
            var parameters = new DynamicParameters();
            parameters.AddDynamicParams(entity);
            parameters.Add("@ZipCode", entity.Address.ZipCode);
            parameters.Add("@Neigborhood", entity.Address.Neigborhood);
            parameters.Add("@Street", entity.Address.Street);
            parameters.Add("@City", entity.Address.City);
            parameters.Add("@StateId", entity.Address.State);
            parameters.Add("@Complement", entity.Address.Complement);
            parameters.Add("@ZipCode", entity.Address.ZipCode);
            parameters.Add("@Number", entity.Address.Number);


            IEnumerable<int> id = await conn.QueryAsync<int>(ClientQueries.CreateClient, parameters);

            parameters.Add("@IdClient", id);

            await conn.ExecuteAsync(AddressQueries.CreateAddress, parameters);

            return await conn.QueryFirstAsync<Clients>(ClientQueries.GetClientById, parameters);

        }

        public Task DeleteAsync(Clients entity)
        {
            throw new NotImplementedException();
        }

        public Task<Clients> UpdateAsync(Clients entity)
        {
            throw new NotImplementedException();
        }
    }
}
