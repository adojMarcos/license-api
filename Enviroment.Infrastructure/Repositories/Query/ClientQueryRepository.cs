using Dapper;
using Enviroment.Core.Entities;
using Enviroment.Core.Repositories.Query;
using Enviroment.Core.Repositories.Query.Base;
using Enviroment.Infrastructure.Data;

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
            var sql = @"SELECT 
                            c.Id, 
                            c.CorporateName, 
                            c.TradeName, 
                            c.Responsible, 
                            c.Cellphone, 
                            c.Email, 
                            c.Rg, 
                            c.CNPJ,
                            a.Id,
                            a.ZipCode, 
                            a.Neighborhood, 
                            a.Street, 
                            a.Complement, 
                            a.Number, 
                            a.City, 
                            (SELECT State FROM States s WHERE s.UFCode = a.Id) as State
                            FROM clients c INNER JOIN Address a ON c.Id = a.IdClient";

            using var connection = _db.CreateConnection();
            var result = (await connection.QueryAsync<Clients, Address, Clients>(sql, map: (client, address) =>
            {
                client.Address = address;
                return client;
            }, splitOn: "Id")).ToList();

            return result;
        }

        public Task<Clients> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Clients> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }
    }
}
