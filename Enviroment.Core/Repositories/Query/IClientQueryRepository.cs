using Enviroment.Core.Entities;
using Enviroment.Core.Repositories.Query.Base;

namespace Enviroment.Core.Repositories.Query
{
    public interface IClientQueryRepository : IQueryRepository<Clients>
    {
        Task<IReadOnlyCollection<Clients>> GetAllAsync();
        Task<Clients> GetByIdAsync(int id);
        Task<Clients> GetByNameAsync(string name);
    }
}
