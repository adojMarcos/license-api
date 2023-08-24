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
            using var transaction = conn.BeginTransaction();

            var parameters = new DynamicParameters();
            parameters.AddDynamicParams(entity);
            parameters.AddDynamicParams(entity.Address);


            IEnumerable<int> id = await conn.QueryAsync<int>(ClientQueries.CreateClient, parameters, transaction);

            parameters.Add("@Id", id);

            await conn.ExecuteAsync(AddressQueries.CreateAddress, parameters, transaction);
            var result = (await conn.QueryAsync<Clients, Address, Clients>(ClientQueries.GetAllClients, map: (client, address) =>
            {
                client.Address = address;
                return client;
            }, null, transaction, true, splitOn: "Id")).ToList();

            transaction.Commit();

            var i = result.First(x => x.Id == id.First());
            return i;
        }

        public async Task DeleteAsync(Clients entity)
        {
            using IDbConnection conn = _db.CreateConnection();
            conn.Open();
            var parameters = new DynamicParameters();

            parameters.Add("@id", entity.Id);

            await conn.ExecuteAsync(ClientQueries.DeleteClient, parameters);
        }

        public async Task<Clients> UpdateAsync(Clients entity)
        {
            using IDbConnection conn = _db.CreateConnection();

            conn.Open();
            using var transaction = conn.BeginTransaction();

            var parameters = new DynamicParameters();
            parameters.AddDynamicParams(entity);
            parameters.Add("@ZipCode", entity.Address.ZipCode);
            parameters.Add("@Neigborhood", entity.Address.Neigborhood);
            parameters.Add("@Street", entity.Address.Street);
            parameters.Add("@City", entity.Address.City);
            parameters.Add("@StateId", entity.Address.StateId);
            parameters.Add("@Complement", entity.Address.Complement);
            parameters.Add("@ZipCode", entity.Address.ZipCode);
            parameters.Add("@Number", entity.Address.Number);



            await conn.ExecuteAsync(ClientQueries.UpdateClient, parameters, transaction);
            await conn.ExecuteAsync(AddressQueries.UpdateAddressByClientId, parameters, transaction);

            transaction.Commit();

            return await conn.QueryFirstAsync<Clients>(ClientQueries.GetClientById, entity);

        }
    }
}
