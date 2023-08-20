using Enviroment.Application.Queries.ClientQueries;
using Enviroment.Core.Entities;
using Enviroment.Core.Repositories.Query;
using MediatR;

namespace Enviroment.Application.Handlers.QueryHandlers.ClientQueryHandlers
{
    public class GetAllClientsHandler : IRequestHandler<GetAllClientsQuery, List<Clients>>
    {
        private readonly IClientQueryRepository _clientQueryRepository;

        public GetAllClientsHandler(IClientQueryRepository clientQueryRepository)
        {
            _clientQueryRepository = clientQueryRepository;
        }
        public async Task<List<Clients>> Handle(GetAllClientsQuery request, CancellationToken cancellationToken)
        {
            return (List<Clients>)await _clientQueryRepository.GetAllAsync();
        }
    }
}
