using Enviroment.Application.Queries.ClientQueries;
using Enviroment.Core.Entities;
using Enviroment.Core.Repositories.Query;
using MediatR;

namespace Enviroment.Application.Handlers.QueryHandlers.ClientQueryHandlers
{
    public class GetClientById : IRequestHandler<GetClientByIdQuery, Clients>
    {
        private readonly IClientQueryRepository _clientQueryRepository;

        public GetClientById(IClientQueryRepository clientQueryRepository)
        {
            _clientQueryRepository = clientQueryRepository;
        }

        public async Task<Clients> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
        {
            return await _clientQueryRepository.GetByIdAsync(request.Id);
        }
    }
}
