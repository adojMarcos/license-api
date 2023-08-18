using Enviroment.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enviroment.Application.Queries.LicenseQueries
{
    public class GetLicenseByNameQuery : IRequest<Licenses>
    {
        public string Name { get; private set; } = string.Empty;

        public GetLicenseByNameQuery(string name)
        {
            Name = name;
        }
    }
}
