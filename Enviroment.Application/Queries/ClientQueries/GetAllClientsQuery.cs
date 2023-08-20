using Enviroment.Core.Entities;
using MediatR;

namespace Enviroment.Application.Queries.ClientQueries
{
    public class GetAllClientsQuery : IRequest<List<Clients>>
    {
    }
}
