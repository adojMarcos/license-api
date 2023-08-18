using Enviroment.Core.Entities;
using Enviroment.Core.Repositories.Query.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enviroment.Core.Repositories.Query
{
    public interface ILicenseQueryRepository : IQueryRepository<Licenses>
    {
        Task<IReadOnlyCollection<Licenses>> GetAllAsync();
        Task<Licenses> GetByIdAsync(int id);
        Task<Licenses> GetByNameAsync(string name);
    }
}
