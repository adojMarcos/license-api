using Dapper;
using Enviroment.Core.Entities;
using Enviroment.Core.Repositories.Query;
using Enviroment.Core.Repositories.Query.Base;
using Enviroment.Infrastructure.Data;
using Enviroment.Infrastructure.SQLQueries;

namespace Enviroment.Infrastructure.Repositories.Query
{
    public class ClientQueryRepository : IQueryRepository<Clients>, IClientQueryRepository
    {
        private readonly IDbConector _db;


        public ClientQueryRepository(IDbConector db)
        {
            _db = db;
        }
        public async Task<IReadOnlyCollection<Clients>> GetAllAsync()
        {
            using var connection = _db.CreateConnection();
            var result = (await connection.QueryAsync<Clients, Address, Clients>(ClientQueries.GetAllClients, map: (client, address) =>
            {
                client.Address = address;
                return client;
            }, splitOn: "Id")).ToList();

            return result;
        }

        public async Task<Clients> GetByIdAsync(int id)
        {
            var clients = await GetAllAsync();
            return clients.First(x => x.Id == id);


        }

        public Task<Clients> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }
    }
}
