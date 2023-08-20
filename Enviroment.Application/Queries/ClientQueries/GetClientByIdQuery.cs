using Enviroment.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enviroment.Application.Queries.ClientQueries
{
    public class GetClientByIdQuery : IRequest<Clients>
    {
        public int Id { get; set; }

        public GetClientByIdQuery(int id)
        {
            Id = id;
        }
    }
}
