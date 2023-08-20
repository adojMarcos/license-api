using Enviroment.Core.Entities;
using Enviroment.Core.Repositories.Query.Base;


namespace Enviroment.Core.Repositories.Query
{
    public interface ILicenseQueryRepository : IQueryRepository<Licenses>
    {
        Task<IReadOnlyCollection<Licenses>> GetAllAsync();
        Task<Licenses> GetByIdAsync(int id);
        Task<Licenses> GetByNameAsync(string name);
    }
}
