using Enviroment.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enviroment.Application.Queries.LicenseQueries
{
    public class GetLicenseByIdQuery: IRequest<Licenses>
    {
        public int Id { get; private set; } 
        public GetLicenseByIdQuery(int id)
        {
            Id = id;
        }
    }
}
